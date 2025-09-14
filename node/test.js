const {add} = require("./Math.js");

let  num = 42;  // let 으로 설정하면 중복 변수선언 안됨 const 같은
var name = "Tom";
let isStudent = true;

console.log(add(num , num));
let color = ["red" , "green" , "blue"];

let person = {name : "Alice" , age : 30};

function greet(name)
{
    console. log ("Hello" + name + "!");
}

greet(person.name);

if (num >30)
{
console.log ("number is greater than 30");
}
else 
{

    console.log("number is lower than 30");
}

for (var i = 0 ; i < 5; i++ )
{
    console.log (i);
} 

setTimeout(() => {
console.log ("Delayed Message 1 ");

}, 1000); // 1초

setTimeout(() => {
console.log ("Delayed Message 2 ");

}, 750); // 0.75초
setTimeout(() => {
console.log ("Delayed Message 3");

}, 2000); // 2초
setTimeout(() => {
console.log ("Delayed Message 4 ");

}, 500); // 0.5초