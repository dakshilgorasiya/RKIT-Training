let s = "5";

let num = Number(s); // converts string to number
console.log(num); // 5

let a = undefined;
num = Number(a); // converts undefined to number
console.log(num); // NaN
console.log(typeof num); // number

// Type of NaN if number
// If we try to convert string it will assign NaN
// If we try to convert null it will assign 0
// If we try to convert undefined it will assign NaN
// If we try to convert boolean it will assign 1(true) or 0(false)

let boolean = Boolean("");
console.log(boolean); //false

// Other falsy values
// false
// undefined
// null
// 0
// NaN
// the empty string ("")

console.log("1" + 1 + 1); // 111 (first string concetanation, then again string concetanation)
console.log(1 + 1 + "1"); // 21 (first arithmetic addition, then string concetanation)

console.log(2 == "2"); // true
console.log(2 === "2"); // false (strict comparision)
