import { Calculator } from "./Calculator.js";
// import { Calculator as c } from "./Calculator.js";  // code execute once no matter how many times imported

const num1 = 10;
const num2 = 5;

console.log(`Addition: ${Calculator.add(num1, num2)}`);
console.log(`Subtraction: ${Calculator.subtract(num1, num2)}`);
console.log(`Multiplication: ${Calculator.multiply(num1, num2)}`);
console.log(`Division: ${Calculator.divide(num1, num2)}`);
