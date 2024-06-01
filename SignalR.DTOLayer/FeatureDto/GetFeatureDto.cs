using System;
namespace SignalR.DTOLayer.FeatureDto
{
	public class GetFeatureDto
	{
        public int FeatureID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}

