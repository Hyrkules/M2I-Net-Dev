CREATE DATABASE TP_recipes;

USE TP_recipes;

CREATE TABLE Ingredient (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL
);

CREATE TABLE Etape (
    id INT PRIMARY KEY AUTO_INCREMENT,
    description VARCHAR(1000) NOT NULL
);

CREATE TABLE Categorie (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL
);

CREATE TABLE Commentaire (
    id INT PRIMARY KEY AUTO_INCREMENT,
    description VARCHAR(1000) NOT NULL
);

CREATE TABLE Recette (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    tempsPrep INT NOT NULL,
    tempsCuisson INT NOT NULL,
    difficulte INT NOT NULL,
    ID_Ingredient INT NOT NULL, FOREIGN KEY (ID_Ingredient) REFERENCES Ingredient(id),
    ID_Etape INT NOT NULL, FOREIGN KEY (ID_Etape) REFERENCES Etape(id),
    ID_Commentaire INT NOT NULL, FOREIGN KEY (ID_Commentaire) REFERENCES Commentaire(id),
    ID_Categorie INT NOT NULL, FOREIGN KEY (ID_Categorie) REFERENCES Categorie(id)
);

CREATE TABLE IF NOT EXISTS RecetteIngredient (
  id INT AUTO_INCREMENT PRIMARY KEY,
  recette_id INT NOT NULL,
  ingredient_id INT NOT NULL,
  quantite VARCHAR(100) NULL,
  ordre INT DEFAULT 0,
  FOREIGN KEY (recette_id) REFERENCES Recette(id) ON DELETE CASCADE,
  FOREIGN KEY (ingredient_id) REFERENCES Ingredient(id) ON DELETE CASCADE
);