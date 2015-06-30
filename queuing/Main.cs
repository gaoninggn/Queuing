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
            InitializeComponent();

            this.Text = "排队系统";
        }

        private void btnQueuing_Click(object sender, EventArgs e)
        {
            var idCard = this.textBox1.Text.Trim();
            var validateResult = ValidateIDCard(idCard);

            if (!validateResult)
            {
                MessageBox.Show("身份证错误", "提示");
                return;
            }

            bool isOrder = IsOrder(idCard);

            if (isOrder)
            {

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

        private bool ValidateIDCard(string idCard)
        {
            var reg = new Regex(@"^\d{17}(\d|x)$");

            return reg.IsMatch(idCard);
        }
    }
}
