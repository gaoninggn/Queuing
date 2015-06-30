using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace queuing.Models
{
    [Table("tb_business")]
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string IDCard { get; set; }
        public virtual BusinessType businessType { get; set; }
    }
}
