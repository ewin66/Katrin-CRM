DELETE FROM SavedQuery
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default User List'    ,
ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'User')    ,IsDefault = 1    ,
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
  <property name="Columns" iskey="true" value="14">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">106</property>
      <property name="ColumnEditName" />
      <property name="Name">colCreatedOn</property>
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Width">123</property>
      <property name="ColumnEditName" />
      <property name="Name">colEmailAddress</property>
      <property name="FieldName">EmailAddress</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colFirstName</property>
      <property name="FieldName">FirstName</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">122</property>
      <property name="ColumnEditName" />
      <property name="Name">colFullName</property>
      <property name="FieldName">FullName</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colHomePhone</property>
      <property name="FieldName">HomePhone</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colLastName</property>
      <property name="FieldName">LastName</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Width">113</property>
      <property name="ColumnEditName" />
      <property name="Name">colMobilePhone</property>
      <property name="FieldName">MobilePhone</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">105</property>
      <property name="ColumnEditName" />
      <property name="Name">colModifiedOn</property>
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">101</property>
      <property name="ColumnEditName" />
      <property name="Name">colNickName</property>
      <property name="FieldName">NickName</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colTitle</property>
      <property name="FieldName">Title</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">106</property>
      <property name="ColumnEditName" />
      <property name="Name">colUserName</property>
      <property name="FieldName">UserName</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedById</property>
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="ColumnEditName" />
      <property name="Name">colDepartmentId</property>
      <property name="FieldName">DepartmentId</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">Default</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">EntityGridView</property>
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
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'

-------------------------------------------------------------------ProjectWeekReport---------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default ProjectWeekReport List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'ProjectWeekReport')    ,IsDefault = 1  
  ,LayoutXml = '<XtraSerializer version="1.0" application="View">
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
  <property name="Columns" iskey="true" value="12">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">121</property>
      <property name="ColumnEditName" />
      <property name="Name">colName</property>
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Width">84</property>
      <property name="ColumnEditName" />
      <property name="Name">colCurrentProgressCode</property>
      <property name="Caption">CurrentProgressCode</property>
      <property name="FieldName">CurrentProgressCode</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">88</property>
      <property name="ColumnEditName" />
      <property name="Name">colOutlookProgressCode</property>
      <property name="Caption">OutlookProgressCode</property>
      <property name="FieldName">OutlookProgressCode</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Width">86</property>
      <property name="ColumnEditName" />
      <property name="Name">colCurrentQualityCode</property>
      <property name="Caption">CurrentQualityCode</property>
      <property name="FieldName">CurrentQualityCode</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">490</property>
      <property name="ColumnEditName" />
      <property name="Name">colOutlookQualityCode</property>
      <property name="Caption">OutlookQualityCode</property>
      <property name="FieldName">OutlookQualityCode</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedOn</property>
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedById</property>
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedOn</property>
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">139</property>
      <property name="ColumnEditName" />
      <property name="Name">colProjectId</property>
      <property name="FieldName">ProjectId</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">86</property>
      <property name="ColumnEditName" />
      <property name="Name">colProjectIterationId</property>
      <property name="FieldName">ProjectIterationId</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colRecordOn</property>
      <property name="FieldName">RecordOn</property>
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
  </property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
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
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'

    

--------------------------------------------------------------------lEAD----------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml) 
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Lead List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Lead')    ,IsDefault = 1    
,LayoutXml = '<XtraSerializer version="1.0" application="View">
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
  <property name="Columns" iskey="true" value="24">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">132</property>
      <property name="ColumnEditName" />
      <property name="Name">colFullName</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">FullName</property>
      <property name="FieldName">FullName</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">230</property>
      <property name="ColumnEditName" />
      <property name="Name">colSubject</property>
      <property name="Caption">Subject</property>
      <property name="FieldName">Subject</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="ColumnEditName" />
      <property name="Name">colTechnologyCode</property>
      <property name="Caption">TechnologyCode</property>
      <property name="FieldName">TechnologyCode</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="ColumnEditName" />
      <property name="Name">colStatusCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">StatusCode</property>
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCompanyName</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">CompanyName</property>
      <property name="FieldName">CompanyName</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colDescription</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Description</property>
      <property name="FieldName">Description</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="ColumnEditName" />
      <property name="Name">colEmailAddress</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">EmailAddress</property>
      <property name="FieldName">EmailAddress</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colFax</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Fax</property>
      <property name="FieldName">Fax</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colFirstName</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">FirstName</property>
      <property name="FieldName">FirstName</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colLastName</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">LastName</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colLeadSourceCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Source</property>
      <property name="FieldName">LeadSourceCode</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colMobilePhone</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">MobilePhone</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">8</property>
      <property name="Width">101</property>
      <property name="ColumnEditName" />
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colNumberOfEmployees</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">NumberOfEmployees</property>
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="ColumnEditName" />
      <property name="Name">colPriorityCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Priority</property>
      <property name="FieldName">PriorityCode</property>
    </property>
    <property name="Item17" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colRevenue</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">Revenue</property>
    </property>
    <property name="Item18" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colTelephone1</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Office Phone</property>
      <property name="FieldName">Telephone1</property>
    </property>
    <property name="Item19" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colWebSiteUrl</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">WebSiteUrl</property>
    </property>
    <property name="Item20" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCountry</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">CountryCode</property>
      <property name="FieldName">Country</property>
    </property>
    <property name="Item21" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="ColumnEditName" />
      <property name="Name">colOwnerId</property>
      <property name="FieldName">OwnerId</property>
    </property>
    <property name="Item22" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item23" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="ColumnEditName" />
      <property name="Name">colDepartmentId</property>
      <property name="FieldName">DepartmentId</property>
    </property>
    <property name="Item24" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedById</property>
      <property name="FieldName">ModifiedById</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">Default</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">EntityGridView</property>
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
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF1EZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xLCBWZXJzaW9uPTEyLjEuNy4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI4OGQxNzU0ZDcwMGU0OWEFAQAAADhEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvQ29sbGVjdGlvbgQAAAAKZ3JvdXBDb3VudAVjbG9uZQ9jbG9uZUdyb3VwQ291bnQTQ29sbGVjdGlvbkJhc2UrbGlzdAADAAMIsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dCBxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AgAAAAAAAAAJAwAAAAAAAAAJBAAAAAQDAAAAsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAABgAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
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

