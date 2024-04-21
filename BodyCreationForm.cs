namespace GUI
{
    public partial class BodyCreationForm : Form
    {

        private Vector yaxis = new Vector(0, 1);

        private SimulationDisplay form;
        public BodyCreationForm(SimulationDisplay form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void positionxtextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Vector position = new Vector(Convert.ToDouble(positionxtextbox.Text), Convert.ToDouble(positionytextbox.Text));
                positionlabel.Text = $"Orbital Radius: {position.Modulus():f2}km Angle: {position.AngleBetween(yaxis):f2}";
            }
            catch { }
        }

        private void positionytextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Vector position = new Vector(Convert.ToDouble(positionxtextbox.Text), Convert.ToDouble(positionytextbox.Text));
                positionlabel.Text = $"Orbital Radius: {position.Modulus():f2}km Angle: {position.AngleBetween(yaxis):f2}";
            }
            catch { }
        }

        private void velocityxtextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Vector velocity = new Vector(Convert.ToDouble(velocityxtextbox.Text), Convert.ToDouble(velocityytextbox.Text));
                velocitylabel.Text = $"Speed: {velocity.Modulus():f2}km/s Angle: {velocity.AngleBetween(yaxis):f2}";
            }
            catch { }
        }

        private void velocityytextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Vector velocity = new Vector(Convert.ToDouble(velocityxtextbox.Text), Convert.ToDouble(velocityytextbox.Text));
                velocitylabel.Text = $"Speed: {velocity.Modulus():f2}km/s Angle: {velocity.AngleBetween(yaxis):f2}";
            }
            catch { }
        }

        // Creates a new body from the user input, only if a valid body can be created
        private void createbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Vector position = new Vector(Convert.ToDouble(positionxtextbox.Text), Convert.ToDouble(positionytextbox.Text));

                Vector velocity = new Vector(Convert.ToDouble(velocityxtextbox.Text), Convert.ToDouble(velocityytextbox.Text));

                Body body = new Body(nametextbox.Text, "UserGeneratedPlanet", Convert.ToDouble(masstextbox.Text), Convert.ToDouble(radiustextbox.Text), position, velocity);
                body.Colours = new Appearance(Color.FromName(primarytextbox.Text), Color.FromName(secondarytextbox.Text));
                form.AddBody(body);
                Close();
            }
            catch
            {

            }
            
        }
    }
}
