using System.Xml.Linq;

namespace GUI
{
    public class Appearance
    {
        // Properties
        private Color primary;
        private Color secondary;

        // Constructor
        public Appearance(Color primary, Color secondary)
        {
            this.primary = primary;
            this.secondary = secondary;
            // Primary refers to the outline colour
            // Secondary refers to the fill colour and colour of the vector arrow
        }

        // Methods
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
