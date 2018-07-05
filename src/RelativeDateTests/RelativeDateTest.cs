namespace RelativeDateTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RelativeDate;

    [TestClass]
    public class RelativeDateTest
    {
        [TestMethod]
        public void KnownMonth_Interval_Day()
        {
            //Arrange
            int targetYear = 2018;
            int targetMonth = 5;
            RelativeDate actual;

            //Act
            actual = new RelativeDate(targetYear, targetMonth);

            //Assert
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 1), actual.First(RelativeDate.Interval.Day));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 2), actual.Second(RelativeDate.Interval.Day));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 3), actual.Third(RelativeDate.Interval.Day));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 4), actual.Fourth(RelativeDate.Interval.Day));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 31), actual.Last(RelativeDate.Interval.Day));
        }

        [TestMethod]
        public void KnownMonth_Interval_Monday()
        {
            //Arrange
            int targetYear = 2018;
            int targetMonth = 5;
            RelativeDate actual;

            //Act
            actual = new RelativeDate(targetYear, targetMonth);

            //Assert
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 7), actual.First(RelativeDate.Interval.Monday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 14), actual.Second(RelativeDate.Interval.Monday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 21), actual.Third(RelativeDate.Interval.Monday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 28), actual.Fourth(RelativeDate.Interval.Monday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 28), actual.Last(RelativeDate.Interval.Monday));
        }

        [TestMethod]
        public void KnownMonth_Interval_Thursday()
        {
            //Arrange
            int targetYear = 2018;
            int targetMonth = 5;
            RelativeDate actual;

            //Act
            actual = new RelativeDate(targetYear, targetMonth);

            //Assert
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 3), actual.First(RelativeDate.Interval.Thursday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 10), actual.Second(RelativeDate.Interval.Thursday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 17), actual.Third(RelativeDate.Interval.Thursday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 24), actual.Fourth(RelativeDate.Interval.Thursday));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 31), actual.Last(RelativeDate.Interval.Thursday));
        }

        [TestMethod]
        public void KnownMonth_Interval_WeekDay()
        {
            //Arrange
            int targetYear = 2018;
            int targetMonth = 5;
            RelativeDate actual;

            //Act
            actual = new RelativeDate(targetYear, targetMonth);

            //Assert
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 1), actual.First(RelativeDate.Interval.WeekDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 2), actual.Second(RelativeDate.Interval.WeekDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 3), actual.Third(RelativeDate.Interval.WeekDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 4), actual.Fourth(RelativeDate.Interval.WeekDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 31), actual.Last(RelativeDate.Interval.WeekDay));
        }

        [TestMethod]
        public void KnownMonth_Interval_WeekendDay()
        {
            //Arrange
            int targetYear = 2018;
            int targetMonth = 5;
            RelativeDate actual;

            //Act
            actual = new RelativeDate(targetYear, targetMonth);

            //Assert
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 5), actual.First(RelativeDate.Interval.WeekendDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 6), actual.Second(RelativeDate.Interval.WeekendDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 12), actual.Third(RelativeDate.Interval.WeekendDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 13), actual.Fourth(RelativeDate.Interval.WeekendDay));
            Assert.AreEqual(new DateTime(targetYear, targetMonth, 27), actual.Last(RelativeDate.Interval.WeekendDay));
        }

        [TestMethod]
        public void ReadMeTests()
        {
            DateTime firstMonday = new RelativeDate(2018, 6).First(RelativeDate.Interval.Monday);
            Assert.AreEqual(new DateTime(2018, 6, 4), firstMonday);
            // first Monday in June 2018 is the 4th

            DateTime secondThursday = new RelativeDate(2018, 6).Second(RelativeDate.Interval.Thursday);
            Assert.AreEqual(new DateTime(2018, 6, 14), secondThursday);
            // second Thursday in June 2018 is the 14th

            DateTime thirdDay = new RelativeDate(2018, 6).Third(RelativeDate.Interval.Day);
            Assert.AreEqual(new DateTime(2018, 6, 3), thirdDay);
            // third day in June 2018 is the 3rd (Duh)

            DateTime fourthWeekDay = new RelativeDate(2018, 6).Fourth(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 6, 6), fourthWeekDay);
            // fourth week day in June 2018 is the 6th (It's a Wednesday btw)

            DateTime lastWeekEndDay = new RelativeDate(2018, 6).Last(RelativeDate.Interval.WeekendDay);
            Assert.AreEqual(new DateTime(2018, 6, 30), lastWeekEndDay);
        }

        [TestMethod]
        public void DOWSaturday()
        {
            DateTime firstSaturday = new RelativeDate(2018, 6).First(RelativeDate.Interval.Saturday);
            Assert.AreEqual(new DateTime(2018, 6, 2), firstSaturday);

            DateTime secondSaturday = new RelativeDate(2018, 6).Second(RelativeDate.Interval.Saturday);
            Assert.AreEqual(new DateTime(2018, 6, 9), secondSaturday);

            DateTime thirdSaturday = new RelativeDate(2018, 6).Third(RelativeDate.Interval.Saturday);
            Assert.AreEqual(new DateTime(2018, 6, 16), thirdSaturday);

            DateTime fourthSaturday = new RelativeDate(2018, 6).Fourth(RelativeDate.Interval.Saturday);
            Assert.AreEqual(new DateTime(2018, 6, 23), fourthSaturday);

            DateTime lastSaturday = new RelativeDate(2018, 6).Last(RelativeDate.Interval.Saturday);
            Assert.AreEqual(new DateTime(2018, 6, 30), lastSaturday);
        }

        [TestMethod]
        public void DOWSunday()
        {
            DateTime firstSunday = new RelativeDate(2018, 6).First(RelativeDate.Interval.Sunday);
            Assert.AreEqual(new DateTime(2018, 6, 3), firstSunday);

            DateTime secondSunday = new RelativeDate(2018, 6).Second(RelativeDate.Interval.Sunday);
            Assert.AreEqual(new DateTime(2018, 6, 10), secondSunday);

            DateTime thirdSunday = new RelativeDate(2018, 6).Third(RelativeDate.Interval.Sunday);
            Assert.AreEqual(new DateTime(2018, 6, 17), thirdSunday);

            DateTime fourthSunday = new RelativeDate(2018, 6).Fourth(RelativeDate.Interval.Sunday);
            Assert.AreEqual(new DateTime(2018, 6, 24), fourthSunday);

            DateTime lastSunday = new RelativeDate(2018, 6).Last(RelativeDate.Interval.Sunday);
            Assert.AreEqual(new DateTime(2018, 6, 24), lastSunday);
        }

        [TestMethod]
        public void FirstMonthIsWednesday()
        {
            RelativeDate actual = new RelativeDate(2017, 11);

            DateTime fourthWeekDay = actual.Fourth(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 11, 6), fourthWeekDay);
        }

        [TestMethod]
        public void FirstMonthIsThursday()
        {
            RelativeDate actual = new RelativeDate(2018, 3);

            DateTime thirdWeekDay = actual.Third(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 3, 5), thirdWeekDay);

            DateTime fourthWeekDay = actual.Fourth(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 3, 6), fourthWeekDay);
        }

        [TestMethod]
        public void FirstMonthIsFriday()
        {
            RelativeDate actual = new RelativeDate(2018, 6);

            DateTime fourthWeekDay = actual.Fourth(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 6, 6), fourthWeekDay);
        }

        [TestMethod]
        public void FirstMonthIsSaturday()
        {
            RelativeDate actual = new RelativeDate(2017, 7);

            DateTime first = actual.First(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 7, 3), first);

            DateTime second = actual.Second(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 7, 4), second);

            DateTime third = actual.Third(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 7, 5), third);

            DateTime fourth = actual.Fourth(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 7, 6), fourth);

            DateTime last = actual.Last(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 7, 31), last);
        }

        [TestMethod]
        public void FirstMonthIsSunday()
        {
            RelativeDate actual = new RelativeDate(2018, 7);

            DateTime firstWeekDay = actual.First(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 7, 2), firstWeekDay);

            DateTime secondWeekDay = actual.Second(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 7, 3), secondWeekDay);

            DateTime thirdWeekDay = actual.Third(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 7, 4), thirdWeekDay);

            DateTime fourthWeekDay = actual.Fourth(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 7, 5), fourthWeekDay);

            DateTime lastWeekDay = actual.Last(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 7, 31), lastWeekDay);

            DateTime secondWeekendDay = actual.Second(RelativeDate.Interval.WeekendDay);
            Assert.AreEqual(new DateTime(2018, 7, 7), secondWeekendDay);

            DateTime fourthWeekendDay = actual.Fourth(RelativeDate.Interval.WeekendDay);
            Assert.AreEqual(new DateTime(2018, 7, 14), fourthWeekendDay);
        }

        [TestMethod]
        public void LastMonthIsSaturday()
        {
            // 196 Last WeekDay where LastDOM is Sat
            RelativeDate actual = new RelativeDate(2018, 6);

            DateTime lastWeekDay = actual.Last(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2018, 6, 29), lastWeekDay);
        }

        [TestMethod]
        public void LastMonthIsSunday()
        {
            RelativeDate actual = new RelativeDate(2017, 12);

            DateTime lastWeekDay = actual.Last(RelativeDate.Interval.WeekDay);
            Assert.AreEqual(new DateTime(2017, 12, 29), lastWeekDay);
        }

        // 97 second weekday where 2nd is sunday (not possible)
        // 132 third weekday where 2nd weekday is sayurday (not possible)
        // 166 fourth WeekDay where 3rd weekday is saturday (not possible)
    }
}
