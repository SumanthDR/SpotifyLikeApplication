using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmRegisterNewUser : Form
    {
        string message = string.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        public FrmRegisterNewUser()
        {
            InitializeComponent();
        }

        private void clearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void addNewUser()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", txtbx_userName.Text.Trim());
                cmd.Parameters.AddWithValue("@userEmail", txtbx_userEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@userPassword", txtbx_rePassword.Text);
                cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = (string)cmd.Parameters["@ERROR"].Value;                
                MessageBox.Show(message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally
            {
                con.Close();                
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            addNewUser();
            clearTextBoxes();
        }
    }
}
