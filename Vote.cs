using System;
using System.ComponentModel.DataAnnotations;

namespace PoolApi
{
    public class Vote
    {
        public Nullable<System.DateTime> date { get; set; }
        
        [Key]
        public int option_id { get; set; }
    }
}