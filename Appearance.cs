using System.Xml.Linq;

namespace GUI
{
    public class Appearance
    {
        private Color primary;
        private Color secondary;

        public Appearance(Color primary, Color secondary)
        {

            this.primary = primary;
            this.secondary = secondary;
        }




        public Color Primary
        {
            get { return primary; }
            set { primary = value; }
        }

        public Color Secondary
        {
            get { return secondary; }
            set { secondary = value; }
        }

    }
}
