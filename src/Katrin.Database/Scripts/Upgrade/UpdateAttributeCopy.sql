UPDATE Metadata_Attribute SET IsCopyEnabled=1
UPDATE Metadata_Attribute SET IsCopyEnabled=0 WHERE IsPKAttribute=1
UPDATE Metadata_Attribute SET IsCopyEnabled=0 WHERE TableColumnName like '%create%' OR 
TableColumnName like '%modif%'