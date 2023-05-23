using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturGmbH
{    
    public partial class LoadingScreen : Form
    {
        public int percentValue = 0;

        public LoadingScreen()
        {
            InitializeComponent();
        }

        // Wenn die Form geladen wurde
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
        }

        // Timer Tick Handler
        private void timer1_Tick(object sender, EventArgs e)
        {            
            // if(progressBar1.Value <= 99 || 100-1  --> Ist eine MagicNumber d.h. Fester Wert dies ist nicht so professionell wie unten das vorgehen ↓
            if(progressBar1.Value <= progressBar1.Maximum-1)
            {
                progressBar1.Value+=1;
                lbl_ProgressInPercent.Text = ((percentValue+=1)+"%").ToString();
            }
            else
            {
                timer1.Stop();
            }            
        }

        
    }
}
