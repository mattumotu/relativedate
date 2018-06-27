namespace RelativeDate
{
    using System;
    using System.Collections.Generic;

    public class RelativeDate
    {
        public enum Interval
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7,
            Day = 8,
            WeekDay = 9,
            WeekendDay = 10
        };

        private readonly int targetYear;
        private readonly int targetMonth;

        public RelativeDate(int targetYear, int targetMonth)
        {
            this.targetYear = targetYear;
            this.targetMonth = targetMonth;
        }

        public DateTime First(Interval interval)
        {
            if (interval == Interval.Day)
            {
                return new DateTime(this.targetYear, this.targetMonth, 1);
            }

            if (interval == Interval.WeekDay)
            {
                DateTime targetDate = new DateTime(this.targetYear, this.targetMonth, 1);
                if (targetDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    targetDate = targetDate.AddDays(2);
                }
                else if (targetDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            if (interval == Interval.WeekendDay)
            {
                DateTime targetDate = new DateTime(this.targetYear, this.targetMonth, 1);
                while (targetDate.DayOfWeek != DayOfWeek.Saturday && targetDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            // DayOfWeek (which DateTime uses) and Interval (which we get from SQL Server) don't match.
            // So we convert Interval to DayOfWeek so we can run some calculations
            DayOfWeek targetDay = IntervalToDayOfWeek(interval);
            DayOfWeek firstDay = new DateTime(this.targetYear, this.targetMonth, 1).DayOfWeek;

            // firstDay - targetDay shows us how far ahead the first is compared to target date
            // (e.g. if firstDay is Tue and targetDay is Monday, shift will be 1)
            int shift = (firstDay - targetDay);
            if (shift < 0)
            {
                // shift is negative, i.e. targetDay is before firstDay, not after.
                // this will messup our maths (will give us 2nd occurance, not first)
                // add 7 to compensate
                shift += 7;
            }
            //Shift back from the first, will give correct day, but previous week, so add 7 days to get the one we want
            return new DateTime(this.targetYear, this.targetMonth, 1).AddDays(-shift).AddDays(7);
        }

        public DateTime Second(Interval interval)
        {
            if (interval == Interval.Day)
            {
                return this.First(interval).AddDays(1);
            }

            if (interval == Interval.WeekDay)
            {
                DateTime targetDate = this.First(interval).AddDays(1);
                if (targetDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    targetDate = targetDate.AddDays(2);
                }
                else if (targetDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            if (interval == Interval.WeekendDay)
            {
                DateTime targetDate = this.First(interval).AddDays(1);
                while (targetDate.DayOfWeek != DayOfWeek.Saturday && targetDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            return this.First(interval).AddDays(7);
        }

        public DateTime Third(Interval interval)
        {
            if (interval == Interval.Day)
            {
                return this.First(interval).AddDays(2);
            }

            if (interval == Interval.WeekDay)
            {
                DateTime targetDate = this.Second(interval).AddDays(1);
                if (targetDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    targetDate = targetDate.AddDays(2);
                }
                else if (targetDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            if (interval == Interval.WeekendDay)
            {
                DateTime targetDate = this.Second(interval).AddDays(1);
                while (targetDate.DayOfWeek != DayOfWeek.Saturday && targetDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            return this.Second(interval).AddDays(7);
        }

        public DateTime Fourth(Interval interval)
        {
            if (interval == Interval.Day)
            {
                return this.First(interval).AddDays(3);
            }

            if (interval == Interval.WeekDay)
            {
                DateTime targetDate = this.Third(interval).AddDays(1);
                if (targetDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    targetDate = targetDate.AddDays(2);
                }
                else if (targetDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            if (interval == Interval.WeekendDay)
            {
                DateTime targetDate = this.Third(interval).AddDays(1);
                while (targetDate.DayOfWeek != DayOfWeek.Saturday && targetDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(1);
                }
                return targetDate;
            }

            return this.Third(interval).AddDays(7);
        }

        public DateTime Last(Interval interval)
        {
            if (interval == Interval.Day)
            {
                return new DateTime(this.targetYear, this.targetMonth, 1).AddMonths(1).AddDays(-1);
            }

            if (interval == Interval.WeekDay)
            {
                DateTime targetDate = new DateTime(this.targetYear, this.targetMonth, 1).AddMonths(1).AddDays(-1);
                if (targetDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    targetDate = targetDate.AddDays(-1);
                }
                else if (targetDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(-2);
                }
                return targetDate;
            }

            if (interval == Interval.WeekendDay)
            {
                DateTime targetDate = new DateTime(this.targetYear, this.targetMonth, 1).AddMonths(1).AddDays(-1);
                while (targetDate.DayOfWeek != DayOfWeek.Saturday && targetDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    targetDate = targetDate.AddDays(-1);
                }
                return targetDate;
            }

            // DayOfWeek (which DateTime uses) and Interval (which we get from SQL Server) don't match.
            // So we convert Interval to DayOfWeek so we can run some calculations
            DayOfWeek targetDay = IntervalToDayOfWeek(interval);
            DayOfWeek firstDay = new DateTime(this.targetYear, this.targetMonth + 1, 1).DayOfWeek;
            // firstDay - targetDay shows us how far ahead the first is compared to target date
            // (e.g. if firstDay is Tue and targetDay is Monday, shift will be 1)
            int shift = (firstDay - targetDay);
            //Shift back from the first of next month
            return new DateTime(this.targetYear, this.targetMonth + 1, 1).AddDays(-shift);
        }

        private DayOfWeek IntervalToDayOfWeek(Interval interval)
        {
            Dictionary<Interval, DayOfWeek> freq2dow = new Dictionary<Interval, DayOfWeek>();
            freq2dow.Add(Interval.Sunday, DayOfWeek.Sunday);
            freq2dow.Add(Interval.Monday, DayOfWeek.Monday);
            freq2dow.Add(Interval.Tuesday, DayOfWeek.Tuesday);
            freq2dow.Add(Interval.Wednesday, DayOfWeek.Wednesday);
            freq2dow.Add(Interval.Thursday, DayOfWeek.Thursday);
            freq2dow.Add(Interval.Friday, DayOfWeek.Friday);
            freq2dow.Add(Interval.Saturday, DayOfWeek.Saturday);

            return freq2dow[interval];
        }
    }
}
