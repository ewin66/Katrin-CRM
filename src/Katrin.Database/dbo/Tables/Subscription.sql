CREATE TABLE [dbo].[Subscription] (
    [SubscriptionId]                 UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER              NULL,
    [NotificationProfileId]          UNIQUEIDENTIFIER              NULL, 
    CONSTRAINT [PK_Subscription] PRIMARY KEY ([SubscriptionId]), 
    CONSTRAINT [FK_Subscription_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_Subscription_NotificationProfile] FOREIGN KEY ([NotificationProfileId]) REFERENCES [NotificationProfile]([NotificationProfileId])
);

