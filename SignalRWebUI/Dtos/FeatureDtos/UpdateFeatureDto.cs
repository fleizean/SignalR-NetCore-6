using System;
namespace SignalRWebUI.Dtos.FeatureDtos
{
	public class UpdateFeatureDto
	{
        public int FeatureID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}

