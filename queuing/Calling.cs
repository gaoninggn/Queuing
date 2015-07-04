using System;
using System.Linq;
using System.Windows.Forms;
using queuing.Models;

namespace queuing
{
    public partial class Calling : Form
    {
        private int _orderCount = -1;
        private int _withoutCount = -1;

        public Calling()
        {
            InitializeComponent();
        }

        private void Calling_Load(object sender, EventArgs e)
        {
            Reflush();
        }

        private void Reflush()
        {
            var orderList = GetOrders(out _orderCount);
            var withoutList = GetWithoutOrder(out _withoutCount);

            dgvOrder.DataSource = orderList;
            dgvWithoutOrder.DataSource = withoutList;

            label1.Text += ":" + _orderCount;
            label2.Text += ":" + _withoutCount;
        }

        private void BtnCalling_Click(object sender, EventArgs e)
        {
            if (_orderCount <= 0)
            {
                var user = CallingWithoutOrder();
                MessageBox.Show("请" + user + "到X号窗口");
                RemoveWithoutOrder(user);
            }
            else
            {
                var user = CallingOrder();
                MessageBox.Show("请" + user + "到X号窗口");
                RemoveOrder(user);
            }

            Reflush();
        }

        private static dynamic GetOrders(out int count)
        {
            using (var context = new BusinessContext())
            {
                var orderList = context.business.Select(a => new
                {
                    a.IDCard,
                    a.Name,
                    a.OrderTime,
                    a.Id,
                    typeName = a.businessType.Name
                }).ToList();
                count = orderList.Count;

                return orderList;
            }
        }

        private static dynamic GetWithoutOrder(out int count)
        {
            using (var context = new BusinessContext())
            {
                var withoutList = context.businessWithoutOrder.Select(a => new
                {
                    a.Name,
                    a.CreateTime,
                    a.IDCard,
                    a.Id,
                    typeName = a.businessType.Name
                }).ToList();
                count = withoutList.Count;

                return withoutList;
            }
        }

        private static string CallingWithoutOrder()
        {
            using (var context = new BusinessContext())
            {
                var user = context.businessWithoutOrder.OrderBy(a => a.CreateTime).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show(@"没有人排队");
                    return "";
                }

                return user.Name;
            }
        }

        private static string CallingOrder()
        {
            using (var context = new BusinessContext())
            {
                var user = context.business.OrderBy(a => a.OrderTime).ThenBy(a => a.ComingTime).FirstOrDefault();

                if (user == null)
                {
                    throw new Exception("队列为空");
                }

                return user.Name;
            }
        }

        private static void RemoveWithoutOrder(string name)
        {
            using (var context = new BusinessContext())
            {
                var bwo = context.businessWithoutOrder.OrderBy(a => a.CreateTime).FirstOrDefault(a => a.Name.Equals(name));

                if (bwo == null)
                {
                    throw new Exception("队列出现错误");
                }

                context.businessWithoutOrder.Remove(bwo);
                context.SaveChanges();
            }
        }

        private static void RemoveOrder(string name)
        {
            using (var context = new BusinessContext())
            {
                var b = context.business.OrderBy(a => a.CreateTime).FirstOrDefault(a => a.Name.Equals(name));

                if (b == null)
                {
                    throw new Exception("队列出现错误");
                }

                context.business.Remove(b);
                context.SaveChanges();
            }
        }
    }
}
