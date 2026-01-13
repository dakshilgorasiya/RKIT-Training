// will not work in browser only work in node.js
// module.export = function add(a, b){
//   return a + b;
// }

// exports.sub = function (a, b){
//   return a - b;
// }

define(function () {
  return {
    add: (a, b) => a + b,
  };
});
