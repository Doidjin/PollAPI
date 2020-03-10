using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoolApi.Models
{
    public class PoolDatabase : Pool
    {
        [Key]
        public int Id { get { return poll_id; } set { poll_id = value; } }

        public string Description { get {return poll_description;} set { poll_description = value;} }

        //public List<string> OptionsList
        //{
          //  get
            //{
              //  return Options;
            //}

        //}
        public OptionsValidatorEntity Options { get; set; }
    }
}