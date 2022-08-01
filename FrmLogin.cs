using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmLogin : Form
    {
        string message = String.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public FrmLogin()
        {
            InitializeComponent();
        }
        private int checkUserCredentials()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_checkUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@userEmail", txtbx_userId.Text.Trim());
                cmd.Parameters.AddWithValue("@userPassword", txtbx_password.Text);
                cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = (string)cmd.Parameters["@ERROR"].Value;                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally{ con.Close(); }
            return Convert.ToInt32(message);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {            
            FrmAdminHome frmAdminHome = new FrmAdminHome();
         
            // Check for Admin Login only
            if ((txtbx_userId.Text == "admin") && (txtbx_password.Text == "admin"))
            {                
                this.Hide();
                frmAdminHome.Show();
            }
            else if (checkUserCredentials() == 1)
            {
                this.Hide();
                frmAdminHome.Show();
            }
            else
                MessageBox.Show("Invalid User ID or Password");
        }

        private void linklbl_registerUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegisterNewUser frmRegisterNewUser = new FrmRegisterNewUser();
            frmRegisterNewUser.Show();
        }
    }
}
