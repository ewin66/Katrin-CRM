﻿CREATE TABLE [dbo].[ProjectWeekReport] (
    [ProjectWeekReportId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]           UNIQUEIDENTIFIER NOT NULL,
    [ProjectIterationId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]                NVARCHAR (500)   NOT NULL,
    [CurrentProgressCode] INT              NULL,
    [OutlookProgressCode] INT              NULL,
    [CriteriaProgress]    NVARCHAR (MAX)   NULL,
    [CurrentQualityCode]  INT              NULL,
    [OutlookQualityCode]  INT              NULL,
    [CriteriaQuality]     NVARCHAR (MAX)   NULL,
    [Suggestions]         NVARCHAR (MAX)   NULL,
    [Reviews]             NVARCHAR (MAX)   NULL,
    [RecordOn]            DATETIME         NULL,
    [CreatedOn]           DATETIME         NULL,
    [CreatedById]         UNIQUEIDENTIFIER NULL,
    [ModifiedOn]          DATETIME         NULL,
    [ModifiedById]        UNIQUEIDENTIFIER NULL,
    [VersionNumber]       ROWVERSION       NULL,
    CONSTRAINT [PK_ProjectWeekReport] PRIMARY KEY CLUSTERED ([ProjectWeekReportId] ASC),
    CONSTRAINT [FK_ProjectWeekReport_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]),
    CONSTRAINT [FK_ProjectWeekReport_ProjectIteration] FOREIGN KEY ([ProjectIterationId]) REFERENCES [dbo].[ProjectIteration] ([ProjectIterationId]),
    CONSTRAINT [FK_ProjectWeekReport_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_ProjectWeekReport_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
);

