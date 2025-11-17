const express = require('express');
const mysql = require('mysql2/promise');
const app = express();

app.use (express.json());

const pool = mysql.createPool({

    host : 'localhost',
    user : 'root',
    password : '@Pjw71932002',
    datebass : 'gametest'
});


app.post ('/login', async (req ,res )=> {
    const {username , password_hash} = req.body;

    try
    {
        const [player] =await pool.query(
            'SELECT * FROM players WHERE username = ? AND password_hash = ?',
            [username , password_hash] 
        );

        if(players.length > 0)
        {
            await pool.query
            (
                'UPDATE players SET last_login = CURRENT_TIMESTAMP WHERE player_id =?'
                [player[0].player.id]
            );
        }
        else
            {
                res.status(500).json({success: false , message :'로그인 실패'});
            }
    }
    catch(error)
    {
        res.status (500).json({success: false , message : error.message});
    }
});





app.get('/inventory/:playerId' , async (req, res)=>{

    try
    {
        const[inventory]= await pool.query(

           // 'SELECT i.* inv.quantity FROM inventories inv JOIN items i ON inv.item_id = i.item_id WHERE inv.player_id =?'
             'SELECT inv.item_id,inv.quantity FROM inventories inventories inv JOIN items i ON inv.item_id =i.item_id WHERE pq.player_id =?',
          
           [req.params.playerId]
        );
        res.json(inventory);
    }
    catch(error)
    {
        res.status(500).json({success : false , message : error.message});
    }
});

app.get('/quests/:playerId' , async (req, res)=>{

    console.log(req.params.playerId);
    try
    {
        console.log("try 문 진입");
        const[quests]= await pool.query(

           // 'SELECT i.* inv.quantity FROM inventories inv JOIN items i ON inv.item_id = i.item_id WHERE inv.player_id =?'
            'SELECT q.*, pq .`STATUS` FROM player_quests pq JOIN quests q ON pq.quest_id = q.quest_id WHERE pq.player_id = ? ',
           [req.params.playerId]
        );
        console.log(quests);
        res.json(quests);
    }
    catch(error)
    {
        res.status(500).json({success : false , message : error.message});
    }
});





const PORT = 3000;

app.listen (PORT , ()=> {
    console.log(`서버 실행중 : ${PORT}`);
})



const WebSocket = require('ws');
const iconv = require('iconv-lite');

class GameServer{

    constructor(port){
        this.wss = new WebSocket.Server({port});
        this.clients = new set();
        this.player = new Map();
        this.SetupServerEvent();
        console.log(`게임 서버 포트 ${port}에서 시작 되었습니다`);
    }
}

SetupServerEvent()
{
    this.wss.on('connection' , (socket) => {

     this .clients . add(socket);
     const playerId = this.generatePlayerId();

     this.player.set(playerId , {
        socket : socket,
        position : {x: 0 , y : 0 , z: 0}

     });
     console.log(`클라이언트 접속 ID : ${playerID} 현재 접속자 : ${this.clients.size}`);

     const welcomData = {
        type : 'connection',
        PlayerId : playerId,
        message : '서버에 연결 되었습니다'
     };
     socket.send(JSON.stringify(welcomData));
    });
}