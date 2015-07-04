using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using queuing.Models;

namespace queuing
{
    public partial class Main : Form
    {
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            Text = "排队系统";

            // Init();
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

                context.businessWithoutOrder.Add(new BusinessWithoutOrder
                {
                    Name = "张三三",
                    IDCard = "111111111111111111",
                    businessType = bt1,
                    CreateTime = DateTime.Now
                });
                context.businessWithoutOrder.Add(new BusinessWithoutOrder
                {
                    Name = "张三疯",
                    IDCard = "111111117283911111",
                    businessType = bt2,
                    CreateTime = DateTime.Now
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
                var business = GetBusiness(idCard);

                if (business == null)
                {
                    throw new Exception("此用户不存在");
                }

                if (CheckOrderTime(business.OrderTime))
                {
                    MessageBox.Show(@"超过预约时间10分钟,请重新预约或排队取号");
                    return;
                }

                var frmOrder = new Order(idCard);
                frmOrder.ShowDialog();
            }
            else
            {
                var frmWithoutOrder = new WithoutOrder(idCard);
                frmWithoutOrder.ShowDialog();
            }
        }

        private Business GetBusiness(string idCard)
        {
            using (var context = new BusinessContext())
            {
                return context.business.FirstOrDefault(a => a.IDCard.Equals(idCard));
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

        public bool CheckOrderTime(DateTime dt)
        {
            var dd = DateDiff(dt, DateTime.Now);

            return dd.TotalMinutes > 10;
        }

        private static TimeSpan DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            var ts1 = new TimeSpan(dateTime1.Ticks);
            var ts2 = new TimeSpan(dateTime2.Ticks);
            var ts = ts1.Subtract(ts2).Duration();

            return ts;
        }
    }
}
