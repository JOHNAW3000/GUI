using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class BodyInfo : Form
    {
        private Body body;
        public BodyInfo(Body b)
        {
            InitializeComponent();
            this.body = b;
            nametextbox.Text = b.Name;
            masstextbox.Text = b.Mass.ToString();
        }






    }
}
