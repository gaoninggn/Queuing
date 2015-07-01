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
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 刷卡时间
        /// </summary>
        public DateTime ComingTime { get; set; }
        public string IDCard { get; set; }
        public virtual BusinessType businessType { get; set; }
    }
}
