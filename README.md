# Relative Date

![RelativeDate Logo](https://raw.githubusercontent.com/mattumotu/relativedate/master/relativedate.png "Relative Date Logo") 

[![Build status](https://ci.appveyor.com/api/projects/status/3atm9w710gwtsik4/branch/master?svg=true)](https://ci.appveyor.com/project/mattumotu/relativedate/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/mattumotu/relativedate/badge.svg?branch=master)](https://coveralls.io/github/mattumotu/relativedate?branch=master)


Sometimes you just need to know the date of the third sunday of a month, Relative Date has you covered.

For a given year and month Relative Date will find the First, Second, Third, Fouth and Last interval, where the interval is Mon-Sat, Day, WeekDay or WeekendDay.

```cs
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
// last weekend day in June 2018 is the 30th (Saturday)
```
