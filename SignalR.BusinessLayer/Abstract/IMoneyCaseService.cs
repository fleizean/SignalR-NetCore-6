﻿using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        public decimal TTotalPriceMoneyCase();
    }
}

