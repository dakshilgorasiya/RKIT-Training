const users = [
  { name: "John", role: "admin" },
  { name: "Jane", role: "user" },
  { name: "Bob", role: "admin" },
  { name: "Alice", role: "user" },
];

const admins = $.grep(users, function (user) {
  return user.role === "admin";
});
console.log(admins);

const adminNames = $.map(admins, function (admin) {
  return admin.name;
});
console.log(adminNames);

const defaultSettings = {
  theme: "dark",
  notification: true,
}

const userSettings = {
  theme: "light",
}

const finalSettings = $.extend({}, defaultSettings, userSettings);
console.log(finalSettings);