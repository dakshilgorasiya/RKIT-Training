const arr = [1, 2, 3, 4, 5];

// forEach
arr.forEach(num => console.log(`Number: ${num}`));

// map
const squared = arr.map(num => num * num);
console.log('Squared:', squared);

// filter
const evenNumbers = arr.filter(num => num % 2 === 0);
console.log('Even Numbers:', evenNumbers);

// reduce
const sum = arr.reduce((acc, num) => acc + num, 0);
console.log('Sum:', sum);
