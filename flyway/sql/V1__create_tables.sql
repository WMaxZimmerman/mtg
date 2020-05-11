CREATE SCHEMA dbo;

CREATE TABLE dbo.Card (
    Id varchar(255) PRIMARY KEY,
    Name varchar(255) Unique,
    CMC int,
    Cost varchar(255),
    Oracle_Text varchar(255),
    Power varchar(255),
    Toughness varchar(255),
    Types varchar(255),
    Sub_Types varchar(255),
    Colors varchar(255)
);

CREATE TABLE dbo.Set (
    Id varchar(255) PRIMARY KEY,
    Name varchar(255) Unique,
    Border varchar(255),
    Type varchar(255),
    Url varchar(255),
    Number int
);

CREATE TABLE dbo.Card_Set (
    Id SERIAL PRIMARY KEY,
    Card_Id varchar(255) NOT NULL,
    Set_Id varchar(255) NOT NULL,
    High_Price decimal,
    Median_Price decimal,
    Low_Price decimal,
    Quantity int NOT NULL DEFAULT 0,

    --Foreign Keys
    FOREIGN KEY (Card_Id) REFERENCES dbo.Card(Id),
    FOREIGN KEY (Set_Id) REFERENCES dbo.Set(Id)
);

CREATE TABLE dbo.Deck (
    Id SERIAL PRIMARY KEY,
    Name varchar(255) NOT NULL UNIQUE,
    Commander varchar(255) NOT NULL,

    --Foreign Keys
    FOREIGN KEY (Commander) REFERENCES dbo.Card(Id)
);

CREATE TABLE dbo.Deck_Card (
    Id SERIAL PRIMARY KEY,
    Deck_Id int NOT NULL,
    Card_Id varchar(255) NOT NULL,
    Quantity int NOT NULL DEFAULT 1,

    --Foreign Keys
    FOREIGN KEY (Deck_Id) REFERENCES dbo.Deck(Id),
    FOREIGN KEY (Card_Id) REFERENCES dbo.Card(Id)
);

CREATE TABLE dbo.Tag (
    Id SERIAL PRIMARY KEY,
    Name varchar(255) NOT NULL
);

CREATE TABLE dbo.Deck_Tag (
    Id SERIAL PRIMARY KEY,
    Deck_Id int NOT NULL,
    Tag_Id int NOT NULL,
    Quantity int NOT NULL DEFAULT 1,

    --Foreign Keys
    FOREIGN KEY (Deck_Id) REFERENCES dbo.Deck(Id),
    FOREIGN KEY (Tag_Id) REFERENCES dbo.Tag(Id)
);

CREATE TABLE dbo.Card_Tag (
    Id SERIAL PRIMARY KEY,
    Card_Id varchar(255) NOT NULL,
    Tag_Id int NOT NULL,

    --Foreign Keys
    FOREIGN KEY (Card_Id) REFERENCES dbo.Card(Id),
    FOREIGN KEY (Tag_Id) REFERENCES dbo.Tag(Id)
);
