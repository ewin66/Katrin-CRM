
if not exists(select * from syscolumns where name ='QueryParentId')
ALTER TABLE SavedQuery
ADD   QueryParentId UNIQUEIDENTIFIER NULL  


delete from SavedQuery where Name = 'Default ProjectIteration List'
delete from SavedQuery where Name = 'Iteration Task Detail List'

declare @SavedQueryId UNIQUEIDENTIFIER
set @SavedQueryId = NEWID()

--------------------------------------------------------------------------------------ProjectIteration---------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = @SavedQueryId    ,QueryType = 0    ,Name = 'Default ProjectIteration List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'ProjectIteration')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="GroupPanelText" />
  <property name="NewItemRowText" />
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="LevelIndent">-1</property>
  <property name="PreviewIndent">-1</property>
  <property name="PreviewLineCount">-1</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="HorzScrollStep">3</property>
  <property name="PreviewFieldName" />
  <property name="ViewCaptionHeight">-1</property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="Columns" iskey="true" value="5">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">348</property>
      <property name="ColumnEditName" />
      <property name="Name">colName</property>
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">135</property>
      <property name="ColumnEditName" />
      <property name="Name">colStartDate</property>
      <property name="Caption">StartDate</property>
      <property name="FieldName">StartDate</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Width">103</property>
      <property name="ColumnEditName" />
      <property name="Name">colEndDate</property>
      <property name="Caption">End Date</property>
      <property name="FieldName">Deadline</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">249</property>
      <property name="ColumnEditName" />
      <property name="Name">colVersionNumber</property>
      <property name="FieldName">ProjectVersionId</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">253</property>
      <property name="ColumnEditName" />
      <property name="Name">colProjectId</property>
      <property name="FieldName">ProjectId</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">Default</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">gridView1</property>
  <property name="DetailHeight">350</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="VertScrollTipFieldName" />
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ShowGroupPanel">false</property>
    <property name="WaitAnimationOptions">Panel</property>
    <property name="AllowHtmlDrawHeaders">true</property>
  </property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AutoExpandAllGroups">true</property>
    <property name="AllowFixedGroups">True</property>
  </property>
  <property name="FixedLineWidth">2</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="ShowDetailTabs">false</property>
  </property>
  <property name="ChildGridLevelName">ProjectTasks</property>
  <property name="IndicatorWidth">-1</property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="VertScrollVisibility">Auto</property>
  <property name="GroupRowHeight">-1</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="RowSeparatorHeight">0</property>
  <property name="RowHeight">-1</property>
  <property name="ActiveFilterString" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF1EZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xLCBWZXJzaW9uPTEyLjEuNy4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI4OGQxNzU0ZDcwMGU0OWEFAQAAADhEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvQ29sbGVjdGlvbgQAAAAKZ3JvdXBDb3VudAVjbG9uZQ9jbG9uZUdyb3VwQ291bnQTQ29sbGVjdGlvbkJhc2UrbGlzdAADAAMIsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dCBxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AgAAAAEAAAAJAwAAAAAAAAAJBAAAAAQDAAAAsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAABAAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAQAAAAYJAAAAEGNvbFZlcnNpb25OdW1iZXIL</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'
--------------------------------------------------iteration task detail view---------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryParentId,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryParentId=@SavedQueryId,QueryType = 0    ,Name = 'Iteration Task Detail List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity 
WHERE Name = 'ProjectIteration')    ,
IsDefault = 0    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="GroupPanelText" />
  <property name="NewItemRowText" />
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="LevelIndent">-1</property>
  <property name="PreviewIndent">-1</property>
  <property name="PreviewLineCount">-1</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="HorzScrollStep">3</property>
  <property name="PreviewFieldName" />
  <property name="ViewCaptionHeight">-1</property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="Columns" iskey="true" value="8">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">104</property>
      <property name="ColumnEditName" />
      <property name="Name">colName</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Name</property>
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">81</property>
      <property name="ColumnEditName" />
      <property name="Name">colStatusCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">StatusCode</property>
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="ColumnEditName" />
      <property name="Name">colCreatedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">82</property>
      <property name="ColumnEditName" />
      <property name="Name">colQuoteWorkHours</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">QuoteWorkHours</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Width">52</property>
      <property name="ColumnEditName" />
      <property name="Name">colActualWorkHours</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ActualWorkHours</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Width">56</property>
      <property name="ColumnEditName" />
      <property name="Name">colActualInput</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ActualInput</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">53</property>
      <property name="ColumnEditName" />
      <property name="Name">colEffort</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">Effort</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">71</property>
      <property name="ColumnEditName" />
      <property name="Name">colOwnerId</property>
      <property name="FieldName">OwnerId</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">NoBorder</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">gridView1</property>
  <property name="DetailHeight">350</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="VertScrollTipFieldName" />
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ShowGroupPanel">false</property>
    <property name="WaitAnimationOptions">Panel</property>
    <property name="ColumnAutoWidth">false</property>
  </property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AllowIncrementalSearch">true</property>
  </property>
  <property name="FixedLineWidth">2</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="ChildGridLevelName" />
  <property name="IndicatorWidth">-1</property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="VertScrollVisibility">Auto</property>
  <property name="GroupRowHeight">-1</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="RowSeparatorHeight">0</property>
  <property name="RowHeight">-1</property>
  <property name="ActiveFilterString" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="FormatConditions" iskey="true" value="1">
    <property name="Item1" isnull="true" iskey="true">
      <property name="ColumnName" />
      <property name="Condition">Expression</property>
    </property>
  </property>
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'