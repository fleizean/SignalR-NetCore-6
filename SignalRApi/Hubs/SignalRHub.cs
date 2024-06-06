using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;


namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
	{
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMenuTableService _menuTableService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IDiscountService _discountService;
        private readonly IMoneyCaseHistoryService _moneyCaseHistoryService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMenuTableService menuTableService, IOrderService orderService, IMoneyCaseService moneyCaseService, IDiscountService discountService, IMoneyCaseHistoryService moneyCaseHistoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _menuTableService = menuTableService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _discountService = discountService;
            _moneyCaseHistoryService = moneyCaseHistoryService;
        }

        public async Task TakeDashboardCounts()
        {
            try
            {
                var categoryCount = _categoryService.TCategoryCount();
                var mostValuableCategory = _categoryService.TMostValuableCategory();
                var activeCategoryCount = _categoryService.TActiveCategoryCount();
                var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
                var productCount = _productService.TProductCount();
                var highestProductName = _productService.THighestProductPriceName();
                var productPriceAvg = _productService.TProductPriceAverage();
                var lowestProductName = _productService.TLowestProductPriceName();
                var atLeastValuableCategory = _categoryService.TAtLeastValuableCategory();
                var lastOrderPrice = _orderService.TLastOrderPrice();
                var totalActiveOrder = _orderService.TTotalActiveOrderCount();
                var tableCount = _menuTableService.TMenuTableCount();
                var totalPriceMoneyCase = _moneyCaseService.TTotalPriceMoneyCase();
                var todayTotalPrice = _orderService.TTodayTotalPrice();
                var lastDiscountProduct = _discountService.TLastDiscountProduct();
                var mostDiscountAmount = _discountService.TMostDiscountAmount();

                var dashboardCounts = new
                {
                    CategoryCount = categoryCount,
                    ProductCount = productCount,
                    ActiveCategoryCount = activeCategoryCount,
                    PassiveCategoryCount = passiveCategoryCount,
                    HighestProductName = highestProductName,
                    ProductPriceAvg = Math.Round(productPriceAvg, 2).ToString("0.00") + " ₺",
                    LowestProductName = lowestProductName,
                    MostValuableCategory = mostValuableCategory,
                    AtLeastValuableCategory = atLeastValuableCategory,
                    LastOrderPrice = Math.Round(lastOrderPrice, 2).ToString("0.00") + " ₺",
                    TotalActiveOrder = totalActiveOrder,
                    TableCount = tableCount,
                    TotalPriceMoneyCase = Math.Round(totalPriceMoneyCase, 2).ToString("0.00") + " ₺",
                    TodayTotalPrice = todayTotalPrice.ToString("0.00") + "₺",
                    LastDiscountProduct = lastDiscountProduct,
                    MostDiscountAmount = mostDiscountAmount.ToString() + "%",
                };

                await Clients.Caller.SendAsync("ReceiveDashboardCounts", dashboardCounts);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ReceiveDashboardCountsError", ex.Message);
            }
        }

        public async Task TakeProgress()
        {
            try
            {
                var totalMoneyCase = _moneyCaseService.TTotalPriceMoneyCase();
                var moneyCaseHistories = _moneyCaseHistoryService.TMoneyCaseHistories();
                var activeOrders = _orderService.TGetActiveOrdersWithDetails();
                var todayTotalPrice = _orderService.TTodayTotalPrice();
                var totalActiveOrder = _orderService.TTotalActiveOrderCount();
                var productPriceAvg = _productService.TProductPriceAverage();
                var activeMenuTable = _menuTableService.TActiveMenuTable();
                var highestProductName = _productService.THighestProductPriceName();
                var lastOrderPrice = _orderService.TLastOrderPrice();
                var muchSelling = _orderService.TMostSellingOrders();
                var productStatList = _productService.TPriceAndProductList();

                var adminStatistic = new
                {
                    TotalMoneyCase = Math.Round(totalMoneyCase, 2).ToString("0.00") + " ₺",
                    MoneyCaseHistories = moneyCaseHistories,
                    ActiveOrders = activeOrders,

                    TodayTotalPrice = todayTotalPrice,
                    TotalActiveOrder = totalActiveOrder,
                    ProductPriceAvg = productPriceAvg,
                    ActiveMenuTable = activeMenuTable,
                    HighestProductName = highestProductName,
                    LastOrderPrice = lastOrderPrice,
                    MuchSelling = muchSelling,
                    ProductStatList = productStatList,
                };

                await Clients.Caller.SendAsync("ReceiveAdminStatistics", adminStatistic);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ReceiveAdminStatisticsError", ex.Message);
            }
        }

       
    }
}

