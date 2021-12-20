CREATE SCHEMA pkm;
GO

CREATE TABLE pkm.Pokemon (
    mainID int NOT NULL IDENTITY,
    Name varchar(255) NOT NULL,
    PokeHeight varchar(255) NOT NULL,
    PokeWeight varchar(255) NOT NULL,
    PRIMARY KEY (mainID)
);

CREATE TABLE pkm.Types (
    ID int NOT NULL IDENTITY,
    Name varchar(255) NOT NULL UNIQUE,
    PRIMARY KEY (ID)
);

CREATE TABLE pkm.PokemonType (
    conID int NOT NULL IDENTITY,
    pokemonID int NOT NULL,
    TypeID int NOT NULL,
    PRIMARY KEY (conID),
    FOREIGN KEY (pokemonID) REFERENCES pkm.Pokemon(mainID),
    FOREIGN KEY (TypeID) REFERENCES pkm.Types(ID)
    
    
);

--Write a query that will retrieve all columns from each record in the `Pokemon` table,
-- and include the Type.Id, Type.Name, and PokemonType.Id fields for each record.  

SELECT * FROM pkm.Pokemon;

INSERT INTO pkm.Pokemon (Name, PokeHeight, PokeWeight)
VALUES ('Bulbasaur', '7', '70' );
INSERT INTO pkm.Pokemon (Name, PokeHeight, PokeWeight)
VALUES ('Ditto', '3', '40' );

INSERT INTO pkm.Types (Name)
VALUES ('Normal');
INSERT INTO pkm.Types (Name)
VALUES ('Grass' );

INSERT INTO pkm.PokemonType(pokemonID, TypeID)
VALUES (1,2);
INSERT INTO pkm.PokemonType(pokemonID, TypeID)
VALUES (2,1 );

 DROP TABLE pkm.pokemon;
 DROP TABLE pkm.Types;
 DROP TABLE pkm.PokemonType;


