using System;
namespace SignalR.DTOLayer.SliderDto
{
	public class CreateSliderDto
	{
        public int Row { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}

