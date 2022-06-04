namespace MemoryGame
{
    public partial class Form1 : Form
    {
        readonly List<Bitmap> bitmap = new List<Bitmap> { Properties.Resources._1, Properties.Resources._2,
        Properties.Resources._3, Properties.Resources._4, Properties.Resources._5, Properties.Resources._6};
        List<Bitmap> listMatch = new List<Bitmap>();
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
                listMatch.Add(bitmap[j]);
            }
        }

        bool a = true;
        private void pb1Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideImage();
        }

        private void ClickPicture(object sender, EventArgs e)
        {
            // untuk mengetahui index yang di klik di picture box
            int index = gbMemory.Controls.IndexOf(sender as PictureBox);
            label.Text = Convert.ToString(index);
            ((PictureBox)gbMemory.Controls[index]).Image = listMatch[index];
        }

        private void HideImage()
        {
            for (int i = 0; i < gbMemory.Controls.Count; i++)
            {
                ((PictureBox)gbMemory.Controls[i]).Image = Properties.Resources.question;
            }
        }
    }
}