-----------------------------------------------------PROJECT------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Project List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Project')    ,IsDefault = 1   
 ,LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">gridView1</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="21">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Width">150</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colName</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">95</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colPlannedStartDate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">PlannedStartDate</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Width">95</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Name">colPlannedEndDate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">PlannedEndDate</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">95</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Name">colActualStartDate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ActualStartDate</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Width">95</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Name">colActualEndDate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ActualEndDate</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Width">110</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Name">colActualProgress</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ActualProgress</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Width">91</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colStatusCode</property>
      <property name="ColumnEditName" />
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Width">95</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Name">colEstimatedEndDate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">EstimatedEndDate</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Name">colManagerId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ManagerId</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Width">110</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">8</property>
      <property name="Name">colSaleService</property>
      <property name="ColumnEditName" />
      <property name="FieldName">SaleServiceId</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="Width">150</property>
      <property name="Name">colTechnologyCode</property>
      <property name="ColumnEditName" />
      <property name="FieldName">TechnologyCode</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="Width">100</property>
      <property name="Name">colProjectTypeCode</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ProjectTypeCode</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="Name">colSumQuoteWorkHours</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="Name">colSumActualWorkHours</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="Name">colSumActualInput</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Name">colSumEffort</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
    <property name="Item17" isnull="true" iskey="true">
      <property name="Name">colSumOvertime</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
    <property name="Item18" isnull="true" iskey="true">
      <property name="Name">colSumRemainderTime</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
	<property name="Item19" isnull="true" iskey="true">
      <property name="Width">130</property>
      <property name="Name">colContact</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Contact</property>
    </property>
    <property name="Item20" isnull="true" iskey="true">
      <property name="Name">colEvaluateExactlyRate</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
	<property name="Item21" isnull="true" iskey="true">
      <property name="Name">colInputEffortRate</property>
      <property name="Caption"></property>
      <property name="ColumnEditName" />
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ColumnAutoWidth">false</property>
    <property name="WaitAnimationOptions">Panel</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Contact List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Contact')    ,IsDefault = 1    ,LayoutXml = '<XtraSerializer version="1.0" application="View">    <property name="#LayoutVersion" />    <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>    <property name="BestFitMaxRowCount">-1</property>    <property name="HorzScrollStep">3</property>    <property name="FocusRectStyle">RowFocus</property>    <property name="PreviewLineCount">-1</property>    <property name="NewItemRowText" />    <property name="GroupPanelText" />    <property name="PreviewFieldName" />    <property name="PreviewIndent">-1</property>    <property name="LevelIndent">-1</property>    <property name="GroupFooterShowMode">VisibleIfExpanded</property>    <property name="ActiveFilterEnabled">true</property>    <property name="SynchronizeClones">true</property>    <property name="BorderStyle">Default</property>    <property name="ViewCaption" />    <property name="DetailHeight">350</property>    <property name="Name">EntityGridView</property>    <property name="DetailTabHeaderLocation">Top</property>    <property name="Columns" iskey="true" value="30">      <property name="Item1" isnull="true" iskey="true">        <property name="Name">colAccountRoleCode</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="Caption">Role</property>        <property name="ColumnEditName" />        <property name="FieldName">AccountRoleCode</property>      </property>      <property name="Item2" isnull="true" iskey="true">        <property name="Name">colAnniversary</property>        <property name="ColumnEditName" />        <property name="FieldName">Anniversary</property>      </property>      <property name="Item3" isnull="true" iskey="true">        <property name="Name">colAssistantName</property>        <property name="ColumnEditName" />        <property name="FieldName">AssistantName</property>      </property>      <property name="Item4" isnull="true" iskey="true">        <property name="Name">colAssistantPhone</property>        <property name="ColumnEditName" />        <property name="FieldName">AssistantPhone</property>      </property>      <property name="Item5" isnull="true" iskey="true">        <property name="Name">colBirthDate</property>        <property name="ColumnEditName" />        <property name="FieldName">BirthDate</property>      </property>      <property name="Item6" isnull="true" iskey="true">        <property name="Name">colCreatedOn</property>        <property name="ColumnEditName" />        <property name="FieldName">CreatedOn</property>      </property>      <property name="Item7" isnull="true" iskey="true">        <property name="Name">colDescription</property>        <property name="ColumnEditName" />        <property name="FieldName">Description</property>      </property>      <property name="Item8" isnull="true" iskey="true">        <property name="Width">177</property>        <property name="Visible">true</property>        <property name="VisibleIndex">1</property>        <property name="Name">colEMailAddress1</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="Caption">E-mail</property>        <property name="ColumnEditName" />        <property name="FieldName">EMailAddress1</property>      </property>      <property name="Item9" isnull="true" iskey="true">        <property name="Name">colEducationCode</property>        <property name="Caption">Education</property>        <property name="ColumnEditName" />        <property name="FieldName">EducationCode</property>      </property>      <property name="Item10" isnull="true" iskey="true">        <property name="Name">colEmployeeId</property>        <property name="ColumnEditName" />        <property name="FieldName">EmployeeId</property>      </property>      <property name="Item11" isnull="true" iskey="true">        <property name="Name">colFax</property>        <property name="ColumnEditName" />        <property name="FieldName">Fax</property>      </property>      <property name="Item12" isnull="true" iskey="true">        <property name="Name">colFirstName</property>        <property name="ColumnEditName" />        <property name="FieldName">FirstName</property>      </property>      <property name="Item13" isnull="true" iskey="true">        <property name="Width">109</property>        <property name="Visible">true</property>        <property name="VisibleIndex">0</property>        <property name="Name">colFullName</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="ColumnEditName" />        <property name="FieldName">FullName</property>      </property>      <property name="Item14" isnull="true" iskey="true">        <property name="Name">colGenderCode</property>        <property name="Caption">Gender</property>        <property name="ColumnEditName" />        <property name="FieldName">GenderCode</property>      </property>      <property name="Item15" isnull="true" iskey="true">        <property name="Name">colJobTitle</property>        <property name="ColumnEditName" />        <property name="FieldName">JobTitle</property>      </property>      <property name="Item16" isnull="true" iskey="true">        <property name="Name">colLastName</property>        <property name="Caption">LastName</property>        <property name="ColumnEditName" />        <property name="FieldName">LastName</property>      </property>      <property name="Item17" isnull="true" iskey="true">        <property name="Name">colManagerName</property>        <property name="ColumnEditName" />        <property name="FieldName">ManagerName</property>      </property>      <property name="Item18" isnull="true" iskey="true">        <property name="Name">colManangerPhone</property>        <property name="ColumnEditName" />        <property name="FieldName">ManangerPhone</property>      </property>      <property name="Item19" isnull="true" iskey="true">        <property name="Name">colMiddleName</property>        <property name="ColumnEditName" />        <property name="FieldName">MiddleName</property>      </property>      <property name="Item20" isnull="true" iskey="true">        <property name="Name">colMobilePhone</property>        <property name="ColumnEditName" />        <property name="FieldName">MobilePhone</property>      </property>      <property name="Item21" isnull="true" iskey="true">        <property name="Width">119</property>        <property name="Visible">true</property>        <property name="VisibleIndex">3</property>        <property name="Name">colModifiedOn</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="ColumnEditName" />        <property name="FieldName">ModifiedOn</property>      </property>      <property name="Item22" isnull="true" iskey="true">        <property name="Name">colNickName</property>        <property name="ColumnEditName" />        <property name="FieldName">NickName</property>      </property>      <property name="Item23" isnull="true" iskey="true">        <property name="Name">colNumberOfChildren</property>        <property name="ColumnEditName" />        <property name="FieldName">NumberOfChildren</property>      </property>      <property name="Item24" isnull="true" iskey="true">        <property name="Name">colSpousesName</property>        <property name="ColumnEditName" />        <property name="FieldName">SpousesName</property>      </property>      <property name="Item25" isnull="true" iskey="true">        <property name="Name">colStatusCode</property>        <property name="Caption">StatusCode</property>        <property name="ColumnEditName" />        <property name="FieldName">StatusCode</property>      </property>      <property name="Item26" isnull="true" iskey="true">        <property name="Width">118</property>        <property name="Visible">true</property>        <property name="VisibleIndex">2</property>        <property name="Name">colTelephone1</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="Caption">Business Phone</property>        <property name="ColumnEditName" />        <property name="FieldName">Telephone1</property>      </property>      <property name="Item27" isnull="true" iskey="true">        <property name="Name">colTelephone2</property>        <property name="Caption">Home Phone</property>        <property name="ColumnEditName" />        <property name="FieldName">Telephone2</property>      </property>      <property name="Item28" isnull="true" iskey="true">        <property name="Name">colCreatedById</property>        <property name="ColumnEditName" />        <property name="FieldName">CreatedById</property>      </property>      <property name="Item29" isnull="true" iskey="true">        <property name="Name">colDepartment</property>        <property name="ColumnEditName" />        <property name="FieldName">Department</property>      </property>      <property name="Item30" isnull="true" iskey="true">        <property name="Name">colModifiedById</property>        <property name="ColumnEditName" />        <property name="FieldName">ModifiedById</property>      </property>    </property>    <property name="ShowButtonMode">ShowForFocusedCell</property>    <property name="ViewCaptionHeight">-1</property>    <property name="VertScrollTipFieldName" />    <property name="OptionsView" isnull="true" iskey="true">      <property name="ShowGroupPanel">false</property>      <property name="ShowFilterPanelMode">Never</property>      <property name="ShowIndicator">false</property>      <property name="ColumnAutoWidth">false</property>      <property name="WaitAnimationOptions">Panel</property>    </property>    <property name="OptionsSelection" isnull="true" iskey="true">      <property name="EnableAppearanceFocusedCell">false</property>    </property>    <property name="RowSeparatorHeight">0</property>    <property name="FixedLineWidth">2</property>    <property name="IndicatorWidth">-1</property>    <property name="ColumnPanelRowHeight">-1</property>    <property name="GroupRowHeight">-1</property>    <property name="RowHeight">-1</property>    <property name="OptionsBehavior" isnull="true" iskey="true">      <property name="Editable">false</property>      <property name="AllowIncrementalSearch">true</property>    </property>    <property name="GroupFormat">{0}: [#image]{1} {2}</property>    <property name="FooterPanelHeight">-1</property>    <property name="OptionsDetail" isnull="true" iskey="true">      <property name="EnableMasterViewMode">false</property>    </property>    <property name="ChildGridLevelName" />    <property name="VertScrollVisibility">Auto</property>    <property name="HorzScrollVisibility">Auto</property>    <property name="FormatConditions" iskey="true" value="0" />    <property name="GroupSummary" iskey="true" value="0" />    <property name="ActiveFilterString" />    <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>    <property name="GroupSummarySortInfoState" />  </XtraSerializer>'

---------------------------------------------------------------------------------------------------------------QUOTE--------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Quote List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Quote')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">EntityGridView</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="19">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Name">colCreatedOn</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Name">colDescription</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Description</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Name">colExchangeRate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ExchangeRate</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">86</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Name">colExpiresOn</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ExpiresOn</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Width">88</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Name">colModifiedOn</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Width">217</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colName</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Name</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Name">colPaymentTermsCode</property>
      <property name="ColumnEditName" />
      <property name="FieldName">PaymentTermsCode</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Name">colQuoteId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">QuoteId</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Width">56</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colQuoteNumber</property>
      <property name="ColumnEditName" />
      <property name="FieldName">QuoteNumber</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colStageCode</property>
      <property name="Caption">Stage</property>
      <property name="ColumnEditName" />
      <property name="FieldName">StageCode</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
	<property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Name">colTotalAmount1</property>
      <property name="ColumnEditName" />
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">n2</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="FieldName">TotalAmount</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="Name">colTotalLineItemAmount</property>
      <property name="ColumnEditName" />
      <property name="FieldName">TotalLineItemAmount</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="Name">colTotalDiscountAmount</property>
      <property name="ColumnEditName" />
      <property name="FieldName">TotalDiscountAmount</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="Name">colTotalTax</property>
      <property name="ColumnEditName" />
      <property name="FieldName">TotalTax</property>
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="Name">colBillTo_ContactName</property>
      <property name="ColumnEditName" />
      <property name="FieldName">BillTo_ContactName</property>
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Name">colCreatedById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item17" isnull="true" iskey="true">
      <property name="Name">colModifiedById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item18" isnull="true" iskey="true">
      <property name="Name">colOpportunityId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OpportunityId</property>
    </property>
    <property name="Item19" isnull="true" iskey="true">
	<property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Name">colOwnerId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OwnerId</property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFooter">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ColumnAutoWidth">false</property>
    <property name="WaitAnimationOptions">Panel</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="AutoPopulateColumns">false</property>
    <property name="Editable">false</property>
    <property name="CacheValuesOnRowUpdating">Disabled</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'

------------------------------------------------------------------------------------CONTRACT----------------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Contract List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Contract')    ,IsDefault = 1    
,LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="NewItemRowText" />
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="LevelIndent">-1</property>
  <property name="PreviewIndent">-1</property>
  <property name="PreviewLineCount">-1</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="HorzScrollStep">3</property>
  <property name="GroupPanelText" />
  <property name="ActiveFilterEnabled">true</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="Columns" iskey="true" value="16">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Name">colContractNumber</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">ContractNumber</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">129</property>
      <property name="Name">colDescription</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">Description</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Width">82</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Name">colExpiresOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">ExpiresOn</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">57</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colStatusCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="Caption">Status</property>
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Width">243</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colTitle</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Title</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:N2}</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="Width">70</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Name">colTotalPrice</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">TotalPrice</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Width">82</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Name">colActiveOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">ActiveOn</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Width">88</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">8</property>
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Name">colCreatedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colBillingCustomerId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">BillingCustomerId</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Name">colDepartmentId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">DepartmentId</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="Name">colModifiedById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="Name">colOpportunityId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OpportunityId</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Name">colOwnerId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OwnerId</property>
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="Name">colCreatedById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Name">colCustomerSatisfactionCode</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CustomerSatisfactionCode</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">Default</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">EntityGridView</property>
  <property name="DetailHeight">350</property>
  <property name="PreviewFieldName" />
  <property name="ChildGridLevelName" />
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ShowGroupPanel">false</property>
    <property name="WaitAnimationOptions">Panel</property>
    <property name="ColumnAutoWidth">false</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
  </property>
  <property name="FooterPanelHeight">-1</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="VertScrollVisibility">Auto</property>
  <property name="RowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="VertScrollTipFieldName" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'

-------------------------------------------------------------------------------------PRODUCT-----------------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Product List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Product')    ,IsDefault = 1    ,LayoutXml = '<XtraSerializer version="1.0" application="View">    <property name="#LayoutVersion" />    <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>    <property name="BestFitMaxRowCount">-1</property>    <property name="HorzScrollStep">3</property>    <property name="FocusRectStyle">RowFocus</property>    <property name="PreviewLineCount">-1</property>    <property name="NewItemRowText" />    <property name="GroupPanelText" />    <property name="PreviewFieldName" />    <property name="PreviewIndent">-1</property>    <property name="LevelIndent">-1</property>    <property name="GroupFooterShowMode">VisibleIfExpanded</property>    <property name="ActiveFilterEnabled">true</property>    <property name="SynchronizeClones">true</property>    <property name="BorderStyle">Default</property>    <property name="ViewCaption" />    <property name="DetailHeight">350</property>    <property name="Name">EntityGridView</property>    <property name="DetailTabHeaderLocation">Top</property>    <property name="Columns" iskey="true" value="6">      <property name="Item1" isnull="true" iskey="true">        <property name="Width">199</property>        <property name="Visible">true</property>        <property name="VisibleIndex">0</property>        <property name="Name">colName</property>        <property name="ColumnEditName" />        <property name="FieldName">Name</property>      </property>      <property name="Item2" isnull="true" iskey="true">        <property name="Width">92</property>        <property name="Visible">true</property>        <property name="VisibleIndex">1</property>        <property name="DisplayFormat" isnull="true" iskey="true">          <property name="FormatString">{0:N2}</property>          <property name="FormatType">Numeric</property>        </property>        <property name="Name">colPrice</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="ColumnEditName" />        <property name="FieldName">Price</property>      </property>      <property name="Item3" isnull="true" iskey="true">        <property name="Width">104</property>        <property name="Visible">true</property>        <property name="VisibleIndex">2</property>        <property name="Name">colStatusCode</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="Caption">Status</property>        <property name="ColumnEditName" />        <property name="FieldName">StatusCode</property>      </property>      <property name="Item4" isnull="true" iskey="true">        <property name="Name">colProductType</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="Caption">ProductTypeCode</property>        <property name="ColumnEditName" />        <property name="FieldName">ProductTypeCode</property>      </property>      <property name="Item5" isnull="true" iskey="true">        <property name="Name">colCreatedOn</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="ColumnEditName" />        <property name="FieldName">CreatedOn</property>      </property>      <property name="Item6" isnull="true" iskey="true">        <property name="Width">119</property>        <property name="Visible">true</property>        <property name="VisibleIndex">3</property>        <property name="Name">colModifiedOn</property>        <property name="OptionsColumn" isnull="true" iskey="true">          <property name="FixedWidth">true</property>        </property>        <property name="ColumnEditName" />        <property name="FieldName">ModifiedOn</property>      </property>    </property>    <property name="ShowButtonMode">ShowForFocusedCell</property>    <property name="ViewCaptionHeight">-1</property>    <property name="VertScrollTipFieldName" />    <property name="OptionsView" isnull="true" iskey="true">      <property name="ShowGroupPanel">false</property>      <property name="ShowFilterPanelMode">Never</property>      <property name="ShowIndicator">false</property>      <property name="ColumnAutoWidth">false</property>      <property name="WaitAnimationOptions">Panel</property>    </property>    <property name="OptionsSelection" isnull="true" iskey="true">      <property name="EnableAppearanceFocusedCell">false</property>    </property>    <property name="RowSeparatorHeight">0</property>    <property name="FixedLineWidth">2</property>    <property name="IndicatorWidth">-1</property>    <property name="ColumnPanelRowHeight">-1</property>    <property name="GroupRowHeight">-1</property>    <property name="RowHeight">-1</property>    <property name="OptionsBehavior" isnull="true" iskey="true">      <property name="Editable">false</property>    </property>    <property name="GroupFormat">{0}: [#image]{1} {2}</property>    <property name="FooterPanelHeight">-1</property>    <property name="OptionsDetail" isnull="true" iskey="true">      <property name="EnableMasterViewMode">false</property>    </property>    <property name="ChildGridLevelName" />    <property name="VertScrollVisibility">Auto</property>    <property name="HorzScrollVisibility">Auto</property>    <property name="FormatConditions" iskey="true" value="0" />    <property name="GroupSummary" iskey="true" value="0" />    <property name="ActiveFilterString" />    <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>    <property name="GroupSummarySortInfoState" />  </XtraSerializer>'
    

------------------------------------------------------------------------------------------ACCOUNT----------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml) 
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Account List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Account')    ,IsDefault = 1    ,LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">EntityGridView</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="28">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Width">207</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colName</property>
      <property name="Caption">Account Name</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">103</property>
      <property name="Name">colEMailAddress1</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">E-mail</property>
      <property name="ColumnEditName" />
      <property name="FieldName">EMailAddress1</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Width">57</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colStatusCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Status</property>
      <property name="ColumnEditName" />
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Name">colAccountCategoryCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Category</property>
      <property name="ColumnEditName" />
      <property name="FieldName">AccountCategoryCode</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Name">colAccountClassificationCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Classification</property>
      <property name="ColumnEditName" />
      <property name="FieldName">AccountClassificationCode</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Name">colAccountNumber</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">AccountNumber</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Name">colAccountRatingCode</property>
	   <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Rating</property>
      <property name="ColumnEditName" />
      <property name="FieldName">AccountRatingCode</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Name">colBusinessTypeCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Business Type</property>
      <property name="ColumnEditName" />
      <property name="FieldName">BusinessTypeCode</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Name">colCreatedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Name">colCustomerSizeCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Customer Size</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CustomerSizeCode</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="Name">colCustomerTypeCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Customer Type</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CustomerTypeCode</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="Name">colDescription</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">Description</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="Name">colIndustryCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Industry</property>
      <property name="ColumnEditName" />
      <property name="FieldName">IndustryCode</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="Width">92</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="Name">colNumberOfEmployees</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">NumberOfEmployees</property>
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Name">colOwnershipCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Ownership</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OwnershipCode</property>
    </property>
    <property name="Item17" isnull="true" iskey="true">
      <property name="Name">colRevenue</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">Revenue</property>
    </property>
    <property name="Item18" isnull="true" iskey="true">
      <property name="Name">colSIC</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">SIC</property>
    </property>
    <property name="Item19" isnull="true" iskey="true">
      <property name="Name">colTelephone1</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">Telephone1</property>
    </property>
    <property name="Item20" isnull="true" iskey="true">
      <property name="Name">colTelephone2</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">Telephone2</property>
    </property>
    <property name="Item21" isnull="true" iskey="true">
      <property name="Name">colTickerSymbol</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">TickerSymbol</property>
    </property>
    <property name="Item22" isnull="true" iskey="true">
      <property name="Width">143</property>
      <property name="Name">colWebSiteURL</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">WebSiteURL</property>
    </property>
    <property name="Item23" isnull="true" iskey="true">
		<property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Name">colOwnerId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OwnerId</property>
    </property>
    <property name="Item24" isnull="true" iskey="true">
      <property name="Name">colPrimaryContactId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">PrimaryContactId</property>
    </property>
    <property name="Item25" isnull="true" iskey="true">
      <property name="Name">colCreatedById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item26" isnull="true" iskey="true">
      <property name="Name">colModifiedById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item27" isnull="true" iskey="true">
	 <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Name">colCountry</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Country</property>
    </property>
	<property name="Item28" isnull="true" iskey="true">
	 <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colDepartment</property>
      <property name="ColumnEditName" />
      <property name="FieldName">DepartmentId</property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ColumnAutoWidth">false</property>
    <property name="WaitAnimationOptions">Panel</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AllowIncrementalSearch">true</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'

------------------------------------------------ROLE LIST LAYOUT
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Role List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity 
WHERE Name = 'Role')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">EntityGridView</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="2">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Width">152</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colRoleName</property>
      <property name="ColumnEditName" />
      <property name="FieldName">RoleName</property>
	  <property name="OptionsColumn" isnull="true" iskey="true">
		<property name="AllowEdit">false</property>
	  </property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">646</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colDescription</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Description</property>
	   <property name="OptionsColumn" isnull="true" iskey="true">
		<property name="AllowEdit">false</property>
	  </property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ColumnAutoWidth">false</property>
    <property name="WaitAnimationOptions">Panel</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Always</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAQAAAAYJAAAAC2NvbFJvbGVOYW1lCw==</property>
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'

INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Audit List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity 
WHERE Name = 'Audit')    ,IsDefault = 1    ,LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">AuditGridView</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="6">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Name">colAction</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Action</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">162</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colFieldName</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">FieldName</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Width">219</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Name">colNewValue</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">NewValue</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">284</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colOriginalValue</property>
      <property name="ColumnEditName" />
      <property name="FieldName">OriginalValue</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Width">142</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Name">colUserId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">UserId</property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ColumnAutoWidth">false</property>
    <property name="WaitAnimationOptions">Panel</property>
    <property name="RowAutoHeight">true</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="ReadOnly">true</property>
    <property name="Editable">false</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAAwAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Note List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Note')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ViewCaptionHeight">-1</property>
  <property name="DetailHeight">350</property>
  <property name="DetailAutoHeight">true</property>
  <property name="CardVertInterval">2</property>
  <property name="Name">layoutView1</property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="MultiSelect">false</property>
  </property>
  <property name="SynchronizeClones">true</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="OptionsItemText" isnull="true" iskey="true">
    <property name="TextToControlDistance">5</property>
    <property name="AlignMode">AlignGlobal</property>
  </property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
  </property>
  <property name="OptionsSingleRecordMode" isnull="true" iskey="true">
    <property name="CardAlignment">Center</property>
    <property name="StretchCardToViewHeight">false</property>
    <property name="StretchCardToViewWidth">false</property>
  </property>
  <property name="OptionsMultiRecordMode" isnull="true" iskey="true">
    <property name="StretchCardToViewHeight">false</property>
    <property name="MaxCardRows">0</property>
    <property name="MaxCardColumns">0</property>
    <property name="MultiColumnScrollBarOrientation">Default</property>
    <property name="MultiRowScrollBarOrientation">Default</property>
    <property name="StretchCardToViewWidth">true</property>
  </property>
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ViewMode">Column</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="CardArrangeRule">AllowPartialCards</property>
    <property name="ShowHeaderPanel">false</property>
    <property name="ShowCardCaption">false</property>
  </property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="CardMinSize">@3,Width=418@2,Height=60</property>
  <property name="Columns" iskey="true" value="6">
    <property name="Item1" isnull="true" iskey="true">
      <property name="ColumnEditName">SubjectItemTextEdit</property>
      <property name="FieldName">Subject</property>
      <property name="AppearanceCell" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt, style=Bold</property>
        <property name="Options" isnull="true" iskey="true">
          <property name="UseFont">true</property>
        </property>
      </property>
      <property name="ImageAlignment">Near</property>
      <property name="Visible">true</property>
      <property name="Name">colSubject</property>
      <property name="VisibleIndex">-1</property>
      <property name="ToolTip" />
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="ColumnEditName">NoteTextItemMemoEdit</property>
      <property name="FieldName">NoteText</property>
      <property name="ImageAlignment">Near</property>
      <property name="Visible">true</property>
      <property name="Name">colNoteText</property>
      <property name="VisibleIndex">-1</property>
      <property name="Caption">NoteTextItemMemoEdit</property>
      <property name="ToolTip" />
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedById</property>
      <property name="ImageAlignment">Near</property>
      <property name="Visible">true</property>
      <property name="Name">colCreatedBy</property>
      <property name="VisibleIndex">-1</property>
      <property name="ToolTip" />
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="FieldName">CreatedOn</property>
      <property name="AppearanceCell" isnull="true" iskey="true">
        <property name="Options" isnull="true" iskey="true">
          <property name="UseForeColor">true</property>
        </property>
        <property name="ForeColor">Gray</property>
      </property>
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">g</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="ImageAlignment">Near</property>
      <property name="Visible">true</property>
      <property name="Name">colCreatedOn</property>
      <property name="VisibleIndex">-1</property>
      <property name="ToolTip" />
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedById</property>
      <property name="ImageAlignment">Near</property>
      <property name="Visible">true</property>
      <property name="Name">colModifiedBy</property>
      <property name="VisibleIndex">-1</property>
      <property name="ToolTip" />
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="FieldName">ModifiedOn</property>
      <property name="ImageAlignment">Near</property>
      <property name="Visible">true</property>
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="AllowEdit">false</property>
      </property>
      <property name="VisibleIndex">-1</property>
      <property name="ToolTip" />
    </property>
  </property>
  <property name="CardCaptionFormat" />
  <property name="OptionsHeaderPanel" isnull="true" iskey="true">
    <property name="ShowCarouselModeButton">true</property>
    <property name="EnableCarouselModeButton">true</property>
    <property name="ShowMultiColumnModeButton">true</property>
    <property name="EnableMultiColumnModeButton">true</property>
    <property name="ShowCustomizeButton">true</property>
    <property name="EnableCustomizeButton">true</property>
    <property name="ShowPanButton">true</property>
    <property name="EnablePanButton">true</property>
    <property name="ShowRowModeButton">true</property>
    <property name="EnableRowModeButton">true</property>
    <property name="ShowSingleModeButton">true</property>
    <property name="EnableSingleModeButton">true</property>
    <property name="ShowMultiRowModeButton">true</property>
    <property name="EnableMultiRowModeButton">true</property>
    <property name="ShowColumnModeButton">true</property>
    <property name="EnableColumnModeButton">true</property>
  </property>
  <property name="FieldCaptionFormat" />
  <property name="OptionsCustomization" isnull="true" iskey="true">
    <property name="ShowGroupView">true</property>
    <property name="ShowSaveLoadLayoutButtons">true</property>
    <property name="ShowGroupCardCaptions">true</property>
    <property name="ShowGroupFields">true</property>
    <property name="ShowGroupCards">true</property>
    <property name="ShowGroupLayout">true</property>
    <property name="ShowGroupCardIndents">true</property>
    <property name="UseAdvancedRuntimeCustomization">false</property>
    <property name="AllowFilter">false</property>
    <property name="AllowSort">false</property>
    <property name="ShowResetShrinkButtons">true</property>
    <property name="ShowGroupHiddenItems">true</property>
    <property name="ShowGroupLayoutTreeView">true</property>
  </property>
  <property name="OptionsCarouselMode" isnull="true" iskey="true">
    <property name="PitchAngle">1.57079637</property>
    <property name="Radius">0</property>
    <property name="RollAngle">3.14159274</property>
    <property name="BottomCardAlphaLevel">0</property>
    <property name="BottomCardFading">0</property>
    <property name="BottomCardScale">0.2</property>
    <property name="CardCount">15</property>
    <property name="InterpolationMode">Default</property>
    <property name="StretchCardToViewHeight">false</property>
    <property name="StretchCardToViewWidth">false</property>
    <property name="FrameDelay">10000</property>
    <property name="FrameCount">250</property>
    <property name="CenterOffset">@1,X=0@1,Y=0</property>
  </property>
  <property name="CardHorzInterval">2</property>
  <property name="ActiveFilterString" />
  <property name="Items" iskey="true" value="7">
    <property name="Item1" isnull="true" iskey="true">
      <property name="ExpandButtonLocation">AfterText</property>
      <property name="OptionsItemText" isnull="true" iskey="true">
        <property name="TextAlignMode">UseParentOptions</property>
        <property name="TextToControlDistance">5</property>
      </property>
      <property name="GroupBordersVisible">false</property>
      <property name="ParentName" />
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="Name">layoutViewTemplateCard</property>
      <property name="AppearanceTabPage" isnull="true" iskey="true">
        <property name="HeaderHotTracked" isnull="true" iskey="true">
          <property name="Font">Tahoma, 9pt</property>
          <property name="BackColor2" />
          <property name="BackColor" />
          <property name="ForeColor" />
          <property name="BorderColor" />
          <property name="GradientMode">Horizontal</property>
        </property>
        <property name="PageClient" isnull="true" iskey="true">
          <property name="Font">Tahoma, 9pt</property>
          <property name="BackColor2" />
          <property name="BackColor" />
          <property name="ForeColor" />
          <property name="BorderColor" />
          <property name="GradientMode">Horizontal</property>
        </property>
        <property name="HeaderDisabled" isnull="true" iskey="true">
          <property name="Font">Tahoma, 9pt</property>
          <property name="BackColor2" />
          <property name="BackColor" />
          <property name="ForeColor" />
          <property name="BorderColor" />
          <property name="GradientMode">Horizontal</property>
        </property>
        <property name="Header" isnull="true" iskey="true">
          <property name="Font">Tahoma, 9pt</property>
          <property name="BackColor2" />
          <property name="BackColor" />
          <property name="ForeColor" />
          <property name="BorderColor" />
          <property name="GradientMode">Horizontal</property>
        </property>
        <property name="HeaderActive" isnull="true" iskey="true">
          <property name="Font">Tahoma, 9pt</property>
          <property name="BackColor2" />
          <property name="BackColor" />
          <property name="ForeColor" />
          <property name="BorderColor" />
          <property name="GradientMode">Horizontal</property>
        </property>
      </property>
      <property name="Size">@3,Width=418@2,Height=62</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="Location">@1,X=0@1,Y=0</property>
      <property name="TypeName">LayoutViewCard</property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="AppearanceGroup" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="Text">TemplateCard</property>
      <property name="CustomizationFormText">TemplateCard</property>
      <property name="TabbedGroupParentName" />
      <property name="ExpandButtonVisible">false</property>
      <property name="TextToControlDistance">0</property>
      <property name="ExpandOnDoubleClick">false</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Location">@2,X=80@1,Y=0</property>
      <property name="Name">layoutViewField_colSubject</property>
      <property name="TextSize">@1,Width=0@1,Height=0</property>
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="ParentName">layoutViewTemplateCard</property>
      <property name="TextVisible">false</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="TextToControlDistance">0</property>
      <property name="TypeName">LayoutViewField</property>
      <property name="EditorPreferredWidth">194</property>
      <property name="CustomizationFormText">Subject</property>
      <property name="ColumnName">colSubject</property>
      <property name="Text">Subject:</property>
      <property name="ShowInCustomizationForm">true</property>
      <property name="ControlName" isnull="true" />
      <property name="Size">@3,Width=198@2,Height=20</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Location">@2,X=80@2,Y=20</property>
      <property name="SizeConstraintsType">SupportHorzAlignment</property>
      <property name="Name">layoutViewField_colNoteText</property>
      <property name="TextSize">@1,Width=0@1,Height=0</property>
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="ParentName">layoutViewTemplateCard</property>
      <property name="TextVisible">false</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="TextToControlDistance">0</property>
      <property name="TypeName">LayoutViewField</property>
      <property name="EditorPreferredWidth">314</property>
      <property name="CustomizationFormText">Note Text</property>
      <property name="ColumnName">colNoteText</property>
      <property name="Text">Note Text:</property>
      <property name="ShowInCustomizationForm">true</property>
      <property name="ControlName" isnull="true" />
      <property name="Size">@3,Width=318@2,Height=22</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="MaxSize">@2,Width=80@2,Height=20</property>
      <property name="MinSize">@2,Width=80@2,Height=20</property>
      <property name="Location">@1,X=0@1,Y=0</property>
      <property name="TextAlignMode">CustomSize</property>
      <property name="SizeConstraintsType">Custom</property>
      <property name="Name">layoutViewField_colCreatedBy</property>
      <property name="TextSize">@1,Width=0@1,Height=0</property>
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="ParentName">layoutViewTemplateCard</property>
      <property name="TextVisible">false</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="TextToControlDistance">0</property>
      <property name="TypeName">LayoutViewField</property>
      <property name="EditorPreferredWidth">76</property>
      <property name="CustomizationFormText">Created By Name</property>
      <property name="ColumnName">colCreatedBy</property>
      <property name="Text">Created By Name:</property>
      <property name="ShowInCustomizationForm">true</property>
      <property name="ControlName" isnull="true" />
      <property name="Size">@2,Width=80@2,Height=42</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="MaxSize">@3,Width=120@2,Height=20</property>
      <property name="MinSize">@3,Width=120@2,Height=20</property>
      <property name="Location">@3,X=278@1,Y=0</property>
      <property name="TextAlignMode">CustomSize</property>
      <property name="SizeConstraintsType">Custom</property>
      <property name="Name">layoutViewField_colCreatedOn</property>
      <property name="TextSize">@1,Width=0@1,Height=0</property>
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="ParentName">layoutViewTemplateCard</property>
      <property name="TextVisible">false</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="TextToControlDistance">0</property>
      <property name="TypeName">LayoutViewField</property>
      <property name="EditorPreferredWidth">116</property>
      <property name="CustomizationFormText">Created On</property>
      <property name="ColumnName">colCreatedOn</property>
      <property name="Text">Created On:</property>
      <property name="ShowInCustomizationForm">true</property>
      <property name="ControlName" isnull="true" />
      <property name="Size">@3,Width=120@2,Height=20</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="MaxSize">@1,Width=0@2,Height=20</property>
      <property name="MinSize">@2,Width=24@2,Height=20</property>
      <property name="Location">@1,X=0@1,Y=0</property>
      <property name="SizeConstraintsType">Custom</property>
      <property name="Name">layoutViewField_colModifiedOn</property>
      <property name="TextSize">@1,Width=0@1,Height=0</property>
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="ParentName">Customization</property>
      <property name="TextVisible">false</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="TextToControlDistance">0</property>
      <property name="TypeName">LayoutViewField</property>
      <property name="EditorPreferredWidth">20</property>
      <property name="CustomizationFormText">Modified On</property>
      <property name="ColumnName">colModifiedOn</property>
      <property name="Text">Modified On:</property>
      <property name="ShowInCustomizationForm">true</property>
      <property name="ControlName" isnull="true" />
      <property name="Size">@3,Width=398@2,Height=42</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Location">@1,X=0@1,Y=0</property>
      <property name="Name">layoutViewField_colModifiedBy</property>
      <property name="TextSize">@3,Width=101@2,Height=14</property>
      <property name="AppearanceItemCaption" isnull="true" iskey="true">
        <property name="Font">Tahoma, 9pt</property>
        <property name="BackColor2" />
        <property name="BackColor" />
        <property name="ForeColor" />
        <property name="BorderColor" />
        <property name="GradientMode">Horizontal</property>
      </property>
      <property name="ParentName">Customization</property>
      <property name="OptionsToolTip" isnull="true" iskey="true">
        <property name="IconToolTipTitle" />
        <property name="IconToolTipIconType">None</property>
        <property name="EnableIconToolTip">true</property>
        <property name="IconToolTip" />
        <property name="ToolTip" />
        <property name="ToolTipTitle" />
        <property name="ToolTipIconType">None</property>
      </property>
      <property name="OptionsCustomization" isnull="true" iskey="true">
        <property name="AllowDrop">Default</property>
        <property name="AllowDrag">Default</property>
      </property>
      <property name="TextToControlDistance">5</property>
      <property name="TypeName">LayoutViewField</property>
      <property name="EditorPreferredWidth">20</property>
      <property name="CustomizationFormText">Modified By Name</property>
      <property name="ColumnName">colModifiedBy</property>
      <property name="Text">Modified By Name:</property>
      <property name="ShowInCustomizationForm">true</property>
      <property name="ControlName" isnull="true" />
      <property name="Size">@3,Width=398@2,Height=42</property>
    </property>
  </property>
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAAAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAABAAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="FormatConditions" iskey="true" value="0" />
</XtraSerializer>'

