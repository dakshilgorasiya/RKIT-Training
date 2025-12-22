//! constructor
// js represents dates and times using a integer value that counts milliseconds since January 1, 1970, 00:00:00 UTC

const d1 = new Date(); // Current date and time
const d2 = new Date("2023-01-01"); // Specific date
const d3 = new Date(584564894984); // Date from timestamp
const d4 = new Date(d1); // Copy of another date

const d5 = new Date(2023, 0, 1); // Year, month (0-based), day
// new Date(year, monthIndex)
// new Date(year, monthIndex, day)
// new Date(year, monthIndex, day, hours)
// new Date(year, monthIndex, day, hours, minutes)
// new Date(year, monthIndex, day, hours, minutes, seconds)
// new Date(year, monthIndex, day, hours, minutes, seconds, milliseconds)

//! Static Methods
console.log(Date.now()); // Current timestamp in milliseconds
console.log(Date.parse("2023-01-01")); // Timestamp of specific date

console.log(Date.UTC(2023, 0, 1)); // Timestamp of specific date in UTC
// Other utc overloads
// Date.UTC(year)
// Date.UTC(year, monthIndex)
// Date.UTC(year, monthIndex, day)
// Date.UTC(year, monthIndex, day, hours)
// Date.UTC(year, monthIndex, day, hours, minutes)
// Date.UTC(year, monthIndex, day, hours, minutes, seconds)
// Date.UTC(year, monthIndex, day, hours, minutes, seconds, milliseconds)

//! Instance Methods

// getDate() method
// Get day of the month (1-31)
console.log(d2.getDate()); // 1
console.log(d2.getUTCDate()); // 1

// getDay() method
// Get day of the week (0-6, 0 is Sunday)
console.log(d2.getDay()); // 0
console.log(d2.getUTCDay()); // 0

// getFullYear() method
// Get four-digit year
console.log(d2.getFullYear()); // 2023
console.log(d2.getUTCFullYear()); // 2023

// getHours() method
// Get hours (0-23)
console.log(d2.getHours()); // 5
console.log(d2.getUTCHours()); // 0

// getMilliseconds() method
// Get milliseconds (0-999)
console.log(d2.getMilliseconds()); // 0
console.log(d2.getUTCMilliseconds()); // 0

// getMinutes() method
// Get minutes (0-59)
console.log(d2.getMinutes()); // 30
console.log(d2.getUTCMinutes()); // 0

// getMonth() method
// Get month (0-11, 0 is January)
console.log(d2.getMonth()); // 0
console.log(d2.getUTCMonth()); // 0

// getSeconds() method
// Get seconds (0-59)
console.log(d2.getSeconds()); // 0
console.log(d2.getUTCSeconds()); // 0

// getTime() method
// Get timestamp in milliseconds
console.log(d2.getTime()); // 1672531200000

// getTimezoneOffset() method
// Get timezone offset in minutes
console.log(d2.getTimezoneOffset()); // e.g., -330

// setDate() method
// Set day of the month (1-31)
d2.setDate(15);
console.log(d2); // Sun Jan 15 2023 05:30:00 GMT+0530 (India Standard Time)

// setFullYear() method
// Set four-digit year
d2.setFullYear(2024);
console.log(d2); // Mon Jan 15 2024 05:30:00 GMT+0530 (India Standard Time)

// setHours() method
// Set hours (0-23)
d2.setHours(10);
console.log(d2); // Mon Jan 15 2024 10:30:00 GMT+0530 (India Standard Time)

// setMilliseconds() method
// Set milliseconds (0-999)
d2.setMilliseconds(500);
console.log(d2); // Mon Jan 15 2024 10:30:00.500 GMT+0530 (India Standard Time)

// setMinutes() method
// Set minutes (0-59)
d2.setMinutes(45);
console.log(d2); // Mon Jan 15 2024 10:45:00 GMT+0530 (India Standard Time)

// setMonth() method
// Set month (0-11, 0 is January)
d2.setMonth(5);
console.log(d2); // Mon Jun 15 2024 10:45:00 GMT+0530 (India Standard Time)

// setSeconds() method
// Set seconds (0-59)
d2.setSeconds(30);
console.log(d2); // Mon Jun 15 2024 10:45:30 GMT+0530 (India Standard Time)

// setTime() method
// Set timestamp in milliseconds
d2.setTime(1700000000000);
console.log(d2); // Wed Nov 15 2023 03:43:20 GMT+0530 (India Standard Time)

// setUTCDate() method
// Set day of the month (1-31) in UTC
d2.setUTCDate(20);
console.log(d2); // Tue Nov 21 2023 03:43:20 GMT+0530 (India Standard Time)
console.log(d2.toUTCString()); // Mon, 20 Nov 2023 22:13:20 GMT

// other
// setUTCFullYear(), setUTCHours(), setUTCMilliseconds(), setUTCMinutes(), setUTCMonth(), setUTCSeconds() methods

// toDateString() method
// Get date portion as string
console.log(d2.toDateString()); // "Tue Nov 21 2023"

// toISOString() method
// Get date in ISO 8601 format
console.log(d2.toISOString()); // "2023-11-20T22:13:20.000Z"

// toJSON() method
// Get date in JSON format
console.log(d2.toJSON()); // "2023-11-20T22:13:20.000Z"

// toLocaleDateString() method
// Get date portion in locale-specific format
console.log(d2.toLocaleDateString()); // e.g., "11/21/2023"
console.log(d2.toLocaleDateString("en-GB", {
  day: "2-digit",
  month: "2-digit",
  year: "2-digit"
})); // e.g., "21/11/23"


// toLocaleString() method
// Get date and time in locale-specific format
console.log(d2.toLocaleString()); // e.g., "11/21/2023, 3:13:20 AM"
console.log(d2.toLocaleString("en-GB")); // e.g., "21/11/2023, 3:13:20"

// toLocaleTimeString() method
// Get time portion in locale-specific format
console.log(d2.toLocaleTimeString()); // e.g., "3:13:20 AM"
console.log(d2.toLocaleTimeString("en-GB")); // e.g., "03:13:20"

// toString() method
// Get date as string
console.log(d2.toString()); // e.g., "Tue Nov 21 2023 03:43:20 GMT+0530 (India Standard Time)"

// toTimeString() method
// Get time portion as string
console.log(d2.toTimeString()); // e.g., "03:43:20 GMT+0530 (India Standard Time)"

// toUTCString() method
// Get date in UTC string format
console.log(d2.toUTCString()); // e.g., "Mon, 20 Nov 2023 22:13:20 GMT"

// valueOf() method
// Get primitive value of date object (timestamp in milliseconds)
console.log(d2.valueOf()); // 1700518400000 