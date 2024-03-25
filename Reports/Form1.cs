using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Reports
{
    public partial class Form1 : Form
    {
        public string SqlConnectionString = "Data Source=CH-Hashim;Initial Catalog=northwind;Integrated Security=True;Encrypt=False";
        public Form1()
        {
            InitializeComponent();
            textBox.Focus();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                try
                {
                    string query = "select o.OrderID, c.CustomerID, c.ContactName, c.Address, c.PostalCode, c.City, c.Phone " +
                                    "from Orders o inner join Customers c on o.CustomerID = c.CustomerID " +
                                    $"where c.City = '{ textBox.Text }'";
                    dataGrid.DataSource = connection.Query<Orders>(query, commandType: CommandType.Text);
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            int orderId = int.Parse(dataGrid.SelectedRows[0].Cells[0].Value.ToString());
            string contactName = dataGrid.SelectedRows[0].Cells[1].Value.ToString();
            string customerID = dataGrid.SelectedRows[0].Cells[2].Value.ToString();
            string postalCode = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
            string address = dataGrid.SelectedRows[0].Cells[4].Value.ToString();
            string city = dataGrid.SelectedRows[0].Cells[5].Value.ToString();
            string phone = dataGrid.SelectedRows[0].Cells[6].Value.ToString();

            Orders obj = new Orders(orderId, contactName, customerID, postalCode, address, city, phone);
            if (obj != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(SqlConnectionString))
                    {
                        string query = "select d.OrderID, p.ProductName, d.Quantity, d.Discount, d.UnitPrice from [Order Details] d inner join Products p on p.ProductID = d.ProductID" +
                               $" where d.OrderID = {obj.orderID}";
                        List<OrderDetails> list = connection.Query<OrderDetails>(query, commandType: CommandType.Text).ToList();
                        using(printForm frm = new printForm(list, obj))
                        {
                            frm.ShowDialog();
                        }
                    }
                }catch(Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
    }
}
