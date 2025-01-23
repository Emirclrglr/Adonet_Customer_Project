using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet_Customer_Project
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("server=DESKTOP-HUCJQU2;database=DbCustomer;integrated security=true; TrustServerCertificate=true;");

        private void btnList_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select CustomerId, CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CityName From Customers Inner Join Cities as c ON CustomerCityId = c.CityId", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Exec CustomerListWithCity", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Cities", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbCity.ValueMember = "CityId";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dataTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand("Insert into Customers (CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CustomerCityId) values (@customerName, @customerSurname, @customerBalance, @customerStatus, @customerCityId)", connection);
            cmd.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            cmd.Parameters.AddWithValue("@customerBalance", txtCustomerBalance.Text);
            cmd.Parameters.AddWithValue("@customerCityId", cmbCity.SelectedValue);
            if (rdbActive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", true);
            }
            else if (rdbPassive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", false);
            }
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Müşteri ekleme işlemi başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete from Customer Where CustomerId = @p1", connection);
            cmd.Parameters.AddWithValue("@p1", txtCustomerId.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Müşteri silme işlemi başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update Customers SET CustomerName = @customerName, CustomerSurname = @customerSurname, CustomerBalance = @customerBalance, CustomerStatus = @customerStatus, CustomerCityId = @customerCityId Where CustomerId = @id", connection);
            cmd.Parameters.AddWithValue("@id", txtCustomerId.Text);
            cmd.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            cmd.Parameters.AddWithValue("@customerBalance", txtCustomerBalance.Text);
            cmd.Parameters.AddWithValue("@customerCityId", cmbCity.SelectedValue);
            if (rdbActive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", true);
            }
            else if (rdbPassive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", false);
            }
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Müşteri güncelleme işlemi başarılı");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From Customers Where CustomerName = @p1", connection);
            cmd.Parameters.AddWithValue("@p1", txtCustomerName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
