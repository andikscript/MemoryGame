using System.Timers;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        readonly List<Bitmap> bitmap = new List<Bitmap> { Properties.Resources._1, Properties.Resources._2,
        Properties.Resources._3, Properties.Resources._4, Properties.Resources._5, Properties.Resources._6};
        readonly List<Bitmap> listMatch = new List<Bitmap>();
        List<int> listNumber = new List<int>();
        List<int> listCompare = new List<int>();
        List<int> listIndex = new List<int>();
        int count = 0;
        int counter = 60;

        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000;
            labelTime.Text = "01:00";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer.Stop();
            labelTime.Text = counter.ToString().Length == 1 ? "00:0" + counter.ToString() :
                "00:" + counter.ToString();
            if (labelTime.Text == "00:00")
            {
                MessageBox.Show("Waktu Habis\nCoba Kembali", "Picture Puzzle-Image");
                ResetImage();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Shuffle();
            HideImage();
            gbMemory.Enabled = false;
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
                ResetImage();
                timer.Stop();
            }
        }

        private void ResetImage()
        {
            listMatch.Clear();
            listNumber.Clear();
            listCompare.Clear();
            listIndex.Clear();
            VisibleImage();
            Shuffle();
            HideImage();
            count = 0;
            counter = 60;
            labelTime.Text = "01:00";
            Button_Start.Enabled = true;
            gbMemory.Enabled = false;
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
        private void Button_Exit(object sender, EventArgs e)
        {
            var YesOrNo = new DialogResult();
            YesOrNo = MessageBox.Show("Apakah Anda Ingin Keluar??",
                    "Memory Game is Win", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (YesOrNo == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            if (Button_Start.Text == "START")
            {
                Button_Start.Enabled = false;
                gbMemory.Enabled = true;
                timer.Start();
            } 
        }
    }
}