using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports
{
    public partial class printForm : Form
    {
        List<OrderDetails> list;
        Orders orders;
        public printForm(List<OrderDetails> list, Orders orders)
        {
            InitializeComponent();
            this.list = list;
            this.orders = orders;
        }

        private void printForm_Load(object sender, EventArgs e)
        {
            crystalReport11.SetDataSource(list);
            crystalReport11.SetParameterValue("pOrderID", orders.orderID);
            crystalReport11.SetParameterValue("pContactName", orders.contactName);
            crystalReport11.SetParameterValue("pPostalCode", orders.postalCode);
            crystalReport11.SetParameterValue("pAddress", orders.address);
            crystalReport11.SetParameterValue("pCity", orders.city);
            crystalReport11.SetParameterValue("pCustomerID", orders.customerID);
            crystalReport11.SetParameterValue("pPhone", orders.phone);
            crystalReportViewer.ReportSource = crystalReport11;
            crystalReportViewer.Refresh();
        }
    }
}
