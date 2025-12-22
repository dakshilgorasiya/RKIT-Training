// function getRandomUser() {
//   return fetch(
//     "https://api.freeapi.app/api/v1/public/randomusers/user/random"
//   );
// }

// getRandomUser()
//   .then((response) => response.json())
//   .then((data) => console.log(data))
//   .catch((error) => console.error("Error fetching user:", error));

const p1 = new Promise((resolve, reject) => {
  setTimeout(() => {
    let error = false;

    if (!error) {
      console.log("P1 done");
      resolve("P1 resolved");
    } else {
      console.log("P1 fail");
      reject("P1 error");
    }
  }, 1000);
});

const p2 = new Promise((resolve, reject) => {
  setTimeout(() => {
    let error = true;

    if (!error) {
      console.log("P2 done");
      resolve("P2 resolved");
    } else {
      console.log("P2 fail");
      reject("P2 error");
    }
  }, 2000);
});

const p3 = new Promise((resolve, reject) => {
  setTimeout(() => {
    let error = true;

    if (!error) {
      console.log("P3 done");
      resolve("P3 resolved");
    } else {
      console.log("P3 fail");
      reject("P3 error");
    }
  }, 3000);
});

// Promise.all([p1, p2, p3])
//   .then((val) => {
//     console.log(val);
//   })
//   .catch((error) => {
//     console.log("ERROR : ", error);
//   });

// Promise.allSettled([p1, p2, p3])
//   .then((val) => {
//     console.log(val);
//   })
//   .catch((error) => {
//     console.log("ERROR : ", error);
//   });

// Promise.any([p1, p2, p3])
//   .then((val) => {
//     console.log("RESULT :", val);
//   })
//   .catch((error) => {
//     console.log("ERROR : ");
//     console.log(error.message);
//     console.log(error.errors);
//   });

Promise.race([p1, p2, p3])
  .then((val) => {
    console.log(val);
  })
  .catch((error) => {
    console.log("ERROR : ", error);
  });
