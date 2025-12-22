class Animal {
  constructor(name) {
    this.name = name;
  }
}

const canEat = (base) =>
  class extends base {
    constructor(...args) {
      super(...args);
    }
    eat() {
      console.log("Eating");
    }
  };

const canFly = (base) =>
  class extends base {
    constructor(...args) {
      super(...args);
    }
    fly() {
      console.log("Flying");
    }
  };

class Dragon extends canEat(canFly(Animal)) {
  constructor(name) {
    super(name);
  }
}

d1 = new Dragon("ABC");
console.log(d1);
d1.eat();
d1.fly();

// without class syntax
// function Animal(name) {
//   this.name = name;
// }

// function canEat(Base) {
//   function Eat() {}

//   Eat.prototype = Object.create(Base.prototype);
//   Eat.prototype.constructor = Eat;

//   Eat.prototype.eat = function () {
//     console.log("Eating");
//   };

//   return Eat;
// }

// function canFly(Base) {
//   function Fly() {}

//   Fly.prototype = Object.create(Base.prototype);
//   Fly.prototype.constructor = Fly;

//   Fly.prototype.fly = function () {
//     console.log("Flying");
//   };

//   return Fly;
// }

// function Dragon(name) {
//   Animal.call(this, name);
// }

// Dragon.prototype = Object.create(canFly(canEat(Animal)).prototype);
// Dragon.prototype.constructor = Dragon;

// const d1 = new Dragon("ABC");
// console.log(d1);
// d1.fly();
// d1.eat();
