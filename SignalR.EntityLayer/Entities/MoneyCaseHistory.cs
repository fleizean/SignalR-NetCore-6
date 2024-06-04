using System;
namespace SignalR.EntityLayer.Entities
{
	public class MoneyCaseHistory
	{
		public int MoneyCaseHistoryID { get; set; }
		public decimal Amount { get; set; }
		public string TransactionType { get; set; }
		public DateTime TransactionDate { get; set; }
	}
}

