--/*
Drop Table [dbo].[DeckCards]
Drop Table [dbo].[Deck]
Drop Table [dbo].[Cards]
Drop Table [dbo].[Sets]
Drop Table [dbo].[CardSets]
--*/

CREATE TABLE [dbo].[Cards] (
    [CardId] varchar(255) PRIMARY KEY,
    [CardName] varchar(255) Unique,
    [ConvertedManaCost] nvarchar(MAX),
    [Cost] nvarchar(MAX),
    [OracleText] nvarchar(MAX),
    [Power] nvarchar(MAX),
    [Toughness] nvarchar(MAX),
    [Commander] nvarchar(MAX),
    [Modern] nvarchar(MAX),
    [Standard] nvarchar(MAX),
    [Types] nvarchar(MAX),
    [SubTypes] nvarchar(MAX),
    [Colors] nvarchar(MAX)
);

CREATE TABLE [dbo].[Sets] (
    [SetId] varchar(255) PRIMARY KEY,
    [SetName] varchar(255) Unique,
    [Border] nvarchar(MAX),
    [SetType] nvarchar(MAX),
    [Url] nvarchar(MAX),
    [SetNumber] int
);

CREATE TABLE [dbo].[CardSets] (
    [CardSetId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [CardId] varchar(255) NOT NULL,
    [SetId] varchar(255) NOT NULL,
    [HighPrice] decimal,
    [MedianPrice] decimal,
    [LowPrice] decimal,
    [Quantity] int NOT NULL DEFAULT 0,

    --Foreign Keys
    FOREIGN KEY (CardId) REFERENCES [dbo].[Cards](CardId),
    FOREIGN KEY (SetId) REFERENCES [dbo].[Sets](SetId)
);

CREATE TABLE [dbo].[Deck] (
    [DeckId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DeckName] varchar(255) NOT NULL UNIQUE,
    [Commander] varchar(255) NOT NULL,

    --Foreign Keys
    FOREIGN KEY (Commander) REFERENCES [dbo].[Card](CardId)
)

CREATE TABLE [dbo].[DeckCards] (
    [DeckCardsId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DeckId] int NOT NULL,
    [CardId] varchar(255) NOT NULL,
    [Quantity] int NOT NULL DEFAULT 1,

    --Foreign Keys
    FOREIGN KEY (DeckId) REFERENCES [dbo].[Deck](DeckId),
    FOREIGN KEY (CardId) REFERENCES [dbo].[Cards](CardId)
)

CREATE TABLE [dbo].[Tags] (
    [TagId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [TagName] varchar(255) NOT NULL
)

CREATE TABLE [dbo].[DeckTags] (
    [DeckCardsId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [DeckId] int NOT NULL,
    [TagId] varchar(255) NOT NULL,
    [Quantity] int NOT NULL DEFAULT 1,

    --Foreign Keys
    FOREIGN KEY (DeckId) REFERENCES [dbo].[Deck](DeckId),
    FOREIGN KEY (TagId) REFERENCES [dbo].[Tags](TagId)
)

CREATE TABLE [dbo].[CardTags] (
    [CardTagId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [CardId] varchar(255) NOT NULL,
    [TagId] int NOT NULL,

    --Foreign Keys
    FOREIGN KEY (CardId) REFERENCES [dbo].[Cards](CardId),
    FOREIGN KEY (TagId) REFERENCES [dbo].[Tags](TagId)
)
