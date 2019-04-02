﻿CREATE TABLE [dbo].[CustomerAddress] (
    [CustomerAddressId]  UNIQUEIDENTIFIER NOT NULL,
    [ParentId]           UNIQUEIDENTIFIER NULL,
    [AddressTypeCode]    INT              NULL,
    [Name]               NVARCHAR (200)   NULL,
    [PrimaryContactName] NVARCHAR (150)   NULL,
    [Line1]              NVARCHAR (MAX)   NULL,
    [Line2]              NVARCHAR (MAX)   NULL,
    [Line3]              NVARCHAR (MAX)   NULL,
    [City]               NVARCHAR (MAX)   NULL,
    [StateOrProvince]    NVARCHAR (MAX)   NULL,
    [County]             NVARCHAR (MAX)   NULL,
    [Country]            NVARCHAR (MAX)   NULL,
    [PostOfficeBox]      NVARCHAR (50)    NULL,
    [PostalCode]         NVARCHAR (50)    NULL,
    [Latitude]           FLOAT (53)       NULL,
    [Longitude]          FLOAT (53)       NULL,
    [Fax]                NVARCHAR (50)    NULL,
    [VersionNumber]      ROWVERSION       NULL,
    [CreatedById]        UNIQUEIDENTIFIER NULL,
    [CreatedOn]          DATETIME         NULL,
    [ModifiedById]       UNIQUEIDENTIFIER NULL,
    [ModifiedOn]         DATETIME         NULL,
    [IsDeleted]          BIT              CONSTRAINT [DF_CustomerAddress_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CustomerAddress] PRIMARY KEY CLUSTERED ([CustomerAddressId] ASC)
);

