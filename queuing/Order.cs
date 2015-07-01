using queuing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace queuing
{
    public partial class Order : Form
    {
        public string IDCard { get; set; }

        public Order(string idcard)
        {
            InitializeComponent();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            this.Text = "预约用户办理业务";
            this.IDCard = idcard;
            this.lblIdCard.Text = IDCard;

            var thread = new Thread(new ThreadStart(GetNameByIDCardNum));
            thread.IsBackground = true;
            thread.Start();
        }


        private void GetNameByIDCardNum()
        {
            using (var context = new BusinessContext())
            {
                var business = context.business.Where(a => a.IDCard.Equals(IDCard)).FirstOrDefault();

                if (business == null)
                {
                    throw new Exception("");
                }
                else
                {
                    this.lblName.Text = business.Name;
                }
            }
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            using (var context = new BusinessContext())
            {
                var business = context.business.Where(a => a.IDCard.Equals(IDCard)).FirstOrDefault();
                MessageBox.Show("您的号码为B：" + business.Id);
            }
        }
    }
}
