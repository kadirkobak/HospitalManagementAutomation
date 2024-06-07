using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementAutomation
{
    public partial class FormBilgiDuzenle : Form
    {
        public FormBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tcNo;
        
        private void FormBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTCKimlikNo.Text = tcNo;
        }
    }
}
