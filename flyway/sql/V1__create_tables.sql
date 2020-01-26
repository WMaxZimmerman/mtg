CREATE TABLE Cards (
    CardId varchar(255) PRIMARY KEY,
    CardName varchar(255) Unique,
    ConvertedManaCost int,
    Cost int,
    OracleText varchar(255),
    Power varchar(255),
    Toughness varchar(255),
    Types varchar(255),
    SubTypes varchar(255),
    Colors varchar(255)
);

CREATE TABLE Sets (
    SetId varchar(255) PRIMARY KEY,
    SetName varchar(255) Unique,
    Border varchar(255),
    SetType varchar(255),
    Url varchar(255),
    SetNumber int
);

CREATE TABLE CardSets (
    CardSetId SERIAL PRIMARY KEY,
    CardId varchar(255) NOT NULL,
    SetId varchar(255) NOT NULL,
    HighPrice decimal,
    MedianPrice decimal,
    LowPrice decimal,
    Quantity int NOT NULL DEFAULT 0,

    --Foreign Keys
    FOREIGN KEY (CardId) REFERENCES Cards(CardId),
    FOREIGN KEY (SetId) REFERENCES Sets(SetId)
);

CREATE TABLE Decks (
    DeckId SERIAL PRIMARY KEY,
    DeckName varchar(255) NOT NULL UNIQUE,
    Commander varchar(255) NOT NULL,

    --Foreign Keys
    FOREIGN KEY (Commander) REFERENCES Cards(CardId)
);

CREATE TABLE DeckCards (
    DeckCardsId SERIAL PRIMARY KEY,
    DeckId int NOT NULL,
    CardId varchar(255) NOT NULL,
    Quantity int NOT NULL DEFAULT 1,

    --Foreign Keys
    FOREIGN KEY (DeckId) REFERENCES Decks(DeckId),
    FOREIGN KEY (CardId) REFERENCES Cards(CardId)
);

CREATE TABLE Tags (
    TagId SERIAL PRIMARY KEY,
    TagName varchar(255) NOT NULL
);

CREATE TABLE DeckTags (
    DeckCardsId SERIAL PRIMARY KEY,
    DeckId int NOT NULL,
    TagId int NOT NULL,
    Quantity int NOT NULL DEFAULT 1,

    --Foreign Keys
    FOREIGN KEY (DeckId) REFERENCES Decks(DeckId),
    FOREIGN KEY (TagId) REFERENCES Tags(TagId)
);

CREATE TABLE CardTags (
    CardTagId SERIAL PRIMARY KEY,
    CardId varchar(255) NOT NULL,
    TagId int NOT NULL,

    --Foreign Keys
    FOREIGN KEY (CardId) REFERENCES Cards(CardId),
    FOREIGN KEY (TagId) REFERENCES Tags(TagId)
);
