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
    public partial class frmCities : Form
    {
        public frmCities()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("server=DESKTOP-HUCJQU2;database=DbCustomer;integrated security=true; TrustServerCertificate=true;");

        private void btnList_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From Cities", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Insert into Cities (CityName, CityCountry) values (@p1, @p2)", connection);
            cmd.Parameters.AddWithValue("@p1", txtCityName.Text);
            cmd.Parameters.AddWithValue("@p2", txtCountryName.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Şehir ekleme işlemi başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete from Cities Where CityId = @p1", connection);
            cmd.Parameters.AddWithValue("@p1", txtCityId.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Şehir silme işlemi başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update Cities SET CityName = @p1, CityCountry = @p2 Where CityId = @p3", connection);
            cmd.Parameters.AddWithValue("@p1", txtCityName.Text);
            cmd.Parameters.AddWithValue("@p2", txtCountryName.Text);
            cmd.Parameters.AddWithValue("@p3", txtCityId.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Şehir güncelleme işlemi başarılı");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From Cities Where CityName = @p1", connection);
            cmd.Parameters.AddWithValue("@p1", txtCityName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
