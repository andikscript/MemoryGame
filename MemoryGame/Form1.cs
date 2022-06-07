namespace MemoryGame
{
    public partial class Form1 : Form
    {
        readonly List<Bitmap> bitmap = new List<Bitmap> { Properties.Resources._1, Properties.Resources._2,
        Properties.Resources._3, Properties.Resources._4, Properties.Resources._5, Properties.Resources._6};
        readonly List<Bitmap> listMatch = new List<Bitmap>();
        List<int> listNumber = new List<int>();
        List<int> listCompare = new List<int>();
        List<int> listIndex = new List<int>();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Shuffle();
            HideImage();
            // pictureBox2.Visible = false;
        }

        private void Shuffle()
        {
            int j;
            List<int> list = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5 });
            var r = new Random();
            var listShuffle = list.OrderBy(_ => r.Next()).ToList();
            listNumber = listShuffle;

            for (int i = 0; i < list.Count; i++)
            {
                j = listShuffle[i];
                ((PictureBox)gbMemory.Controls[i]).Image = bitmap[j];
                listMatch.Add(bitmap[j]);
            }
        }

        private void ClickPicture(object sender, EventArgs e)
        {

            // untuk mengetahui index yang di klik di picture box
            int index = gbMemory.Controls.IndexOf(sender as PictureBox);
            ((PictureBox)gbMemory.Controls[index]).Image = listMatch[index];
            listCompare.Add(listNumber[index]);
            listIndex.Add(index);
            
            if (listCompare.Count == 2)
            {
                if (listCompare[0] == listCompare[1] && listIndex[0] != listIndex[1])
                {
                    ((PictureBox)gbMemory.Controls[listIndex[0]]).Visible = false;
                    ((PictureBox)gbMemory.Controls[listIndex[1]]).Visible = false;
                    count += 1;
                } else
                {
                    ((PictureBox)gbMemory.Controls[listIndex[0]]).Image = Properties.Resources.question;
                    ((PictureBox)gbMemory.Controls[listIndex[1]]).Image = Properties.Resources.question;
                }

                listCompare.Clear();
                listIndex.Clear();
            }

            if (count == 6)
            {
                MessageBox.Show("Congratulation...\nMemory Game is Win\n");
                listMatch.Clear();
                listNumber.Clear();
                listCompare.Clear();
                listIndex.Clear();
                VisibleImage();
                Shuffle();
                HideImage();
                count = 0;
            }
        }

        private void HideImage()
        {
            for (int i = 0; i < gbMemory.Controls.Count; i++)
            {
                ((PictureBox)gbMemory.Controls[i]).Image = Properties.Resources.question;
            }
        }

        private void VisibleImage()
        {
            for (int i = 0; i < 12; i++)
            {
                ((PictureBox)gbMemory.Controls[i]).Visible = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}