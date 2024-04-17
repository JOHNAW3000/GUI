using System.Diagnostics;

namespace GUI
{
    public partial class Legend : Form
    {
        private List<Body> bodies;
        private List<BodyInfo> bodyInfoList = new List<BodyInfo>();
        private SimulationDisplay form;
        public Legend(List<Body> bodies, SimulationDisplay form)
        {
            InitializeComponent();
            this.bodies = bodies;
            foreach (Body body in this.bodies)
            {
                legendlist.Items.Add(body.Name);
            }
            this.form = form;

            FormClosed += new FormClosedEventHandler(FormClosing);
        }

        public List<BodyInfo> BodyInfoList
        {
            get { return bodyInfoList; }
            private set { bodyInfoList = value; }
        }

        public void Update(List<Body> bodies)
        {
            legendlist.Items.Clear();
            foreach (Body body in this.bodies)
            {
                legendlist.Items.Add(body.Name);
            }
        }

        private void legendlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Body body in bodies)
            {
                if (body.Name == legendlist.SelectedItem)
                {
                    BodyInfo newinfo = new BodyInfo(body, form);
                    bodyInfoList.Add(newinfo);
                    newinfo.Show();
                    break;
                }
            }
        }

        private void FormClosing(object sender, FormClosedEventArgs e)
        {
            foreach (BodyInfo info in bodyInfoList)
            {
                info.Close();
            }
        }
    }
}
