// this
// The value of this in JavaScript depends on how a function is invoked (runtime binding), not how it is defined. When a regular function is invoked as a method of an object (obj.method()), this points to that object. When invoked as a standalone function (not attached to an object: func()), this typically refers to the global object (in non-strict mode) or undefined (in strict mode). The Function.prototype.bind() method can create a function whose this binding doesn't change, and methods Function.prototype.apply() and Function.prototype.call() can also set the this value for a particular call.
// When a function is used as a constructor (with the new keyword), its this is bound to the new object being constructed, no matter which object the constructor function is accessed on. The value of this becomes the value of the new expression unless the constructor returns another non–primitive value.

function vehicle(make, model) {
  // so here we can use this so it will bind data to newly created object
  this.make = make;
  this.model = model;
  // return 10; // ignored as this is primitive value and if not returne anything this will be returned
  // return { hi: 5 }; // it will be assigned, and prototype of vehicle will be ingored but prototype of returned function will be assigned
}

// static property
vehicle.horn = function () {
  console.log("BEEP BEEP");
};

vehicle.prototype.info = function () {
  console.log(this.model, this.make);
};

// swift = new vehicle(2010, "swift");
// behind the scene something like this happen for new keyword
// const swift = {};                 // create empty object
// swift.__proto__ = vehicle.prototype; // link prototype
// vehicle.call(swift, 2010, "swift");       // set this = p1
// return vehicle;

// console.log(swift);
// swift.info(); // swift 2010

function swift(make, model, average) {
  // call constructor of base class
  vehicle.call(this, make, model);
  this.average = average;
}

// Now to add methods of base class to derived
swift.prototype = Object.create(vehicle.prototype);
// swift.prototype = vehicle.prototype;   // this is wrong way as this will point reference of swift and vehicle to same object and modifying child prototype will modify parent's prototype so it is not inheritance it is alias also by this swift.prototype.construtctor will point to vehicle not swift

// don't need everything work without it but lookup in devtools becomes difficult and constructor is not pointing where it should
swift.prototype.constructor = swift;

// For inheritance of static properties
Object.setPrototypeOf(swift, vehicle);

// to add a method for only derived
swift.prototype.repair = function () {
  console.log("Repaied");
};

c1 = new swift(2010, "swift", 18.5);
console.log(c1);

wagonR = new vehicle(2011, "WagonR");
console.log(wagonR);

vehicle.horn();
swift.horn();
