-- =============================================
-- Set lookup columns
-- =============================================
DELETE FROM Metadata_AttributeLookupValue

DECLARE	@AttributeId uniqueidentifier
DECLARE	@DisplayEntityAttributeId uniqueidentifier
DECLARE	@EntityId uniqueidentifier

------------------------------Lead------------------------------------
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Lead'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Lead'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Lead'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Lead'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Lead'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Lead'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Lead'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Lead'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---DepartmentId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Lead'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Lead'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Department'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

------------------------------Account------------------------------------
---DepartmentId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Account'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Account'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Department'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Account'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Account'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---PrimaryContactId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'PrimaryContactId'
AND e.Name = 'Account'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'PrimaryContactId'
AND e.Name = 'Account'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'Contact'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---OriginatingLeadId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OriginatingLeadId'
AND e.Name = 'Account'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OriginatingLeadId'
AND e.Name = 'Account'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'Lead'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Account'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Account'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Account'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Account'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

------------------------------Contact------------------------------------
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Contact'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Contact'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---OriginatingLeadId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OriginatingLeadId'
AND e.Name = 'Contact'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OriginatingLeadId'
AND e.Name = 'Contact'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'Lead'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Contact'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Contact'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Contact'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Contact'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ParentCustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ParentCustomerId'
AND e.Name = 'Contact'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ParentCustomerId'
AND e.Name = 'Contact'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

------------------------------Opportunity------------------------------------
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---OriginatingLeadId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OriginatingLeadId'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OriginatingLeadId'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'Lead'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---TransactionCurrencyId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CurrencyName'
AND e.Name = 'TransactionCurrency'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---DepartmentId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Department'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---TechnicianId----	
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TechnicianId'
AND e.Name = 'Opportunity'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TechnicianId'
AND e.Name = 'Opportunity'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)


/********************Product************************/

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Product'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Product'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Product'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Product'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---TransactionCurrencyId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Product'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Product'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CurrencyName'
AND e.Name = 'TransactionCurrency'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)


/********************Quote************************/

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---OpportunityId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OpportunityId'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OpportunityId'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Opportunity'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
	
---CustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
	
---TransactionCurrencyId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CurrencyName'
AND e.Name = 'TransactionCurrency'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)	
	
---BillTo_AddressId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'BillTo_AddressId'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'BillTo_AddressId'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'CustomerAddress'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)	
		
		
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Quote'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Quote'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
		

/********************Contract************************/

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Contract'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Contract'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Contract'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Contract'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---OpportunityId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OpportunityId'
AND e.Name = 'Contract'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OpportunityId'
AND e.Name = 'Contract'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Opportunity'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
	
---CustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'BillingCustomerId'
AND e.Name = 'Contract'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'BillingCustomerId'
AND e.Name = 'Contract'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
	
---TransactionCurrencyId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Contract'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Contract'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CurrencyName'
AND e.Name = 'TransactionCurrency'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)	
	
	
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Contract'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Contract'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---DepartmentId----
SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'Contract'

UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
WHERE AttributeId = @AttributeId

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Department'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)


/********************Invoice************************/

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Invoice'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Invoice'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Invoice'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Invoice'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---TransactionCurrencyId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Invoice'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'TransactionCurrencyId'
AND e.Name = 'Invoice'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CurrencyName'
AND e.Name = 'TransactionCurrency'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)	
	
	
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Invoice'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'Invoice'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---BillingCustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'BillingCustomerId'
AND e.Name = 'Invoice'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'BillingCustomerId'
AND e.Name = 'Invoice'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
/********************Audit************************/

---UserId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'UserId'
AND e.Name = 'Audit'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'UserId'
AND e.Name = 'Audit'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

/********************Note************************/

---CreatedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Note'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Note'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ModifiedBy----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Note'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Note'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---------------------------------------------------task-----------------------
-----------CreatedBy------------
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'ProjectTask'
SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'ProjectTask'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
-------------------ModifiedBy
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'ProjectTask'
SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'ProjectTask'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
---OwnerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'ProjectTask'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'OwnerId'
AND e.Name = 'ProjectTask'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ProjectId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectId'
AND e.Name = 'ProjectTask'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectId'
AND e.Name = 'ProjectTask'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Project'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ProjectIterationId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectIterationId'
AND e.Name = 'ProjectTask'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectIterationId'
AND e.Name = 'ProjectTask'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'ProjectIteration'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---------------------------------------ProjectIteration
---ProjectId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectId'
AND e.Name = 'ProjectIteration'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectId'
AND e.Name = 'ProjectIteration'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Project'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ProjectVersionId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectVersionId'
AND e.Name = 'ProjectIteration'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectVersionId'
AND e.Name = 'ProjectIteration'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'VersionName'
AND e.Name = 'ProjectVersion'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---------------------------------------------------Project-----------------------
---CustomerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Project'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CustomerId'
AND e.Name = 'Project'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Account'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

-----------CreatedBy------------
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Project'
SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Project'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
-------------------ModifiedBy
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Project'
SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Project'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

-------------------SaleServiceId
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'SaleServiceId'
AND e.Name = 'Project'
SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'SaleServiceId'
AND e.Name = 'Project'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ManagerId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ManagerId'
AND e.Name = 'Project'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ManagerId'
AND e.Name = 'Project'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ContractId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ContractId'
AND e.Name = 'Project'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ContractId'
AND e.Name = 'Project'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Title'
AND e.Name = 'Contract'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---------------------------ProjectWeekReport

---ProjectId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectId'
AND e.Name = 'ProjectWeekReport'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectId'
AND e.Name = 'ProjectWeekReport'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Project'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---ProjectIterationId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectIterationId'
AND e.Name = 'ProjectWeekReport'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ProjectIterationId'
AND e.Name = 'ProjectWeekReport'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'ProjectIteration'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

---CreatedById----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'ProjectWeekReport'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'ProjectWeekReport'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
---ModifiedById----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'ProjectWeekReport'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'ProjectWeekReport'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

/********************TimeTracking************************/

---RecordById----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'RecordById'
AND e.Name = 'TimeTracking'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'RecordById'
AND e.Name = 'TimeTracking'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
------------------USER------------------------
---DepartmentId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'User'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'DepartmentId'
AND e.Name = 'User'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'Name'
AND e.Name = 'Department'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
------------------Attendance------------------------
---RecordPersonId----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'RecordPersonId'
AND e.Name = 'Attendance'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'RecordPersonId'
AND e.Name = 'Attendance'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
---CreatedById----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Attendance'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'CreatedById'
AND e.Name = 'Attendance'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)
---ModifiedById----
UPDATE Metadata_Attribute
SET	AttributeTypeId	= '00000000-0000-0000-00AA-110000000031'
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Attendance'

SELECT	@AttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'ModifiedById'
AND e.Name = 'Attendance'

SELECT	@EntityId					= e.EntityId,
		@DisplayEntityAttributeId	= a.AttributeId
FROM	Metadata_Entity e
		INNER JOIN Metadata_Attribute a
		ON	a.EntityId	= e.EntityId
WHERE	a.PhysicalName	= 'FullName'
AND e.Name = 'User'

INSERT INTO Metadata_AttributeLookupValue(
	AttributeLookupValueId, 
	AttributeId, 
	EntityId, 
	DisplayEntityAttributeId)
VALUES(
	NEWID(), 
	@AttributeId, 
	@EntityId,
	@DisplayEntityAttributeId)

