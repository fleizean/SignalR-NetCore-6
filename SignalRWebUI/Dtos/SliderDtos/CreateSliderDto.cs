using System;
namespace SignalRWebUI.Dtos.SliderDtos
{
	public class CreateSliderDto
	{
        public int Row { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}

