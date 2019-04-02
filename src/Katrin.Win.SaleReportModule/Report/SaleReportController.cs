using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Controls;
using Katrin.AppFramework.WinForms.MVC;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using ICSharpCode.Core;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms;
using System.Drawing;
using System.ComponentModel;
using Katrin.Win.Common.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Services.Client;
using System.Linq.Dynamic;
namespace Katrin.Win.SaleReportModule.Report
{
    public class SaleReportController : ObjectController
    {
        private ISaleReportView _SaleReportView;
        private List<Domain.Impl.User> _users;
        private List<Domain.Impl.Department> _departMents;
        private RibbonControl _ribbon;
        private List<SaleOverview> overviewCollection = new List<SaleOverview>();
        private RepositoryItemLookUpEdit dimensionData = new RepositoryItemLookUpEdit();
        private BarEditItem targetItem;
        //BarEditItem chartTypeItem;
        private BarEditItem dimensionItem;
        private BarButtonItem pieBar;
        private BarButtonItem lineBar;
        private BarButtonItem barBar;
        private BarEditItem beginYear;
        private BarEditItem endYear;
        private BarEditItem beginMonth;
        private BarEditItem endMonth;
        /// <summary>
        ///  init unit type
        /// </summary>
        private BarEditItem unitTypeItem;
        private RepositoryItemPopupContainerEdit DimensionData;
        private BarButtonItem preBarItem = null;
        private int displayIndex = 0;
        private RepositoryItemPopupContainerEdit technicianData;
        private RepositoryItemPopupContainerEdit saleData;
        private string sortName;
        private BarEditItem beginSeasion;
        private BarEditItem endSeasion;
        /// <summary>
        /// init sales
        /// </summary>
        private List<Guid> OwnerIds
        {
            get { return saleData.GetSelection(); }
        }

        /// <summary>
        /// init Technician
        /// </summary>
        private List<Guid> TechnicianIds
        {
            get { return technicianData.GetSelection(); }
        }
        /// <summary>
        /// init Dimension
        /// </summary>
        private ArrayList Dimensions
        {
            get { return DimensionData.GetSelectionObjects(); }
        }


        public override IActionResult Execute(ActionParameters parameters)
        {
            _ribbon = parameters.Get<RibbonControl>("ribbonControl");
            _SaleReportView = ViewFactory.CreateView("DefaultSaleReportView") as ISaleReportView;

            OnViewSet();
            var result = new PartialViewResult();
            result.View = _SaleReportView;
            return result;
        }

        protected void OnViewSet()
        {
            _SaleReportView.SearchReport += View_SearchReport;
            _SaleReportView.NameCellClicked += View_NameCellClicked;
            _SaleReportView.OnViewReady += _SaleReportView_OnViewReady;
            _users = (List<Domain.Impl.User>)_objectSpace.GetObjects("User");
            _departMents = (List<Domain.Impl.Department>)_objectSpace.GetObjects("Department");
            SetMenu();
        }

        public override void Dispose()
        {
            if (_SaleReportView != null)
            {
                _SaleReportView.SearchReport -= View_SearchReport;
                _SaleReportView.NameCellClicked -= View_NameCellClicked;
                _SaleReportView.OnViewReady -= _SaleReportView_OnViewReady;
                _SaleReportView = null;
            }
            if (this._objectSpace != null)
            {
                this._objectSpace = null;
            }
            _users.Clear();
            _departMents.Clear();
            _ribbon = null;
            overviewCollection.Clear();
            dimensionData = null;
            targetItem = null;            
            dimensionItem = null;
            pieBar = null;
            lineBar = null;
            barBar = null;
            beginYear = null;
            endYear = null;
            beginMonth = null;
            endMonth = null;       
            unitTypeItem = null;
            DimensionData = null;
            preBarItem = null;
            technicianData = null;
            saleData = null;
            beginSeasion = null;
            endSeasion = null;
            base.Dispose();
        }

        void _SaleReportView_OnViewReady(object sender, EventArgs e)
        {
            OnViewReady();
        }

