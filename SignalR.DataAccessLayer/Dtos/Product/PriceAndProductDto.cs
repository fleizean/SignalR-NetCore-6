using System;
namespace SignalR.DataAccessLayer.Dtos.Product
{
	public class PriceAndProductDto
	{
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}

