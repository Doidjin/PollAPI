using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoolApi
{
    public class Option
    {
        [Key]
        public int option_id { get; set; }
        public string option_description { get; set; }
        public int poll_id { get; set; }
    }
}