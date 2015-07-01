using System;
using System.Collections.Generic;
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
                MessageBox.Show("请" + "" + "到X号窗口");
            }
            else
            {

            }
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
                    Num = "B" + a.Id,
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
                    Num = "A" + a.Id,
                    typeName = a.businessType.Name
                }).ToList();
                count = withoutList.Count;

                return withoutList;
            }
        }
    }
}
