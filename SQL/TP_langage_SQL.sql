CREATE DATABASE IF NOT EXISTS tabletoptreasures_database;

use tabletoptreasures_database;

CREATE TABLE Clients (id INT PRIMARY KEY AUTO_INCREMENT, nom VARCHAR(30) NOT NULL, prenom VARCHAR(30) NOT NULL, adresse_mail VARCHAR(30) NOT NULL, Adresse_de_livraison VARCHAR(100), Telephone VARCHAR(15));

CREATE TABLE Categories (id INT PRIMARY KEY AUTO_INCREMENT, nom VARCHAR(30) NOT NULL);

CREATE TABLE Jeux (id INT PRIMARY KEY AUTO_INCREMENT, nom VARCHAR(30) NOT NULL, Description VARCHAR(1000), prix INT, ID_Categorie INT NOT NULL, FOREIGN KEY (ID_Categorie) REFERENCES Categories(id));

CREATE TABLE Commandes (id INT PRIMARY KEY AUTO_INCREMENT, ID_Client INT NOT NULL, FOREIGN KEY (ID_Client) REFERENCES Clients(id), date_de_commande DATE, Adresse_de_livraison VARCHAR(100), Statut VARCHAR(50), ID_Jeux INT NOT NULL, FOREIGN KEY (ID_Jeux) REFERENCES Jeux(id));

INSERT INTO Categories(nom) VALUES('Stratégie'),
('Familial'),
('Aventure');

INSERT INTO Jeux(nom, Description, prix, ID_Categorie) VALUE ('Catan', 'Jeu de stratégie et de développement de colonies', 30, 1),
('Dixit', 'Jeu d''association d''images', 25, 2),
('Les Aventuriers', 'Jeu de plateau d''aventure', 40, 3),
('Carcassonne', 'Jeu de placement de tuiles', 28, 1),
('Codenames', 'Jeu de mots et d''indices', 20, 2),
('Pandemic', 'Jeu de coopération pour sauver le monde', 35, 3),
('7 Wonders', 'Jeu de cartes et de civilisations', 29, 1),
('Splendor', 'Jeu de développement économique', 27, 2),
('Horreur à Arkham', 'Jeu d''enquête et d''horreur', 45, 3),
('Risk', 'Jeu de conquête mondiale', 22, 1),
('Citadelles', 'Jeu de rôles et de bluff', 23, 2),
('Terraforming Mars', 'Jeu de stratégie de colonisation de Mars', 55, 3),
('Small World', 'Jeu de civilisations fantastiques', 32, 1),
('7 Wonders Duel', 'Jeu de cartes pour 2 joueurs', 26, 2),
('Horreur à l''Outreterre', 'Jeu d''aventure horrifique', 38, 3);

INSERT INTO Clients(nom, prenom, adresse_mail, Adresse_de_livraison, Telephone) VALUES('Dubois', 'Marie', 'marie.dubois@example.com', '123 Rue de la Libération, Ville', '+1234567890'),
('Lefebvre', 'Thomas', 'thomas.lefebvre@example.com', '456 Avenue des Roses, Ville', '+9876543210'),
('Martinez', 'Léa', 'lea.martinez@example.com', '789 Boulevard de la Paix, Ville', '+2345678901'),
('Dupuis', 'Antoine', 'antoine.dupuis@example.com', '567 Avenue de la Liberté, Ville', '+3456789012'),
('Morin', 'Camille', 'camille.morin@example.com', '890 Rue de l''Avenir, Ville', '+4567890123'),
('Girard', 'Lucas', 'lucas.girard@example.com', '234 Avenue des Champs, Ville', '+5678901234'),
('Petit', 'Emma', 'emma.petit@example.com', '123 Rue des Étoiles, Ville', '+6789012345'),
('Sanchez', 'Gabriel', 'gabriel.sanchez@example.com', '345 Boulevard du Bonheur, Ville', '+7890123456'),
('Rossi', 'Clara', 'clara.rossi@example.com', '678 Avenue de la Joie, Ville', '+8901234567'),
('Lemoine', 'Hugo', 'hugo.lemoine@example.com', '456 Rue de la Nature, Ville', '+9012345678'),
('Moreau', 'Eva', 'eva.moreau@example.com', '789 Avenue de la Créativité, Ville', '+1234567890'),
('Fournier', 'Noah', 'noah.fournier@example.com', '234 Rue de la Découverte, Ville', '+2345678901'),
('Leroy', 'Léa', 'lea.leroy@example.com', '567 Avenue de l''Imagination, Ville', '+3456789012'),
('Robin', 'Lucas', 'lucas.robin@example.com', '890 Rue de la Création, Ville', '+4567890123'),
('Marchand', 'Anna', 'anna.marchand@example.com', '123 Boulevard de l''Innovation, Ville', '+5678901234');