-------------------------------------------------------------------------------------PROJECT TASK------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default ProjectTask List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity 
WHERE Name = 'ProjectTask')    ,
IsDefault = 1    ,
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
  <property name="Columns" iskey="true" value="21">
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
      <property name="VisibleIndex">3</property>
      <property name="Width">62</property>
      <property name="ColumnEditName" />
      <property name="Name">colStatusCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">StatusCode</property>
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colDescription</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Description</property>
      <property name="FieldName">Description</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">12</property>
      <property name="Width">77</property>
      <property name="ColumnEditName" />
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
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
    <property name="Item6" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">58</property>
      <property name="ColumnEditName" />
      <property name="Name">colQuoteWorkHours</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">QuoteWorkHours</property>
      <property name="Summary" iskey="true" value="1">
        <property name="Item1" isnull="true" iskey="true">
          <property name="FieldName">QuoteWorkHours</property>
          <property name="Tag" isnull="true" />
          <property name="DisplayFormat">{0:0.00}</property>
          <property name="SummaryType">Sum</property>
        </property>
      </property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">52</property>
      <property name="ColumnEditName" />
      <property name="Name">colActualWorkHours</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ActualWorkHours</property>
      <property name="Summary" iskey="true" value="1">
        <property name="Item1" isnull="true" iskey="true">
          <property name="FieldName">ActualWorkHours</property>
          <property name="Tag" isnull="true" />
          <property name="DisplayFormat">{0:0.00}</property>
          <property name="SummaryType">Sum</property>
        </property>
      </property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Width">56</property>
      <property name="ColumnEditName" />
      <property name="Name">colActualInput</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ActualInput</property>
      <property name="Summary" iskey="true" value="1">
        <property name="Item1" isnull="true" iskey="true">
          <property name="FieldName">ActualInput</property>
          <property name="Tag" isnull="true" />
          <property name="DisplayFormat">{0:0.00}</property>
          <property name="SummaryType">Sum</property>
        </property>
      </property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">8</property>
      <property name="Width">53</property>
      <property name="ColumnEditName" />
      <property name="Name">colEffort</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">Effort</property>
      <property name="Summary" iskey="true" value="1">
        <property name="Item1" isnull="true" iskey="true">
          <property name="FieldName">Effort</property>
          <property name="Tag" isnull="true" />
          <property name="DisplayFormat">{0:0.00}</property>
          <property name="SummaryType">Sum</property>
        </property>
      </property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colOvertime</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">Overtime</property>
      <property name="Summary" iskey="true" value="1">
        <property name="Item1" isnull="true" iskey="true">
          <property name="FieldName">Overtime</property>
          <property name="Tag" isnull="true" />
          <property name="DisplayFormat">{0:0.00}</property>
          <property name="SummaryType">Sum</property>
        </property>
      </property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">9</property>
      <property name="Width">67</property>
      <property name="ColumnEditName" />
      <property name="Name">colStartDate</property>
      <property name="Caption">StartDate</property>
      <property name="FieldName">StartDate</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">10</property>
      <property name="Width">67</property>
      <property name="ColumnEditName" />
      <property name="Name">colEndDate</property>
      <property name="Caption">EndDate</property>
      <property name="FieldName">EndDate</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedById</property>
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">11</property>
      <property name="Width">71</property>
      <property name="ColumnEditName" />
      <property name="Name">colOwnerId</property>
      <property name="FieldName">OwnerId</property>
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">134</property>
      <property name="ColumnEditName" />
      <property name="Name">colProjectId</property>
      <property name="FieldName">ProjectId</property>
    </property>
    <property name="Item17" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">63</property>
      <property name="ColumnEditName" />
      <property name="Name">colProjectIterationId</property>
      <property name="FieldName">ProjectIterationId</property>
    </property>
    <property name="Item18" isnull="true" iskey="true">
      <property name="UnboundExpression">[QuoteWorkHours]/[ActualWorkHours]</property>
      <property name="UnboundType">Decimal</property>
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:0%}</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="ColumnEditName" />
      <property name="Name">colEvaluateExactlyRate</property>
      <property name="Caption">EvaluateExactlyRate</property>
      <property name="FieldName">colEvaluateExactlyRate</property>
    </property>
    <property name="Item19" isnull="true" iskey="true">
      <property name="UnboundExpression">[Effort]/[ActualInput]</property>
      <property name="UnboundType">Decimal</property>
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:0%}</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="ColumnEditName" />
      <property name="Name">colInputEffortRate</property>
      <property name="Caption">InputEffortRate</property>
      <property name="FieldName">colInputEffortRate</property>
    </property>
    <property name="Item20" isnull="true" iskey="true">
      <property name="UnboundExpression">[ActualWorkHours]-[Effort]</property>
      <property name="UnboundType">Decimal</property>
      <property name="ColumnEditName" />
      <property name="Name">colRemainderTime</property>
      <property name="Caption">RemainderTime</property>
      <property name="FieldName">colRemainderTime</property>
      <property name="Summary" iskey="true" value="1">
        <property name="Item1" isnull="true" iskey="true">
          <property name="FieldName">colRemainderTime</property>
          <property name="Tag" isnull="true" />
          <property name="DisplayFormat">{0:0.00}</property>
          <property name="SummaryType">Sum</property>
        </property>
      </property>
    </property>
    <property name="Item21" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Width">57</property>
      <property name="ColumnEditName" />
      <property name="Name">Priority</property>
      <property name="Caption">Priority</property>
      <property name="FieldName">PriorityCode</property>
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
    <property name="ShowFooter">true</property>
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
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF1EZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xLCBWZXJzaW9uPTEyLjEuNy4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI4OGQxNzU0ZDcwMGU0OWEFAQAAADhEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvQ29sbGVjdGlvbgQAAAAKZ3JvdXBDb3VudAVjbG9uZQ9jbG9uZUdyb3VwQ291bnQTQ29sbGVjdGlvbkJhc2UrbGlzdAADAAMIsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dCBxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AgAAAAAAAAAJAwAAAAAAAAAJBAAAAAQDAAAAsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAABgAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
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

