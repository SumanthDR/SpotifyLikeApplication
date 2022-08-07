using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmViewSongs : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        public FrmViewSongs()
        {
            InitializeComponent();
        }
        private void loadGridView()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_ViewSongs", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adt.Fill(dt);

                    // Clear binding
                    dataGridView1.DataSource = null;

                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 5;

                    dataGridView1.Columns[1].Name = "songName";
                    dataGridView1.Columns[1].HeaderText = "Song Name";
                    dataGridView1.Columns[1].DataPropertyName = "songName";
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "songDOR";
                    dataGridView1.Columns[2].HeaderText = "Date of Release";
                    dataGridView1.Columns[2].DataPropertyName = "songDOR";
                    dataGridView1.Columns[2].Width = 130;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "ARTISTNAME";
                    dataGridView1.Columns[3].HeaderText = "Artists";
                    dataGridView1.Columns[3].DataPropertyName = "ARTISTNAME";
                    dataGridView1.Columns[3].Width = 180;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].Name = "songId";
                    dataGridView1.Columns[4].DataPropertyName = "songId";
                    dataGridView1.Columns[4].Visible = false;


                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void FrmViewSongs_Load(object sender, EventArgs e)
        {
            loadGridView();
        }
    }
}
