// will not work in browser, work in node.js
// const { add, sub } = require("./calculator");

// console.log(add(2, 3));
// console.log(sub(5, 3));

require(["./calculator"], function (calculator) {
  console.log(calculator.add(3, 4));
});
