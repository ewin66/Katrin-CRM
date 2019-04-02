using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Katrin.Database.Migrations
{
    [Migration(20121127144330)]
    public class _20121127144330_UpdateSaveQueryTable : Migration
    {
        public override void Up()
        {
            string layoutXml = "<XtraSerializer version=\"1.0\" application=\"View\">  <property name=\"#LayoutVersion\" />  <property name=\"GroupPanelText\" />  <property name=\"NewItemRowText\" />  <property name=\"GroupFooterShowMode\">VisibleIfExpanded</property>  <property name=\"LevelIndent\">-1</property>  <property name=\"PreviewIndent\">-1</property>  <property name=\"PreviewLineCount\">-1</property>  <property name=\"BestFitMaxRowCount\">-1</property>  <property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property>  <property name=\"FocusRectStyle\">RowFocus</property>  <property name=\"HorzScrollStep\">3</property>  <property name=\"PreviewFieldName\" />  <property name=\"ViewCaptionHeight\">-1</property>  <property name=\"ShowButtonMode\">ShowForFocusedCell</property>  <property name=\"Columns\" iskey=\"true\" value=\"27\">    <property name=\"Item1\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">6</property>      <property name=\"Width\">106</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colCreatedOn</property>      <property name=\"FieldName\">CreatedOn</property>    </property>    <property name=\"Item2\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">3</property>      <property name=\"Width\">123</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colEmailAddress</property>      <property name=\"FieldName\">EmailAddress</property>    </property>    <property name=\"Item3\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colFirstName</property>      <property name=\"FieldName\">FirstName</property>    </property>    <property name=\"Item4\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">0</property>      <property name=\"Width\">122</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colFullName</property>      <property name=\"FieldName\">FullName</property>    </property>    <property name=\"Item5\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colHomePhone</property>      <property name=\"FieldName\">HomePhone</property>    </property>    <property name=\"Item6\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colLastName</property>      <property name=\"FieldName\">LastName</property>    </property>    <property name=\"Item7\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">4</property>      <property name=\"Width\">113</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colMobilePhone</property>      <property name=\"FieldName\">MobilePhone</property>    </property>    <property name=\"Item8\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">5</property>      <property name=\"Width\">105</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colModifiedOn</property>      <property name=\"FieldName\">ModifiedOn</property>    </property>    <property name=\"Item9\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">2</property>      <property name=\"Width\">101</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colNickName</property>      <property name=\"FieldName\">NickName</property>    </property>    <property name=\"Item10\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colTitle</property>      <property name=\"FieldName\">Title</property>    </property>    <property name=\"Item11\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">1</property>      <property name=\"Width\">106</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colUserName</property>      <property name=\"FieldName\">UserName</property>    </property>    <property name=\"Item12\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colCreatedById</property>      <property name=\"FieldName\">CreatedById</property>    </property>    <property name=\"Item13\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colModifiedById</property>      <property name=\"FieldName\">ModifiedById</property>    </property>    <property name=\"Item14\" isnull=\"true\" iskey=\"true\">      <property name=\"Visible\">true</property>      <property name=\"VisibleIndex\">7</property>      <property name=\"ColumnEditName\" />      <property name=\"Name\">colDepartmentId</property>      <property name=\"FieldName\">DepartmentId</property>    </property>    <property name=\"Item15\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colEntryDate</property>      <property name=\"FieldName\">EntryDate</property>    </property>    <property name=\"Item16\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colJobLevelCode</property>      <property name=\"FieldName\">JobLevelCode</property>    </property>    <property name=\"Item17\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colLastPromotionDate</property>      <property name=\"FieldName\">LastPromotionDate</property>    </property>    <property name=\"Item18\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colGraduatedCollege</property>      <property name=\"FieldName\">GraduatedCollege</property>    </property>    <property name=\"Item19\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colWorkExperience</property>      <property name=\"FieldName\">WorkExperience</property>    </property>    <property name=\"Item20\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colTechnicalExpertise</property>      <property name=\"FieldName\">TechnicalExpertise</property>    </property>    <property name=\"Item21\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colEnglishLevel</property>      <property name=\"FieldName\">EnglishLevel</property>    </property>    <property name=\"Item22\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colEnglishCommunication</property>      <property name=\"FieldName\">EnglishCommunication</property>    </property>    <property name=\"Item23\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colBirthDate</property>      <property name=\"FieldName\">BirthDate</property>    </property>    <property name=\"Item24\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colHobby</property>      <property name=\"FieldName\">Hobby</property>    </property>    <property name=\"Item25\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colNativePlace</property>      <property name=\"FieldName\">NativePlace</property>    </property>    <property name=\"Item26\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colMSN</property>      <property name=\"FieldName\">MSN</property>    </property>    <property name=\"Item27\" isnull=\"true\" iskey=\"true\">      <property name=\"ColumnEditName\" />      <property name=\"Name\">colQQ</property>      <property name=\"FieldName\">QQ</property>    </property>  </property>  <property name=\"ViewCaption\" />  <property name=\"BorderStyle\">Default</property>  <property name=\"SynchronizeClones\">true</property>  <property name=\"DetailTabHeaderLocation\">Top</property>  <property name=\"Name\">gridView1</property>  <property name=\"DetailHeight\">350</property>  <property name=\"ActiveFilterEnabled\">true</property>  <property name=\"VertScrollTipFieldName\" />  <property name=\"GroupFormat\">{0}: [#image]{1} {2}</property>  <property name=\"OptionsView\" isnull=\"true\" iskey=\"true\">    <property name=\"ShowFilterPanelMode\">Never</property>    <property name=\"ShowIndicator\">false</property>    <property name=\"ShowGroupPanel\">false</property>    <property name=\"WaitAnimationOptions\">Panel</property>    <property name=\"ColumnAutoWidth\">false</property>  </property>  <property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\">    <property name=\"Editable\">false</property>    <property name=\"AllowIncrementalSearch\">true</property>  </property>  <property name=\"FixedLineWidth\">2</property>  <property name=\"OptionsDetail\" isnull=\"true\" iskey=\"true\">    <property name=\"EnableMasterViewMode\">false</property>  </property>  <property name=\"ChildGridLevelName\" />  <property name=\"IndicatorWidth\">-1</property>  <property name=\"OptionsSelection\" isnull=\"true\" iskey=\"true\">    <property name=\"EnableAppearanceFocusedCell\">false</property>  </property>  <property name=\"ColumnPanelRowHeight\">-1</property>  <property name=\"VertScrollVisibility\">Auto</property>  <property name=\"GroupRowHeight\">-1</property>  <property name=\"HorzScrollVisibility\">Auto</property>  <property name=\"FooterPanelHeight\">-1</property>  <property name=\"RowSeparatorHeight\">0</property>  <property name=\"RowHeight\">-1</property>  <property name=\"ActiveFilterString\" />  <property name=\"GroupSummary\" iskey=\"true\" value=\"0\" />  <property name=\"FormatConditions\" iskey=\"true\" value=\"0\" />  <property name=\"GroupSummarySortInfoState\" />  <property name=\"FindFilterText\" />  <property name=\"FindPanelVisible\">false</property></XtraSerializer>";
            Update.Table("SavedQuery").Set(new { LayoutXml = layoutXml })
                .Where(new { SavedQueryId = "17D097AC-EF43-4B5B-AA02-22642D82FC4C" });
        }

        public override void Down()
        {
           
        }
    }
}
