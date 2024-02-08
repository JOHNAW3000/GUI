namespace GUI
{
    public class Appearance
    {
        private Pen primary;
        private Brush secondary;

        public Appearance(Color primary, Color secondary)
        {

            this.primary = new Pen(primary, 5);
            this.secondary = new SolidBrush(secondary);
        }




        public Pen getPrimary()
        {
            return primary;
        }

        public Brush getSecondary()
        {
            return secondary;
        }

    }
}
