using System;
using System.Linq;
using System.Windows.Forms;
using queuing.Models;

namespace queuing
{
    public partial class Order : Form
    {
        public string IdCard { get; set; }

        public Order(string idcard)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Text = "预约用户办理业务";
            IdCard = idcard;
            lblIdCard.Text = IdCard;

            GetNameByIdCardNum();
        }

        private void GetNameByIdCardNum()
        {
            using (var context = new BusinessContext())
            {
                var business = context.business.FirstOrDefault(a => a.IDCard.Equals(IdCard));

                if (business == null)
                {
                    throw new Exception("没有这个人");
                }

                else
                {
                    lblName.Text = business.Name;
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
                var business = context.business.OrderBy(a => a.OrderTime).ThenBy(a => a.ComingTime).FirstOrDefault(a => a.IDCard.Equals(IdCard));

                if (business != null) MessageBox.Show(@"您的号码为B：" + business.Id);
            }
        }
    }
}
