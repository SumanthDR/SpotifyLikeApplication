using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace StunningDisco
{
    public partial class FrmAddSong : Form
    {
        string message = string.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        String fName = string.Empty;
        string fileContent = string.Empty;
        string filePath = string.Empty;
        string songId = string.Empty;

        public FrmAddSong()
        {
            InitializeComponent();
        }

        private void insertArtistSongMapped()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_InsertArtistSongMapping", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            try
            {
                foreach (var item in chkLstArtist.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                    cmd.Parameters.AddWithValue("@mapArtistId", row["artistId"]);
                    cmd.Parameters.AddWithValue("@mapSongId", Convert.ToInt32(songId));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong \n\n" + ex);
            }
            finally { con.Close(); }            
        }
        private void retrieveSongId()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_RetrieveSongId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                songId = (dr["songId"].ToString());
            con.Close();            
        }

        private void selectFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
                //openFileDialog.Filter = "Img files (*.jpg)|*.jpeg|All files (*.png)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private byte[] ImageToStream(string fileName)
        {
            MemoryStream stream = new MemoryStream();
        tryagain:
            try
            {
                Bitmap image = new Bitmap(fileName);
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception)
            {
                goto tryagain;
            }
            return stream.ToArray();
        }

        private void displayChkLst()
        {
            SqlConnection con = new SqlConnection(connectionString);
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


        private void addNewSong()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                fName = filePath;                
                SqlCommand cmd = new SqlCommand("sp_InsertNewSong", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@songName", txtbx_songName.Text.Trim());
                cmd.Parameters.AddWithValue("@songDOR", dateTimePicker_DOR.Value.Date);
                byte[] content = ImageToStream(fName);
                if (File.Exists(fName))                                    
                    cmd.Parameters.AddWithValue("@songImage", content);                
                cmd.Parameters.AddWithValue("@songIsActive", 1);
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


        private void FrmAddSong_Load(object sender, EventArgs e)
        {
            displayChkLst();
        }

        private void btn_addArtist_Click(object sender, EventArgs e)
        {
            FrmAddArtist frmAddArtist = new FrmAddArtist();
            frmAddArtist.Show();            
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            displayChkLst();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            selectFile();
            MessageBox.Show("Image selected");            
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            addNewSong();
            filePath = String.Empty;
            retrieveSongId();
            insertArtistSongMapped();
        }
    }
}
