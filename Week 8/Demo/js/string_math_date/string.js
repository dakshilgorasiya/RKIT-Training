//! ways to create strings

// Primitive string literals
let str1 = "Hello, World!";
let str2 = "Hello, World!";
let str3 = String("Hello, World!");

// Non-primitive string object
let str4 = new String("Hello, World!");

console.log(typeof str1); // "string"
console.log(typeof str4); // "object"

//! static methods

// Return string from character codes
console.log(String.fromCharCode(72, 101, 108, 108, 111)); // "Hello"

// Return string from Unicode code points
// Different from fromCharCode, can handle code points > 65535,
console.log(String.fromCodePoint(128512)); // "😀"

// Raw string (ignores escape sequences)
console.log(String.raw`Hello\nWorld`); // "Hello\nWorld"

//! Instance methods
let sampleStr = "  Hello, JavaScript!  ";

// at() method
// Get element at specific index (negative index counts from end)
console.log(sampleStr.at(5)); // "l"
console.log(sampleStr.at(-4)); // "t"

// charAt() method
// try to convert index to integer
// return empty string if index is out of range
// Get character at specific index
console.log(sampleStr.charAt(9)); // "J"

// charCodeAt() method
// Get Unicode of character at specific index
console.log(sampleStr.charCodeAt(2)); // 72 (Unicode of 'H')

// codePointAt() method
// Get Unicode code point of character at specific index
console.log(sampleStr.codePointAt(2)); // 72 (Unicode of 'H')

// concat() method
// Concatenate strings
let strA = "Hello";
let strB = "World!";
console.log(strA.concat(", ", strB)); // "Hello, World!"

// endsWith() method
// Check if string ends with specified substring
console.log(sampleStr.trim().endsWith("JavaScript!")); // true

// includes() method
// Check if string contains specified substring
console.log(sampleStr.includes("Java")); // true

// indexOf() method
// Get index of first occurrence of substring
console.log(sampleStr.indexOf("a")); // 10

// isWellFormed() method
// Check if string is well-formed (valid Unicode)
console.log(sampleStr.isWellFormed()); // true

// lastIndexOf() method
// Get index of last occurrence of substring
console.log(sampleStr.lastIndexOf("l")); // 5

// localeCompare() method
// Compare two strings based on locale
console.log("apple".localeCompare("banana")); // negative value

// match() method
// Match string against regular expression
console.log("The rain in SPAIN stays mainly in the plain.".match(/ain/gi)); // ["ain", "AIN", "ain", "ain"]

// matchAll() method
// Get all matches of regular expression in string
let regex = /ain/gi;
let matches = "The rain in SPAIN stays mainly in the plain.".matchAll(regex);
for (const match of matches) {
  console.log(match); // "ain", "AIN", "ain", "ain"
}

// normalize() method
// Normalize string to specified Unicode form
let accentedStr = "é";
console.log(accentedStr.normalize("NFD")); // "é" (decomposed form)

// padEnd() method
// Pad string at the end to specified length
console.log("Hello".padEnd(10, ".")); // "Hello....."

// padStart() method
// Pad string at the start to specified length
console.log("Hello".padStart(10, ".")); // ".....Hello"

// repeat() method
// Repeat string specified number of times
console.log("Ha".repeat(3)); // "HaHaHa"

// replace() method
// Replace substring with new substring
console.log("Hello, World!".replace("World", "JavaScript")); // "Hello, JavaScript!"
// it also accept function as the second parameter
console.log("Hello, World!".replace("World", (match) => match.toUpperCase())); // "Hello, WORLD!"

// replaceAll() method
// Replace all occurrences of substring with new substring
console.log("Hello, World! World!".replaceAll("World", "JavaScript")); // "Hello, JavaScript! JavaScript!"

// search() method
// Search for substring using regular expression
console.log("The rain in SPAIN stays mainly in the plain.".search(/ain/)); // 5

// slice() method
// Extract substring from string
// startindex, endindex(not included)
console.log(sampleStr.slice(2, 7)); // "Hello"

// split() method
// Split string into array based on separator
console.log(sampleStr.trim().split(", ")); // ["Hello", "JavaScript!"]

// startsWith() method
// Check if string starts with specified substring
console.log(sampleStr.trim().startsWith("Hello")); // true

// substring() method
// Extract substring between two indices
console.log(sampleStr.substring(2, 7)); // "Hello"

// toLowerCase() method
// Convert string to lowercase
console.log(sampleStr.toLowerCase()); // "  hello, javascript!  "

// toUpperCase() method
// Convert string to uppercase
console.log(sampleStr.toUpperCase()); // "  HELLO, JAVASCRIPT!  "

// toString() method
// Convert string object to primitive string
console.log(str4); // [String: 'Hello, World!']
console.log(str4.toString()); // "Hello, World!"

// trim() method
// Remove whitespace from both ends of string
console.log(sampleStr.trim()); // "Hello, JavaScript!"

// trimStart() method
// Remove whitespace from start of string
console.log(sampleStr.trimStart()); // "Hello, JavaScript!  "

// trimEnd() method
// Remove whitespace from end of string
console.log(sampleStr.trimEnd()); // "  Hello, JavaScript!"

// valueOf() method
// Get primitive value of string object
console.log(str4.valueOf()); // "Hello, World!"


//! Instance properties
// length property
// Get length of string
console.log(sampleStr.length); // 22