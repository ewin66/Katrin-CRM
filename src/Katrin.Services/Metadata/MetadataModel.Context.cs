

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Katrin.Services.Metadata
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class KatrinEntities : DbContext
{
    public KatrinEntities()
        : base("name=KatrinEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<EntityAttribute> EntityAttributes { get; set; }

    public DbSet<AttributeLookupValue> AttributeLookupValues { get; set; }

    public DbSet<AttributePicklistValue> AttributePicklistValues { get; set; }

    public DbSet<AttributeType> AttributeTypes { get; set; }

    public DbSet<Entity> Entities { get; set; }

    public DbSet<EntityRelationship> EntityRelationships { get; set; }

    public DbSet<EntityRelationshipRelationships> EntityRelationshipRelationships { get; set; }

    public DbSet<EntityRelationshipRole> EntityRelationshipRoles { get; set; }

    public DbSet<OptionSet> OptionSets { get; set; }

    public DbSet<Relationship> Relationships { get; set; }

    public DbSet<LocalizedLabel> LocalizedLabels { get; set; }

    public DbSet<ColumnMapping> ColumnMappings { get; set; }

    public DbSet<ImportMap> ImportMaps { get; set; }

    public DbSet<SavedQuery> SavedQueries { get; set; }

    public DbSet<Criterion> Criteria { get; set; }

    public DbSet<CriteriaNode> CriteriaNodes { get; set; }

    public DbSet<NotificationProfile> NotificationProfiles { get; set; }

    public DbSet<NotificationRecipientAttribute> NotificationRecipientAttributes { get; set; }

    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    public DbSet<NotificationVariable> NotificationVariables { get; set; }

    public DbSet<ProfileVariable> ProfileVariables { get; set; }

    public DbSet<Subscription> Subscriptions { get; set; }

}

}

