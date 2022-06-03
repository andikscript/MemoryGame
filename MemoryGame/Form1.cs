namespace MemoryGame
{
    public partial class Form1 : Form
    {
        readonly List<Bitmap> bitmap = new List<Bitmap> { Properties.Resources._1, Properties.Resources._2,
        Properties.Resources._3, Properties.Resources._4, Properties.Resources._5, Properties.Resources._6};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Shuffle();
            // pictureBox2.Visible = false;
        }

        private void Shuffle()
        {
            int j;
            List<int> list = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5 });
            var r = new Random();
            var listShuffle = list.OrderBy(_ => r.Next()).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                j = listShuffle[i];
                ((PictureBox)gbMemory.Controls[i]).Image = bitmap[j];
            }
        }

        bool a = true;
        private void pb1Click(object sender, EventArgs e)
        {
            if (a)
            {
                ((PictureBox)gbMemory.Controls[8]).Image = Properties.Resources._1;
            } else
            {
                ((PictureBox)gbMemory.Controls[8]).Image = null;
            }
            a = !a;
            ((PictureBox)gbMemory.Controls[3]).Image = Properties.Resources._6;
            ((PictureBox)gbMemory.Controls[4]).Image = Properties.Resources._5;
            ((PictureBox)gbMemory.Controls[5]).Image = Properties.Resources._4;
            ((PictureBox)gbMemory.Controls[6]).Image = Properties.Resources._3;
            ((PictureBox)gbMemory.Controls[7]).Image = Properties.Resources._2;
            ((PictureBox)gbMemory.Controls[8]).Image = Properties.Resources._1;
        }
    }
}