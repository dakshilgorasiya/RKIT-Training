// abs() method
// Get absolute value of number
console.log(Math.abs(-7.25)); // 7.25

// acos() method
// Get arccosine of number
console.log(Math.acos(1)); // 0

// acosh() method
// Get inverse hyperbolic cosine of number
console.log(Math.acosh(1)); // 0

// asin, asinh, atan, atan2, atanh, sin, sinh, cos, cosh, tan, tanh methods

// cbrt() method
// Get cube root of number
console.log(Math.cbrt(27)); // 3

// ceil() method
// Round number up to nearest integer
console.log(Math.ceil(4.2)); // 5

// exp() method
// Get e raised to the power of number(e^x)
console.log(Math.exp(1)); // 2.718281828459045

// expm1() method
// Get e raised to the power of number minus 1(e^x - 1)
console.log(Math.expm1(1)); // 1.718281828459045

// floor() method
// Round number down to nearest integer
console.log(Math.floor(4.7)); // 4

// hypot() method
// Get square root of sum of squares of arguments
console.log(Math.hypot(3, 4)); // 5

// imul() method
// Get result of 32-bit integer multiplication
console.log(Math.imul(2, 4)); // 8

// log() method
// Get natural logarithm of number
console.log(Math.log(10)); // 2.302585092994046

// log1p() method
// Get natural logarithm of 1 plus number
console.log(Math.log1p(1)); // 0.6931471805599453 
// log2, log10 methods

// max() method
// Get maximum value among arguments
console.log(Math.max(1, 3, 2)); // 3
// min() method

// pow() method
// Get base raised to the power of exponent
console.log(Math.pow(2, 3)); // 8

// random() method
// Get random number between 0 (inclusive) and 1 (exclusive)
console.log(Math.random()); // e.g., 0.10426218150621136

// To get random number in specific range
function getRandomInRange(min, max) {
  return Math.random() * (max - min) + min;
}
console.log(getRandomInRange(1, 10)); // e.g., 7.34567891234567

// round() method
// Round number to nearest integer
console.log(Math.round(4.5)); // 5

// sign() method
// Get sign of number
console.log(Math.sign(-10)); // -1

// sqrt() method
// Get square root of number
console.log(Math.sqrt(16)); // 4

// trunc() method
// Get integer part of number by removing fractional digits
console.log(Math.trunc(4.9)); // 4


//! static properties
// Euler's number
console.log(Math.E); // 2.718281828459045

// LN2 (natural logarithm of 2)
console.log(Math.LN2); // 0.6931471805599453

// LN10 (natual logarithm of 10)
console.log(Math.LN10); // 2.302585092994046

// LOG2E (base 2 logarithm of e)
console.log(Math.LOG2E); // 1.4426950408889634

// LOG10E (base 10 logarithm of e)
console.log(Math.LOG10E); // 0.4342944819032518

// PI (property of π)
console.log(Math.PI); // 3.141592653589793

// SQRT1_2 (square root of 1/2)
console.log(Math.SQRT1_2); // 0.7071067811865476

// SQRT2 (square root of 2)
console.log(Math.SQRT2); // 1.4142135623730951