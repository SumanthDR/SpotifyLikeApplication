using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmAddSong : Form
    {
        string message = string.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        public FrmAddSong()
        {
            InitializeComponent();
        }
        private void displayChkLst()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DisplayArtistName", con);                
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                chkLstArtist.DataSource = dt;
                chkLstArtist.DisplayMember = "artistName";
                chkLstArtist.ValueMember = "artistId";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally { con.Close(); }
        }

        private void FrmAddSong_Load(object sender, EventArgs e)
        {
            displayChkLst();
        }
    }
}
