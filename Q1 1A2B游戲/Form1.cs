using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1_1A2B游戲
{
    public partial class Form1 : Form
    {
        private int[] ans = {0,1,2,3,4,5,6,7,8,9}; //答案範圍
        private string[] Num = new string[10];
        private int tmp, r;
        private Random ran = new Random(Guid.NewGuid().GetHashCode());
        private int[] answer = new int[4];
        public Form1()
        {
            InitializeComponent();
           
            MenuItem01.Click += new System.EventHandler(MenuItem01_Click);

            countLabel.Text = anslabel2.Text = String.Empty;
            label1.Text = "請輸入四個不重複的數字";
            
            for (int i = 0; i < 10; i++)
            {
                r = ran.Next(0, 10);
                tmp = ans[r];
                ans[r] = ans[9 - i];
                ans[9 - i] = tmp;                
            }
            for (int i = 0; i < 4; i++)
            {
                answer[i] = ans[i];
            }
        }        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MenuItem02_Click(object sender, EventArgs e)
        {
            foreach (int item in answer)
            {
                anslabel2.Text += Convert.ToString(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = "";
            int a = 0, b = 0;
            if (textBox1.TextLength != 4)
            {
                MessageBox.Show("請輸入4個不一樣的數字");
            }
            else
            {
                for (int j = 1; j <= 4; j++)
                {
                    Num[j] = textBox1.Text.Substring(j - 1, 1);
                    num += Num[j];
                }
                if ((Num[1] == Num[2] || Num[1] == Num[3] ||
                Num[1] == Num[4] || Num[2] == Num[3] ||
                Num[2] == Num[4] || Num[3] == Num[4]))
                {
                    MessageBox.Show("不能輸入重複的數字");
                }
                else
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        for (int l = 1; l <= 4; l++)
                        {
                            if (Num[k] == ans[l].ToString())
                            {
                                if (k == l)
                                {
                                    a++;
                                }
                                else if (k != l)
                                {
                                    b++;
                                }
                            }
                        }
                    }
                    textBox2.Text += num + "-----" + a.ToString() + "A" + b.ToString() + "B" + "\r\n";
                    countLabel.Text = "已經第" + (textBox2.Lines.Length - 1) + "次猜";
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                if (a == 4 && b == 0)
                { 
                    MessageBox.Show("恭喜你猜對了");
                    button1.Enabled = false;
                }
                else if (textBox2.Lines.Length == 11)
                {
                    MessageBox.Show("猜錯了");
                    button1.Enabled = false;
                }
            }
        }

        private void anslabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuItem01_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            for (int i = 0; i < 10; i++)
            {
                r = ran.Next(0, 10);
                tmp = ans[r];
                ans[r] = ans[9 - i];
                ans[9 - i] = tmp;
            }
            for (int i = 0; i < 4; i++)
            {
                answer[i] = ans[i];
            }
            anslabel2.Text = string.Empty;
            
        }
    
    }
}
