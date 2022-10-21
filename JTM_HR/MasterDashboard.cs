using JTM_HR.Properties;
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
using Microsoft;

namespace JTM_HR
{
    public partial class MasterDashboard : Form
    {

        private bool isCollapsed = true;
        public MasterDashboard()
        {
            InitializeComponent();
            ucRecruitment1.Hide();
            ucOnboarding1.Hide();
            timer1.Stop();

        }
        SqlConnection con = new SqlConnection("Data Source=USER\\SQLEXPRESS01;Initial Catalog=jtm_hr;Integrated Security = True");
        
        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Hide();
            LoginForm fmLogin = new LoginForm();
            fmLogin.ShowDialog();
            this.Close();
        }

        private void btnExitMD_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOnboarding_Click(object sender, EventArgs e)
        {
            ucRecruitment1.Hide();
            ucOnboarding1.Show();
            ucOnboarding1.BringToFront();
            lblModuleHeading.Visible = true;
            lblModuleHeading.Text = "Onboarding";

          
        }

        private void btnRecruitment_Click(object sender, EventArgs e)
        {
         

            timer1.Start();
               ucOnboarding1.Hide();
               ucRecruitment1.Show();
               ucRecruitment1.BringToFront();
               lblModuleHeading.Visible = true;
               lblModuleHeading.Text = "Recruitment";
             



        }

        private void ucRecruitment1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                if (isCollapsed)
                {
                    btnRecruitment.Image = Resources.cOLLAPSE_eRROA;
                    panel3.Height += 10;
                    if (panel3.Size == panel3.MaximumSize)
                    {
                        timer1.Stop();
                        isCollapsed = false;
                    }
                }
                else
                {
                    btnRecruitment.Image = Resources.COLLAPSE;
                    panel3.Height -= 10;
                    if (panel3.Size == panel3.MinimumSize)
                    {
                        timer1.Stop();
                        isCollapsed = true;

                    }

                }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            int empID = int.Parse(txtEmployeeID.Text);
            string Emp_Initials = txtInitials.Text, Emp_Firstname =txtEmployeeFirstName.Text, Emp_SecondName=txtEmployeeSecondName.Text,Emp_KnownAs = txtKnownAs.Text, Emp_LastName = txtLastName.Text, Emp_GroupCode = cmbGroupCode.Text, Emp_Language = cmbLanguage.Text, Emp_MaritalStatus = cmbMaritalStatus.Text, sex = "";
            DateTime Emp_BirthDate = DateTime.Parse(dtpBirthDate.Text);
            int age = int.Parse(txtAge.Text);

