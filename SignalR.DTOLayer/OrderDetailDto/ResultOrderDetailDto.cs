﻿using System;
namespace SignalR.DTOLayer.OrderDetailDto
{
	public class ResultOrderDetailDto
	{
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
    }
}

