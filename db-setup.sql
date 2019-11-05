-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     hash VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

-- CREATE TABLE banks (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE items (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     items INT DEFAULT 0,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE bankitems (
--     id int NOT NULL AUTO_INCREMENT,
--     bankId int NOT NULL,
--     itemId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (bankId, itemId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (bankId)
--         REFERENCES banks(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (itemId)
--         REFERENCES items(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET ITEMS BY BANKID
-- SELECT * FROM bankitems vk
-- INNER JOIN items k ON k.id = vk.itemId 
-- WHERE (bankId = @bankId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS bankitems;
-- DROP TABLE IF EXISTS banks;
-- DROP TABLE IF EXISTS items;
-- DROP TABLE IF EXISTS users;
