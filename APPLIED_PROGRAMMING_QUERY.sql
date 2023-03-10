CREATE DATABASE APPR;

CREATE TABLE LOGINS
(
LOGIN_ID INT PRIMARY KEY IDENTITY(1,1),
FIRST_NAME VARCHAR(200) NOT NULL,
SECOND_NAME VARCHAR(200) NOT NULL,
GENDER VARCHAR(10) NOT NULL,
EMAIL VARCHAR(200) NOT NULL,
ACCOUNT_PASSWORD VARCHAR(200) NOT NULL
);

CREATE TABLE DISASTER
(
DISASTER_ID INT PRIMARY KEY IDENTITY(1,1),
STARTING_DATE VARCHAR(200) NOT NULL,
ENDING_DATE VARCHAR(200) NOT NULL,
LOCATION VARCHAR(200) NOT NULL,
DISASTER_DESCRIPTION TEXT NOT NULL,
AID VARCHAR(50) NOT NULL,
NEW_AID VARCHAR(200) NULL,
LOGIN_ID INT,
FOREIGN KEY(LOGIN_ID) REFERENCES LOGINS(LOGIN_ID)
);

CREATE TABLE MONEY_
(
MONEY_ID INT PRIMARY KEY IDENTITY(1,1),
DATE_OF_DONATION VARCHAR(200) NOT NULL,
AMOUNT FLOAT NOT NULL,
ANONYMOUS_ VARCHAR(10) NOT NULL,
COMMENT VARCHAR(200) NULL,
LOGIN_ID INT,
FOREIGN KEY(LOGIN_ID) REFERENCES LOGINS(LOGIN_ID)
);


CREATE TABLE GOODS
(
GOODS_ID INT PRIMARY KEY IDENTITY(1,1),
NUMBER_OF_ITEM VARCHAR(200) NOT NULL,
CATEGORY VARCHAR(200) NOT NULL,
NEW_CATEGORY VARCHAR(200) NULL,
DATE_ITEM VARCHAR(200) NOT NULL,
LOGIN_ID INT,
FOREIGN KEY(LOGIN_ID) REFERENCES LOGINS(LOGIN_ID)
);



    