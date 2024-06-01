using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
	public class Feature
	{
		[Key]
		public int FeatureID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
	}
}

