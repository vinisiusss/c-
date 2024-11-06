using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_game_gallows
{
    public partial class Form3 : Form
    {
        public Form1 frm1;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Segoe Script", 18, FontStyle.Bold);
            label1.Text = "ПОМОЩЬ.\nВаша задача угадать слово по двум известным буквам.\nВы даете ответ с помощью предложенного снизу алфавита.\nЕсли висельница достроится прежде чем вы полностью откроете слово, то вы проиграли.\nУДАЧИ!";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            frm1.Show();
            this.Close();
        }
    }
}
