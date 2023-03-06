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
    public partial class AddNewDonor : Form
    {
        function fn = new function();
        public AddNewDonor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtDOB.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtBloodGroup.Text != "" && txtCity.Text != "" && txtAddress.Text != "")
            {
                String dname = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String dob = txtDOB.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String bgroup = txtBloodGroup.Text;
                String city = txtCity.Text;
                String address = txtAddress.Text;

                String query = "insert into newDonor (dname,fname,mname,dob,mobile,gender,email,bloodgroup,city,daddress) values ('"+dname+"','"+fname+"','"+mname+"','"+dob+"',"+mobile+",'"+gender+"','"+email+"','"+bgroup+"','"+city+"','"+address+"')";
                fn.setDate(query);
            }
            else
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddNewDonor_Load(object sender, EventArgs e) //Increases the donor number by one everytime a new one is being added
        {
            String query = "select max(did) from newDonor";
            DataSet ds = fn.getData(query);
            var count = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            labelNewID.Text = (count+1).ToString();     
        }

        private void btnReset_Click(object sender, EventArgs e) //Ensures the reset buttonclears all the information
        {
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtDOB.ResetText();
            txtMobile.Clear();
            txtGender.ResetText();
            txtEmail.Clear();
            txtBloodGroup.ResetText();
            txtAddress.Clear();
        }
    }
}
