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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Convert.ToInt16(textBox6.Text.ToString());
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
            Draw(50, 50);
        }

        public void Draw(int width, int height)
        {
            Bitmap bmp;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Rectangle rect = new Rectangle(20, 20, width, height);
            g.DrawRectangle(new Pen(Color.Red, .5f), rect);
            g.FillRectangle(Brushes.Red, new Rectangle(20, 20, width, height));
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
            label9.Text = "Площадь = "+calculateAreaInputForm();
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
            MessageBox.Show("Вы нажали на Column"+e.ColumnIndex+" Row"+e.RowIndex);
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

            }
            //else MessageBox.Show();
            /*dataGridView1.Rows.Add();
            int widthBlock = Convert.ToInt32(textBox3.Text);
            int hightBlock = Convert.ToInt32(textBox5.Text);
            dataGridView1.Rows[colRows].HeaderCell.Value = ".!.";
            dataGridView1.Rows[colRows].Cells[0].Value = widthBlock;
            dataGridView1.Rows[colRows].Cells[1].Value = hightBlock;
            dataGridView1.Rows[colRows].Cells[2].Value = widthBlock * hightBlock;

            colRows++;
            label1.Text = "Количество элементов - " + colRows;*/
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addBlock();
            }
        }
    }
}
