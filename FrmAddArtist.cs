using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmAddArtist : Form
    {
        string message = string.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        public FrmAddArtist()
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

        private void addNewArtist()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertNewArtist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@artistName", txtbx_artistName.Text.Trim());
                cmd.Parameters.AddWithValue("@artistDOB", dateTime_artistDOB.Value.Date);
                cmd.Parameters.AddWithValue("@artistBio", txtbx_bio.Text);
                cmd.Parameters.AddWithValue("@artistIsActive", 1);
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
            addNewArtist();
            clearTextBoxes();            
        }

        private void FrmAddArtist_Load(object sender, EventArgs e)
        {

        }
    }
}
