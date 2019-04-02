using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Katrin.Services.Metadata
{

    [DataContract(IsReference = true)]
    [KnownType(typeof(Entity))]
    public partial class AttributeLookupValue
    {
    }

    [DataContract(IsReference = true)]
    public partial class AttributeType
    { }

    [DataContract(IsReference = true)]
    [KnownType(typeof(EntityAttribute))]
    [KnownType(typeof(EntityRelationshipRole))]
    public partial class Entity
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(AttributeType))]
    [KnownType(typeof(OptionSet))]
    [KnownType(typeof(AttributeLookupValue))]
    public partial class EntityAttribute
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(EntityRelationshipRelationships))]
    [KnownType(typeof(EntityRelationshipRole))]
    public partial class EntityRelationship
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(Relationship))]
    public partial class EntityRelationshipRelationships
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(EntityRelationship))]
    public partial class EntityRelationshipRole
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(EntityAttribute))]
    [KnownType(typeof(Entity))]
    public partial class Relationship
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(ColumnMapping))]
    public partial class ImportMap
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(ImportMap))]
    public partial class ColumnMapping
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(NotificationProfile))]
    [KnownType(typeof(Criteria))]
    public partial class NotificationRecipientAttributes
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(NotificationRecipientAttributes))]
    [KnownType(typeof(Criteria))]
    [KnownType(typeof(NotificationTemplate))]
    [KnownType(typeof(ProfileVariable))]
    [KnownType(typeof(Subscription))]
    public partial class NotificationProfile
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(NotificationProfile))]
    public partial class NotificationTemplate
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(NotificationProfile))]
    public partial class Subscription
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(NotificationProfile))]
    [KnownType(typeof(NotificationVariable))]
    public partial class ProfileVariable
    {
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(ProfileVariable))]
    public partial class NotificationVariable
    {

    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(NotificationRecipientAttributes))]
    [KnownType(typeof(CriteriaNode))]
    [KnownType(typeof(NotificationProfile))]
    public partial class Criteria
    {

    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(Criteria))]
    public partial class CriteriaNode
    {

    }
}
