using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Katrin.Win.Common.Properties;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Antlr4.StringTemplate;
using System.Xml.Linq;
using Katrin.Win.Common.Security;
using System.IO;
using Katrin.Win.Common.Core;
using System.Drawing;
using Katrin.Win.Common.FilterCondition;
using Microsoft.Practices.CompositeUI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Common.Constants;
using DevExpress.Data.Filtering;

namespace Katrin.Win.Common.Controls
{
    public class RibbonGalleryBar : RibbonGalleryBarItem
    {
        private WorkItem _workItem;
        private EntityListView _view;
        private ColumnView _entityGridView;
        private string _entityName;
        private string _gridFilter = "GridFilter";
        public RibbonGalleryBar(WorkItem workItem, EntityListView contentView,string entityName)
        {
            this.Name = "FilterGalleryBar";
            _workItem = workItem;
            _view = contentView;
            _entityGridView = contentView.EntityGridView;
            _entityName = entityName;
        }

        public void InitFilters()
        {
            Ribbon.ShowCustomizationMenu += (s, e) => e.ShowCustomizationMenu = false;
            Ribbon.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && hasClick)
                {
                    PopupMenu(Ribbon).ShowPopup(new System.Drawing.Point(e.X, e.Y));
                    hasClick = false;
                }
            };
            this.GalleryItemClick += (s, e) =>
            {
                hasClick = true;
                editGalleryItem = e.Item;
                SetFilter(e.Item);
            };
            this.GalleryItemHover += (s, e) =>
            {
                hasClick = true; editGalleryItem = e.Item;
            };
            this.GalleryItemLeave += (s, e) => { hasClick = false; editGalleryItem = null; };
            this.Gallery.ColumnCount = 3;
            this.Gallery.RowCount = 7;
            this.Gallery.ShowItemText = true;
             
            //this.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = new System.Drawing.Font("??", 8F);
            this.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            //this.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = new System.Drawing.Font("??", 8F);
            this.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            this.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.Gallery.DistanceBetweenItems = 0;

            GalleryDropDown galleryDropDown = new GalleryDropDown();
            galleryDropDown.Ribbon = Ribbon;
            //galleryDropDown.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = new System.Drawing.Font("??", 8F);
            galleryDropDown.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            galleryDropDown.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            //galleryDropDown.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = new System.Drawing.Font("??", 8F);
            galleryDropDown.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            galleryDropDown.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            galleryDropDown.Gallery.ShowGroupCaption = false;
            galleryDropDown.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            galleryDropDown.Gallery.ColumnCount = 2;
            galleryDropDown.Gallery.RowCount = 7;
            galleryDropDown.Gallery.ShowItemText = true;
            galleryDropDown.GalleryItemClick += (s, e) => SetFilter(e.Item);
            SetBarItem("AddFilter", galleryDropDown, true);
            this.GalleryDropDown = galleryDropDown;

