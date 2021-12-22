CREATE DATABASE [ShopApp];
GO

USE [ShopApp];
GO

CREATE SCHEMA shop;
GO

-- DROP TABLE shop.Users;
-- DROP TABLE shop.Items;
-- DROP TABLE shop.Orders;

CREATE TABLE shop.Users (
    userID int NOT NULL IDENTITY,
    userName NVARCHAR(255) NOT NULL UNIQUE,
    PRIMARY KEY (userName)
);

CREATE TABLE shop.Items (
    itemID int NOT NULL IDENTITY,
    itemName NVARCHAR(255) NOT NULL UNIQUE,
    itemPrice INT NOT NULL,
    Store NVARCHAR(255) NOT NULL,
    PRIMARY KEY (itemName),
);

CREATE TABLE shop.Orders (
    orderID int NOT NULL IDENTITY,
    orderName NVARCHAR(255) NOT NULL,
    orderItem NVARCHAR(255) NOT NULL
    PRIMARY KEY (orderID)
    FOREIGN KEY (orderName) REFERENCES shop.Users(userName),
    FOREIGN KEY (orderItem) REFERENCES shop.Items(itemName)
);


--Dummy Data
INSERT INTO shop.users (userName)
VALUES ('Bill' );
INSERT INTO shop.users (userName)
VALUES ('Jack' );
INSERT INTO shop.users (userName)
VALUES ('Karen' );

INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('shirt', 5, 'GenSup');
INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('pants', 5, 'GenSup');
INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('shoes', 5, 'GenSup');

INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('hat', 5, 'proShop');
INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('gloves', 5, 'proShop');
INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('boots', 5, 'proShop');

INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('Fruit', 5, 'QuikMart');
INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('Vegi', 5, 'QuikMart');
INSERT INTO shop.Items (itemName , itemPrice, Store )
VALUES ('Meat', 5, 'QuikMart');


SELECT * FROM shop.users;
SELECT * FROM shop.Items;