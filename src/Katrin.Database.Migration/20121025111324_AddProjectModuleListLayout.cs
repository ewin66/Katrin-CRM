using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121025111324)]
    public class _20121025111324_AddProjectModuleListLayout : Migration
    {
        public override void Up()
        {
            string layoutXml = "<XtraSerializer version=\"1.0\" application=\"View\"><property name=\"#LayoutVersion\" /><property name=\"GroupPanelText\" /><property name=\"NewItemRowText\" /><property name=\"GroupFooterShowMode\">VisibleIfExpanded</property><property name=\"LevelIndent\">-1</property><property name=\"PreviewIndent\">-1</property><property name=\"PreviewLineCount\">-1</property><property name=\"BestFitMaxRowCount\">-1</property><property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property><property name=\"FocusRectStyle\">RowFocus</property><property name=\"HorzScrollStep\">3</property><property name=\"PreviewFieldName\" /><property name=\"ViewCaptionHeight\">-1</property><property name=\"ShowButtonMode\">ShowForFocusedCell</property><property name=\"Columns\" iskey=\"true\" value=\"2\"><property name=\"Item1\" isnull=\"true\" iskey=\"true\"><property name=\"Visible\">true</property><property name=\"VisibleIndex\">0</property><property name=\"Width\">348</property><property name=\"ColumnEditName\" /><property name=\"Name\">colModuleName</property><property name=\"FieldName\">ModuleName</property></property><property name=\"Item2\" isnull=\"true\" iskey=\"true\"><property name=\"Visible\">true</property><property name=\"VisibleIndex\">1</property><property name=\"Width\">348</property><property name=\"ColumnEditName\" /><property name=\"Name\">colDescription</property><property name=\"FieldName\">Description</property></property></property><property name=\"ViewCaption\" /><property name=\"BorderStyle\">Default</property><property name=\"SynchronizeClones\">true</property><property name=\"DetailTabHeaderLocation\">Top</property><property name=\"Name\">gridView1</property><property name=\"DetailHeight\">350</property><property name=\"ActiveFilterEnabled\">true</property><property name=\"VertScrollTipFieldName\" /><property name=\"GroupFormat\">{0}: [#image]{1} {2}</property><property name=\"OptionsView\" isnull=\"true\" iskey=\"true\"><property name=\"ShowFilterPanelMode\">Never</property><property name=\"ShowIndicator\">false</property><property name=\"ShowGroupPanel\">false</property><property name=\"WaitAnimationOptions\">Panel</property></property><property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\"><property name=\"Editable\">false</property></property><property name=\"FixedLineWidth\">2</property><property name=\"OptionsDetail\" isnull=\"true\" iskey=\"true\"><property name=\"EnableMasterViewMode\">false</property></property><property name=\"ChildGridLevelName\" /><property name=\"IndicatorWidth\">-1</property><property name=\"OptionsSelection\" isnull=\"true\" iskey=\"true\"><property name=\"EnableAppearanceFocusedCell\">false</property></property><property name=\"ColumnPanelRowHeight\">-1</property><property name=\"VertScrollVisibility\">Auto</property><property name=\"GroupRowHeight\">-1</property><property name=\"HorzScrollVisibility\">Auto</property><property name=\"FooterPanelHeight\">-1</property><property name=\"RowSeparatorHeight\">0</property><property name=\"RowHeight\">-1</property><property name=\"ActiveFilterString\" /><property name=\"GroupSummary\" iskey=\"true\" value=\"0\" /><property name=\"FormatConditions\" iskey=\"true\" value=\"0\" /><property name=\"GroupSummarySortInfoState\" /><property name=\"FindFilterText\" /><property name=\"FindPanelVisible\">false</property></XtraSerializer>";
            string sql = @"INSERT INTO SavedQuery(   SavedQueryId   ,QueryType   ,Name   ,ReturnedTypeId   ,IsDefault ,LayoutXml )     
                        SELECT SavedQueryId = NEWID()    ,QueryType = 0    ,Name = 'Default ProjectModule List'    ,ReturnedTypeId = (SELECT EntityId FROM Metadata_Entity WHERE Name = 'ProjectModule')    ,IsDefault = 1 ,LayoutXml='"+layoutXml+"'";
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = "DELETE FROM SavedQuery WHERE Name='Default ProjectModule List'";
            Execute.Sql(sql);
        }

    }
}