        public void OnViewReady()
        {
            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += (s, ex) =>
                {
                    ex.Result = GetSaleOverviewCollection();
                };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Result is IEnumerable)) return;
            overviewCollection = (List<SaleOverview>)e.Result;
            _SaleReportView.DimensionItemChange(Dimensions);
            BindReportData();
        }


        private void BindReportData()
        {
            bool sdepartMentName = false;
            bool sSalesName = false;
            bool sTechnologyName = false;
            bool sTechnologyPerson = false;
            var dimensionList = Dimensions.Cast<LookupListItem<int?>>().ToList();
            string defaultSort = "Year,Season,Month";
            Enum.GetNames(typeof(Dimension)).ToList().ForEach(name =>
                {
                    if (dimensionList.Select(c => c.DisplayName).ToList().Contains(GetLocalizedCaption(name)))
                    {
                        if (name == "SalesName") { sSalesName = true; defaultSort += "," + "SalesName"; }
                        if (name == "DepartMentName") { sdepartMentName = true; defaultSort += "," + "DepartMentName"; }
                        if (name == "TechnologyName") { sTechnologyName = true; defaultSort += "," + "TechnologyName"; }
                        if (name == "TechnologyPerson") { sTechnologyPerson = true; defaultSort += "," + "TechnologyPerson"; }
                    }
                });

            List<SaleOverview> dataResult = new List<SaleOverview>();
            dataResult.AddRange(
            overviewCollection.GroupBy(c => new
            {
                c.UnitType,
                c.UnitName,
                c.Season,
                c.Year,
                c.Month,
                DepartMentName = sdepartMentName ? c.DepartMentName : string.Empty,
                SalesName = sSalesName ? c.SalesName : string.Empty,
                TechnologyName = sTechnologyName ? c.TechnologyName : string.Empty,
                TechnologyPerson = sTechnologyPerson ? c.TechnologyPerson : string.Empty
            })
                .Select(group => new SaleOverview()
                {
                    UnitType = group.Key.UnitType,
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    Season = group.Key.Season,
                    SalesName = group.Key.SalesName,
                    DepartMentName = group.Key.DepartMentName,
                    TechnologyName = group.Key.TechnologyName,
                    TechnologyPerson = group.Key.TechnologyPerson,
                    LeadNumber = group.Sum(c => c.LeadNumber),
                    FirstEmailCount = group.Sum(c => c.FirstEmailCount),
                    NumberIntoOpportunity = group.Sum(c => c.NumberIntoOpportunity),
                    NumberOfTheDead = group.Sum(c => c.NumberOfTheDead),
                    OpportunityNumber = group.Sum(c => c.OpportunityNumber),
                    NumberIntoContract = group.Sum(c => c.NumberIntoContract),
                    ContractAmount = group.Sum(c => c.ContractAmount),
                    ContractNumber = group.Sum(c => c.ContractNumber),
                    OldCustomerNumber = group.Sum(c => c.OldCustomerNumber)

                }));
            if (!string.IsNullOrEmpty(sortName))
                dataResult = dataResult.AsQueryable().OrderBy("" + sortName + " desc").ToList();
            else
                dataResult = dataResult.AsQueryable().OrderBy("" + defaultSort + " desc").ToList();
            _SaleReportView.Bind((IEnumerable)dataResult);

        }

        void View_SearchReport(object sender, EventArgs e)
        {

        }

        void View_NameCellClicked(object sender, EventArgs<SaleOverview> e)
        {
        }


        private string GetUserName(Guid? userId)
        {
            var user = _users.Where(c => c.UserId == userId).FirstOrDefault();
            if (user == null) return string.Empty;
            return user.FullName;
        }
        private string GetDepartMentName(Guid? departMentId)
        {
            var departMent = _departMents.Where(c => c.DepartmentId == departMentId).FirstOrDefault();
            if (departMent == null) return string.Empty;
            return departMent.Name;
        }

        private void SetSeasion(int year, int minSeason, int maxSeason, List<SaleOverview> saleList)
        {
            for (int s = minSeason; s <= maxSeason; s++)
            {
                SaleOverview saleOverview = new SaleOverview();
                saleOverview.Year = year;
                saleOverview.Season = s;
                saleList.Add(saleOverview);
            }
        }
        private void SetMonth(int year, int minMonth, int maxMonth, List<SaleOverview> saleList)
        {
            for (int m = minMonth; m <= maxMonth; m++)
            {
                SaleOverview saleOverview = new SaleOverview();
                saleOverview.Year = year;
                saleOverview.Month = m;
                saleList.Add(saleOverview);
            }
        }
        private List<SaleOverview> GetNullTimeList(UnitType unitType, DateTime startDate, DateTime endDate)
        {
            List<SaleOverview> saleList = new List<SaleOverview>();
            int minYear = startDate.Year;
            int maxYear = endDate.Year;
            if (unitType == UnitType.Year)
            {
                for (int y = minYear; y <= maxYear; y++)
                {
                    SaleOverview saleOverview = new SaleOverview();
                    saleOverview.Year = y;
                    saleList.Add(saleOverview);
                }
            }
            else if (unitType == UnitType.Season)
            {
                int minSeason = startDate.Month / 3 + 1;
                int maxSeason = endDate.Month / 3 + 1;
                for (int y = minYear; y <= maxYear; y++)
                {
                    if ((maxYear - minYear) == 0)
                    {
                        SetSeasion(y, minSeason, maxSeason, saleList);
                    }
                    else
                    {
                        if (y == minYear)
                        {
                            SetSeasion(y, minSeason, 4, saleList);
                        }
                        else if (y == maxYear)
                        {
                            SetSeasion(y, 1, maxSeason, saleList);
                        }
                        else
                        {
                            SetSeasion(y, 1, 4, saleList);
                        }
                    }
                }
            }
            else
            {
                int minMonth = startDate.Month;
                int maxMonth = endDate.Month;
                for (int y = minYear; y <= maxYear; y++)
                {
                    if ((maxYear - minYear) == 0)
                    {
                        SetMonth(y, minMonth, maxMonth, saleList);
                    }
                    else
                    {
                        if (y == minYear)
                        {
                            SetMonth(y, minMonth, 12, saleList);
                        }
                        else if (y == maxYear)
                        {
                            SetMonth(y, 1, maxMonth, saleList);
                        }
                        else
                        {
                            SetMonth(y, 1, 12, saleList);
                        }
                    }
                }
            }
            return saleList;
        }

        private List<SaleOverview> GetSaleOverviewCollection()
        {
            List<SaleOverview> saleList = new List<SaleOverview>();
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            int byear = int.Parse(beginYear.EditValue.ToString());
            int bseason = int.Parse(beginSeasion.EditValue.ToString());
            int bmonth = int.Parse(beginMonth.EditValue.ToString());

            int ebyear = int.Parse(endYear.EditValue.ToString());
            int eseason = int.Parse(endSeasion.EditValue.ToString());
            int emonth = int.Parse(endMonth.EditValue.ToString());
            UnitType unitType = (UnitType)unitTypeItem.EditValue;
            if (unitType == UnitType.Month)
            {
                startDate = new DateTime(byear, bmonth, 1);
                endDate = new DateTime(ebyear, emonth, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
            }
            else if (unitType == UnitType.Season)
            {
                startDate = new DateTime(byear, bseason * 3 - 2, 1);
                endDate = new DateTime(ebyear, eseason * 3 - 2, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
            }
            else
            {
                startDate = new DateTime(byear, 1, 1);
                endDate = new DateTime(ebyear, 12, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
            }
            if (endDate > DateTime.Now) endDate = DateTime.Now;



            var leadQuery = (DataServiceQuery<Katrin.Domain.Impl.Lead>)_objectSpace.GetObjectQuery("Lead");
            var oppQuery = (DataServiceQuery<Katrin.Domain.Impl.Opportunity>)_objectSpace.GetObjectQuery("Opportunity");
            var contractQuery = (DataServiceQuery<Katrin.Domain.Impl.Contract>)_objectSpace.GetObjectQuery("Contract");

            var resultList1 = leadQuery.Where(c => ((c.ClosedOn == null) || (c.ClosedOn != null && c.ClosedOn > startDate))).ToList();
            var resultList11 = resultList1.GroupBy(c => new
            {
                Year = c.ClosedOn == null ? 0 : c.ClosedOn.Value.Year,
                Season = (unitType != UnitType.Season || c.ClosedOn == null) ? 0 : c.ClosedOn.Value.Month / 3 + 1,
                Month = (unitType != UnitType.Month || c.ClosedOn == null) ? 0 : c.ClosedOn.Value.Month,
                CreatedOnYear = c.CreatedOn == null ? 0 : c.CreatedOn.Value.Year,
                CreatedOnMonth = (unitType == UnitType.Year || c.CreatedOn == null) ? 0 : c.CreatedOn.Value.Month,
                c.Technology,
                c.OwnerId,
                c.DepartmentId
            })
                    .Select(group => new { group.Key, LeadNumber = group.Count(), MinCreatedOn = group.Min(c => c.CreatedOn) }).ToList();
            DateTime minCratedOn = (DateTime)resultList11.Min(c => c.MinCreatedOn);
            if (startDate > minCratedOn) minCratedOn = startDate;
            List<SaleOverview> nullList = GetNullTimeList(unitType, minCratedOn, endDate);
            foreach (var item in resultList11)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId ?? Guid.Empty)) continue;


                nullList.ForEach(c =>
                {
                    bool isEableAdd = false;
                    if (item.MinCreatedOn == null) isEableAdd = false;
                    else
                    {
                        isEableAdd = item.Key.CreatedOnYear <= c.Year && ((item.Key.Year == 0)
                            || (item.Key.Year > 0 && item.Key.Year >= c.Year)) && unitType == UnitType.Year;
                        if (!isEableAdd)
                        {
                            isEableAdd = item.Key.CreatedOnYear == c.Year && item.Key.CreatedOnMonth <= c.Month
                               && ((item.Key.Month == 0) || (item.Key.Month > 0 && item.Key.Month >= c.Month))
                                && ((item.Key.Season == 0) || (item.Key.Season > 0 && item.Key.Season >= c.Season));
                            bool diffrentYear = item.Key.CreatedOnYear < c.Year &&
                                (item.Key.Year == 0 ||
                              ((item.Key.Year > 0 && item.Key.Year > c.Year)
                              ||
                              (item.Key.Year > 0 &&
                              item.Key.Year == c.Year
                              && ((item.Key.Month == 0) || (item.Key.Month > 0 && item.Key.Month >= c.Month))
                                && ((item.Key.Season == 0) || (item.Key.Season > 0 && item.Key.Season >= c.Season))
                              ))
                              );
                            isEableAdd = isEableAdd || diffrentYear;
                            isEableAdd = isEableAdd && unitType != UnitType.Year;
                        }

                    }
                    if (isEableAdd)
                    {
                        SaleOverview overview = new SaleOverview();
                        overview.Year = c.Year;
                        overview.Season = c.Season;
                        overview.Month = c.Month;
                        overview.UnitType = unitType;
                        overview.TechnologyName = item.Key.Technology;
                        overview.SalesName = GetUserName(item.Key.OwnerId);
                        overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                        overview.TechnologyPerson = string.Empty;
                        overview.LeadNumber = item.LeadNumber;
                        saleList.Add(overview);
                    }
                });
            }


            var resultList2 = leadQuery.Where(c => c.FirstResponsedOn != null
                && c.FirstResponsedOn >= startDate && c.FirstResponsedOn <= endDate).ToList();
            var resultList22 = resultList2.GroupBy(c => new
            {
                c.FirstResponsedOn.Value.Year,
                Season = unitType != UnitType.Season ? 0 : c.FirstResponsedOn.Value.Month / 3 + 1,
                Month = unitType != UnitType.Month ? 0 : c.FirstResponsedOn.Value.Month,
                c.Technology,
                c.OwnerId,
                c.DepartmentId
            })
                    .Select(group => new { group.Key, FirstEmailCount = group.Count() }).ToList();
            foreach (var item in resultList22)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId ?? Guid.Empty)) continue;

                SaleOverview overview = new SaleOverview();
                overview.UnitType = unitType;
                overview.Year = item.Key.Year;
                overview.Month = item.Key.Month;
                overview.Season = item.Key.Season;
                overview.TechnologyName = item.Key.Technology;
                overview.SalesName = GetUserName(item.Key.OwnerId);
                overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                overview.TechnologyPerson = string.Empty;
                overview.FirstEmailCount = item.FirstEmailCount;
                saleList.Add(overview);
            }

            var leadIdList = oppQuery.Where(c => c.CreatedOn != null && c.CreatedOn >= startDate && c.CreatedOn <= endDate
                && c.OriginatingLeadId != null).Select(c => new { c.OriginatingLeadId, c.CreatedOn }).ToList();
            var resultList3 = leadQuery.Where(c => true).ToList();

            var resultList33 = resultList3.Join(leadIdList, i => i.LeadId, o => o.OriginatingLeadId, (slead, sopp) => new { slead, sopp.OriginatingLeadId, sopp.CreatedOn })
                .Where(c => c.OriginatingLeadId == c.slead.LeadId).GroupBy(c => new
                {
                    c.CreatedOn.Value.Year,
                    Season = unitType != UnitType.Season ? 0 : c.CreatedOn.Value.Month / 3 + 1,
                    Month = unitType != UnitType.Month ? 0 : c.CreatedOn.Value.Month,
                    c.slead.Technology,
                    c.slead.OwnerId,
                    c.slead.DepartmentId
                })
                .Select(group => new { group.Key, NumberIntoOpportunity = group.Count() });

            foreach (var item in resultList33)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId ?? Guid.Empty)) continue;

                SaleOverview overview = new SaleOverview();
                overview.UnitType = unitType;
                overview.Year = item.Key.Year;
                overview.Month = item.Key.Month;
                overview.Season = item.Key.Season;
                overview.TechnologyName = item.Key.Technology;
                overview.SalesName = GetUserName(item.Key.OwnerId);
                overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                overview.TechnologyPerson = string.Empty;
                overview.NumberIntoOpportunity = item.NumberIntoOpportunity;
                saleList.Add(overview);
            }

            var resultList4 = leadQuery.Where(c => c.ModifiedOn != null && c.ModifiedOn >= startDate
                && c.ModifiedOn <= endDate && c.StatusCode == 6).ToList();
            var resultList44 = resultList4.GroupBy(c => new
            {
                c.ModifiedOn.Value.Year,
                Season = unitType != UnitType.Season ? 0 : c.ModifiedOn.Value.Month / 3 + 1,
                Month = unitType != UnitType.Month ? 0 : c.ModifiedOn.Value.Month,
                c.Technology,
                c.OwnerId,
                c.DepartmentId
            })
                   .Select(group => new { group.Key, NumberOfTheDead = group.Count() }).ToList();
            foreach (var item in resultList44)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId ?? Guid.Empty)) continue;

                SaleOverview overview = new SaleOverview();
                overview.UnitType = unitType;
                overview.Year = item.Key.Year;
                overview.Month = item.Key.Month;
                overview.Season = item.Key.Season;
                overview.TechnologyName = item.Key.Technology;
                overview.SalesName = GetUserName(item.Key.OwnerId);
                overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                overview.TechnologyPerson = string.Empty;
                overview.NumberOfTheDead = item.NumberOfTheDead;
                saleList.Add(overview);
            }

            var resultList5 = oppQuery.Where(c => ((c.ClosedTime == null) || (c.ClosedTime != null && c.ClosedTime > startDate))).ToList();
            var resultList55 = resultList5.GroupBy(c => new
            {
                Year = c.ClosedTime == null ? 0 : c.ClosedTime.Value.Year,
                Season = (unitType != UnitType.Season || c.ClosedTime == null) ? 0 : c.ClosedTime.Value.Month / 3 + 1,
                Month = (unitType != UnitType.Month || c.ClosedTime == null) ? 0 : c.ClosedTime.Value.Month,
                CreatedOnYear = c.CreatedOn == null ? 0 : c.CreatedOn.Value.Year,
                CreatedOnMonth = (unitType == UnitType.Year || c.CreatedOn == null) ? 0 : c.CreatedOn.Value.Month,
                c.Technology,
                c.OwnerId,
                c.DepartmentId,
                c.TechnicianId
            })
                    .Select(group => new { group.Key, OpportunityNumber = group.Count(), MinCreatedOn = group.Min(c => c.CreatedOn) }).ToList();
            DateTime minoPPCratedOn = (DateTime)resultList55.Min(c => c.MinCreatedOn);
            if (startDate > minoPPCratedOn) minoPPCratedOn = startDate;
            List<SaleOverview> oppnullList = GetNullTimeList(unitType, minoPPCratedOn, endDate);
            foreach (var item in resultList55)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId ?? Guid.Empty)) continue;

                if (TechnicianIds != null && TechnicianIds.Count() > 0 && item.Key.TechnicianId != null
                    && !TechnicianIds.Contains(item.Key.TechnicianId ?? Guid.Empty)) continue;

                oppnullList.ForEach(c =>
                {
                    bool isEableAdd = false;
                    if (item.Key.CreatedOnYear == 0) isEableAdd = false;
                    else
                    {
                        isEableAdd = item.Key.CreatedOnYear <= c.Year && ((item.Key.Year == 0)
                           || (item.Key.Year > 0 && item.Key.Year >= c.Year)) && unitType == UnitType.Year;
                        if (!isEableAdd)
                        {
                            isEableAdd = item.Key.CreatedOnYear == c.Year && item.Key.CreatedOnMonth <= c.Month
                               && ((item.Key.Month == 0) || (item.Key.Month > 0 && item.Key.Month >= c.Month))
                                && ((item.Key.Season == 0) || (item.Key.Season > 0 && item.Key.Season >= c.Season));
                            bool diffrentYear = item.Key.CreatedOnYear < c.Year &&
                                (item.Key.Year == 0 ||
                              ((item.Key.Year > 0 && item.Key.Year > c.Year)
                              ||
                              (item.Key.Year > 0 &&
                              item.Key.Year == c.Year
                              && ((item.Key.Month == 0) || (item.Key.Month > 0 && item.Key.Month >= c.Month))
                                && ((item.Key.Season == 0) || (item.Key.Season > 0 && item.Key.Season >= c.Season))
                              ))
                              );
                            isEableAdd = isEableAdd || diffrentYear;
                            isEableAdd = isEableAdd && unitType != UnitType.Year;
                        }
                    }
                    if (isEableAdd)
                    {
                        SaleOverview overview = new SaleOverview();
                        overview.Year = c.Year;
                        overview.Month = c.Month;
                        overview.Season = c.Season;
                        overview.UnitType = unitType;
                        overview.TechnologyName = item.Key.Technology;
                        overview.SalesName = GetUserName(item.Key.OwnerId);
                        overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                        overview.TechnologyPerson = GetUserName(item.Key.TechnicianId);
                        overview.OpportunityNumber = item.OpportunityNumber;
                        saleList.Add(overview);
                    }
                });
            }


            var contractList = contractQuery.Where(c => c.CreatedOn != null && c.CreatedOn >= startDate && c.CreatedOn <= endDate
                && c.OpportunityId != null).Select(c => new { c.OpportunityId, c.CreatedOn }).ToList();
            var resultList6 = oppQuery.Where(c => true).ToList();

            var resultList66 = resultList6.Join(contractList, i => i.OpportunityId, o => o.OpportunityId, (sopp, sc) => new { sopp, sc.OpportunityId, sc.CreatedOn })
                .Where(c => c.OpportunityId == c.sopp.OpportunityId).GroupBy(c => new
                {
                    c.CreatedOn.Value.Year,
                    Season = unitType != UnitType.Season ? 0 : c.CreatedOn.Value.Month / 3 + 1,
                    Month = unitType != UnitType.Month ? 0 : c.CreatedOn.Value.Month,
                    c.sopp.Technology,
                    c.sopp.OwnerId,
                    c.sopp.DepartmentId,
                    c.sopp.TechnicianId
                })
                .Select(group => new { group.Key, NumberIntoContract = group.Count() });

            foreach (var item in resultList66)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId ?? Guid.Empty)) continue;

                if (TechnicianIds != null && TechnicianIds.Count() > 0 && item.Key.TechnicianId != null
                    && !TechnicianIds.Contains(item.Key.TechnicianId ?? Guid.Empty)) continue;

                SaleOverview overview = new SaleOverview();
                overview.UnitType = unitType;
                overview.Year = item.Key.Year;
                overview.Month = item.Key.Month;
                overview.Season = item.Key.Season;
                overview.TechnologyName = item.Key.Technology;
                overview.SalesName = GetUserName(item.Key.OwnerId);
                overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                overview.TechnologyPerson = GetUserName(item.Key.TechnicianId);
                overview.NumberIntoContract = item.NumberIntoContract;
                saleList.Add(overview);
            }

            var resultList7 = contractQuery.Where(c => c.CreatedOn != null && c.CreatedOn >= startDate && c.CreatedOn <= endDate).ToList();
            var oldCustomerQuery = contractQuery.Where(c => c.BillingCustomerId != null).ToList();
            var oldCustomer = oldCustomerQuery.GroupBy(c => c.BillingCustomerId).Select(group => new { group.Key, contractCount = group.Count() })
                .Where(c => c.contractCount > 1).Select(c => c.Key).ToList();
            var resultList77 = resultList7.Join(resultList6, c => c.OpportunityId, d => d.OpportunityId, (scontract, opp) => new { scontract, opp })
                .Where(c => (c.scontract.OpportunityId == c.opp.OpportunityId && c.scontract.Opportunity != null) || c.scontract.Opportunity == null)
                .GroupBy(c => new
                {
                    c.scontract.CreatedOn.Value.Year,
                    Season = unitType != UnitType.Season ? 0 : c.scontract.CreatedOn.Value.Month / 3 + 1,
                    Month = unitType != UnitType.Month ? 0 : c.scontract.CreatedOn.Value.Month,
                    c.opp.Technology,
                    c.scontract.OwnerId,
                    c.scontract.DepartmentId,
                    c.opp.TechnicianId
                })
                    .Select(group => new
                    {
                        group.Key,
                        ContractAmount = group.Sum(c => c.scontract.TotalPrice),
                        ContractNumber = group.Count(),
                        OldCustomerNumber = group.Count(d => oldCustomer.Contains(d.scontract.BillingCustomerId))
                    }).ToList();
            foreach (var item in resultList77)
            {
                if (OwnerIds != null && OwnerIds.Count() > 0 && item.Key.OwnerId != null
                    && !OwnerIds.Contains(item.Key.OwnerId)) continue;

                if (TechnicianIds != null && TechnicianIds.Count() > 0 && item.Key.TechnicianId != null
                    && !TechnicianIds.Contains(item.Key.TechnicianId ?? Guid.Empty)) continue;

                SaleOverview overview = new SaleOverview();
                overview.UnitType = unitType;
                overview.Year = item.Key.Year;
                overview.Month = item.Key.Month;
                overview.Season = item.Key.Season;
                overview.TechnologyName = item.Key.Technology;
                overview.SalesName = GetUserName(item.Key.OwnerId);
                overview.DepartMentName = GetDepartMentName(item.Key.DepartmentId);
                overview.TechnologyPerson = GetUserName(item.Key.TechnicianId);
                overview.ContractAmount = item.ContractAmount ?? 0;
                overview.ContractNumber = item.ContractNumber;
                overview.OldCustomerNumber = item.OldCustomerNumber;
                saleList.Add(overview);
            }
            return saleList;
        }



        private void SetPropertyValue(object source, string sourceProperty, object target, string targetProperty)
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourceProperty);
            var targetPropertyInfo = target.GetType().GetProperty(targetProperty);
            targetPropertyInfo.SetValue(target, sourcePropertyInfo.GetValue(source, null), null);
        }

        private object GetPropertyValue(object source, string sourceProperty)
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourceProperty);
            return sourcePropertyInfo.GetValue(source, null);
        }

        protected string GetLocalizedCaption(string name)
        {
            return StringParser.Parse("${res:" + name + "}");
        }

        #region set filter
        private void SetMenu()
        {
            //RibbonPage generalPage = (RibbonPage)WorkItem.RootWorkItem.UIExtensionSites[ExtensionSiteNames.Ribbon].First();
            RibbonControl ribbon = this._ribbon;
            RibbonController control = new RibbonController(ribbon, _SaleReportView.ReportPrintControl);
            ribbon.AutoSizeItems = true;
            string groupName = "GeneralPageGroup";
            // search
            InitUnitType(groupName, ribbon.Pages[0].Groups[0]);
            YearRang(groupName, ribbon.Pages[0].Groups[0]);
            SeasonRang(groupName, ribbon.Pages[0].Groups[0]);
            MonthRang(groupName, ribbon.Pages[0].Groups[0]);
            InitTechnicianPerson(groupName, ribbon.Pages[0].Groups[0]);
            InitSalePerson(groupName, ribbon.Pages[0].Groups[0]);
            InitSearchButton(groupName, ribbon.Pages[0].Groups[0]);

            // dimsion
            InitDimension(groupName, ribbon.Pages[0].Groups[1]);
            InitSort(groupName, ribbon.Pages[0].Groups[1]);
            InitSelectChart(groupName, ribbon.Pages[0].Groups[1], ribbon.Pages[0].Groups[2]);

            //
            ChartOperator(groupName, ribbon.Pages[0].Groups[2]);

        }


        private void BindEnum<T>(RepositoryItemLookUpEdit lookUpEdit, string emptyText, int? emptyValue)
        {
            var statusTypeNames = Enum.GetNames(typeof(T));
            var statusItems = statusTypeNames
                .Select(name => new LookupListItem<int?>
                {
                    DisplayName = GetLocalizedCaption(name),
                    Value = (int)Enum.Parse(typeof(T), name)
                }).ToList();
            if (!string.IsNullOrEmpty(emptyText))
            {
                string localizedEmptyText = GetLocalizedCaption(emptyText);
                statusItems.Insert(0, new LookupListItem<int?> { DisplayName = localizedEmptyText, Value = emptyValue });
            }
            lookUpEdit.Properties.InitializeLookUpEdit(statusItems);
        }


        private void InitUnitType(string groupName, RibbonPageGroup ribbonGroup)
        {
            unitTypeItem = new BarEditItem();
            unitTypeItem.Alignment = BarItemLinkAlignment.Right;
            unitTypeItem.Width = 100;
            unitTypeItem.Caption = GetLocalizedCaption("UnitType");
            unitTypeItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit unitTypeData = new RepositoryItemLookUpEdit();
            BindEnum<UnitType>(unitTypeData, null, null);
            unitTypeItem.Edit = unitTypeData;
            unitTypeItem.EditValue = (int)UnitType.Month;
            unitTypeData.Columns.Clear();
            unitTypeData.Columns.Add(new LookUpColumnInfo(unitTypeData.DisplayMember));
            unitTypeItem.EditValueChanged += unitTypeItem_EditValueChanged;
            ribbonGroup.ItemLinks.Add(unitTypeItem);
        }

        void unitTypeItem_EditValueChanged(object sender, EventArgs e)
        {
            if (((UnitType)unitTypeItem.EditValue) == UnitType.Month)
            {
                beginMonth.Visibility = BarItemVisibility.Always;
                endMonth.Visibility = BarItemVisibility.Always;
                beginSeasion.Visibility = BarItemVisibility.Never;
                endSeasion.Visibility = BarItemVisibility.Never;
            }
            else if (((UnitType)unitTypeItem.EditValue) == UnitType.Season)
            {
                beginMonth.Visibility = BarItemVisibility.Never;
                endMonth.Visibility = BarItemVisibility.Never;
                beginSeasion.Visibility = BarItemVisibility.Always;
                endSeasion.Visibility = BarItemVisibility.Always;
            }
            else
            {
                beginMonth.Visibility = BarItemVisibility.Never;
                endMonth.Visibility = BarItemVisibility.Never;
                beginSeasion.Visibility = BarItemVisibility.Never;
                endSeasion.Visibility = BarItemVisibility.Never;
            }
        }



        private void InitDimension(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem sourceDimensionItem = new BarEditItem();
            sourceDimensionItem.Alignment = BarItemLinkAlignment.Right;
            sourceDimensionItem.Width = 100;
            sourceDimensionItem.Caption = GetLocalizedCaption("AutoColumn");
            sourceDimensionItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            DimensionData = new RepositoryItemPopupContainerEdit();
            GridColumn column = new GridColumn();
            column.Name = "ColDisplayName";
            column.FieldName = "DisplayName";
            column.Caption = GetLocalizedCaption("AutoColumn");
            column.Visible = true;
            var dimensionNames = Enum.GetNames(typeof(Dimension));
            var dimensionItems =
                dimensionNames.Select(name => new LookupListItem<int?>
                {
                    DisplayName = GetLocalizedCaption(name),
                    Value = (int)Enum.Parse(typeof(Dimension), name)
                }).ToList();
            DimensionData.InitEdit(new List<GridColumn>() { column }, dimensionItems, "DisplayName", true);

            sourceDimensionItem.Edit = DimensionData;
            ribbonGroup.ItemLinks.Add(sourceDimensionItem);
            DimensionData.QueryResultValue += (sender, s) =>
                {
                    InitDimension();
                    _SaleReportView.DimensionItemChange(Dimensions);
                    BindReportData();
                    if (displayIndex == 0 || displayIndex == 2)
                    {
                        if (targetItem != null) targetItem.Enabled = true;
                        if (pieBar != null) pieBar.Enabled = true;
                        if (lineBar != null) lineBar.Enabled = true;
                        if (barBar != null) barBar.Enabled = true;
                        if (dimensionItem != null) dimensionItem.Enabled = true;
                    }
                    if (Dimensions.Count > 1)
                    {
                        if (targetItem != null) targetItem.Enabled = false;
                        if (pieBar != null) pieBar.Enabled = false;
                        if (lineBar != null) lineBar.Enabled = false;
                        if (barBar != null) barBar.Enabled = false;
                        if (dimensionItem != null) dimensionItem.Enabled = false;
                    }
                };
        }


        private void InitSort(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem sortItem = new BarEditItem();
            sortItem.Alignment = BarItemLinkAlignment.Right;
            sortItem.Width = 100;
            sortItem.Caption = GetLocalizedCaption("sortName");
            sortItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit sortData = new RepositoryItemLookUpEdit();

            string[] arrColums = {string.Empty, "LeadNumber", "FirstEmailCount",  "NumberIntoOpportunity", 
                                     "NumberOfTheDead", "OpportunityNumber","NumberIntoContract",
                                 "ContractAmount","ContractNumber"};
            List<LookupListItem<int?>> sortdataList = new List<LookupListItem<int?>>();
            for (int i = 0; i < arrColums.Count(); i++)
            {
                sortdataList.Add(new LookupListItem<int?>()
                {
                    DisplayName = string.IsNullOrEmpty(arrColums[i]) ? arrColums[i] :
                        GetLocalizedCaption(arrColums[i]),
                    Value = i
                });
            }
            sortData.Properties.InitializeLookUpEdit(sortdataList);

            sortItem.Edit = sortData;
            sortItem.EditValue = 0;
            sortItem.EditValueChanged += (sender, e) =>
                {
                    if (sortItem.EditValue == null) return;
                    if (string.IsNullOrEmpty(sortItem.EditValue.ToString())) return;
                    int sortIndex = int.Parse(sortItem.EditValue.ToString());
                    sortName = arrColums[sortIndex];
                    BindReportData();
                };
            ribbonGroup.ItemLinks.Add(sortItem);
        }

        private BarButtonItem NewBarItem(string barName)
        {
            BarButtonItem chartItem = new BarButtonItem();
            var icon = WinFormsResourceService.GetIcon(barName.ToLower());
            Image largeImage = icon.ToBitmap();
            chartItem.Name = barName;
            chartItem.ButtonStyle = BarButtonStyle.Check;
            chartItem.LargeGlyph = largeImage;
            chartItem.Glyph = new Bitmap(largeImage, new Size(16, 16));
            chartItem.Caption = ResourceService.GetString(barName);
            return chartItem;
        }
        private void InitSelectChart(string groupName, RibbonPageGroup ribbonGroup, RibbonPageGroup hideGroup)
        {
            var allBar = NewBarItem("All");
            allBar.Down = true;
            ribbonGroup.ItemLinks.Add(allBar);
            allBar.ItemClick += Bar_ItemClick;
            var listBar = NewBarItem("List");
            listBar.ItemClick += Bar_ItemClick;
            ribbonGroup.ItemLinks.Add(listBar);
            var diagramBar = NewBarItem("Diagram");
            diagramBar.ItemClick += Bar_ItemClick;
            ribbonGroup.ItemLinks.Add(diagramBar);
        }

        void Bar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item is BarButtonItem)
            {
                var barItem = e.Item as BarButtonItem;
                if (preBarItem != null) preBarItem.Down = false;
                barItem.Down = true;
                preBarItem = barItem;
                displayIndex = barItem.Name == "All" ? 0 : (barItem.Name == "List" ? 1 : 2);
                if (displayIndex == 0 || displayIndex == 2)
                {
                    if (targetItem != null && Dimensions.Count <= 1) targetItem.Enabled = true;
                    if (pieBar != null && Dimensions.Count == 0) pieBar.Enabled = true;
                    if (lineBar != null && Dimensions.Count <= 1) lineBar.Enabled = true;
                    if (barBar != null && Dimensions.Count <= 1) barBar.Enabled = true;
                    if (dimensionItem != null && Dimensions.Count <= 1) dimensionItem.Enabled = true;
                }
                else
                {
                    if (targetItem != null) targetItem.Enabled = false;
                    if (pieBar != null) pieBar.Enabled = false;
                    if (lineBar != null) lineBar.Enabled = false;
                    if (barBar != null) barBar.Enabled = false;
                    if (dimensionItem != null) dimensionItem.Enabled = false;
                }
                _SaleReportView.SelectChart(displayIndex);
            }
        }



        private void InitTechnicianPerson(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem technicianItem = new BarEditItem();
            technicianItem.Alignment = BarItemLinkAlignment.Right;
            technicianItem.Width = 100;
            technicianItem.Caption = GetLocalizedCaption("TechnologyPerson");
            technicianItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            technicianData = new RepositoryItemPopupContainerEdit();
            technicianData.InitEdit("User", "Department", true);
            technicianItem.Edit = technicianData;
            ribbonGroup.ItemLinks.Add(technicianItem, true);
        }


        private void InitSalePerson(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem saleItem = new BarEditItem();
            saleItem.Alignment = BarItemLinkAlignment.Right;
            saleItem.Width = 100;
            saleItem.Caption = GetLocalizedCaption("OwnerPerson").Replace(":", string.Empty);
            saleItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            saleData = new RepositoryItemPopupContainerEdit();
            saleData.InitEdit("User", "Department", true);
            saleItem.Edit = saleData;
            ribbonGroup.ItemLinks.Add(saleItem);
        }




        private void SetYears(RepositoryItemLookUpEdit lookUpEdit)
        {
            var years = new List<LookupListItem<int?>>();
            for (int y = 0; y < 30; y++)
            {
                int year = 2000 + y;
                years.Add(new LookupListItem<int?>() { DisplayName = year.ToString() + GetLocalizedCaption("Year"), Value = year });
            }
            lookUpEdit.Properties.InitializeLookUpEdit(years);
        }

        private void YearRang(string groupName, RibbonPageGroup ribbonGroup)
        {

            beginYear = new BarEditItem();
            beginYear.Alignment = BarItemLinkAlignment.Right;
            beginYear.Width = 100;
            beginYear.Caption = GetLocalizedCaption("beginYear");
            beginYear.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit beginYearData = new RepositoryItemLookUpEdit();
            SetYears(beginYearData);
            beginYear.Edit = beginYearData;
            beginYear.EditValue = DateTime.Now.Year;
            ribbonGroup.ItemLinks.Add(beginYear, true);

            endYear = new BarEditItem();
            endYear.Alignment = BarItemLinkAlignment.Right;
            endYear.Width = 100;
            endYear.Caption = GetLocalizedCaption("endYear");
            endYear.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit endYearData = new RepositoryItemLookUpEdit();
            SetYears(endYearData);
            endYear.Edit = endYearData;
            endYear.EditValue = DateTime.Now.Year;
            ribbonGroup.ItemLinks.Add(endYear);
        }


        private void SetSeasions(RepositoryItemLookUpEdit lookUpEdit)
        {
            var seasions = new List<LookupListItem<int?>>();
            for (int s = 1; s <= 4; s++)
            {
                seasions.Add(new LookupListItem<int?>() { DisplayName = s + GetLocalizedCaption("Season"), Value = s });
            }
            lookUpEdit.Properties.InitializeLookUpEdit(seasions);
        }

        private void SeasonRang(string groupName, RibbonPageGroup ribbonGroup)
        {

            beginSeasion = new BarEditItem();
            beginSeasion.Alignment = BarItemLinkAlignment.Right;
            beginSeasion.Visibility = BarItemVisibility.Never;
            beginSeasion.Width = 100;
            beginSeasion.Caption = GetLocalizedCaption("beginSeasion");
            beginSeasion.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit beginSeasonData = new RepositoryItemLookUpEdit();
            SetSeasions(beginSeasonData);
            beginSeasion.Edit = beginSeasonData;
            beginSeasion.EditValue = DateTime.Now.Month / 3 + 1;
            ribbonGroup.ItemLinks.Add(beginSeasion, true);

            endSeasion = new BarEditItem();
            endSeasion.Alignment = BarItemLinkAlignment.Right;
            endSeasion.Visibility = BarItemVisibility.Never;
            endSeasion.Width = 100;
            endSeasion.Caption = GetLocalizedCaption("endSeasion");
            endSeasion.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit endSeasionData = new RepositoryItemLookUpEdit();
            SetSeasions(endSeasionData);
            endSeasion.Edit = endSeasionData;
            endSeasion.EditValue = DateTime.Now.Month / 3 + 1;
            ribbonGroup.ItemLinks.Add(endSeasion);
        }


        private void SetMonths(RepositoryItemLookUpEdit lookUpEdit)
        {
            var months = new List<LookupListItem<int?>>();
            for (int s = 1; s <= 12; s++)
            {
                months.Add(new LookupListItem<int?>() { DisplayName = s + GetLocalizedCaption("Month"), Value = s });
            }
            lookUpEdit.Properties.InitializeLookUpEdit(months);
        }

        private void MonthRang(string groupName, RibbonPageGroup ribbonGroup)
        {

            beginMonth = new BarEditItem();
            beginMonth.Alignment = BarItemLinkAlignment.Right;
            beginMonth.Width = 100;
            beginMonth.Caption = GetLocalizedCaption("beginMonth");
            beginMonth.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit beginMonthData = new RepositoryItemLookUpEdit();
            SetMonths(beginMonthData);
            beginMonth.Edit = beginMonthData;
            beginMonth.EditValue = DateTime.Now.Month;
            ribbonGroup.ItemLinks.Add(beginMonth, true);

            endMonth = new BarEditItem();
            endMonth.Alignment = BarItemLinkAlignment.Right;
            endMonth.Width = 100;
            endMonth.Caption = GetLocalizedCaption("endMonth");
            endMonth.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit endMonthData = new RepositoryItemLookUpEdit();
            SetMonths(endMonthData);
            endMonth.Edit = endMonthData;
            endMonth.EditValue = DateTime.Now.Month;
            ribbonGroup.ItemLinks.Add(endMonth);
        }

        private void InitSearchButton(string groupName, RibbonPageGroup ribbonGroup)
        {
            var buttonItem = new BarButtonItem() { Caption = GetLocalizedCaption("Search") };

            var icon = WinFormsResourceService.GetIcon("search");
            Image largeImage = icon.ToBitmap();
            buttonItem.LargeGlyph = largeImage;
            buttonItem.Glyph = new Bitmap(largeImage, new Size(16, 16));


            buttonItem.ItemClick += (sender, e) =>
            {
                var worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += (s, ex) =>
                {
                    ex.Result = GetSaleOverviewCollection();
                };
                worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
                worker.RunWorkerAsync();
            };
            ribbonGroup.ItemLinks.Add(buttonItem, true);

        }



        private void ChartOperator(string groupName, RibbonPageGroup ribbonGroup)
        {
            targetItem = new BarEditItem();
            targetItem.Alignment = BarItemLinkAlignment.Right;
            targetItem.Width = 100;
            targetItem.Caption = GetLocalizedCaption("TargetName");
            targetItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            RepositoryItemLookUpEdit tagetData = new RepositoryItemLookUpEdit();

            string[] arrColums = { "LeadNumber", "FirstEmailCount",  "NumberIntoOpportunity", 
                                     "NumberOfTheDead", "OpportunityNumber","NumberIntoContract",
                                 "ContractAmount","ContractNumber"};
            List<LookupListItem<int?>> targets = new List<LookupListItem<int?>>();
            for (int i = 0; i < arrColums.Count(); i++)
            {
                targets.Add(new LookupListItem<int?>() { DisplayName = GetLocalizedCaption(arrColums[i]), Value = i });
            }
            tagetData.Properties.InitializeLookUpEdit(targets);

            targetItem.Edit = tagetData;
            targetItem.EditValue = 0;

            ribbonGroup.ItemLinks.Add(targetItem);


            dimensionItem = new BarEditItem();
            dimensionItem.Alignment = BarItemLinkAlignment.Right;
            dimensionItem.Width = 100;
            dimensionItem.Caption = GetLocalizedCaption("DiagramColumn");
            dimensionItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            dimensionItem.Edit = dimensionData;
            InitDimension();
            ribbonGroup.ItemLinks.Add(dimensionItem);
            pieBar = NewBarItem("PieDiagram");
            pieBar.Down = true;
            lineBar = NewBarItem("LineDiagram");
            barBar = NewBarItem("BarDiagram");
            ribbonGroup.ItemLinks.Add(pieBar);
            ribbonGroup.ItemLinks.Add(lineBar);
            ribbonGroup.ItemLinks.Add(barBar);
            pieBar.ItemClick += (sender, e) =>
                {
                    pieBar.Down = true;
                    barBar.Down = false;
                    lineBar.Down = false;
                    int tindex = int.Parse(targetItem.EditValue.ToString());
                    int dim = 0;
                    int chartType = 0;
                    if (pieBar.Down) chartType = 0;
                    else if (lineBar.Down) chartType = 1;
                    else if (barBar.Down) chartType = 2;
                    if (dimensionItem.EditValue != null)
                    {
                        dim = int.Parse(dimensionItem.EditValue.ToString());
                    }
                    _SaleReportView.ChangeChart(arrColums[tindex], dim, chartType);
                };
            lineBar.ItemClick += (sender, e) =>
                {
                    pieBar.Down = false;
                    barBar.Down = false;
                    lineBar.Down = true;
                    int tindex = int.Parse(targetItem.EditValue.ToString());
                    int dim = 0;
                    int chartType = 0;
                    if (pieBar.Down) chartType = 0;
                    else if (lineBar.Down) chartType = 1;
                    else if (barBar.Down) chartType = 2;
                    if (dimensionItem.EditValue != null)
                    {
                        dim = int.Parse(dimensionItem.EditValue.ToString());
                    }
                    _SaleReportView.ChangeChart(arrColums[tindex], dim, chartType);
                };

            barBar.ItemClick += (sender, e) =>
                {
                    pieBar.Down = false;
                    barBar.Down = true;
                    lineBar.Down = false;
                    int tindex = int.Parse(targetItem.EditValue.ToString());
                    int dim = 0;
                    int chartType = 0;
                    if (pieBar.Down) chartType = 0;
                    else if (lineBar.Down) chartType = 1;
                    else if (barBar.Down) chartType = 2;
                    if (dimensionItem.EditValue != null)
                    {
                        dim = int.Parse(dimensionItem.EditValue.ToString());
                    }
                    _SaleReportView.ChangeChart(arrColums[tindex], dim, chartType);
                };

            targetItem.EditValueChanged += (sender, e) =>
                {
                    int tindex = int.Parse(targetItem.EditValue.ToString());
                    int dim = 0;
                    if (dimensionItem.EditValue != null)
                    {
                        dim = int.Parse(dimensionItem.EditValue.ToString());
                    }
                    int chartType = 0;
                    if (pieBar.Down) chartType = 0;
                    else if (lineBar.Down) chartType = 1;
                    else if (barBar.Down) chartType = 2;
                    _SaleReportView.ChangeChart(arrColums[tindex], dim, chartType);
                };
            dimensionItem.EditValueChanged += (sender, e) =>
                {
                    int tindex = int.Parse(targetItem.EditValue.ToString());
                    int dim = 0;
                    if (dimensionItem.EditValue != null)
                    {
                        dim = int.Parse(dimensionItem.EditValue.ToString());
                    }
                    if (dim > 0 && pieBar.Down)
                    {
                        pieBar.Enabled = false;
                        pieBar.Down = false;
                        lineBar.Down = true;
                    }
                    else if (dim <= 0)
                    {
                        pieBar.Enabled = true;
                    }
                    int chartType = 0;
                    if (pieBar.Down) chartType = 0;
                    else if (lineBar.Down) chartType = 1;
                    else if (barBar.Down) chartType = 2;

                    _SaleReportView.ChangeChart(arrColums[tindex], dim, chartType);
                };
        }

        private void InitDimension()
        {
            if (dimensionData == null) return;
            List<LookupListItem<int?>> dimensionList = new List<LookupListItem<int?>>();
            dimensionList.Add(new LookupListItem<int?>() { DisplayName = string.Empty, Value = 0 });
            foreach (var item in Dimensions)
            {
                LookupListItem<int?> lookup = (LookupListItem<int?>)item;
                dimensionList.Add(new LookupListItem<int?>() { DisplayName = lookup.DisplayName, Value = lookup.Value });
            }
            dimensionData.Properties.InitializeLookUpEdit(dimensionList);
        }

        #endregion

        #region no user

        public override object SelectedObject
        {
            get { throw new NotImplementedException(); }
        }
        #endregion


    }
}
