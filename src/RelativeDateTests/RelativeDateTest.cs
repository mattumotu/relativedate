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
    }
}
