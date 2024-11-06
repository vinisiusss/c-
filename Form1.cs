using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_game_gallows
{

    public partial class Form1 : Form
    {
        public Form1 frm1;
        public Form3 frm3;
        public char[] mas = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'щ', 'ш', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        Button[,] bt = new Button[3, 11]; // массив для кнопок
        PictureBox vis = new PictureBox(); // место под картинки
        Label un_word = new Label(); // место для слова
        string[] words; // массив для слов на выбор
        string word;
        string fon = @"visel.jpg";
        string fon1 = @"ff.png";

        string name_pic; // имя файла картинки
        int h = 60, l = 40, word_len;//размер кнопки
        int x0 = 400, y0 = 320;//координаты 
        int hp = 1;
        int level = 0;
        



        public Form1()
        {
            InitializeComponent();
        }

        void new_game()
        {
            this.BackgroundImage = Image.FromFile(fon1);
            un_word.ForeColor = Color.Black;
            if (level == 3)
            {
                this.BackgroundImage = Image.FromFile(fon1);
                un_word.ForeColor = Color.Black;
            }
            open_words();
            create_alfo();
            create_pb();
            show_word();
        }

        void open_words() // функция выбора слова на простом уровне сложности
        {
            Random rnd = new Random();
            string name_words = @"words.txt";
            if (level == 1)
                name_words = @"words.txt";
            if (level == 2)
                name_words = @"wordsn.txt";
            if (level == 3)
            {
                name_words = @"wordsb.txt";
            }
            words = File.ReadAllLines(name_words, Encoding.UTF8);
            word = words[rnd.Next(0, words.Length)];
            word = word.ToLower();
            word_len = word.Length;
        }


        void create_pb() // редактирование места под картинку
        {
            vis.Left = 12;
            vis.Top = 12;
            vis.Width = 400;
            vis.Height = 590;
            name_pic = hp.ToString() + ".jpg";
            vis.Image = Image.FromFile(@name_pic);
            vis.SizeMode = PictureBoxSizeMode.AutoSize;
            vis.Visible = true;
            Controls.Add(vis);
        }


         void show_word() // отображение загаданного слова
        {
            Random rnd = new Random();
            int i1, i2;
            un_word.BackColor = Color.Transparent;
            un_word.Text = "";
            un_word.Left = 430;
            un_word.Top = 12;
            un_word.Width = 400;
            un_word.Height = 350;
            un_word.Visible = true;
            un_word.Font = new Font("Segoe Script", 55, FontStyle.Bold);
            un_word.TextAlign = ContentAlignment.MiddleCenter;
            un_word.Text = "";
            i1 = rnd.Next(0, word_len);
            i2 = rnd.Next(0, word_len);
            if (word[i1] == ' ' || word[i2] == ' ' || word[i1] == word[i2]) // проверка на совпадение случайных букв
            {
                if (word[i1] == ' ')
                    i1++;
                if (word[i2] == ' ')
                    i2++;
                if (word[i1] == word[i2])
                {
                    if (i1 >= 0 && i1 < word_len - 1)
                        i1++;
                    else i1--;
                }
            }
            for (int i = 0; i < word.Length; i++) // заполнение поля для слова 
            {
                if (i == i1)
                    un_word.Text += word[i1].ToString();
                else if (i == i2)
                    un_word.Text += word[i2].ToString();
                else if (word[i] == ' ')
                    un_word.Text += "\n";
                else
                    un_word.Text += "*";
            }
            Controls.Add(un_word);
        }


        void create_alfo() // заполнение массива с буквами
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    bt[i, j] = new Button();
                    bt[i, j].Left = x0 + j * l + 10;
                    bt[i, j].Top = y0 + i * h + 10;
                    bt[i, j].Width = l;
                    bt[i, j].Height = h;
                    bt[i, j].Font = new Font("Arial", 24, FontStyle.Bold);
                    char w;
                    w = mas[(i * 11) + j];
                    bt[i, j].Click += bt_Click;
                    bt[i, j].Text = w.ToString();
                    Controls.Add(bt[i, j]);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(fon); 
        }

        public void button5_Click_1(object sender, EventArgs e) // простой уровень
        {
            level = 1;
            button8.Visible = true;
            button1.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button9.Visible = true;
            button2.Visible = false;
            new_game();
        }

        private void button7_Click_1(object sender, EventArgs e) // Сложный уровень
        {
            level = 3;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button1.Visible = false;
            button8.Visible = true;
            button2.Visible = false;
            button9.Visible = true;
            new_game();
        }


     


        private void button9_Click(object sender, EventArgs e)
        {
            if (level != 0)
            {
                
                hp = 1;
                for (int i = 0; i < 3; i++) // прячем кнопки алфавита
                {
                    for (int j = 0; j < 11; j++)
                    {
                        bt[i, j].Visible = false;
                        bt[i, j].BackColor = Color.Black;
                    }

                }
                vis.Visible = false;
                this.BackgroundImage = Image.FromFile(fon);
            }

            button8.Visible = false;
            button9.Visible = false;
            un_word.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e) // Помощь
        {
            frm3 = new Form3();
            frm3.frm1 = this;
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            this.Close();
            frm1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < 3; i++) // прячем кнопки алфавита
            {
                for (int j = 0; j < 11; j++)
                {
                    bt[i, j].Visible = false;
                    bt[i, j].BackColor = Color.White;
                }

            }
            new_game();
        }


        public void bt_Click(object sender, EventArgs e) // нажатие кнопки
        {

            int k, m, flag = 0;
            int word_len_p = 0;
            string show_mes = "", text = "Начать новую игру?"; // сообщение в конце
            Button Tb = sender as Button;
            DialogResult dr = new DialogResult();
            k = (Tb.Left - x0 - 10) / l; // индекс столбца
            m = (Tb.Top - y0 - 10) / h; // индекс строки

            for (int i = 0; i < word_len; i++) // проверка на совпадение текста буквы с буквами из слова
            {
                if (Tb.BackColor == Color.Red)
                {
                    flag = 1;
                    break;
                }

                else if (bt[m, k].Text == word[i].ToString())
                {
                    string help_word = un_word.Text;
                    un_word.Text = "";
                    for (int j = 0; j < word_len; j++) // перезапись загаданного слова
                    {
                        if (j == i)
                            un_word.Text += word[i].ToString();
                        else if (help_word[j] != '*')
                            un_word.Text += help_word[j].ToString();
                        else
                            un_word.Text += "*";
                    }
                    bt[m, k].Visible = false;
                    flag = 1;
                }
            }

            for (int i = 0; i < word_len; i++) // цикл для проверки на победу
            {
                string help_word = un_word.Text;
                if (help_word[i] != '*')
                {
                    word_len_p += 1;
                }
            }
            if (word_len_p == word_len || (hp + 1 == 7 && flag == 0)) // проверка на окончание игры
            {
                if (word_len_p == word_len) // проверка на победу
                {
                    
                    show_mes = "Вы выиграли!";
                }
                else if (hp + 1 == 7 && flag == 0) // проверка на поражение
                {
                    
                    hp++;
                    if (level == 3)
                    {
                        hp++;
                    }
                    name_pic = hp.ToString() + ".jpg";
                    vis.Image = Image.FromFile(@name_pic);
                    hp = 1;
                    show_mes = "Вы проиграли!";
                    text = "Слово - " + word + ".\nНачать новую игру?";
                }
                hp = 1;
                dr = MessageBox.Show(text, caption: show_mes, MessageBoxButtons.YesNo); // вывод сообщения о заверж=шении игры

                for (int i = 0; i < 3; i++) // прячем кнопки алфавита
                {
                    for (int j = 0; j < 11; j++)
                    {
                        bt[i, j].Visible = false;
                        bt[i, j].BackColor = Color.White;
                    }

                }
                vis.Visible = false; 
                if (dr == DialogResult.Yes)
                {
                    new_game();
                }
                else if (dr == DialogResult.No)
                {
                    this.BackgroundImage = Image.FromFile(fon);
                    button8.Visible = false;
                    button1.Visible = true;
                    button9.Visible = false;              
                    un_word.Visible = false;
                    button2.Visible = true;
                    button7.Visible = true;
                    button6.Visible = true;
                    button5.Visible = true; 
                }

            }
            else if (flag == 0)
            {
                hp++;
                name_pic = hp.ToString() + ".jpg";
                vis.Image = Image.FromFile(@name_pic);
                Tb.BackColor = Color.Red;
            }

        }


        private void button6_Click(object sender, EventArgs e)
        {
            level = 2;
            button1.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            button2.Visible = false;
            button9.Visible = true;
            new_game();
        }

    }
}
