using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoolApi
{
    public class Pool
    {
        [Key]
        public int poll_id { get; set; }
        public string poll_description { get; set; }

        //public virtual List<string> Options {get;set;}

        public class OptionsValidatorEntity
        {
            public Pool Options { get; set; }
            
        }
    }
}