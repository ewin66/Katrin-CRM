using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Antlr4.StringTemplate;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Context;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using ICSharpCode.Core;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using Katrin.AppFramework.WinForms.Services;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.Win.FilterModule.FilterCondition;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.Security;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.ConfigService;
using Katrin.AppFramework.Utils;

namespace Katrin.Win.FilterModule
{
    public class FilterGalleryBarItem : RibbonGalleryBarItem, IObjectAware,IFilter
    {
        private FilterGalleryItem _currentItem;
        private IActionContext _viewContext;
        private PopupMenu _popupMenu;
        private string _gridFilter = "GridFilter";
        private RibbonControlEx _ribbon;
        private RibbonControl _mergeOwner;
        private string _filterName;
        public string ObjectName
        {
            get;
            set;
        }

        public string ControllerId
        {
            get;
            set;
        }
        
        public FilterGalleryBarItem(object caller)
        {
            if (caller == null) return;
            if (!(caller is IObjectAware)) return;
            var listController = (IObjectAware)caller;
           
            this.Name = "FilterGalleryBar";
            ObjectName = listController.ObjectName;
            ControllerId = listController.ControllerId;
            _viewContext = new ActionContext();
            InitFilters();
            GalleryInitDropDownGallery += FilterGalleryBarItem_GalleryInitDropDownGallery;
            GalleryItemClick += FilterGalleryBarItem_GalleryItemClick;
        }

        void FilterGalleryBarItem_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            SetFilter(e.Item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _popupMenu.Dispose();
                _popupMenu = null;
                GalleryInitDropDownGallery -= FilterGalleryBarItem_GalleryInitDropDownGallery;
                GalleryItemClick -= FilterGalleryBarItem_GalleryItemClick;
                if (_ribbon != null)
                {
                    _ribbon.MergeOwnerChanged -= ribbonControl_MergeOwnerChanged;
                    _ribbon.ShowCustomizationMenu -= Ribbon_ShowCustomizationMenu;
                    if (_mergeOwner != null)
                        _mergeOwner.ShowCustomizationMenu -= Ribbon_ShowCustomizationMenu;
                    _mergeOwner = null;
                    _ribbon = null;
                }
            }
            base.Dispose(disposing);
            GC.Collect();
            //GC.SuppressFinalize(this);
        }

        void FilterGalleryBarItem_GalleryInitDropDownGallery(object sender, InplaceGalleryEventArgs e)
        {
            e.PopupGallery.GalleryDropDown.Gallery.Groups.Clear();
            e.PopupGallery.GalleryDropDown.Gallery.Groups.Add(e.Item.Gallery.Groups[0]);
            SetBarItem("AddFilter", e.PopupGallery.GalleryDropDown, true);
        }

        protected override void OnManagerChanged()
        {
            base.OnManagerChanged();
            if (Manager != null)
            {
                _ribbon = Ribbon as RibbonControlEx;
                if (_ribbon != null)
                {
                    _ribbon.MergeOwnerChanged -= ribbonControl_MergeOwnerChanged;
                    _ribbon.MergeOwnerChanged += ribbonControl_MergeOwnerChanged;
                    _ribbon.ShowCustomizationMenu -= Ribbon_ShowCustomizationMenu;
                    _ribbon.ShowCustomizationMenu += Ribbon_ShowCustomizationMenu;
                    InitializePopupMenu();
                }
            }
        }

        void ribbonControl_MergeOwnerChanged(object sender, MergeOwnerChangedEventArgs e)
        {
            if (e.OldValue != null)
                e.OldValue.ShowCustomizationMenu -= Ribbon_ShowCustomizationMenu;
            if (e.NewValue != null)
            {
                e.NewValue.ShowCustomizationMenu -= Ribbon_ShowCustomizationMenu;
                e.NewValue.ShowCustomizationMenu += Ribbon_ShowCustomizationMenu;
                _mergeOwner = e.NewValue;
            }
        }

        void Ribbon_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            RibbonControl ribbon = sender as RibbonControl;
            if (e.HitInfo == null) return;
            

