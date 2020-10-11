using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1008
{
    public partial class 타자연습 : Form
    {
        Random rand = new Random();
        List<string> sentence = new List<string>();
        int count = 10;
        int initialscore = 0;


        public 타자연습()
        {
            InitializeComponent();
            StreamReader rs = new StreamReader("별 헤는 밤-윤동주.txt", Encoding.UTF8);

            while (!rs.EndOfStream)
            {
                sentence.Add(rs.ReadLine());
            }
        }

        private void Form1_Load()       //아래서 게임을 재시작 시 초기화 때 쓰기 위해서 오버로딩
        {
            count = 10;
            initialscore = 0;
            label1.Text = initialscore.ToString();
            label2.Text = $"{count}회";
            label4.Text = sentence[rand.Next(0, sentence.Count)];
            progressBar1.Value = 100;
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = initialscore.ToString();   //속성에 값을 준다 이러면 셋에 간다
            label2.Text = $"{count}회";
            label4.Text = sentence[rand.Next(0, sentence.Count)];

            progressBar1.Value = 100;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //Timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 10 )
            {

                timer1.Stop();
                Restart();
            }
            else
                progressBar1.Value = progressBar1.Value - 10;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0)
            {
                timer1.Start();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //복합키까지 잡아낸다

        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)      //아스키코드로 된 것만 취급, 단순 키 입력일 때 사용
        {
            
            if (e.KeyChar == 13)        //정답체크     //반드시 엔터를 눌렀을 때에만 답을 체크한다
            {
                timer1.Stop();
                if (label4.Text == textBox1.Text)       //점수 올리기
                {
                    label1.Text = (initialscore += 100).ToString();
                    label4.Text = sentence[rand.Next(0, sentence.Count)];       //다음 문제로 넘어가야지
                    textBox1.Clear();
                    if (progressBar1.Value < 100)
                        progressBar1.Value += 10;
                }

                else
                {
                        //오답
                }
                {
                    textBox1.Clear();
                    label2.Text = $"{--count}회";
                }
            }
            if (count == 0)     //기회 소진시에는 다시 할 건지 물어봐야지
            {
                Restart();
            }
        }

        private void Restart()      //다시 할 건지 의사 물어보기
        {
            timer1.Stop();
            MessageBox.Show("짱 못하시네요 ㅎㅎ", "Game Over");
            DialogResult result = MessageBox.Show("다시 시작하시겠습니까?", "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                textBox1.Clear();
                this.Form1_Load();
            }
            else if (result == DialogResult.No)
                Environment.Exit(001);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)      //난이도 하
        {
            timer1.Interval = 3000;
        }

        private void button5_Click(object sender, EventArgs e)      //난이도 중
        {
            timer1.Interval = 1500;
        }

        private void button4_Click(object sender, EventArgs e)      //난이도 상
        {
            timer1.Interval = 1000;
        }
    }
}
