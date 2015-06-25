CREATE TABLE users(
username VARCHAR(50) PRIMARY KEY,
hash INTEGER,
auth_level INTEGER)


INSERT INTO users values('amirajdhawan','99227329','2')
INSERT INTO users values('amiraj1','99227329','1')

CREATE TABLE all_users(
name VARCHAR(100),
username VARCHAR(50) FOREIGN KEY REFERENCES users,
address VARCHAR(300),
contact_number VARCHAR(20),
email_address VARCHAR(100),
balance_amt NUMERIC(5,2),
member_since DATETIME,
member_upto DATETIME,
PRIMARY KEY (username))

SELECT * FROM all_users


INSERT INTO all_users (name,username,address,contact_number,email_address) values('Amiraj','amirajdhawan','15/604 Gulmohar Vasant Vihar Thane(W)','9920678775','amirajdhawan@gmail.com')

CREATE TABLE book(
book_id VARCHAR(50) PRIMARY KEY,
isbn VARCHAR(100),
title VARCHAR(500),
sub_title VARCHAR(500),
num_pages INTEGER,
description VARCHAR(5000),
rating FLOAT,
category VARCHAR(500),
authors VARCHAR(500),
publisher VARCHAR(300),
pub_date DATETIME,
no_of_reviews INTEGER,
section VARCHAR(100),
shelf VARCHAR(100))

CREATE TABLE all_books(
book_id VARCHAR(50) FOREIGN KEY REFERENCES book,
book_name VARCHAR(500),
total_copies INTEGER,
available_copies INTEGER,
PRIMARY KEY(book_id))


SELECT * FROM users
UPDATE users SET hash=99227329 WHERE username='amirajdhawan'