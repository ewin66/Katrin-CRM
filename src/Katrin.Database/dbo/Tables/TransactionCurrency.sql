CREATE TABLE [dbo].[TransactionCurrency] (
    [TransactionCurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [CurrencySymbol]        NVARCHAR (5)     NOT NULL,
    [CurrencyName]          NVARCHAR (100)   NOT NULL,
    [CurrencyPrecision]     INT              NOT NULL,
    [ExchangeRate]          DECIMAL (23, 10) NULL,
    [StatusCode]            INT              NULL,
    [ModifiedOn]            DATETIME         NULL,
    [VersionNumber]         ROWVERSION       NULL,
    [ModifiedById]          UNIQUEIDENTIFIER NULL,
    [CreatedOn]             DATETIME         NULL,
    [CreatedById]           UNIQUEIDENTIFIER NULL,
    [IsDeleted]             BIT              CONSTRAINT [DF_TransactionCurrency_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TransactionCurrency] PRIMARY KEY CLUSTERED ([TransactionCurrencyId] ASC)
);

