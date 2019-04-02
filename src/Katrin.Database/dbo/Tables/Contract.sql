﻿CREATE TABLE [dbo].[Contract] (
    [ContractId]               UNIQUEIDENTIFIER NOT NULL,
    [ContractNumber]           NVARCHAR (100)   NULL,
    [ActiveOn]                 DATETIME         NULL,
    [ExpiresOn]                DATETIME         NULL,
    [CancelOn]                 DATETIME         NULL,
    [Title]                    NVARCHAR (100)   NULL,
    [BillingEndOn]             DATETIME         NULL,
    [BillingStartOn]           DATETIME         NULL,
    [BillingFrequencyCode]     INT              NULL,
    [CreatedById]              UNIQUEIDENTIFIER NULL,
    [CreatedOn]                DATETIME         NULL,
    [ModifiedById]             UNIQUEIDENTIFIER NULL,
    [ModifiedOn]               DATETIME         NULL,
    [TotalPrice]               MONEY            NULL,
    [StatusCode]               INT              NULL,
    [TransactionCurrencyId]    UNIQUEIDENTIFIER NULL,
    [ExchangeRate]             DECIMAL (23, 10) NULL,
    [OwnerId]                  UNIQUEIDENTIFIER NOT NULL,
    [BillingCustomerId]        UNIQUEIDENTIFIER NULL,
    [Description]              NVARCHAR (MAX)   NULL,
    [VersionNumber]            ROWVERSION       NULL,
    [OpportunityId]            UNIQUEIDENTIFIER NULL,
    [DepartmentId]             UNIQUEIDENTIFIER NULL,
    [CustomerSignedOn]         DATETIME         NULL,
    [CompanySignedOn]          DATETIME         NULL,
    [CustomerSatisfactionCode] INT              NULL,
    [EndTypeCode]              INT              NULL,
    [IsDeleted]                BIT              CONSTRAINT [DF_Contract_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED ([ContractId] ASC),
    CONSTRAINT [FK_Contract_Account] FOREIGN KEY ([BillingCustomerId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_Contract_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]),
    CONSTRAINT [FK_Contract_Opportunity] FOREIGN KEY ([OpportunityId]) REFERENCES [dbo].[Opportunity] ([OpportunityId]),
    CONSTRAINT [FK_Contract_TransactionCurrency] FOREIGN KEY ([TransactionCurrencyId]) REFERENCES [dbo].[TransactionCurrency] ([TransactionCurrencyId]),
    CONSTRAINT [FK_Contract_User] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Contract_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Contract_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
);
