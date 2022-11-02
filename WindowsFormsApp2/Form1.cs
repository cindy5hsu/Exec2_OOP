using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class 四個骰子游戲 : Form 
    {
        public 四個骰子游戲()
        {
            InitializeComponent();
            answerlabel1.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            answerlabel1.Text = String.Empty;

            //取得亂數
            Random rnd = new Random();

            int[] x = new int[4] {rnd.Next(1,7), rnd.Next(1,7), 
                                 rnd.Next(1,7), rnd.Next(1,7) };
            for (int i = 0; i < 4; i++)
            {
                answerlabel1.Text += Convert.ToString(x[i]);
            }

            //不符合重新return
            Array.Sort(x);
            if (x[0] != x[1] 
                && x[1] != x[2] 
                && x[2] != x[3] )
            {
                MessageBox.Show("數字至少有兩個數字相同");
                
                return;
            }
            //計算
            int Result = 0;
            if (x[0] == x[1])
            {
                Result = x[2] + x[3];
            }
            else if (x[1] == x[2])
            {
                Result = x[0] + x[3];
            }
            else
            {
                Result = x[0] + x[1];
            }
            //結果
            textBox1.Text = $"結果為{Result}點";
        }
    }
}