--------------------------------------------------------------------------------------ProjectIteration---------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default ProjectIteration List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'ProjectIteration')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">gridView1</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="5">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Width">348</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colName</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">135</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Name">colStartDate</property>
      <property name="Caption">StartDate</property>
      <property name="ColumnEditName" />
      <property name="FieldName">StartDate</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Width">103</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:d}</property>
        <property name="FormatType">DateTime</property>
      </property>
      <property name="Name">colEndDate</property>
      <property name="Caption">End Date</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Deadline</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">249</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colVersionNumber</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ProjectVersionId</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
	  <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">253</property>
      <property name="Name">colProjectId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">ProjectId</property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="WaitAnimationOptions">Panel</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'


--------------------------------------------------------------------------------------ProjectVersion---------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default ProjectVersion List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'ProjectVersion')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">gridView1</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="5">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Width">348</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colVersionNumber</property>
      <property name="ColumnEditName" />
      <property name="FieldName">VersionName</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">348</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colDescription</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Description</property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="WaitAnimationOptions">Panel</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'


--------------------------------------------------------------------------------------Invoice------------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Invoice List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Invoice')    ,IsDefault = 1    ,
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
  <property name="Columns" iskey="true" value="13">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">214</property>
      <property name="ColumnEditName" />
      <property name="Name">colName</property>
      <property name="FieldName">Name</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">127</property>
      <property name="ColumnEditName" />
      <property name="Name">colInvoiceNumber</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">InvoiceNumber</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">88</property>
      <property name="ColumnEditName" />
      <property name="Name">colDateDelivered</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">DateDelivered</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:N2}</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="ColumnEditName" />
      <property name="Name">colPaidAmount</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">PaidAmount</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Width">84</property>
      <property name="ColumnEditName" />
      <property name="Name">colReceivedDate</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">ReceivedDate</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">{0:N2}</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="ColumnEditName" />
      <property name="Name">colTotalAmount</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="FieldName">TotalAmount</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">73</property>
      <property name="ColumnEditName" />
      <property name="Name">colStatusCode</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Status</property>
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">9</property>
      <property name="Width">86</property>
      <property name="ColumnEditName" />
      <property name="Name">colModifiedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Modified On</property>
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedOn</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="FixedWidth">true</property>
      </property>
      <property name="Caption">Created On</property>
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">81</property>
      <property name="ColumnEditName" />
      <property name="Name">colBillingCustomerId</property>
      <property name="FieldName">BillingCustomerId</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedById</property>
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">8</property>
      <property name="ColumnEditName" />
      <property name="Name">colOwnerId</property>
      <property name="FieldName">OwnerId</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">Default</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">EntityGridView</property>
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
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF1EZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xLCBWZXJzaW9uPTEyLjEuNy4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI4OGQxNzU0ZDcwMGU0OWEFAQAAADhEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvQ29sbGVjdGlvbgQAAAAKZ3JvdXBDb3VudAVjbG9uZQ9jbG9uZUdyb3VwQ291bnQTQ29sbGVjdGlvbkJhc2UrbGlzdAADAAMIsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dCBxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AgAAAAAAAAAJAwAAAAAAAAAJBAAAAAQDAAAAsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAAEgAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'