            string Emp_Citizenship = cmbCitizenship.Text;
            DateTime JoiningDate = DateTime.Parse(dtpJoiningDate.Text);
            string Contact = txtCell.Text, Emp_Email = txtEmail.Text, Emp_RSAID = txtRSAID.Text, Emp_Passport = txtPassport.Text, Emp_PassportCountry = txtPassportCountry.Text, Emp_BusinessUnit = cmbBusinessUnit.Text, Emp_Department = cmbDepartment.Text, City = cmbCity1.Text;
            if (rbMale.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            //this con is to initialize the string
            SqlCommand cmd = new SqlCommand("exec InsertEmp_SP1 '"+ empID + "','" + Emp_Initials + "','" + Emp_Firstname + "','" + Emp_SecondName + "','" + Emp_KnownAs + "','" + Emp_LastName +  "','" + Emp_GroupCode +  "','" + Emp_Language +"','" + Emp_MaritalStatus +  "','" + sex + "','" + Emp_BirthDate +  "','" + age +  "','" + Emp_Citizenship +  "','" + JoiningDate + "','" + Contact + "','" + Emp_Email +  "','" + Emp_RSAID +  "','" + Emp_Passport + "','" + Emp_PassportCountry + "','" + Emp_BusinessUnit +  "','" + Emp_Department + "','" + City + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfuly Created");
            getEmpList();
            con.Close();
            txtEmployeeID.Text = "";
            txtEmployeeFirstName.Text = "";
            cmbCity1.Text = "";
            txtCell.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtAge.Text = "";
            dtpJoiningDate.Text = "";

        }

        void getEmpList()
        {
            SqlCommand cmd = new SqlCommand("exec ListEmp_SP1",con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void MasterDashboard_Load(object sender, EventArgs e)
        {
            getEmpList();


            panel5.Visible = false;
            panel7.Visible = false; 
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            int empID = int.Parse(txtEmployeeID.Text);
            string Emp_Initials = txtInitials.Text, Emp_Firstname = txtEmployeeFirstName.Text, Emp_SecondName = txtEmployeeSecondName.Text, Emp_KnownAs = txtKnownAs.Text, Emp_LastName = txtLastName.Text, Emp_GroupCode = cmbGroupCode.Text, Emp_Language = cmbLanguage.Text, Emp_MaritalStatus = cmbMaritalStatus.Text, sex = "";
            DateTime Emp_BirthDate = DateTime.Parse(dtpBirthDate.Text);
            int age = int.Parse(txtAge.Text);

            string Emp_Citizenship = cmbCitizenship.Text;
            DateTime JoiningDate = DateTime.Parse(dtpJoiningDate.Text);
            string Contact = txtCell.Text, Emp_Email = txtEmail.Text, Emp_RSAID = txtRSAID.Text, Emp_Passport = txtPassport.Text, Emp_PassportCountry = txtPassportCountry.Text, Emp_BusinessUnit = cmbBusinessUnit.Text, Emp_Department = cmbDepartment.Text, City = cmbCity1.Text;
            if (rbMale.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            //this con is to initialize the string
            SqlCommand cmd = new SqlCommand("exec UpdateEmp_SP1 '" + empID + "','" + Emp_Initials + "','" + Emp_Firstname + "','" + Emp_SecondName + "','" + Emp_KnownAs + "','" + Emp_LastName + "','" + Emp_GroupCode + "','" + Emp_Language + "','" + Emp_MaritalStatus + "','" + sex + "','" + Emp_BirthDate + "','" + age + "','" + Emp_Citizenship + "','" + JoiningDate + "','" + Contact + "','" + Emp_Email + "','" + Emp_RSAID + "','" + Emp_Passport + "','" + Emp_PassportCountry + "','" + Emp_BusinessUnit + "','" + Emp_Department + "','" + City + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfuly Updated");
            getEmpList();
            con.Close();
            txtEmployeeID.Text = "";
            txtEmployeeFirstName.Text = "";
            cmbCity1.Text = "";
            txtCell.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtAge.Text = "";
            dtpJoiningDate.Text = "";
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            int Emp_ID = int.Parse(txtEmployeeID.Text);

            if (MessageBox.Show("Are you sure you want to Delete an Employee's Records?","Delete Records",MessageBoxButtons.YesNo)==DialogResult.Yes) {
                con.Open();
                //this con is to initialize the string
                SqlCommand cmd = new SqlCommand("exec DeleteEmp_SP '" + Emp_ID + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfuly Deleted an Employee");
                getEmpList();
                con.Close();
                txtEmployeeID.Text = "";
            }
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            int empID = int.Parse(txtEmployeeID.Text);
            con.Open();
            //this con is to initialize the string
            SqlCommand cmd = new SqlCommand("exec LoadEmp_SP '" + empID + "'", con);
           SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            txtEmployeeID.Text = "";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void btnResidentialAddress_Click(object sender, EventArgs e)
        {
            //MasterDashboard fmMasterDashboard = new MasterDashboard();
            //fmMasterDashboard.ShowDialog();
            btnResidentialAddress.BackColor = SystemColors.Window;
            btnEmergency.BackColor = SystemColors.Control;
            panel5.Visible = true;
            panel7.Visible = false;
            btnResidentialAddress.FlatStyle = FlatStyle.Flat;
        }

        private void btnIndustrialRelations_Click(object sender, EventArgs e)
        {

        }

        private void btnEEC_Click(object sender, EventArgs e)
        {

        }

        private void btnHealthSafety_Click(object sender, EventArgs e)
        {

        }

        private void btnCareerManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnLabourRelations_Click(object sender, EventArgs e)
        {

        }

        private void btnCompensationBenefits_Click(object sender, EventArgs e)
        {

        }

        private void btnPerformanceManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnTrainingAndDevelopment_Click(object sender, EventArgs e)
        {

        }

        private void btnAssetManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnSuccessionPlanning_Click(object sender, EventArgs e)
        {

        }

        private void btnCompanyAnnouncement_Click(object sender, EventArgs e)
        {

        }

        private void bntLabourLawCompliance_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAEF_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnBackgroundChecks_Click(object sender, EventArgs e)
        {

        }

        private void btnExitInterview_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ucOnboarding1_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
         
            try
            {
               
                dataGridView1.ToString();

            DataObject copydata = dataGridView1.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            object meseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(meseddata);

            xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[1, 1];
            xlr.Select();
            xlSheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            for (int i = 1; i<dataGridView1.Columns.Count+1;i++)
            {
                xlSheet.Cells[1,i] = dataGridView1.Columns[i-1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               
                for (int j = 0;j< dataGridView1.Columns.Count;j++)
                {

                xlSheet.Cells[i+2,j+1] = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value.ToString());
            }
            }


            }
            catch (Exception )
            {
                Console.WriteLine("Instance of an Object Error Occured");

            }

        
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void lblModuleHeading_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDesignation_Click(object sender, EventArgs e)
        {

        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountDetails_Click(object sender, EventArgs e)
        {
            btnEmergency.BackColor = SystemColors.Window;
            btnResidentialAddress.BackColor = SystemColors.Control;
            panel7.Visible = true;
            panel5.Visible=false;
            btnEmergency.FlatStyle = FlatStyle.Flat;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cmbCity1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
