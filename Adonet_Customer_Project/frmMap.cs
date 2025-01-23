using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet_Customer_Project
{
    public partial class frmMap : Form
    {
        public frmMap()
        {
            InitializeComponent();
        }

        private void btnCities_Click(object sender, EventArgs e)
        {
            frmCities frmCity = new frmCities();
            frmCity.Show();
           

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomer = new frmCustomers();
            frmCustomer.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
