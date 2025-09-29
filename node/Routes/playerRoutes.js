const express = require('express');
const fs = require('fs');
 //const { platform } = require('os');
const router = express.Router();

const resourceFilePath = 'resources.json';

const initalResources = {
    metal : 500,
    crystal : 300 ,
    deuterium : 100,
}

global.players = {};

router.post('/regitster' , (req,res) =>{
    const {name , password }= req.body;
    if(global.players[name])
    {
        return res.status(400).send({message : '이미 등록된 사용자입니다'});
    }


    global.players[name] = {
        playerName :name,
        password : password,
        resources :{
           
            metal : 500,
            srystal : 300,
            deuterium : 100
        },
        planets:[]

    };
    saveResources();
    res.send({message : '등록완료' ,player:name});

})
//return.post('/login' , (req, res) => {})

router.post('/login' , (req,res) =>{
    const {name , password }= req.body;
    if(!global.players[name])
    {
        return res.status(404).send({message : '플레이어를 찾을 수 없습니다'});
    }
    if(password!== global.players[name].password)
    {
        return res.status(401).send({message : '비밀번호가 틀렸습니다'});
    }

    const player = global.players[name];

    const reqponsePayLoad = {
        playerName : player.playerName,
        metal : player.resources.metal,
        crystal : player.resources.crystal,
        deuterium : player.resources.deuterium
    }

    console.log("Login response playLoad : " , reqponsePayLoad);
    res.send(reqponsePayLoad);
});

function saveResources()
{
    fs.writeFileSync(resourceFilePath, JSON.stringify(global.palyers, null ,2))
}
module.exports =router;