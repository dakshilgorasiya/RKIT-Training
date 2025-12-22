class base {
  constructor(a, b) {
    this.a = a;
    this.b = b;
  }

  add() {
    return this.a + this.b;
  }
}

class derived extends base {
  constructor(a, b, c) {
    super(a, b);
    this.c = c;
  }
  multiply() {
    return this.a * this.b * this.c;
  }
}

let obj = new derived(2, 3, 4);
console.log("Addition:", obj.add());
console.log("Multiplication:", obj.multiply());

console.log(obj)

// Equivalent ES5 code:
// function base(a, b) {
//   this.a = a;
//   this.b = b;
// }
// base.prototype.add = function () {
//   return this.a + this.b;
// };

// function derived(a, b, c) {
//   base.call(this, a, b);
//   this.c = c;
// }

// derived.prototype = Object.create(base.prototype);
// derived.prototype.constructor = derived;
// derived.prototype.multiply = function () {
//   return this.a * this.b * this.c;
// };

// let obj = new derived(2, 3, 4);
// console.log("Addition:", obj.add());
// console.log("Multiplication:", obj.multiply());

// console.log(obj)