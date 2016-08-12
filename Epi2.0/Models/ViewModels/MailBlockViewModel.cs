using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models.Blocks;

namespace WebClient.Models.ViewModels
{
    //id :- FRM013
    ///Author:Kunal Doshi
    

    public class MailBlockViewModel
    {
        

        public string From { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]

        public string SendTo { get; set; }

        public MailBlock mailblock { get; set; }

        public string pageURl { get; set; }
    }
}
