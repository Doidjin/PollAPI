using System.ComponentModel.DataAnnotations;

namespace PoolApi.Models
{
    public class OptionDatabase : Option
    {
        [Key]
         public int Id
        {
            get { return option_id; }
            set { option_id = value; }
        }

        public string Description
        {
            get { return option_description; }
            set { option_description = value; }
        }

        public int Poll_Id
        {
            get { return poll_id; }
            set { poll_id = value; }
        }
    }
}