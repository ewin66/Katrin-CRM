CREATE TABLE [dbo].[InvoiceContract] (
    [InvoiceContractId] UNIQUEIDENTIFIER NOT NULL,
    [InvoiceId]         UNIQUEIDENTIFIER NOT NULL,
    [ContractId]        UNIQUEIDENTIFIER NOT NULL,
    [VersionNumber]     ROWVERSION       NULL,
    CONSTRAINT [PK_InvoiceContract] PRIMARY KEY CLUSTERED ([InvoiceContractId] ASC),
    CONSTRAINT [FK_InvoiceContract_Contract] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[Contract] ([ContractId]),
    CONSTRAINT [FK_InvoiceContract_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([InvoiceId])
);

