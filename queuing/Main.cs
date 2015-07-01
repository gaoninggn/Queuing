using queuing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace queuing
{
    public partial class Main : Form
    {
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            this.Text = "排队系统";

            //Init();
        }

        private void Init()
        {
            using (var context = new BusinessContext())
            {
                var bt1 = new BusinessType
                {
                    Name = "机动车业务"
                };
                var bt2 = new BusinessType
                {
                    Name = "驾驶证业务"
                };

                context.businessType.AddRange(new[] { bt1, bt2 });

                context.business.Add(new Business
                {
                    IDCard = "232321029293817283",
                    CreateTime = DateTime.Now,
                    OrderTime = DateTime.Parse("2015-7-1"),
                    ComingTime = DateTime.Parse("2015-7-1"),
                    businessType = bt2,
                    Name = "李一花"
                });
                context.business.Add(new Business
                {
                    IDCard = "232323798193817283",
                    CreateTime = DateTime.Now,
                    OrderTime = DateTime.Parse("2015-7-1"),
                    ComingTime = DateTime.Parse("2015-7-1"),
                    businessType = bt2,
                    Name = "李二花"
                });
                context.business.Add(new Business
                {
                    IDCard = "232323218210417283",
                    CreateTime = DateTime.Now,
                    OrderTime = DateTime.Parse("2015-7-1"),
                    ComingTime = DateTime.Parse("2015-7-1"),
                    businessType = bt2,
                    Name = "李三花"
                });

                context.SaveChanges();
            }
        }

        private void btnQueuing_Click(object sender, EventArgs e)
        {
            var idCard = textBox1.Text.Trim();
            var validateResult = ValidateIdCard(idCard);

            if (!validateResult)
            {
                MessageBox.Show("身份证格式错误", "提示");
                return;
            }

            var isOrder = IsOrder(idCard);

            if (isOrder)
            {
                var frmOrder = new Order(idCard);
                frmOrder.ShowDialog();
            }
            else
            {
                var frmWithoutOrder = new WithoutOrder(idCard);
                frmWithoutOrder.ShowDialog();
            }
        }

        private bool AddWithoutOrder(string idcard)
        {
            using (var context = new BusinessContext())
            {
                var bwo = new BusinessWithoutOrder
                {
                    IDCard = idcard,
                    CreateTime = DateTime.Now
                };
                context.businessWithoutOrder.Add(bwo);
                return context.SaveChanges() > 0;
            }
        }

        private bool IsOrder(string idCard)
        {
            using (var context = new BusinessContext())
            {
                return context.business.Count(a => a.IDCard.Equals(idCard)) > 0;
            }
        }

        private static bool ValidateIdCard(string idCard)
        {
            var reg = new Regex(@"^\d{17}(\d|x)$");

            return reg.IsMatch(idCard);
        }

        private void btnCalling_Click(object sender, EventArgs e)
        {
            var frmCalling = new Calling();
            frmCalling.ShowDialog();
        }
    }
}
