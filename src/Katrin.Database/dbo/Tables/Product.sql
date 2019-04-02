CREATE TABLE [dbo].[Product] (
    [ProductId]             UNIQUEIDENTIFIER NOT NULL,
    [Name]                  NVARCHAR (100)   NULL,
    [Description]           NVARCHAR (MAX)   NULL,
    [ProductTypeCode]       INT              NULL,
    [ProductUrl]            NVARCHAR (255)   NULL,
    [Price]                 MONEY            NULL,
    [ProductNumber]         NVARCHAR (100)   NOT NULL,
    [CurrentCost]           MONEY            NULL,
    [StandardCost]          MONEY            NULL,
    [CreatedOn]             DATETIME         NULL,
    [CreatedById]           UNIQUEIDENTIFIER NULL,
    [ModifiedOn]            DATETIME         NULL,
    [ModifiedById]          UNIQUEIDENTIFIER NULL,
    [StatusCode]            INT              NULL,
    [VersionNumber]         ROWVERSION       NULL,
    [TransactionCurrencyId] UNIQUEIDENTIFIER NULL,
    [ExchangeRate]          DECIMAL (23, 10) NULL,
    [IsDeleted]             BIT              CONSTRAINT [DF_Product_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Product_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
);

