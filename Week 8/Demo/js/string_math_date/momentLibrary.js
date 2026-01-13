const m1 = moment();
console.log(m1.format("YYYY-MM-DD"));

const m2 = moment("2026-01-12");
console.log(m2.toString());

const m3 = moment(new Date());
console.log(m3.toString());

const m4 = moment([2026, 0, 9]);
console.log(m4.toString());

// format
console.log(m1.format("DD-MM-YYYY hh:mm:ss A"));

// parse
const m5 = moment("2026-10-01", "YYYY-DD-MM");
console.log(m5.toString());

// strict parsing
const m6 = moment("2026-10-01", "DD-MM-YYYY", true);
console.log(m6.toString()); // Invalid date
console.log(m6.isValid()); // false

// date manipulation
m5.add(5, "days");
// options : years, months, weeks, days, hours, minutes, seconds
console.log(m5.toString()); // Thu Jan 15 2026 00:00:00 GMT+0530

// comparing dates
console.log(m3.isBefore(m4)); // false
console.log(m3.isAfter(m4)); // true
console.log(m3.isSame(m4)); // false

// To compare only day
console.log(m3.isSame(m4, "day")); // true

// date difference
console.log(m3.diff(m4)); // 64638144
console.log(m3.diff(m4, "hour")); // 17

// relative time
console.log(m2.fromNow()); // in 2 days

// get set
console.log(m1.year()); // 2026
m1.year(2024);
console.log(m1.year()); // 2024

// validation methods
console.log(m1.isValid()); // true
console.log(m1.isLeapYear()); // true
console.log(m1.isBetween(m2, m3)); // false

// other
console.log(m3.calendar()); // Today at 6:18 PM
console.log(m1.toNow()); // in 2 years
console.log(m1.from(m2)); // 2 years ago

// duration
const d = moment.duration({ days: 2, hours: 3 });
console.log(d.asMinutes()); // 3060
console.log(d.days()); // 2
console.log(d.hours()); // 3
console.log(d.humanize()); // 2 days

// week
console.log(m1.week()); // 2
console.log(m1.weekYear()); // 2024

// min, max
console.log(moment.min(m1, m2).toString()); // Tue Jan 09 2024 18:26:55 GMT+0530

// business format
console.log(m1.daysInMonth()); // 31
console.log(m1.weeksInYear()); // 52
console.log(m1.quarter()); // 1

// date manipulation
m1.set({ year: 2026, month: 0, date: 9 });
console.log(m1.toString()); // Fri Jan 09 2026 18:33:17 GMT+0530
