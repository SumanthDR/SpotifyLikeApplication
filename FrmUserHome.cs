using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace StunningDisco
{   
    public partial class FrmUserHome : Form
    {
        string message = string.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        ComboBox combo;
        int rate = -1;

        DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();

        public FrmUserHome()
        {
            InitializeComponent();
        }        
        private void saveRateSongUser()
        {            
            SqlConnection con = new SqlConnection(connectionString);
            try
            {                  
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertUserRating", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (dr.IsNewRow) continue;
                    {
                        cmd.Parameters.AddWithValue("@userIdRate", FrmLogin.userId);
                        cmd.Parameters.AddWithValue("@songIdRate", dr.Cells["songId"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@rate", dr.Cells["cmbbx_rate"].Value ?? DBNull.Value);
                        con.Open();
                        cmd.ExecuteNonQuery();
                       // MessageBox.Show("Saved");
                        con.Close();
                    }                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, Please try again !! \n\n" + ex);
            }
            finally { con.Close(); }
        }
        private void removeDuplicateRows()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = i + 1; j < dataGridView1.Rows.Count; j++)
                {
                    string first_str = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string second_str = dataGridView1.Rows[j].Cells[5].Value.ToString();

                    if (first_str == second_str)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                        j--;
                    }
                    else
                        list.Add(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }
            }
        }

        private void FrmUserHome_Load(object sender, EventArgs e)
        {   
            //loadGridView();
            //removeDuplicateRows();                        
        }
        private void loadGridViewTopArtist()
        {            
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RetrieveTopArtists", con);                
                con.Open();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adt.Fill(dt);

                    combo = null;
                    // Clear binding
                    dataGridView1.DataSource = null;


                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 5;

                    dataGridView1.Columns[1].Name = "artistName";
                    dataGridView1.Columns[1].HeaderText = "Artist Name";
                    dataGridView1.Columns[1].DataPropertyName = "artistName";
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "artistDOB";
                    dataGridView1.Columns[2].HeaderText = "Arist DOB";
                    dataGridView1.Columns[2].DataPropertyName = "artistDOB";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "songsArtist";
                    dataGridView1.Columns[3].HeaderText = "Songs";
                    dataGridView1.Columns[3].DataPropertyName = "songsArtist";
                    dataGridView1.Columns[3].Width = 130;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].Name = "artistId";
                    dataGridView1.Columns[4].DataPropertyName = "artistId";
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
        private void loadGridViewTopSongs()
        {
            int num = -1;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RetrieveTopSongs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if(cmbbx_topSongs.Text == "My Top 10 Songs")
                    cmd.Parameters.AddWithValue("@para", FrmLogin.userId);
                else if (cmbbx_topSongs.Text == "Trending Top 10 Songs")
                    cmd.Parameters.AddWithValue("@para", num);
                con.Open();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adt.Fill(dt);

                    combo = null;
                    // Clear binding
                    dataGridView1.DataSource = null;

                    
                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 6;   

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

                    dataGridView1.Columns[4].Name = "rate";
                    dataGridView1.Columns[4].HeaderText = "Rating";
                    dataGridView1.Columns[4].DataPropertyName = "rate";
                    dataGridView1.Columns[4].Width = 80;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].Name = "songId";
                    dataGridView1.Columns[5].DataPropertyName = "songId";
                    dataGridView1.Columns[5].Visible = false;
                
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
        private void loadGridView(string prc)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(prc, con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (prc == "sp_SearchSongs")
                    cmd.Parameters.AddWithValue("@para", txtbx_search.Text);
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

                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.Name = "songImage";
                    imageColumn.DataPropertyName = "songImage";
                    imageColumn.HeaderText = "Art Work";
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dataGridView1.Columns.Insert(1, imageColumn);
                    dataGridView1.RowTemplate.Height = 100;
                    dataGridView1.Columns[1].Width = 100;

                    dataGridView1.Columns[2].Name = "songName";
                    dataGridView1.Columns[2].HeaderText = "Song Name";
                    dataGridView1.Columns[2].DataPropertyName = "songName";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "songDOR";
                    dataGridView1.Columns[3].HeaderText = "Date of Release";
                    dataGridView1.Columns[3].DataPropertyName = "songDOR";
                    dataGridView1.Columns[3].Width = 130;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].Name = "ARTISTNAME";
                    dataGridView1.Columns[4].HeaderText = "Artists";
                    dataGridView1.Columns[4].DataPropertyName = "ARTISTNAME";
                    dataGridView1.Columns[4].Width = 180;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].Name = "songId";
                    dataGridView1.Columns[5].DataPropertyName = "songId";
                    dataGridView1.Columns[5].Visible = false;


                    ///     CREATES BUTTON IN DATAGRID VIEW  /////////////////                    

//                    DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
                    dataGridView1.Columns.Add(comboBox);
                    comboBox.HeaderText = "Rating";
                    
                    comboBox.Items.Add("1");
                    comboBox.Items.Add("2");
                    comboBox.Items.Add("3");
                    comboBox.Items.Add("4");
                    comboBox.Items.Add("5");
                    comboBox.Name = "cmbbx_rate";                                       
                    

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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChanged);
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            }
            else
                rate = -1;
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (sender as ComboBox).SelectedItem.ToString();            
            rate = Convert.ToInt32(selected);            
        }

        private void btn_rateSave_Click(object sender, EventArgs e)
        {
            saveRateSongUser();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            loadGridView("sp_RetrieveSongs");
            removeDuplicateRows();
        }

        private void cmbbx_topSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            loadGridViewTopSongs();
            removeDuplicateRows();
        }

        private void cmbbx_topArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            loadGridViewTopArtist();
        }
        
        private void txtbx_search_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            loadGridView("sp_SearchSongs");
            removeDuplicateRows();
        }
    }
}

