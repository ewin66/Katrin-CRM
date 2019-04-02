using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraEditors;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.XtraGrid.Views.Base;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework;
using System.Xml.Serialization;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Messages;

namespace Katrin.Win.FormatModule.FormatCondition
{
    public class FormatConditionController : ControllerBase
    {
        private IFormatConditionView _formatView;
        private string _entityTypeName;

        public FormatConditionController()
        {
          
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            var gridView = parameters.Get<GridView>("GridView");
            _formatView = ViewFactory.CreateView("DefaultFormatView") as IFormatConditionView;
            _entityTypeName = parameters.ObjectName;
            OnViewSet(gridView);
            return new ModalViewResult(_formatView);
        }

        protected void OnViewSet(ColumnView gridView)
        {
            _formatView.Apply += ViewApply;
            _formatView.SetGridView(gridView, GetFileName());
        }


        private string GetFileName()
        {
            string formatsDirectory = Path.Combine(Application.StartupPath + "\\AddIns\\", "Formats");
            string viewFormatDirectory = Path.Combine(formatsDirectory, _entityTypeName);
            if (!Directory.Exists(viewFormatDirectory)) Directory.CreateDirectory(viewFormatDirectory);
            var fileFullName = viewFormatDirectory + "\\FormatCondition.xml";
            return fileFullName;
        }

        private void ApplyConditions(IEnumerable<FormatCondition> activeConditons)
        {
            _formatView.PostEdit();
            _formatView.ClearConditions();
            foreach (var conditionSetting in activeConditons)
            {
                var condition = CreateStyleFormatCondition(conditionSetting);
                _formatView.AddCondition(condition);
            }
        }

        public static StyleFormatCondition CreateStyleFormatCondition(FormatCondition conditionSetting)
        {
            StyleFormatCondition condition = new StyleFormatCondition();
            var fontStyle = FontStyle.Regular;
            if (conditionSetting.Underline)
            {
                fontStyle |= FontStyle.Underline;
            }
            if (conditionSetting.Italic)
            {
                fontStyle |= FontStyle.Italic;
            }
            if (conditionSetting.Bold)
            {
                fontStyle |= FontStyle.Bold;
            }
            FontFamily fontFamily = new FontFamily(System.Drawing.SystemFonts.DefaultFont.Name);
            float size = System.Drawing.SystemFonts.DefaultFont.Size;
            if (!string.IsNullOrEmpty(conditionSetting.FontName))
            {
                fontFamily = new FontFamily(conditionSetting.FontName);
                
            }
            if (!string.IsNullOrEmpty(conditionSetting.Size))
            {
                size = float.Parse(conditionSetting.Size);
            }
            System.Drawing.Font font = new Font(fontFamily,size, fontStyle);
            condition.Appearance.Font = font;
            condition.Condition = FormatConditionEnum.Expression;
            condition.Expression = conditionSetting.Conditions;
            condition.Appearance.BackColor = conditionSetting.Backcolor;
            condition.Appearance.ForeColor = conditionSetting.Forecolor;
            condition.Appearance.Options.UseFont = conditionSetting.UseFont;
            condition.Appearance.Options.UseForeColor = conditionSetting.UseForeColor;
            condition.Appearance.Options.UseBackColor = conditionSetting.UseBackColor;
            return condition;
        }

        public void ViewApply(object sender, EventArgs e)
        {
            _formatView.SaveLayout(GetFileName());
            var activeConditons = _formatView.Conditions.Where(c => c.Active);
            ApplyConditions(activeConditons);
        }

        #region FormatRequestService
        private string GetFileName(string objectName)
        {
            string formatsDirectory = Path.Combine(Application.StartupPath + "\\AddIns\\", "Formats");
            string viewFormatDirectory = Path.Combine(formatsDirectory, objectName);
            if (!Directory.Exists(viewFormatDirectory)) Directory.CreateDirectory(viewFormatDirectory);
            var fileFullName = viewFormatDirectory + "\\FormatCondition.xml";
            return fileFullName;
        }
        private IList<FormatCondition> GetFormatConditions(string formatConditionFileName)
        {
            List<FormatCondition> re = new List<FormatCondition>();
            if (File.Exists(formatConditionFileName))
            {
                Stream stream = null;
                try
                {
                    stream = new FileStream(formatConditionFileName, FileMode.Open, FileAccess.Read);
                    if (stream.Length <= 0) return re;
                    XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<FormatCondition>));
                    List<FormatCondition> list = (List<FormatCondition>)xmlFormatter.Deserialize(stream);
                    re.AddRange(list);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageService.ShowException(ex);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }

            return re;
        }
        /// <summary>
        /// FormatRequestMessage Entry
        /// </summary>
        /// <param name="message"></param>
        public void Handle(FormatRequestMessage message)
        {
            string fileName = this.GetFileName(message.ObjectName);
            IList<FormatCondition> conditions = this.GetFormatConditions(fileName);
            var activeConditons = conditions.Where(c => c.Active);

            GridView gridview = message.GridView as GridView;
            gridview.BeginUpdate();
            gridview.FormatConditions.Clear();
            foreach (FormatCondition conditionSetting in activeConditons)
            {
                var condition = CreateStyleFormatCondition(conditionSetting);               
                gridview.FormatConditions.Add(condition);
            }
            gridview.EndUpdate();
        }
        #endregion
    }
}
