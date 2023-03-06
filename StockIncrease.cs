using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class StockIncrease : Form
    {
        function fn = new function();
        String query;
        public StockIncrease()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StockIncrease_Load(object sender, EventArgs e)
        {
            query = "select blood_group,quantity from stock";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIncrease_Click(object sender, EventArgs e) //set quantity to the existing value plus what the user has selected from the combo box
        {
            query = "update stock set quantity = quantity + "+ txtUnits.Text +" where blood_group = '"+ txtBloodGroup.Text + "'";
            fn.setDate(query);
            StockIncrease_Load(this, null);
        }
    }
}
