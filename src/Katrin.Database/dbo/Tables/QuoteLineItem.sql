CREATE TABLE [dbo].[QuoteLineItem] (
    [QuoteLineItemId] UNIQUEIDENTIFIER NOT NULL,
    [QuoteId]         UNIQUEIDENTIFIER NULL,
    [Quantity]        DECIMAL (23, 10) NULL,
    [ProductId]       UNIQUEIDENTIFIER NULL,
    [UnitPrice]       MONEY            NULL,
    [TotalPrice]      MONEY            NULL,
    [VersionNumber]   ROWVERSION       NULL,
    CONSTRAINT [PK_QuoteLineItem] PRIMARY KEY CLUSTERED ([QuoteLineItemId] ASC),
    CONSTRAINT [FK_QuoteLineItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_QuoteLineItem_Quote] FOREIGN KEY ([QuoteId]) REFERENCES [dbo].[Quote] ([QuoteId]) ON DELETE CASCADE
);

