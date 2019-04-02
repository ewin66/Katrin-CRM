using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121114160354)]
    public class _20121114160354_DisposeContactSkipToRelatedAccount:Migration
    {
        public override void Up()
        {
            string sql = @" -------------------Contact----------------------------
                        UPDATE  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=1 where 
                        EntityRelationshipRoleId in
                        (
                        SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
                            INNER JOIN Metadata_Entity B
                            ON A.EntityId= B.EntityId
                            INNER JOIN Metadata_EntityRelationship C
                            ON A.EntityRelationshipId = C.EntityRelationshipId
                            WHERE B.PhysicalName = 'Contact' 
                            and c.SchemaName = 'account_contact')";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = @"UPDATE  Metadata_EntityRelationshipRole  set NavPanelDisplayOption=0 where 
                        EntityRelationshipRoleId in
                        (
                        SELECT a.EntityRelationshipRoleId FROM Metadata_EntityRelationshipRole A 
                            INNER JOIN Metadata_Entity B
                            ON A.EntityId= B.EntityId
                            INNER JOIN Metadata_EntityRelationship C
                            ON A.EntityRelationshipId = C.EntityRelationshipId
                            WHERE B.PhysicalName = 'Contact' 
                            and c.SchemaName = 'account_contact')";
            Execute.Sql(sql);
        }
    }
}