            if (e.HitInfo.InGalleryItem || e.HitInfo.HitTest == RibbonHitTest.GalleryImage)
            {
                var item = e.HitInfo.GalleryItem;
                if (Gallery.Groups.Contains(item.GalleryGroup))
                {
                    _currentItem = item as FilterGalleryItem;
                    e.ShowCustomizationMenu = false;
                    _popupMenu.ShowPopup(ribbon.PointToScreen(e.HitInfo.HitPoint));
                }
            }
        }

        #region PopupMenu
        private void InitializePopupMenu()
        {
            _popupMenu = new PopupMenu();
            _popupMenu.Ribbon = _ribbon;
            var editButton = CreateBarItem("EditFilter", "edit");
            editButton.ItemClick += new ItemClickEventHandler(editButton_ItemClick);
            _popupMenu.ItemLinks.Add(editButton);
            var deleteButton = CreateBarItem("DeleteFilter", "delete");
            deleteButton.ItemClick += new ItemClickEventHandler(deleteButton_ItemClick);
            _popupMenu.ItemLinks.Add(deleteButton);
        }

        void deleteButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentItem == null) return;
            string info = this.GetDeleteFilterInfo("DeleteFilterTip", _currentItem.Caption);
            var confirmDelete = MessageService.AskQuestion(info);
            if (confirmDelete)
            {
                string filterDirectory = GetFilterDirectory();
                if (Directory.Exists(filterDirectory))
                {
                    string fileFullName = Path.Combine(filterDirectory, _currentItem.FilterItem.FileName + ".xml");
                    if (File.Exists(fileFullName))
                    {
                        File.Delete(fileFullName);
                        BindFilterFile();
                    }
                }
            }
        }

        void editButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentItem == null) return;
            if (ShowFilterEditForm(_currentItem.FilterItem) == DialogResult.Cancel) return;
            BindFilterFile();
            SetItemChecked(_currentItem.FilterItem.FileName);
        }

        private BarButtonItem CreateBarItem(string name, string imageName)
        {
            BarButtonItem item = new BarButtonItem();
            item.Name = name;
            item.LargeGlyph = GetBitmapByName(imageName, new Size(16, 16));
            item.Glyph = GetBitmapByName(imageName, new Size(16, 16));
            item.Caption = GetLocalizedCaption(name);
            return item;
        }

        #endregion

        public void InitFilters()
        {
            this.Gallery.ColumnCount = 3;
            this.Gallery.RowCount = 7;
            this.Gallery.ShowItemText = true;

            this.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            //this.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            this.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.Gallery.DistanceBetweenItems = 0;

            BindFilterFile();
        }

        class FilterGalleryItem : GalleryItem
        {
            public FilterGalleryItem(FilterItem item)
            {
                FilterItem = item;
            }
            public FilterItem FilterItem { get; private set; }
        }

        private void BindFilterFile()
        {
            CriteriaOperator currentCriteria = _viewContext.GetFilter(_gridFilter);
            var viewItems = GetListFilterItems();
            var items = viewItems.OrderBy(i => i.Order).ToList();
            GalleryItemGroup itemGroup = new GalleryItemGroup();
            foreach (var item in items)
            {
                GalleryItem galleryItem = new FilterGalleryItem(item);
                galleryItem.Caption = item.DisplayName;
                galleryItem.Image = WinFormsResourceService.GetBitmap("tag");
                galleryItem.HoverImage = galleryItem.Image;
                string filterString = item.FilterString;
                bool isCrietiaEqual = IsCriteriaOperatorEquals(currentCriteria, CriteriaOperator.TryParse(filterString));
                galleryItem.Checked = isCrietiaEqual;
                itemGroup.Items.Add(galleryItem);
            }
            if (!itemGroup.Items.Cast<GalleryItem>().Any(i => i.Checked) && itemGroup.Items.Count > 0)
            {
                itemGroup.Items.Cast<GalleryItem>().Last().Checked = true;
            }
            this.Gallery.Groups.Clear();
            this.Gallery.Groups.Add(itemGroup);
        }

        private bool IsCriteriaOperatorEquals(CriteriaOperator filter1, CriteriaOperator filter2)
        {
            string filterString1 = (object)filter1 == null ? string.Empty : filter1.ToString();
            string filterString2 = (object)filter2 == null ? string.Empty : filter2.ToString();
            return filterString1 == filterString2;
        }

        private Bitmap GetBitmapByName(string name, Size size)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var rnames = asm.GetManifestResourceNames();
            var tofind = "." + name + ".ico";
            var rname = rnames.Where(c => c.EndsWith(tofind, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (rname != null)
            {
                using (var stream = asm.GetManifestResourceStream(rname))
                {
                    Icon icon = new Icon(stream, size);
                    return icon.ToBitmap();
                }
            }
            return null;
        }

        private void SetBarItem(string name, GalleryDropDown galleryDropDown, bool enable)
        {
            BarEditItem barItem = new BarEditItem();
            barItem.Tag = name;
            barItem.Name = name;
            barItem.LargeGlyph = GetBitmapByName("add", new Size(16, 16));
            barItem.Glyph = GetBitmapByName("add", new Size(16, 16));
            barItem.Enabled = enable;
            barItem.ItemClick += (s, e) =>
            {
                FilterItem item = new FilterItem();
                galleryDropDown.HidePopup();
                if (ShowFilterEditForm(item) == DialogResult.Cancel) return;
                BindFilterFile();
                SetItemChecked(item.FileName);
            };
            barItem.Caption = GetLocalizedCaption(name);
            galleryDropDown.ItemLinks.Add(barItem);
        }

        private DialogResult ShowFilterEditForm(FilterItem item)
        {
            var dialog = new FilterConditionList(item);
            dialog.OnSendFilterMessage += SendFilterMessage;
            if (string.IsNullOrEmpty(ControllerId))
            {
                ControllerId = ObjectName;
            }
            dialog.ControllerId = ControllerId;
            dialog.ObjectName = ObjectName;
            return dialog.ShowDialog();
        }

        void SendFilterMessage(object sender, AppFramework.Utils.EventArgs<string> e)
        {
            CriteriaOperator filter = CriteriaOperator.TryParse(e.Data);
            EventAggregationManager.SendMessage(new FilterChangedMessage
            {
                ObjectName = ObjectName,
                Filter = filter
            });
        }

        private void SetFilter(GalleryItem galleryItem)
        {
            if (galleryItem.Checked) return;
            galleryItem.GalleryGroup.Items.Cast<GalleryItem>().ToList().ForEach(i => i.Checked = false);
            galleryItem.Checked = true;
            FilterGalleryItem filterGalleryItem = (FilterGalleryItem)galleryItem;
            _filterName = filterGalleryItem.FilterItem.FileName;
            SendFilterMessage(null, new EventArgs<string>(filterGalleryItem.FilterItem.FilterString));
        }

        private DateTime GetFirstDayOfNextMonth()
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            if (month == 12)
            {
                month = 1;
                year = year + 1;
            }
            else
            {
                month = month + 1;
            }
            return new DateTime(year, month, 1);
        }
        private IEnumerable<FilterItem> GetListFilterItems()
        {
            string filterDirectory = GetFilterDirectory();
            if (Directory.Exists(filterDirectory))
            {
                var filterFiles = Directory.GetFiles(filterDirectory);
                foreach( var file in filterFiles)
                {
                    var item = new FilterItem()
                        {
                            FileName = Path.GetFileNameWithoutExtension(file),
                            Editable = true
                        };
                        var doc = XDocument.Load(file);
                        var filterProperty = doc.Descendants("property").FirstOrDefault();
                        if (filterProperty != null)
                        {
                            var template = new Template(filterProperty.Value, '$', '$');
                            DateTime firstDayOfThisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);                           
                            DateTime firstDayOfNextMonth = this.GetFirstDayOfNextMonth();
                            template.Add("UserName", AuthorizationManager.FullName);
                            template.Add("FirstDayOfThisMonth", firstDayOfThisMonth.ToShortDateString());
                            template.Add("FirstDayOfNextMonth", firstDayOfNextMonth.ToShortDateString());
                            item.FilterString = template.Render();
                        }
                        var orderProperty = doc.Descendants("order").FirstOrDefault();
                        if (orderProperty != null)
                        {
                            item.Order = Convert.ToInt32(orderProperty.Value);
                        }
                        var filterNameProperty = doc.Descendants("FilterName").FirstOrDefault();
                        if (filterNameProperty != null)
                        {
                            XAttribute attribute = filterNameProperty.Attribute("key");
                            item.DisplayName =
                                attribute == null ? filterNameProperty.Value : GetLocalizedCaption(attribute.Value);
                        }
                        else
                        {
                            item.DisplayName = item.FileName;
                        }
                        yield return item;
                }
            }
            yield return new FilterItem() { FileName = "None", Order = int.MaxValue, DisplayName = "(" + GetLocalizedCaption("None") + ")", Editable = false };
        }

        private string GetFilterDirectory()
        {
            string filtersDirectory = Path.Combine(Application.StartupPath + "\\AddIns", "Filters");
            string viewFilterDirectory = Path.Combine(filtersDirectory, ObjectName);
            return viewFilterDirectory;
        }

        protected string GetLocalizedCaption(string name)
        {
            return ResourceService.GetString(name);
        }

        //get delete filter info.
        private string GetDeleteFilterInfo(string resourceKey, string filterName)
        {
            string infoFormat = ResourceService.GetString(resourceKey);

            return string.Format(infoFormat, filterName);
        }

        #region IFilter
        public string GetSelectedFilterName()
        {
           List<GalleryItem> selectedItems = this.Gallery.GetCheckedItems();
           if (selectedItems.Count > 0)
           {
               FilterGalleryItem item = selectedItems[0] as FilterGalleryItem;
               return item.FilterItem.FileName;
           }
           else
           {
               return string.Empty;
           }
        }

        public void SetItemChecked(string filterName)
        {
            bool existFilter = false;
            foreach (FilterGalleryItem item in this.Gallery.GetAllItems())
            {
                if (item.FilterItem.FileName == filterName)
                {
                    SetFilter(item);
                    this.Gallery.ScrollTo(item, true);
                    existFilter = true;
                }
            }
            if (!existFilter && !string.IsNullOrEmpty(_filterName))
            {
                foreach (FilterGalleryItem item in this.Gallery.GetAllItems())
                {
                    if (item.FilterItem.FileName == _filterName)
                    {
                        SetFilter(item);
                        this.Gallery.ScrollTo(item, true);
                    }
                }
            }
        }
        #endregion
    }
}
