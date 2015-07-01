using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queuing.Models
{
    [Table("tb_business_without_order")]
    public class BusinessWithoutOrder
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string IDCard { get; set; }
        public virtual BusinessType businessType { get; set; }
    }
}
