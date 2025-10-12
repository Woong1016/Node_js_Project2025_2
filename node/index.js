const express = require('express');
const fs = require('fs');           // 파일 시스템
const palyerRoutes = require('./Routes/playerRoutes');
const app = express();
const port = 4000;              //포트 4000번대

app.use(express.json());   //json 통신 설정
app.use('/api', palyerRoutes);        // API 라우트 설정
const resourceFilePath = 'resources.json';              //자원 저장  파일 경로

loadResource(); 
function loadResource()
{
    if(fs.existsSync(resourceFilePath))             //파일경로를 확인해서 파일이 있는지 확인
    {
        const data = fs.readFileSync(resourceFilePath); 
        global.palyers = JSON.parse(data);          // 파일에서 로딩

    }
    else
    {
        global.palyers = {};                        //초기화
    }
}
function saveResources()
{
    fs.writeFileSync(resourceFilePath, JSON.stringify(global.palyers, null ,2));
}

app.listen(port , ()=>

{
    console.log(`서버가 http://localhost:${port}에서 실행중입니다.`);
})
