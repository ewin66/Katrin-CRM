using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121024095026)]
    public class _20121024095026_AddProjectModule : Migration
    {
        public override void Up()
        {
            //For ProjectModule
            Create.Table("ProjectModule").InSchema("dbo")
                .WithColumn("ProjectModuleId").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("ProjectId").AsGuid().NotNullable()
                .WithColumn("ModuleName").AsString(500).NotNullable()
                .WithColumn("Description").AsMaxString().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedById").AsGuid().Nullable()
                .WithColumn("ModifiedOn").AsDateTime().Nullable()
                .WithColumn("ModifiedById").AsGuid().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("VersionNumber").AsCustom("rowversion").Nullable()
            ;

            //For ProjectTask
            Alter.Table("ProjectTask").InSchema("dbo")
                .AddColumn("TaskNumber").AsString(50).Nullable()
                .AddColumn("ProjectModuleId").AsGuid().Nullable()
                ;
            //ForeignKey
            Create.ForeignKey().FromTable("ProjectTask").ForeignColumn("ProjectModuleId").ToTable("ProjectModule").PrimaryColumn("ProjectModuleId");
            Create.ForeignKey().FromTable("ProjectModule").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Create.ForeignKey().FromTable("ProjectModule").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey().FromTable("ProjectModule").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");

            //For Metadata_Entity
            string sql = @"INSERT INTO [dbo].[Metadata_Entity]
                                       ([EntityId]
                                       ,[Name]
                                       ,[PhysicalName]
                                       ,[LogicalName]
                                       ,[TableName]
                                       ,[IsAuditEnabled])
                            VALUES	(NEWID()
		                               ,'ProjectModule'
                                       ,'ProjectModule'
                                       ,'projectmodule'
                                       ,'ProjectModule'
                                       ,0)";
            Execute.Sql(sql);
            //For Metadata_Attribute
            sql = @"INSERT	Metadata_Attribute(
		            AttributeId,
		            AttributeTypeId,
		            Name,
		            PhysicalName,
		            Length,
		            IsNullable,
		            EntityId,
		            ColumnNumber,
		            LogicalName,
		            IsAuditEnabled,
		            TableColumnName,
		            IsPKAttribute)
            SELECT	AttributeId = NEWID(),
		            AttributeTypeId = CASE WHEN c.COLUMN_NAME LIKE '%Code' THEN '00000000-0000-0000-00AA-110000000030'
							            ELSE t.AttributeTypeId END, ---???????????
		            Name			= Lower(c.COLUMN_NAME),
		            PhysicalName	= c.COLUMN_NAME,
		            Length			= c.CHARACTER_MAXIMUM_LENGTH,
		            IsNullable		= CASE c.IS_NULLABLE WHEN 'NO' THEN 0 ELSE 1 END,
		            EntityId		= e.EntityId,
		            ColumnNumber	= ORDINAL_POSITION,
		            LogicalName		= Lower(c.COLUMN_NAME),
		            IsAuditEnabled	= 0,
		            TableColumnName	= c.COLUMN_NAME,
		            IsPKAttribute	=  CASE WHEN EXISTS(	select 1
												              from INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc
												              join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcu
													            on kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA
												               and kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME
												               and kcu.TABLE_SCHEMA = tc.TABLE_SCHEMA
												               and kcu.TABLE_NAME = tc.TABLE_NAME
												             where tc.CONSTRAINT_TYPE in ( 'PRIMARY KEY')
												             AND	kcu.TABLE_NAME = e.TableName COLLATE DATABASE_DEFAULT
												             AND	kcu.COLUMN_NAME = c.COLUMN_NAME COLLATE DATABASE_DEFAULT)
								            THEN 1
								            ELSE 0 
							            END
            FROM	[INFORMATION_SCHEMA].[COLUMNS] c
		            INNER JOIN Metadata_Entity e
		            ON	e.TableName	COLLATE DATABASE_DEFAULT = c.TABLE_NAME COLLATE DATABASE_DEFAULT
		            LEFT OUTER JOIN Metadata_AttributeType t
		            ON	t.Description = c.DATA_Type
		            where e.Name='ProjectModule'";
            Execute.Sql(sql);

            // Update Atteibute For ProjectTask
            sql = @"DECLARE @EntityId uniqueidentifier
                    SELECT @EntityId=[EntityId]
                    FROM [dbo].[Metadata_Entity]
                    WHERE [Name]='ProjectTask'
                    INSERT Metadata_Attribute(
		            AttributeId,
		            AttributeTypeId,
		            Name,
		            PhysicalName,
		            IsNullable,
		            EntityId,
		            ColumnNumber,
		            LogicalName,
		            IsAuditEnabled,
		            TableColumnName,
		            IsPKAttribute)
                    VALUES	(NEWID(),
                             '00000000-0000-0000-00AA-110000000031',
                             'projectmoduleid',
                             'ProjectModuleId',
                              1,
                              @EntityId,
                              25,
                              'projectmoduleid',
                              0,
                              'ProjectModuleId',
                               0)
                   INSERT Metadata_Attribute(
		            AttributeId,
		            AttributeTypeId,
		            Name,
		            PhysicalName,
		            IsNullable,
		            EntityId,
		            ColumnNumber,
		            LogicalName,
		            IsAuditEnabled,
		            TableColumnName,
		            IsPKAttribute)
                    VALUES	(NEWID(),
                             '00000000-0000-0000-00AA-11000000001E',
                             'tasknumber',
                             'TaskNumber',
                              1,
                              @EntityId,
                              26,
                              'tasknumber',
                              0,
                              'TaskNumber',
                               0)";
            Execute.Sql(sql);
            //Update ProjectTask
            sql = @"declare @AttributeId	uniqueidentifier
                    declare @EntityId	uniqueidentifier
                    declare @DisplayEntityAttributeId	uniqueidentifier
                    UPDATE Metadata_Attribute
                    SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
                    FROM	Metadata_Entity e
		                    INNER JOIN Metadata_Attribute a
		                    ON	a.EntityId	= e.EntityId
                    WHERE	a.PhysicalName	= 'ProjectModuleId'
                    AND e.Name = 'ProjectTask'

                    SELECT	@AttributeId	= a.AttributeId
                    FROM	Metadata_Entity e
		                    INNER JOIN Metadata_Attribute a
		                    ON	a.EntityId	= e.EntityId
                    WHERE	a.PhysicalName	= 'ProjectModuleId'
                    AND e.Name = 'ProjectTask'

                    SELECT	@EntityId					= e.EntityId,
		                    @DisplayEntityAttributeId	= a.AttributeId
                    FROM	Metadata_Entity e
		                    INNER JOIN Metadata_Attribute a
		                    ON	a.EntityId	= e.EntityId
                    WHERE	a.PhysicalName	= 'ModuleName'
                    AND e.Name = 'ProjectModule'

                    INSERT INTO Metadata_AttributeLookupValue(
	                    AttributeLookupValueId, 
	                    AttributeId, 
	                    EntityId, 
	                    DisplayEntityAttributeId)
                    VALUES(
	                    NEWID(), 
	                    @AttributeId, 
	                    @EntityId,
	                    @DisplayEntityAttributeId)";
            Execute.Sql(sql);

            //Create Relations
            sql = @"INSERT INTO [Metadata_Relationship](
			            [RelationshipId]
                       ,[Name]
                       ,[ReferencingEntityId]
                       ,[ReferencingAttributeId]
                       ,[ReferencedEntityId]
                       ,[ReferencedAttributeId]
                       ,[RelationshipType]
                       ,[CascadeDelete])
            SELECT	[RelationshipId]		= NEWID(),
		            [Name]					= OBJECT_NAME(s.constid),
		            [ReferencingEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = o1.name),
		            [ReferencingAttributeId]= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												            INNER JOIN  Metadata_Entity e 
												            ON e.EntityId	= attr.EntityId
										            WHERE	attr.Name = c1.name AND e.Name = o1.name),
		            [ReferencedEntityId]	= (SELECT EntityId FROM Metadata_Entity WHERE Name = o2.name),
		            [ReferencedAttributeId]	= (SELECT attr.AttributeId FROM Metadata_Attribute attr 
												            INNER JOIN  Metadata_Entity e 
												            ON e.EntityId	= attr.EntityId
										            WHERE	attr.Name = c2.name AND e.Name = o2.name),
		            [RelationshipType]		= 1,
		            [CascadeDelete]			= 1
            FROM	sysforeignkeys s
		            INNER JOIN sysobjects o1
		            ON	o1.id		= s.fkeyid
		            INNER JOIN sysobjects o2
		            ON	o2.id		= s.rkeyid
		            INNER JOIN syscolumns c1
		            ON	c1.id		= s.fkeyid
		            AND	c1.colid	= s.fkey
		            INNER JOIN syscolumns c2
		            ON	c2.id		= s.rkeyid
		            AND	c2.colid	= s.rkey
            WHERE EXISTS(SELECT 1 FROM Metadata_Entity WHERE Name = o1.name and name in('ProjectModule','ProjectTask'))
            and OBJECT_NAME(s.constid) like '%ProjectModule%'";
            Execute.Sql(sql);

            sql= @"GO
            CREATE PROCEDURE [dbo].[CreateEntityOneToManyRelathionshipRole] 
	            @SchemaName			nvarchar(255),
	            @ReferencingEntityName nvarchar(64),
	            @ReferencingAttributeName nvarchar(64),
	            @ReferencedEntityName nvarchar(64),
	            @ReferencedAttributeName nvarchar(64)
            AS
            BEGIN
	            DECLARE	@EntityRelationshipId uniqueidentifier

	            SET @EntityRelationshipId	= NEWID()

	            INSERT INTO [dbo].[Metadata_EntityRelationship]
			               ([EntityRelationshipId]
			               ,[SchemaName]
			               ,[EntityRelationshipType]
			               ,[IsCustomRelationship]
			               ,[IsCustomizable])
	            SELECT	[EntityRelationshipId]		= @EntityRelationshipId,
			            [SchemaName]				= @SchemaName,
			            [EntityRelationshipType]	= 0,
			            [IsCustomRelationship]		= 0,
			            [IsCustomizable]			= 0

	            INSERT INTO [dbo].[Metadata_EntityRelationshipRelationships]
			               ([EntityRelationshipRelationshipsId]
			               ,[EntityRelationshipId]
			               ,[RelationshipId])
	            SELECT	EntityRelationshipRelationshipsId	= NEWID(),
			            [EntityRelationshipId]				= @EntityRelationshipId,
			            [RelationshipId]					= (	SELECT	r.RelationshipId
													            FROM	Metadata_Relationship r
															            INNER JOIN Metadata_Entity referencingEntity
															            ON	referencingEntity.EntityId = r.ReferencingEntityId
															            AND	referencingEntity.Name = @ReferencingEntityName
															            INNER JOIN Metadata_Attribute referencingAttribute
															            ON	referencingAttribute.EntityId	= r.ReferencingEntityId
															            AND	referencingAttribute.AttributeId = r.ReferencingAttributeId
															            AND	referencingAttribute.PhysicalName = @ReferencingAttributeName
															            INNER JOIN Metadata_Entity referencedEntity
															            ON	referencedEntity.EntityId = r.ReferencedEntityId
															            AND	referencedEntity.Name = @ReferencedEntityName
															            INNER JOIN Metadata_Attribute referencedAttribute
															            ON	referencedAttribute.EntityId	= r.ReferencedEntityId
															            AND	referencedAttribute.AttributeId = r.ReferencedAttributeId
															            AND	referencedAttribute.PhysicalName = @ReferencedAttributeName)
	            INSERT INTO [dbo].[Metadata_EntityRelationshipRole]
			               ([EntityRelationshipRoleId]
			               ,[EntityRelationshipId]
			               ,[EntityId]
			               ,[RelationshipRoleType])
	            SELECT	[EntityRelationshipRoleId]	= NEWID(),
			            [EntityRelationshipId]		= @EntityRelationshipId,
			            [EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @ReferencingEntityName),
			            [RelationshipRoleType]		= 1

	            UNION ALL

	            SELECT	[EntityRelationshipRoleId]	= NEWID(),
			            [EntityRelationshipId]		= @EntityRelationshipId,
			            [EntityId]					= (	SELECT	EntityId FROM	Metadata_Entity WHERE Name = @ReferencedEntityName),
			            [RelationshipRoleType]		= 0
            END
            GO
            EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'ProjectTask_ProjectModule', 'ProjectTask','ProjectModuleId', 'ProjectModule','ProjectModuleId'
            EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'ProjectModule_Project', 'ProjectModule','ProjectId', 'Project','ProjectId'
            EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'ProjectModule_user_modifiedBy', 'ProjectModule', 'ModifiedById','user','UserId'
            EXEC dbo.[CreateEntityOneToManyRelathionshipRole] 'ProjectModule_user_createdBy', 'ProjectModule', 'CreatedById','user','UserId'

            Drop PROCEDURE [dbo].[CreateEntityOneToManyRelathionshipRole]";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"DELETE FROM [Metadata_EntityRelationshipRole] 
                           WHERE [EntityRelationshipId] IN (
                           SELECT [EntityRelationshipId] FROM [Metadata_EntityRelationship] WHERE [SchemaName] LIKE '%module%')";
            Execute.Sql(sql);
            sql = @"  DELETE FROM [Metadata_EntityRelationshipRelationships]
                      WHERE [RelationshipId] IN (
                      SELECT [RelationshipId] FROM [Metadata_Relationship] 
                      WHERE [ReferencingEntityId] IN (SELECT [EntityId] 
                      FROM [Metadata_Entity] WHERE [Name]='ProjectModule')
                      OR [ReferencedEntityId]IN (SELECT [EntityId] FROM [Metadata_Entity] WHERE [Name]='ProjectModule'))";
            Execute.Sql(sql);
            sql = @"  DELETE FROM [Metadata_Relationship] 
                      WHERE [ReferencingEntityId] IN (SELECT [EntityId] 
                      FROM [Metadata_Entity] WHERE [Name]='ProjectModule')
                      OR [ReferencedEntityId]IN (SELECT [EntityId] FROM [Metadata_Entity] WHERE [Name]='ProjectModule')";
            Execute.Sql(sql);
            sql = @"  DELETE FROM [Metadata_EntityRelationship] 
                      WHERE [SchemaName] LIKE '%module%'";
            Execute.Sql(sql);

            Delete.ForeignKey().FromTable("ProjectTask").ForeignColumn("ProjectModuleId").ToTable("ProjectModule").PrimaryColumn("ProjectModuleId");
            Delete.ForeignKey().FromTable("ProjectModule").ForeignColumn("ProjectId").ToTable("Project").PrimaryColumn("ProjectId");
            Delete.ForeignKey().FromTable("ProjectModule").ForeignColumn("CreatedById").ToTable("User").PrimaryColumn("UserId");
            Delete.ForeignKey().FromTable("ProjectModule").ForeignColumn("ModifiedById").ToTable("User").PrimaryColumn("UserId");
            Delete.Table("ProjectModule").InSchema("dbo");
            Delete.Column("ProjectModuleId").FromTable("ProjectTask").InSchema("dbo");

        }
    }
}
