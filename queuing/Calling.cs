using System;
using System.Linq;
using System.Windows.Forms;
using queuing.Models;

namespace queuing
{
    public partial class Calling : Form
    {
        public Calling()
        {
            InitializeComponent();
        }

        private void Calling_Load(object sender, EventArgs e)
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

                var withoutList = context.businessWithoutOrder.Select(a => new
                {
                    a.Name,
                    a.CreateTime,
                    a.IDCard,
                    Num = "A" + a.Id,
                    typeName = a.businessType.Name
                }).ToList();

                dgvOrder.DataSource = orderList;
                dgvWithoutOrder.DataSource = withoutList;

                label1.Text += ":" + orderList.Count;
                label2.Text += ":" + withoutList.Count;
            }
        }

        void BtnCalling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("叫号");
        }
    }
}
