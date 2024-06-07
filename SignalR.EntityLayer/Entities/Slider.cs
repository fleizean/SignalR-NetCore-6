using System;
namespace SignalR.EntityLayer.Entities
{
	public class Slider
	{
		public int SliderID { get; set; }
		public int Row { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
	}
}

