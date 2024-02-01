namespace GUI
{
    public class Colours
    {
        private Pen outline;
        private Brush fill;

        public Colours(Pen p, Brush b)
        {
            outline = p;
            fill = b;
        }


        public Pen getOutline()
        {
            return outline;
        }

        public Brush getFill()
        {
            return fill;
        }

    }
}
