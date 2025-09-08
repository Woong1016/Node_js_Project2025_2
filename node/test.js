const {add} = require("./Math.js");

let num = 42; 
var name = "TOM";
let isStudent = true;

let color = ["red" ,"green" , "blue"];

let person = {name : "Alece" , age : 30};

console.log (add(num,num)); 

function greet(name)
{
    console.log("Hello" + name  + "!");
}




if(num > 30)
{
    console.log("Numver is greater than 30");
}
else
{
    console.log("Number  is lower than 30");
    
}

for (var i= 0; i < 5; i++)
{

    console.log(i);
}


setTimeout(() => {
    console.log("Delated message 0.5 ")},500 ); // 0.5

setTimeout(() => {
    console.log("Delated message 0.75")},750 );// 0.75
    

setTimeout(() => {
    console.log("Delated message 1")},1000 ); // 1 
    


setTimeout(() => {
    console.log("Delated message 2")},2000 ); // 2 
    

