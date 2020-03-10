using System;
using System.ComponentModel.DataAnnotations;

namespace PoolApi
{
    public class View
    {
        [Key]
        public int poll_id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }
}