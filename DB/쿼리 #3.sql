CREATE TABLE shops(
shop_id INT AUTO_INCREMENT PRIMARY KEY,
NAME VARCHAR(100) NOT NULL,
location VARCHAR(100)
);

-- 상점 데이터 삽입

INSERT INTO shops (NAME , location) VALUES
('모험가의 장비점', '시작 마을 '),
('마법 물약 상회' , '마법의 숲 ')


-- 상점 재고 테이블 생성

CREATE TABLE shop_inventory(
shop_id INT ,
item_id INT ,
price INT NOT NULL,
stock INT DEFAULT 0,
PRIMARY KEY (shop_id , item_id),
FOREIGN KEY (shop_id) REFERENCES shops (shop_id),
FOREIGN KEY (item_id) REFERENCES items (item_id)
)

-- 상품 재고 데이터 삽입
INSERT INTO shop_inventory (shop_id , item_id , price , stock)VALUES
(1,1,20,5),
(1,2,30,3),
(2,3,10,10)

-- 특정 상점의 재고 조회

SELECT s.name AS shop_name , i.name AS item_name , si.price , si.stock
FROM shops s 
JOIN shop_inventory si ON s.shop_id = si.shop_id
JOIN items i ON si.item_id = i.item_id
WHERE s.shop_id =1

-- 플레이어 지갑 테이블 생성

CREATE TABLE player_wallet(
player_id INT PRIMARY KEY,
gold INT DEFAULT 0,
FOREIGN KEY (player_id)REFERENCES players(player_id)
);

 
INSERT INTO player_wallet (player_id , gold)VALUES
(1, 100),
(2, 200)