            BindFilterFile();
        }

        private bool hasClick = false;
        private GalleryItem editGalleryItem = null;
        private PopupMenu PopupMenu(RibbonControl Ribbon)
        {
            PopupMenu menu = new PopupMenu();
            menu.Ribbon = Ribbon;
            string[] menuItemString = { "EditFilter", "DeleteFilter" };
            string[] imgString = {"edit","delete"};
            for (int i = 0; i < menuItemString.Length; i++)
            {
                BarEditItem barItem = new BarEditItem();
                barItem.Name = menuItemString[i];
                barItem.LargeGlyph = GetBitmapByName(imgString[i], new Size(16, 16));
                barItem.Glyph = GetBitmapByName(imgString[i], new Size(16, 16));
                //barItem.ImageIndex = 0;
                barItem.Caption = GetLocalizedCaption(menuItemString[i]);
                barItem.Tag = menu;
                barItem.ItemClick += (s, e) =>
                {
                    if (e.Item.Name == "EditFilter" && editGalleryItem != null)
                    {
                        PopupMenu pMenu = e.Item.Tag as PopupMenu;
                        if (pMenu != null)
                        {
                            pMenu.HidePopup();
                        }
                        string key = _entityName + ":EditFilterConditionList";
                        var filterConditionListView = _workItem.Items.Get<FilterConditionList>(key);
                        if (filterConditionListView == null) filterConditionListView = _workItem.Items.AddNew<FilterConditionList>(key);
                        string[] tagInfos = editGalleryItem.Tag.ToString().Split(new char[] { '¹' });
                        filterConditionListView.SetGridView(_view, tagInfos[1], editGalleryItem.Caption, tagInfos[0]);
                        filterConditionListView.EntityTypeName = _entityName;
                        filterConditionListView.ShowDialog();
                        BindFilterFile();
                    }
                    else if (e.Item.Name == "DeleteFilter" && editGalleryItem != null)
                    {
                        DialogResult dialogResult = XtraMessageBox.Show(Ribbon, Properties.Resources.DeleteFilterTip,
                          Properties.Resources.Katrin,
                          MessageBoxButtons.OKCancel,
                          MessageBoxIcon.Question,
                          MessageBoxDefaultButton.Button1);
                        if (dialogResult == DialogResult.OK)
                        {
                            string FiltersDirectory = Path.Combine(Application.StartupPath, "Filters");
                            string viewFilterDirectory = Path.Combine(FiltersDirectory, _entityName);
                            string[] tagInfos = editGalleryItem.Tag.ToString().Split(new char[] { '¹' });
                            string fileFullName = Path.Combine(viewFilterDirectory, tagInfos[1] + ".xml");
                            if (File.Exists(fileFullName))
                            {
                                File.Delete(fileFullName);
                                BindFilterFile();
                            }
                        }
                        PopupMenu pMenu = e.Item.Tag as PopupMenu;
                        if (pMenu != null)
                        {
                            pMenu.HidePopup();
                        }
                        editGalleryItem = null;
                    }
                };
                menu.AddItem(barItem);
            }
            return menu;
        }

        private void BindFilterFile()
        {
            CriteriaOperator currentCriteria = _view.Context.GetFilter(_gridFilter);
            var viewItems = GetListFilterItems();
            IEnumerable<ListFilterItem> items = viewItems.OrderBy(i => i.Order).ToList();
            GalleryItemGroup itemGroup = new GalleryItemGroup();
            foreach (ListFilterItem item in items)
            {
                GalleryItem galleryItem = new GalleryItem();
                galleryItem.Caption = item.FilterName + " ";
                galleryItem.Image = (Image)Properties.Resources.ResourceManager.GetObject("tag");
                galleryItem.HoverImage = galleryItem.Image;
                string filterString = item.FilterString;
                bool isCrietiaEqual = IsCriteriaOperatorEquals(currentCriteria, CriteriaOperator.TryParse(filterString));
                galleryItem.Checked = isCrietiaEqual;
                galleryItem.Tag = item.FilterString + "¹" + item.Name;
                itemGroup.Items.Add(galleryItem);
            }
            if (!itemGroup.Items.Cast<GalleryItem>().Any(i => i.Checked) && itemGroup.Items.Count > 0)
            {
                itemGroup.Items.Cast<GalleryItem>().Last().Checked = true;
            }
            this.Gallery.Groups.Clear();
            this.GalleryDropDown.Gallery.Groups.Clear();
            this.Gallery.Groups.Add(itemGroup);
            this.GalleryDropDown.Gallery.Groups.AddRange(new[] { itemGroup });
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
                galleryDropDown.HidePopup();
                string key = _entityName + ":AddFilterConditionList";
                var filterConditionListView = _workItem.Items.Get<FilterConditionList>(key);
                if (filterConditionListView == null)
                    filterConditionListView = _workItem.Items.AddNew<FilterConditionList>(key);
                filterConditionListView.SetGridView(_view, "", "", "");
                filterConditionListView.EntityTypeName = _entityName;
                filterConditionListView.ShowDialog();
                BindFilterFile();
            };
            barItem.Caption = GetLocalizedCaption(name);
            galleryDropDown.ItemLinks.Add(barItem);
        }

        private void SetFilter(GalleryItem galleryItem)
        {
            if (galleryItem != null)
            {
                galleryItem.GalleryGroup.Items.Cast<GalleryItem>().ToList().ForEach(i => i.Checked = false);
                galleryItem.Checked = true;
                string[] tagInfos = galleryItem.Tag.ToString().Split(new char[] { '¹' });
                CriteriaOperator filter = CriteriaOperator.TryParse(tagInfos[0]);
                _view.Context.SetFilter(_gridFilter, filter);
                _view.Context.RefreshData();
            }
        }

        private IEnumerable<ListFilterItem> GetListFilterItems()
        {
            var viewItems = new List<ListFilterItem>();
            string filtersDirectory = Path.Combine(Application.StartupPath, "Filters");
            string viewFilterDirectory = Path.Combine(filtersDirectory, _entityName);
            if (Directory.Exists(viewFilterDirectory))
            {
                var filterFiles = Directory.GetFiles(viewFilterDirectory);
                var items =
                    filterFiles.Select(filterFile =>
                    {
                        var item = new ListFilterItem()
                        {
                            Name = Path.GetFileNameWithoutExtension(filterFile),
                            IsSystemView = true
                        };
                        var doc = XDocument.Load(filterFile);
                        var filterProperty = doc.Descendants("property")
                            .FirstOrDefault();
                        if (filterProperty != null)
                        {
                            var template = new Template(filterProperty.Value, '$', '$');
                            DateTime firstDayOfThisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                            DateTime firstDayOfNextMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
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
                            item.FilterName = attribute == null ? filterNameProperty.Value :
                                GetLocalizedCaption(attribute.Value);
                        }
                        else
                        {
                            item.FilterName = item.Name;
                        }
                        return item;
                    });
                viewItems.AddRange(items);
            }
            viewItems.Add(new ListFilterItem() { Name = "None", Order=9999, FilterName = "(" + GetLocalizedCaption("None") + ")", IsSystemView = true, FilterString = string.Empty });
            return viewItems;
        }

        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }
    }
}
