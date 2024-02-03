using System;
namespace SignalR.DTOLayer.ContactDto
{
	public class ResultContactDto
	{
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
    }
}

