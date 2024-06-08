﻿using System;
namespace SignalRWebUI.Dtos.BasketDtos
{
	public class ResultBasketDto
	{
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}

