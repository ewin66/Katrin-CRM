using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Database.Migrations
{
    [Migration(20121219093026)]
    public class _20121219093026_AddSavedQueryAndLocalizedLabelForAppointmentModule : Migration
    {
        public override void Up()
        {
            string sql = @"
                        DELETE FROM [dbo].[SavedQuery]
                        WHERE [SavedQueryId] = '410615E4-3C85-42B5-9534-EB1D9E2388E0'
                        DELETE FROM [dbo].[Metadata_LocalizedLabel]
                        WHERE [LocalizedLabelId] = '909AEDD6-8AD4-480C-AA6E-ABC34AB52AC7'
                        DELETE FROM [dbo].[Metadata_LocalizedLabel]
                        WHERE [LocalizedLabelId] = 'EB648410-D8CE-460D-AF1D-8850FF262F28'

                        INSERT INTO [dbo].[SavedQuery]
                        ([SavedQueryId],[Name],[Description],[QueryType]
                        ,[IsDefault],[ReturnedTypeId],[IsUserDefined],[FetchXml]
                        ,[IsCustomizable],[IsQuickFindQuery],[ColumnSetXml]
                        ,[LayoutXml]
                        ,[IsPrivate],[AdvancedGroupBy],[ConditionalFormatting],[CanBeDeleted])
                        VALUES
                        ('410615E4-3C85-42B5-9534-EB1D9E2388E0','Default Appointment List','',0
                        ,1,'D133BB15-6A01-4D5E-A1C8-B029DA9A68D7',1,''
                        ,1,0,''
                        ,'<XtraSerializer version=""1.0"" application=""View"">  <property name=""#LayoutVersion"" />  <property name=""GroupPanelText"" />  <property name=""NewItemRowText"" />  <property name=""GroupFooterShowMode"">VisibleIfExpanded</property>  <property name=""LevelIndent"">-1</property>  <property name=""PreviewIndent"">-1</property>  <property name=""PreviewLineCount"">-1</property>  <property name=""BestFitMaxRowCount"">-1</property>  <property name=""ScrollStyle"">LiveVertScroll, LiveHorzScroll</property>  <property name=""FocusRectStyle"">CellFocus</property>  <property name=""HorzScrollStep"">3</property>  <property name=""PreviewFieldName"" />  <property name=""ViewCaptionHeight"">-1</property>  <property name=""ShowButtonMode"">ShowForFocusedCell</property>  <property name=""Columns"" iskey=""true"" value=""1"">    <property name=""Item1"" isnull=""true"" iskey=""true"">      <property name=""Visible"">true</property>      <property name=""VisibleIndex"">0</property>      <property name=""ColumnEditName"" />      <property name=""Name"">colResourceId</property>      <property name=""Caption"">ResourceId</property>      <property name=""FieldName"">ResourceId</property>    </property>  </property>  <property name=""ViewCaption"" />  <property name=""BorderStyle"">NoBorder</property>  <property name=""SynchronizeClones"">true</property>  <property name=""DetailTabHeaderLocation"">Top</property>  <property name=""Name"">gridView1</property>  <property name=""DetailHeight"">350</property>  <property name=""ActiveFilterEnabled"">true</property>  <property name=""VertScrollTipFieldName"" />  <property name=""GroupFormat"">{0}: [#image]{1} {2}</property>  <property name=""OptionsView"" isnull=""true"" iskey=""true"">    <property name=""ShowFilterPanelMode"">Never</property>  </property>  <property name=""OptionsFind"" isnull=""true"" iskey=""true"">    <property name=""AllowFindPanel"">false</property>  </property>  <property name=""OptionsBehavior"" isnull=""true"" iskey=""true"">    <property name=""AllowAddRows"">False</property>    <property name=""AllowDeleteRows"">False</property>    <property name=""Editable"">false</property>    <property name=""ReadOnly"">true</property>  </property>  <property name=""FixedLineWidth"">2</property>  <property name=""ChildGridLevelName"" />  <property name=""IndicatorWidth"">-1</property>  <property name=""ColumnPanelRowHeight"">-1</property>  <property name=""VertScrollVisibility"">Auto</property>  <property name=""GroupRowHeight"">-1</property>  <property name=""HorzScrollVisibility"">Auto</property>  <property name=""FooterPanelHeight"">-1</property>  <property name=""RowSeparatorHeight"">0</property>  <property name=""RowHeight"">-1</property>  <property name=""ActiveFilterString"" />  <property name=""GroupSummary"" iskey=""true"" value=""0"" />  <property name=""FormatConditions"" iskey=""true"" value=""0"" />  <property name=""GroupSummarySortInfoState"" />  <property name=""FindFilterText"" />  <property name=""FindPanelVisible"">false</property></XtraSerializer>'
                        ,0,'','',1)

                        INSERT INTO [dbo].[Metadata_LocalizedLabel]
                        ([LocalizedLabelId],[LanguageId]
                        ,[ObjectId],[ObjectColumnName],[Label])
                        VALUES
                        ('909AEDD6-8AD4-480C-AA6E-ABC34AB52AC7', 2052
                        ,'F4E45112-C0AD-44E1-A1FC-D8824B9CEB7A','Display',N'???')
                        ,('EB648410-D8CE-460D-AF1D-8850FF262F28', 1033
                        ,'F4E45112-C0AD-44E1-A1FC-D8824B9CEB7A','Display','Meeting Room')";
            Execute.Sql(sql);
        }
        public override void Down()
        {

        }
    }
}