INSERT INTO Commandes(ID_Client , date_de_commande, Adresse_de_livraison, Statut, ID_Jeux) VALUES(2, "2026-01-13", "1 rue de truc, Lille", "En cours de paiment", 2),
(8, "2026-01-12", "1 rue de truc, Lille", "Payé", 5),
(1, "2026-01-11", "1 rue de truc, Lille", "En cours de livraison", 4),
(1, "2026-01-11", "1 rue de truc, Lille", "En cours de livraison", 4);

UPDATE Jeux SET prix = 35 WHERE id = 3;

DELETE FROM Jeux
WHERE id = 2;

SELECT DISTINCT nom FROM Categories;
SELECT * FROM Categories WHERE nom LIKE "A%" OR nom LIKE "S%";
SELECT nom FROM Categories WHERE id BETWEEN 2 AND 5;
SELECT DISTINCT COUNT(nom) FROM Categories;
SELECT nom FROM Categories ORDER BY LENGTH(nom) DESC LIMIT 1;
SELECT SUM(ID_Categorie)
FROM Jeux
GROUP BY ID_Categorie;
SELECT * FROM Categories ORDER BY nom DESC;

SELECT DISTINCT nom FROM Jeux;
SELECT * FROM Jeux WHERE prix BETWEEN 25 AND 40;
SELECT nom from Jeux WHERE id = 3;
SELECT Count(nom) FROM Jeux WHERE description LIKE "%aventure%";
SELECT * FROM Jeux ORDER BY prix ASC LIMIT 1;
SELECT SUM(prix) FROM Jeux;
SELECT nom FROM Jeux ORDER BY nom ASC LIMIT 5;

SELECT DISTINCT prenom FROM Clients;
SELECT * FROM Clients WHERE Adresse_de_livraison LIKE "%Rue%" AND telephone LIKE "+1%";
SELECT * FROM Clients WHERE nom LIKE "M%" OR nom LIKE "R%";
SELECT COUNT(adresse_mail) FROM Clients WHERE adresse_mail LIKE "%@%";
SELECT prenom FROM Clients ORDER BY LENGTH(prenom) ASC LIMIT 1;
SELECT COUNT(id) FROM Clients;
SELECT * FROM Clients ORDER BY nom ASC LIMIT 100 OFFSET 3; # Pas de OFFSET sans LIMIT ?

SELECT Clients.nom, Commandes.date_de_commande, Jeux.nom FROM Commandes INNER JOIN Jeux ON Jeux.id = Commandes.ID_Jeux 
INNER JOIN Clients ON Clients.id = Commandes.ID_Client;
SELECT Clients.nom, SUM(Jeux.prix) FROM Commandes INNER JOIN Jeux ON Jeux.id = Commandes.ID_Jeux 
INNER JOIN Clients ON Clients.id = Commandes.ID_Client
GROUP BY nom;
SELECT Jeux.nom, Categories.nom, Jeux.prix FROM Jeux INNER JOIN Categories ON Jeux.ID_Categorie = Categories.id;
SELECT Clients.nom, Commandes.date_de_commande, Jeux.nom FROM Commandes INNER JOIN Jeux ON Jeux.id = Commandes.ID_Jeux 
INNER JOIN Clients ON Clients.id = Commandes.ID_Client;
SELECT Clients.nom ,COUNT(Commandes.id) ,SUM(Jeux.prix) FROM Commandes INNER JOIN Jeux ON Jeux.id = Commandes.ID_Jeux 
INNER JOIN Clients ON Clients.id = Commandes.ID_Client
GROUP BY nom;
