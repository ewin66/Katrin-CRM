CREATE TABLE [dbo].[Attendance] (
    [AttendanceId]       UNIQUEIDENTIFIER NOT NULL,
    [RecordPersonId]     UNIQUEIDENTIFIER NULL,
    [RecordOn]           DATETIME         NULL,
    [AttendanceTypeCode] INT              NULL,
    [AttendanceLength]   INT              NULL,
    [AttendanceUnitCode] INT              NULL,
    [CreatedOn]          DATETIME         NULL,
    [CreatedById]        UNIQUEIDENTIFIER NULL,
    [ModifiedOn]         DATETIME         NULL,
    [ModifiedById]       UNIQUEIDENTIFIER NULL,
    [IsDeleted]          BIT              NOT NULL,
    [VersionNumber]      ROWVERSION       NULL,
    [Description]        NVARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([AttendanceId] ASC),
    CONSTRAINT [FK_Attendance_User_CreatedBy] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Attendance_User_ModifiedBy] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Attendance_User_RecordPersonId] FOREIGN KEY ([RecordPersonId]) REFERENCES [dbo].[User] ([UserId])
);

