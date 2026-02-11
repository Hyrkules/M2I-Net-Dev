CREATE DATABASE IF NOT EXISTS ma_bdd;

use ma_bdd;

CREATE TABLE IF NOT EXISTS User (id INT PRIMARY KEY AUTO_INCREMENT, nom VARCHAR(50) NOT NULL, prenom VARCHAR(50) UNIQUE, age INT DEFAULT(18), CONSTRAINT Check_age CHECK(age >= 18));

CREATE TABLE Command (
    id INT PRIMARY KEY AUTO_INCREMENT,
    prix DOUBLE NOT NULL,
    id_user INT NOT NULL,
    FOREIGN KEY (id_user)
        REFERENCES User (id)
);

-- ALTER TABLE User
-- ADD telephone VARCHAR(10);
-- ALTER TABLE User
-- MODIFY prenom VARCHAR(100);
-- ALTER TABLE User
-- CHANGE nom nom_user VARCHAR(100);

INSERT INTO User (nom, prenom, age) VALUES("Test", "Oui", 24), ("Test2", "Oui2", 25);

UPDATE User 
SET 
    prenom = 'OuiUpdate'
WHERE
    prenom = 'Oui2';

DELETE FROM User 
WHERE
    prenom = 'OuiUpdate';


-- DROP TABLE Command;
-- DROP TABLE User;