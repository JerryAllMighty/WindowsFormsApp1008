using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1008
{
    public partial class 타자연습 : Form
    {
        public 타자연습()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "200";   //속성에 값을 준다 이러면 셋에 간다
            progressBar1.Value = 100;
            timer1.Interval = 300;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Text = "회";   //속성에 값을 준다 이러면 셋에 간다
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
            if (progressBar1.Value < 10)
            {
                progressBar1.Value = 0;
                timer1.Stop();
            }
            else
                progressBar1.Value = progressBar1.Value - 10;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            timer1.Start();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //복합키까지 잡아낸다

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //아스키코드로 된 것만 취급, 단순 키 입력일 때 사용
            if (e.KeyChar == 13)
            {

                timer1.Stop();
                //정답체크
                //if(label3.Text == textBox1.Text)
                    //점수 올리기
                //else 
                        //기회를 빼준다 문제를 다시 출제한다

            }
        }
    }
}