-----------------------------------------------------------------------------------------TimeTracking-------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default TimeTracking List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'TimeTracking')    ,IsDefault = 1    ,LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="HorzScrollStep">3</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="PreviewLineCount">-1</property>
  <property name="NewItemRowText" />
  <property name="GroupPanelText" />
  <property name="PreviewFieldName" />
  <property name="PreviewIndent">-1</property>
  <property name="LevelIndent">-1</property>
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="ActiveFilterEnabled">true</property>
  <property name="SynchronizeClones">true</property>
  <property name="BorderStyle">Default</property>
  <property name="ViewCaption" />
  <property name="DetailHeight">350</property>
  <property name="Name">gridView1</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Columns" iskey="true" value="6">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colRecordById</property>
      <property name="ColumnEditName" />
      <property name="FieldName">RecordById</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">40</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Name">colRecordOn</property>
      <property name="ColumnEditName" />
      <property name="FieldName">RecordOn</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Width">41</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colTypeCode</property>
      <property name="Caption">Type</property>
      <property name="ColumnEditName" />
      <property name="FieldName">TypeCode</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">20</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colEffort</property>
      <property name="OptionsColumn" isnull="true" iskey="true">
        <property name="AllowMerge">False</property>
        <property name="AllowEdit">false</property>
        <property name="AllowGroup">False</property>
      </property>
      <property name="Caption">Effort</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Effort</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Name">colDescription</property>
      <property name="Caption">Description</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Description</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Name">colTimeTrackingId</property>
      <property name="ColumnEditName" />
      <property name="FieldName">TimeTrackingId</property>
    </property>
  </property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="VertScrollTipFieldName" />
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowGroupPanel">false</property>
    <property name="ShowGroupedColumns">true</property>
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="WaitAnimationOptions">Panel</property>
    <property name="AllowCellMerge">true</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="RowHeight">-1</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AllowFixedGroups">True</property>
    <property name="AutoExpandAllGroups">true</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="FooterPanelHeight">-1</property>
  <property name="ChildGridLevelName" />
  <property name="VertScrollVisibility">Auto</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummary" iskey="true" value="2">
    <property name="Item1" isnull="true" iskey="true">
      <property name="DisplayFormat" />
      <property name="SummaryType">Count</property>
      <property name="FieldName">RecordById</property>
      <property name="Tag" isnull="true" />
      <property name="ShowInGroupColumnFooterName" />
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="DisplayFormat" />
      <property name="SummaryType">Sum</property>
      <property name="FieldName">Effort</property>
      <property name="Tag" isnull="true" />
      <property name="ShowInGroupColumnFooterName" />
    </property>
  </property>
  <property name="ActiveFilterString" />
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF5EZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhBQEAAAA4RGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb0NvbGxlY3Rpb24EAAAACmdyb3VwQ291bnQFY2xvbmUPY2xvbmVHcm91cENvdW50E0NvbGxlY3Rpb25CYXNlK2xpc3QAAwADCLMBU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuTGlzdGAxW1tEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvLCBEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yLCBWZXJzaW9uPTExLjIuMTEuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhXV0IHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QCAAAAAQAAAAkDAAAAAAAAAAkEAAAABAMAAACzAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbywgRGV2RXhwcmVzcy5YdHJhR3JpZC52MTEuMiwgVmVyc2lvbj0xMS4yLjExLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAABAAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMS4yBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAQAAAAYJAAAADWNvbFJlY29yZEJ5SWQL</property>
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'

