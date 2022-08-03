using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmAdminHome : Form
    {
        public FrmAdminHome()
        {
            InitializeComponent();
        }

        // Function used to open child form inside the MDI Container Form //
        private void openMdiChild(Form FormOpen)
        {
            if (ActiveMdiChild != null) // Checks if any child form is open
                ActiveMdiChild.Close();
            FormOpen.MdiParent = this;
            FormOpen.Show();
        }

        private void addArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddArtist frmAddArtist = new FrmAddArtist();
            openMdiChild(frmAddArtist);
        }

        private void songToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddSong frmAddSong = new FrmAddSong();
            openMdiChild(frmAddSong);
        }
    }
}
