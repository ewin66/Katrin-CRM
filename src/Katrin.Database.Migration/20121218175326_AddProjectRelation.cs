using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121218175326)]
    public class _20121218175326_AddProjectRelation : Migration
    {
        public override void Up()
        {
            string sql = @"update Metadata_EntityRelationshipRole set NavPanelDisplayOption=1
            where EntityRelationshipRoleId in(
            select EntityRelationshipRoleId from Metadata_EntityRelationshipRole
            where EntityRelationshipId in
            (select EntityRelationshipId from Metadata_EntityRelationshipRelationships where RelationshipId in
            (
            select RelationshipId from Metadata_Relationship where Name like N'%Project_Account%'
            ))
            and RelationshipRoleType = 1)";
            Execute.Sql(sql);
        }
        public override void Down()
        {

        }
    }
}
