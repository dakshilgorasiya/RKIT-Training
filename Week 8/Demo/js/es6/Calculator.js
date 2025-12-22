class Calculator {
  static add(a, b) {
    return a + b;
  }
  static subtract(a, b) {
    return a - b;
  }
  static multiply(a, b) {
    return a * b;
  }
  static divide(a, b) {
    if (b === 0) {
      console.log("Error: Division by zero is not allowed.");
      return null;
    }
    return a / b;
  }
}

// Default export
// Can be imported using: import Calculator(this can be any name) from './Calculator.js';
// export default Calculator;

// Named export
// Can be imported using: import { Calculator } from './Calculator.js';
export { Calculator };

console.log("Calculator module loaded.");