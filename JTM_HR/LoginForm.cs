using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography.X509Certificates;

namespace JTM_HR
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=USER\\SQLEXPRESS01;Initial Catalog=jtm_hr;Integrated Security = True");


       private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtUsername==null)
            {
                lblErrorUsername.Visible = true;
                lblErrorUsername.Text = "Please Enter Username";
            }
            else
            {
                lblErrorUsername.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                lblErrorPassword.Visible = true;
                lblErrorPassword.Text = "Please Enter Password";
            }
            else
            {
                lblErrorPassword.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text !="")
            {
      

                //Login code here
                con.Open();
                //SqlCommand cmd = new SqlCommand("Select * from Users inner join role on users.userrole = role.roleid inner join Onboarding on  Onboarding.Emp_ID = role.roleid where username=username and password=password ",con);
                 SqlCommand cmd = new SqlCommand("select * from Users inner join role on users.userrole = role.roleid where username = @username and password = @password    ", con);

                cmd.Parameters.AddWithValue("@username",txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   string usertype = (string)dt.Rows[0][5];
                    //Role based code Here
                    if (usertype=="admin")
                    {
                        //Need to be Looked at
                     //   MessageBox.Show("Welcome:"+usertype);
                        
                        this.Hide();
                        MasterDashboard fmMasterDashboard = new MasterDashboard();
                        fmMasterDashboard.ShowDialog();
                        this.Close();


                    }else if (usertype == "cashier")
                    {
                        MessageBox.Show("Welcome Cashier");
                    }
                    else if (usertype == "accountant")
                    {
                        MessageBox.Show("Welcome Accountant");
                    }
                    else
                    {
                        MessageBox.Show("Welcome user");
                    }
                }
                else
                {
                    ErrorMsg.Text = "Invalid login details";
                    ErrorMsg.Visible = true;
                }

                con.Close();
              

            }
            else if(txtUsername.Text == "" || txtUsername.Text == null  && txtPassword.Text !="")
            {
                
                    lblErrorUsername.Text = "Please enter username";
                    lblErrorUsername.Visible = true;

            }else if (txtUsername.Text != "" || txtUsername.Text != null && txtPassword.Text == "")
            {

                lblErrorPassword.Text = "Please enter password";
                lblErrorPassword.Visible = true;
            }else if (txtUsername.Text != "" || txtUsername.Text == null && txtPassword.Text != "")
            {
                lblErrorUsername.Text = "Please enter valid characters";
                lblErrorUsername.Visible = true;

            }
            else
            {
                lblErrorUsername.Visible = false;
                lblErrorPassword.Visible = false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}