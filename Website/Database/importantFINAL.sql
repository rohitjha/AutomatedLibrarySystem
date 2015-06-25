/* Populating the database */

INSERT INTO Status VALUES(1, 'Available')
INSERT INTO Status VALUES(2, 'Unavailable')



INSERT INTO Login VALUES('amirajdhawan',99227329,2)
INSERT INTO Login VALUES('amiraj', 99227329, 1)

INSERT INTO UserDetails VALUES('Staff', 'ABCD EFGH', 'asdsvdvsdvd,asvfv,sdg', '1234567890', 'abcd@xyz.com', '20-01-1980')
INSERT INTO UserDetails VALUES('Customer', 'IJKL MNOP QRS', 'asasdadvsds,aadg', '9876543210', 'xyz@abc.com', '01-11-1996')

INSERT INTO BookInfo VALUES('100001', '038534273X, 9780385342735', 'The Google Story', 'For Googles 10th Birthday-2008 publication', 'David A Vise, Mark Malseed', 'Delta Trade Paperbacks', '2008', 330, 'Business & Economics', 3.5, 153, 'Moscow-born Sergey Brin and Midwest-born Larry Page dropped out of graduate school at Stanford University to, in their own words, "change the world" through a powerful search engine that would organize every bit of information on the Web for free.The Google Storytakes you deep inside the wild ride from an idea that struggled for funding in 1998 to a firm that rakes in billions in profits, making Brin and Page the wealthiest young men in America. Based on scrupulous research and extraordinary access to Google, this fast-moving narrative reveals how an unorthodox management style and culture of innovation enabled a search engine to shake up Madison Avenue and Wall Street, scoop up YouTube, and battle Microsoft at every turn. Not afraid of controversy, Google is expanding in Communist China and quietly working on a searchable genetic database, initiatives that test the founders guiding mantra: DONT BE EVIL.')

INSERT INTO Book VALUES('100001', '12321')

INSERT INTO Available VALUES('100001', 1)

INSERT INTO Card VALUES('1248', 'Staff', 0)

INSERT INTO Checkout VALUES('100001', '1248', '14-07-2011', '21-07-2011')

DROP TABLE Available
DROP TABLE Book
DROP TABLE BookInfo
DROP TABLE Card
DROP TABLE Checkout 
DROP TABLE Login
DROP TABLE Status
DROP TABLE UserDetails

/* Database creation */

CREATE TABLE Login(
	username VARCHAR(64),
	hash INTEGER,
	auth_level INTEGER,
	PRIMARY KEY(username))

CREATE TABLE UserDetails(
	username VARCHAR(64),
	Name VARCHAR(100),
	Address VARCHAR(500),
	Phone_num VARCHAR(30),
	Email_addr VARCHAR(100),
	DOB VARCHAR(10),
	FOREIGN KEY(username) REFERENCES Login)

CREATE TABLE Card(
	Num VARCHAR(100),
	username VARCHAR(64),
	Fines REAL,
	PRIMARY KEY(Num),
	FOREIGN KEY(username) REFERENCES Login)

CREATE TABLE BookInfo(
	Book_id	VARCHAR(100),
	ISBN VARCHAR(30),
	Title VARCHAR(200),
	Sub_Title VARCHAR(500),
	Authors VARCHAR(500),
	Publisher VARCHAR(200),
	Pub_Year VARCHAR(10),
	Pages INTEGER,
	Categories VARCHAR(300),
	Rating REAL,
	Num_Reviews INTEGER,
	Description VARCHAR(1000),
	PRIMARY KEY(Book_id))

CREATE TABLE Book(
	Book_id VARCHAR(100),
	BID VARCHAR(100),
	PRIMARY KEY(BID),
	FOREIGN KEY(Book_id) REFERENCES BookInfo)

CREATE TABLE Checkout(
	BID VARCHAR(100),
	Num VARCHAR(100),
	since VARCHAR(10),
	until VARCHAR(10),
	FOREIGN KEY(BID) REFERENCES Book,
	FOREIGN KEY(Num) REFERENCES Card)

CREATE TABLE Status(
	Code INTEGER,
	Availability VARCHAR(50),
	PRIMARY KEY(Code))

CREATE TABLE Available(
	Book_id VARCHAR(100),
	code INTEGER,
	FOREIGN KEY(Book_id) REFERENCES BookInfo)