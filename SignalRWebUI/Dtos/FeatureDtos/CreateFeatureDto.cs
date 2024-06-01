using System;
namespace SignalRWebUI.Dtos.FeatureDtos
{
	public class CreateFeatureDto
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}

