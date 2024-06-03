﻿using System;
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

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMenuTableService menuTableService, IOrderService orderService, IMoneyCaseService moneyCaseService, IDiscountService discountService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _menuTableService = menuTableService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _discountService = discountService;
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
                    ProductPriceAvg = productPriceAvg.ToString("0.00") + "₺",
                    LowestProductName = lowestProductName,
                    MostValuableCategory = mostValuableCategory,
                    AtLeastValuableCategory = atLeastValuableCategory,
                    LastOrderPrice = lastOrderPrice,
                    TotalActiveOrder = totalActiveOrder,
                    TableCount = tableCount,
                    TotalPriceMoneyCase = totalPriceMoneyCase.ToString("0.00") + "₺",
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

       
    }
}

