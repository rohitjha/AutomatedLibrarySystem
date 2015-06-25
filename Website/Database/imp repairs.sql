
CREATE TABLE temp( bid VARCHAR(100), num VARCHAR(100), since VARCHAR(10), until VARCHAR(10))
INSERT INTO temp VALUES ('100001','9090','10-23-1990','10-30-1990');


INSERT INTO BookInfo VALUES('100001', '038534273X, 9780385342735', 'The Google Story', 'For Googles 10th Birthday-2008 publication', 'David A Vise~Mark Malseed~Abc~', 'Delta Trade Paperbacks', '2008', 330, 'Business & Economics', 3.5, 153, 'Moscow-born Sergey Brin and Midwest-born Larry Page dropped out of graduate school at Stanford University to, in their own words, "change the world" through a powerful search engine that would organize every bit of information on the Web for free.The Google Storytakes you deep inside the wild ride from an idea that struggled for funding in 1998 to a firm that rakes in billions in profits, making Brin and Page the wealthiest young men in America. Based on scrupulous research and extraordinary access to Google, this fast-moving narrative reveals how an unorthodox management style and culture of innovation enabled a search engine to shake up Madison Avenue and Wall Street, scoop up YouTube, and battle Microsoft at every turn. Not afraid of controversy, Google is expanding in Communist China and quietly working on a searchable genetic database, initiatives that test the founders guiding mantra: DONT BE EVIL.')

SELECT BI.Book_id, BI.Title, BI.Authors, CO.since, CO.until 
FROM temp CO, BookInfo BI 
WHERE CO.Num = '9090' AND CO.BID = BI.Book_id order by CO.since

SELECT * FROM UserDetails
INSERT INTO UserDetails VALUES('amiraj','Amiraj',NULL,'9920678775','amirajdhawan@gmail.com',NULL)

INSERT INTO Card values('1234567890','amiraj',0.0)
INSERT INTO Book VALUES('100001','0987654321')
INSERT INTO Checkout VALUES('0987654321','1234567890','10-23-1990','10-30-1990')

DROP TABLE temp
SELECT * FROM BookInfo

INSERT INTO Checkout values('3F00ED8804','1234567890',NULL,NULL)
ALTER TABLE BookInfo
ALTER COLUMN Authors VARCHAR(1000)

SELECT * FROM Bookinfo