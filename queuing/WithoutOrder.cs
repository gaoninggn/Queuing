using System;
using System.Linq;
using System.Windows.Forms;
using queuing.Models;

namespace queuing
{
    public partial class WithoutOrder : Form
    {
        public string IdCard { get; set; }
        public WithoutOrder(string idCard)
        {
            InitializeComponent();
            this.Text = "非预约用户办理业务";
            this.IdCard = idCard;
            this.lblIDCard.Text = idCard;
        }

        private void WithoutOrder_Load(object sender, EventArgs e)
        {

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            using (var context = new BusinessContext())
            {
                var businessWithoutOrder = new BusinessWithoutOrder
                {
                    Name = "孙二狗",
                    IDCard = IdCard,
                    CreateTime = DateTime.Now,
                    businessType = context.businessType.FirstOrDefault(a => a.Id == 1),
                };

                var model = context.businessWithoutOrder.Add(businessWithoutOrder);
                var result = context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("出号成功,您的号码为A" + model.Id);
                }
                else
                {
                    throw new Exception("出号失败");
                }
            }
        }
    }
}
