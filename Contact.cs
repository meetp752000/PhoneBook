using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase2
{
    //A contact class which has a name and number for each contact.
    class Contact
    {
 
        public String name { get; set; }
        public String number { get; set; }
        public Contact(String name, String number)
        {
            this.name = name;
            this.number = number;
        }
  


    }
}
