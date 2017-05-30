using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomLeshenko
{
    public partial class Form1 : Form
    {
        Int16 colRows = 0;
        Int16 colCell = 3;

        //int[,] massiveBlocks = new int[3, 2] { {0,1,2 }, {0,1,1 }, { 2,3,4} };

        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = 560;
            pictureBox1.Height = 376;
            generateStartBox();
        }

        private void generateStartBox()
        {
            dataGridView1.ColumnCount = colCell;
            //dataGridView1.Cells[-1].HeaderCell.Value = "HI";
            dataGridView1.Columns[0].HeaderCell.Value = "Ширина";
            dataGridView1.Columns[1].HeaderCell.Value = "Высота";
            dataGridView1.Columns[2].HeaderCell.Value = "Площадь";
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.TopLeftHeaderCell.Value = "#";

            textBox2.Text = pictureBox1.Size.Width.ToString();
            textBox1.Text = pictureBox1.Size.Height.ToString();

            tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addBlock();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //pictureBox1.Width = Convert.ToInt32(textBox1.Text);
            this.changeTextInPreSetArea();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //pictureBox1.Height = Convert.ToInt32(textBox2.Text);
            this.changeTextInPreSetArea();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*tabControl1.SelectedIndex = 0;
            Random ran = new Random();
            for(int i = 0; i < 500; i++)
            {
                textBox5.Text = ran.Next(5, 50).ToString();
                textBox3.Text = ran.Next(5, 50).ToString();
                addBlock();
            }
            //Draw(50, 50);
            drawBlocks();*/
            colRows = 0;
            label1.Text = "Количество элементов - "+colRows;
            dataGridView1.Rows.Clear();
            int[,] generateBlocks_values = new int[5,1];//0{кол-во элементов}, 1{минимальная ширина}, 2{максимальная ширина}, 3{минимальная высота}, 4{максимальная высота}
            if(Convert.ToInt32(this.textBox4.Text) <= 0)//если кол-во блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[0, 0] = 500;
            }

            if (Convert.ToInt32(this.textBox6.Text) <= 0)//если минимаьная ширина блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[1, 0] = 5;
            }

            if (Convert.ToInt32(this.textBox7.Text) <= 0)//если максимальная ширина блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[2, 0] = 50;
            }

            if (Convert.ToInt32(this.textBox9.Text) <= 0)//если минимаьная высота блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[3, 0] = 5;
            }

            if (Convert.ToInt32(this.textBox8.Text) <= 0)//если максимальная высота блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[4, 0] = 50;
            }

            //tabControl1.SelectedIndex = 0;
            Random ran = new Random();
            button1.Enabled = false;
            button2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            for (int i = 0; i < generateBlocks_values[0, 0]; i++)
            {
                textBox5.Text = ran.Next(generateBlocks_values[3, 0], generateBlocks_values[4, 0]).ToString();
                textBox3.Text = ran.Next(generateBlocks_values[1, 0], generateBlocks_values[2, 0]).ToString();
                //System.Threading.Thread.Sleep(10);
                addBlock();
            }
            button1.Enabled = true;
            button2.Enabled = true;
            textBox3.Enabled = true;
            textBox5.Enabled = true;
            //drawBlocks();


        }

        public void Draw(Bitmap bmp, int width, int height, int x, int y)
        {
            /*Bitmap bmp;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);*/
            Random ran = new Random();
            pictureBox1.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Rectangle rect = new Rectangle(x, y, width, height);
            g.DrawRectangle(new Pen(Color.Black, 2), rect);
            g.FillRectangle(Brushes.OrangeRed, new Rectangle(x, y, width, height));
            //Thread.Sleep(1);
        }

        private void drawBlocks()
        {
            /*
             * colRows - кол-во элементов        
            */
            Bitmap bmp;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            int maxWidth = 0;//максимальная ширина блока в столбце
            int summWidth = 0;//общая занятая ширина в контейнере
            int summHeight = 0;//общая занятая длина в столбце
            int[,] mass = new int[500, 2];//входной массив элементов
            Random ran = new Random();
            for (int i = 0; i < 500; i++)
            {
                mass[i, 0] = i;
                mass[i, 1] = ran.Next(0,1);
            }

            int posOrientationW = 0; //если 0 - то так как есть, если 1 - то ширина = длина, длина = ширина(ракеровка)
            int posOrientationH = 1; //если 0 - то так как есть, если 1 - то ширина = длина, длина = ширина(ракеровка)

            int x = 0, y = 0;

           for (int i = 0; i < colRows; i++)
            {
                //System.Threading.Thread.Sleep(10);
                if (mass[i,1] == 1)
                {
                    posOrientationH = 0;
                    posOrientationW = 1;
                }
                else
                {
                    posOrientationH = 1;
                    posOrientationW = 0;
                }

                if((y + Convert.ToInt16(dataGridView1.Rows[mass[i,0]].Cells[posOrientationH].Value)) > pictureBox1.Size.Height)//если места нет, то надо передвинуть на следующий столбец
                {
                    x += maxWidth;
                    summHeight = 0;
                    y = 0;
                    maxWidth = 0;
                }

                if((x + Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value)) > pictureBox1.Size.Width)
                {
                    //MessageBox.Show("Элемент -"+mass[i,0]+" не помещается в ширину формы");
                    continue;
                }

                Draw(bmp, Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value), Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value), x+2, y+2);

                //MessageBox.Show("Отрисовали элемент - "+mass[i, 0]);

                if (Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value) > maxWidth) maxWidth = Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value);

                y += Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value);

                summHeight += Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value);
                summWidth += Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Height = Convert.ToInt32(textBox1.Text);
            pictureBox1.Width = Convert.ToInt32(textBox2.Text);
        }

        private int calculateAreaInputForm()
        {
            if(textBox2.Text != "" && textBox1.Text != "")
            {
                int x, y;
                x = Convert.ToInt32(textBox2.Text);
                y = Convert.ToInt32(textBox1.Text);
                if (x > 0 && y > 0)
                {
                    return x * y;
                }
            }
            return 0;
        }

        private void changeTextInPreSetArea()
        {
            label9.Text = "S = "+calculateAreaInputForm();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            changeTextInInfoArea();
        }

        private void changeTextInInfoArea()
        {
            label2.Text = "Размер контейнера = "+pictureBox1.Height+"x"+pictureBox1.Width;
            label10.Text = "Площадь = " + calculateAreaForm();
        }

        private int calculateAreaForm()
        {
            return pictureBox1.Width * pictureBox1.Height;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Вы нажали на Column"+e.ColumnIndex+" Row"+e.RowIndex);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addBlock();
            }
        }

        private void addBlock()
        {
            if (textBox3.Text != "" && textBox5.Text != "")
            {
                dataGridView1.Rows.Add();
                int widthBlock = Convert.ToInt32(textBox3.Text);
                int hightBlock = Convert.ToInt32(textBox5.Text);
                dataGridView1.Rows[colRows].HeaderCell.Value = ".!.";
                dataGridView1.Rows[colRows].Cells[0].Value = widthBlock;
                dataGridView1.Rows[colRows].Cells[1].Value = hightBlock;
                dataGridView1.Rows[colRows].Cells[2].Value = widthBlock * hightBlock;

                colRows++;
                label1.Text = "Количество элементов - " + colRows;
            }
            else
            {
                MessageBox.Show("Какое - то из полей заполнено неверно или вовсе не заполнено!", "Поле ввода не заполнено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (textBox3.Text == "") textBox3.Focus();
                if (textBox5.Text == "") textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addBlock();
            }
        }

        private void светлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            for (int i = 0; i < 500; i++)
            {
                textBox5.Text = ran.Next(5, 50).ToString();
                textBox3.Text = ran.Next(5, 50).ToString();
                addBlock();
            }
            //Draw(50, 50);
            drawBlocks();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void рстянутьОкноОтображениеПоРазмеруДоступнойОластиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = (tabControl1.Size.Height - 35).ToString();
            textBox2.Text = (tabControl1.Size.Width - 20).ToString();
            pictureBox1.Height = Convert.ToInt32(textBox1.Text);
            pictureBox1.Width = Convert.ToInt32(textBox2.Text);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void мутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.genetickAlhorihm();
        }

        private void genetickAlhorihm()
        {

        }
    }
}