------------------------------------------------------------------------------------Opportunity------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Opportunity List'    ,
ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Opportunity')    ,IsDefault = 1    ,LayoutXml = '<XtraSerializer version="1.0" application="View">
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
  <property name="Columns" iskey="true" value="25">
    <property name="Item1" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colActualCloseDate</property>
      <property name="FieldName">ActualCloseDate</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCloseProbability</property>
      <property name="FieldName">CloseProbability</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colActualValue</property>
      <property name="FieldName">ActualValue</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedOn</property>
      <property name="FieldName">CreatedOn</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Width">150</property>
      <property name="ColumnEditName" />
      <property name="Name">colDescription</property>
      <property name="FieldName">Description</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">9</property>
      <property name="Width">82</property>
      <property name="ColumnEditName" />
      <property name="Name">colEstimatedCloseDate</property>
      <property name="FieldName">EstimatedCloseDate</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="DisplayFormat" isnull="true" iskey="true">
        <property name="FormatString">n0</property>
        <property name="FormatType">Numeric</property>
      </property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Width">79</property>
      <property name="ColumnEditName" />
      <property name="Name">colEstimatedValue</property>
      <property name="FieldName">EstimatedValue</property>
    </property>
    <property name="Item8" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colLeadSourceCode</property>
      <property name="FieldName">LeadSourceCode</property>
    </property>
    <property name="Item9" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">12</property>
      <property name="Width">103</property>
      <property name="ColumnEditName" />
      <property name="Name">colModifiedOn</property>
      <property name="FieldName">ModifiedOn</property>
    </property>
    <property name="Item10" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">145</property>
      <property name="ColumnEditName" />
      <property name="Name">colName</property>
      <property name="FieldName">Name</property>
    </property>
    <property name="Item11" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colOpportunityId</property>
      <property name="FieldName">OpportunityId</property>
    </property>
    <property name="Item12" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">72</property>
      <property name="ColumnEditName" />
      <property name="Name">colOpportunityRatingCode</property>
      <property name="FieldName">OpportunityRatingCode</property>
    </property>
    <property name="Item13" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colOpportunityTypeCode</property>
      <property name="FieldName">OpportunityTypeCode</property>
    </property>
    <property name="Item14" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">7</property>
      <property name="Width">73</property>
      <property name="ColumnEditName" />
      <property name="Name">colSalesStageCode</property>
      <property name="Caption">SalesStage</property>
      <property name="FieldName">SalesStageCode</property>
    </property>
    <property name="Item15" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">55</property>
      <property name="ColumnEditName" />
      <property name="Name">colPriorityCode</property>
      <property name="FieldName">PriorityCode</property>
    </property>
    <property name="Item16" isnull="true" iskey="true">
      <property name="Width">100</property>
      <property name="ColumnEditName" />
      <property name="Name">colStepName</property>
      <property name="FieldName">StepName</property>
    </property>
    <property name="Item17" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">103</property>
      <property name="ColumnEditName" />
      <property name="Name">colTechnologyCode</property>
      <property name="FieldName">TechnologyCode</property>
    </property>
    <property name="Item18" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">95</property>
      <property name="ColumnEditName" />
      <property name="Name">colProjectTypeCode</property>
      <property name="FieldName">ProjectTypeCode</property>
    </property>
    <property name="Item19" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item20" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="ColumnEditName" />
      <property name="Name">colCustomerId</property>
      <property name="FieldName">CustomerId</property>
    </property>
    <property name="Item21" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">8</property>
      <property name="Width">67</property>
      <property name="ColumnEditName" />
      <property name="Name">colStatusCode</property>
      <property name="FieldName">StatusCode</property>
    </property>
    <property name="Item22" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">11</property>
      <property name="ColumnEditName" />
      <property name="Name">colDepartmentId</property>
      <property name="FieldName">DepartmentId</property>
    </property>
    <property name="Item23" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colModifiedById</property>
      <property name="FieldName">ModifiedById</property>
    </property>
    <property name="Item24" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">10</property>
      <property name="ColumnEditName" />
      <property name="Name">colOwnerId</property>
      <property name="FieldName">OwnerId</property>
    </property>
    <property name="Item25" isnull="true" iskey="true">
      <property name="ColumnEditName" />
      <property name="Name">colTechnicianId</property>
      <property name="FieldName">TechnicianId</property>
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
    <property name="ColumnAutoWidth">false</property>
  </property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AutoPopulateColumns">false</property>
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
  <property name="SortInfo">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAF1EZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xLCBWZXJzaW9uPTEyLjEuNy4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI4OGQxNzU0ZDcwMGU0OWEFAQAAADhEZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvQ29sbGVjdGlvbgQAAAAKZ3JvdXBDb3VudAVjbG9uZQ9jbG9uZUdyb3VwQ291bnQTQ29sbGVjdGlvbkJhc2UrbGlzdAADAAMIsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dCBxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AgAAAAAAAAAJAwAAAAAAAAAJBAAAAAQDAAAAsgFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW0RldkV4cHJlc3MuWHRyYUdyaWQuQ29sdW1ucy5HcmlkQ29sdW1uU29ydEluZm8sIERldkV4cHJlc3MuWHRyYUdyaWQudjEyLjEsIFZlcnNpb249MTIuMS43LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAAwRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mb1tdAgAAAAgICQUAAAAAAAAAAAAAAAQEAAAAHFN5c3RlbS5Db2xsZWN0aW9ucy5BcnJheUxpc3QDAAAABl9pdGVtcwVfc2l6ZQhfdmVyc2lvbgUAAAgICQYAAAABAAAABgAAAAcFAAAAAAEAAAAAAAAABC5EZXZFeHByZXNzLlh0cmFHcmlkLkNvbHVtbnMuR3JpZENvbHVtblNvcnRJbmZvAgAAABAGAAAABAAAAAkHAAAADQMMCAAAABlEZXZFeHByZXNzLlh0cmFHcmlkLnYxMi4xBQcAAAAuRGV2RXhwcmVzcy5YdHJhR3JpZC5Db2x1bW5zLkdyaWRDb2x1bW5Tb3J0SW5mbwIAAAAJU29ydE9yZGVyCkNvbHVtbk5hbWUAAQgIAAAAAgAAAAYJAAAADWNvbE1vZGlmaWVkT24L</property>
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'

