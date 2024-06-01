using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Location { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
    }
}