------------------------------------------------------------------------------------Attendance------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default Attendance List'    ,
ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'Attendance')    ,IsDefault = 1    ,
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
  <property name="Columns" iskey="true" value="7">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Width">70</property>
      <property name="ColumnEditName" />
      <property name="Name">colRecordOn</property>
      <property name="FieldName">RecordOn</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Width">57</property>
      <property name="ColumnEditName" />
      <property name="Name">colRecordPersonId</property>
      <property name="FieldName">RecordPersonId</property>
    </property>
    <property name="Item3" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">2</property>
      <property name="Width">52</property>
      <property name="ColumnEditName" />
      <property name="Name">colAttendanceTypeCode</property>
      <property name="FieldName">AttendanceTypeCode</property>
    </property>
    <property name="Item4" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Width">52</property>
      <property name="ColumnEditName" />
      <property name="Name">colAttendanceLength</property>
      <property name="FieldName">AttendanceLength</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Width">50</property>
      <property name="ColumnEditName" />
      <property name="Name">colAttendanceUnitCode</property>
      <property name="FieldName">AttendanceUnitCode</property>
    </property>
    <property name="Item6" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">6</property>
      <property name="Width">102</property>
      <property name="ColumnEditName" />
      <property name="Name">colCreatedById</property>
      <property name="FieldName">CreatedById</property>
    </property>
    <property name="Item7" isnull="true" iskey="true">
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Width">397</property>
      <property name="ColumnEditName" />
      <property name="Name">colDescription</property>
      <property name="FieldName">Description</property>
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
    <property name="ColumnAutoWidth">false</property>
  </property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AutoPopulateColumns">false</property>
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
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
  <property name="FindFilterText" />
  <property name="FindPanelVisible">false</property>
</XtraSerializer>'

------------------------------------------------------------------------------------NotificationRecipient ------------------------------------------------------------------
INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault   ,LayoutXml)     
SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default NotificationRecipient List'    ,
ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'NotificationRecipient')    ,IsDefault = 1    ,
LayoutXml = '<XtraSerializer version="1.0" application="View">
  <property name="#LayoutVersion" />
  <property name="NewItemRowText" />
  <property name="GroupFooterShowMode">VisibleIfExpanded</property>
  <property name="LevelIndent">-1</property>
  <property name="PreviewIndent">-1</property>
  <property name="PreviewLineCount">-1</property>
  <property name="BestFitMaxRowCount">-1</property>
  <property name="ScrollStyle">LiveVertScroll, LiveHorzScroll</property>
  <property name="FocusRectStyle">RowFocus</property>
  <property name="HorzScrollStep">3</property>
  <property name="GroupPanelText" />
  <property name="ActiveFilterEnabled">true</property>
  <property name="ViewCaptionHeight">-1</property>
  <property name="ShowButtonMode">ShowForFocusedCell</property>
  <property name="Columns" iskey="true" value="5">
    <property name="Item1" isnull="true" iskey="true">
      <property name="Width">86</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">0</property>
      <property name="Name">colObjectType</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Notification.ObjectType</property>
    </property>
    <property name="Item2" isnull="true" iskey="true">
      <property name="Width">97</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">1</property>
      <property name="Name">colSubject</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Notification.Subject</property>
    </property>
    
    <property name="Item4" isnull="true" iskey="true">
      <property name="Width">80</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">3</property>
      <property name="Name">colCreatedOn</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Notification.CreatedOn</property>
    </property>
    <property name="Item5" isnull="true" iskey="true">
      <property name="Width">85</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">4</property>
      <property name="Name">colCreatedBy</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Notification.CreatedById</property>
    </property>
	<property name="Item3" isnull="true" iskey="true">
	  <property name="Width">500</property>
      <property name="Visible">true</property>
      <property name="VisibleIndex">5</property>
      <property name="Name">colContent</property>
      <property name="ColumnEditName" />
      <property name="FieldName">Notification.Body</property>
    </property>
  </property>
  <property name="ViewCaption" />
  <property name="BorderStyle">Default</property>
  <property name="SynchronizeClones">true</property>
  <property name="DetailTabHeaderLocation">Top</property>
  <property name="Name">gridView1</property>
  <property name="DetailHeight">350</property>
  <property name="PreviewFieldName" />
  <property name="ChildGridLevelName" />
  <property name="FixedLineWidth">2</property>
  <property name="IndicatorWidth">-1</property>
  <property name="ColumnPanelRowHeight">-1</property>
  <property name="OptionsView" isnull="true" iskey="true">
    <property name="ShowFilterPanelMode">Never</property>
    <property name="ShowIndicator">false</property>
    <property name="ShowGroupPanel">false</property>
    <property name="WaitAnimationOptions">Panel</property>
    <property name="ColumnAutoWidth">true</property>
	<property name="RowAutoHeight">true</property>
  </property>
  <property name="OptionsSelection" isnull="true" iskey="true">
    <property name="EnableAppearanceFocusedCell">false</property>
  </property>
  <property name="RowSeparatorHeight">0</property>
  <property name="OptionsBehavior" isnull="true" iskey="true">
    <property name="Editable">false</property>
    <property name="AutoPopulateColumns">false</property>
  </property>
  <property name="FooterPanelHeight">-1</property>
  <property name="HorzScrollVisibility">Auto</property>
  <property name="VertScrollVisibility">Auto</property>
  <property name="RowHeight">-1</property>
  <property name="GroupRowHeight">-1</property>
  <property name="OptionsDetail" isnull="true" iskey="true">
    <property name="EnableMasterViewMode">false</property>
  </property>
  <property name="GroupFormat">{0}: [#image]{1} {2}</property>
  <property name="VertScrollTipFieldName" />
  <property name="GroupSummary" iskey="true" value="0" />
  <property name="ActiveFilterString" />
  <property name="FormatConditions" iskey="true" value="0" />
  <property name="GroupSummarySortInfoState" />
</XtraSerializer>'