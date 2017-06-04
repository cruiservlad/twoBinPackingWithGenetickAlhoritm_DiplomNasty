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
        int allIteration = 0;

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
            //toolStripProgressBar1.Width = this.Size.Width;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            colRows = 0;
            label1.Text = "Количество элементов - "+colRows;
            dataGridView1.Rows.Clear();
            int[,] generateBlocks_values = new int[5,1];//0{кол-во элементов}, 1{минимальная ширина}, 2{максимальная ширина}, 3{минимальная высота}, 4{максимальная высота}
            if(Convert.ToInt32(this.textBox4.Text) <= 0)//если кол-во блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[0, 0] = 500;
            }
            else generateBlocks_values[0, 0] = Convert.ToInt32(this.textBox4.Text);

            if (Convert.ToInt32(this.textBox6.Text) <= 0)//если минимаьная ширина блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[1, 0] = 5;
            }
            else generateBlocks_values[1, 0] = Convert.ToInt32(this.textBox6.Text);

            if (Convert.ToInt32(this.textBox7.Text) <= 0)//если максимальная ширина блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[2, 0] = 50;
            }
            else generateBlocks_values[2, 0] = Convert.ToInt32(this.textBox7.Text);

            if (Convert.ToInt32(this.textBox9.Text) <= 0)//если минимаьная высота блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[3, 0] = 5;
            }
            else generateBlocks_values[3, 0] = Convert.ToInt32(this.textBox9.Text);

            if (Convert.ToInt32(this.textBox8.Text) <= 0)//если максимальная высота блоков в автогенерации меньше или равно 0 используем значение по дефолту
            {
                generateBlocks_values[4, 0] = 50;
            }
            else generateBlocks_values[4, 0] = 50;

            //tabControl1.SelectedIndex = 0;
            Random ran = new Random();
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;

            textBox4.Text = generateBlocks_values[0, 0].ToString();
            textBox6.Text = generateBlocks_values[1, 0].ToString();
            textBox7.Text = generateBlocks_values[2, 0].ToString();
            textBox9.Text = generateBlocks_values[3, 0].ToString();
            textBox8.Text = generateBlocks_values[4, 0].ToString();

            toolStripProgressBar1.Maximum = generateBlocks_values[0, 0];
            toolStripProgressBar1.Value = 0;
            //MethodInvoker simpleDelegate = new MethodInvoker(addBlock);
            for (int i = 0; i < generateBlocks_values[0, 0]; i++)
            {
                toolStripProgressBar1.Value++;
                textBox5.Text = ran.Next(generateBlocks_values[3, 0], generateBlocks_values[4, 0]).ToString();
                textBox3.Text = ran.Next(generateBlocks_values[1, 0], generateBlocks_values[2, 0]).ToString();
                //System.Threading.Thread.Sleep(10);
                addBlock();
                //simpleDelegate.BeginInvoke(null, null);
                await Task.Delay(1);
            }
            toolStripProgressBar1.Value = 0;
            groupBox4.Enabled = true;
            groupBox1.Enabled = true;
            //drawBlocks();


        }

        public void Draw(Bitmap bmp, int width, int height, int x, int y)
        {
            DateTime localDate = DateTime.Now;
            //MessageBox.Show("Draw");
            /*Bitmap bmp;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);*/
            Random ran = new Random((int)DateTime.Now.Ticks);

            pictureBox1.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Rectangle rect = new Rectangle(x, y, width, height);
            g.DrawRectangle(new Pen(Color.Black, 2), rect);
            Brush[] b = new[] { Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.Aquamarine, Color.Azure, Color.Beige, Color.Bisque, Color.BlanchedAlmond, Color.Blue, Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue, Color.Cornsilk,Color.Crimson,Color.Cyan,
            Color.DarkBlue,Color.DarkCyan,Color.DarkGoldenrod,Color.DarkGray,Color.DarkGreen,Color.DarkKhaki,Color.DarkMagenta,Color.DarkOliveGreen,Color.DarkOrange}.Select(c => new SolidBrush(c)).ToArray();//21
            //b[1] = Color.FromArgb(255,255,255,255);

            
            g.FillRectangle(b[ran.Next(0, b.Length)], new Rectangle(x, y, width, height));
            //System.Threading.Thread.Sleep(10);
            //g.FillRectangle(Brushes.YellowGreen, new Rectangle(x, y, width, height));
            //g.FillRectangle();
            //Thread.Sleep(1);
            /*DateTime localDate2 = DateTime.Now;
            while ((localDate2.Second - localDate.Second) < 1)
            {
                localDate2 = DateTime.Now;
            }*/




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

        private async void genetickAlhorihm()
        {
            //int[,] mass = new int[dataGridView1.RowCount - 1,2];
            
            /*for (int i = 0; i < (dataGridView1.RowCount -1); i++)
            {
                mass[i, 0] = i;
                System.Console.WriteLine(i.ToString());
                mass[i, 1] = ran.Next(0, 1);
            }
            drawBlocks(mass);*/

            int coutOfIteration = Convert.ToInt16(textBox10.Text);
            int timeOfIteration = Convert.ToInt16(textBox11.Text);
            int coutOfConteyner = dataGridView1.RowCount - 1;
            int[,] massDouble = new int[coutOfConteyner, 2];
            int iterIsCool = 0;
            if (coutOfIteration > 0)
            {
                toolStripProgressBar1.Maximum = coutOfIteration;
                toolStripProgressBar1.Value = 0;
                TreeNode iterationTree = new TreeNode("Итерации");
                double maxCF = 0;
                int[,] mass = new int[coutOfConteyner, 2];
                int notIncludedCont = 0;
                for (int coutIter = 0; coutIter < coutOfIteration; coutIter++)
                {
                    toolStripProgressBar1.Value++;
                    Random r = new Random((int)DateTime.Now.Ticks);
                    int max = coutOfConteyner;
                    int[] x = new int[max];
                    for (int i = 0; i < max; i++)
                    {
                        bool contains;
                        int next;
                        do
                        {
                            next = r.Next(max);
                                contains = false;
                                for (int index = 0; index < i; index++)
                                {
                                    int n = x[index];
                                    if (n == next)
                                    {
                                        contains = true;
                                        break;
                                    }
                                }
                        } while (contains);
                        x[i] = next;
                    }
                    for (int i = 0; i < coutOfConteyner; i++)
                    {
                            mass[i, 0] = x[i];
                            mass[i, 1] = r.Next(0, 1);
                    }
                        notIncludedCont = drawBlocks(mass);
                        double cf = ((Convert.ToDouble(coutOfConteyner) - Convert.ToDouble(notIncludedCont)) / Convert.ToDouble(coutOfConteyner));
                        iterationTree.Nodes.Add(new TreeNode("#" + coutIter));
                        iterationTree.Nodes[coutIter].Nodes.Add(new TreeNode("ЦФ=" + cf));
                    if (maxCF < cf)
                    {
                            maxCF = cf;
                            massDouble = mass;
                            iterIsCool = coutIter;
                    }
                    
                    await Task.Delay(1);
                    
                }
                    treeView1.Nodes.Add(iterationTree);
                }

            if(timeOfIteration > 0)
            {

            }

            drawBlocks(massDouble);
            MessageBox.Show("Лучшая итерация - "+iterIsCool);
            toolStripProgressBar1.Value = 0;
        }

            private int drawBlocks(int[,] mass)
            {
                /*
                 * colRows - кол-во элементов        
                */
                int notInclude = 0;
            Bitmap bmp;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            int maxWidth = 0;//максимальная ширина блока в столбце
            int summWidth = 0;//общая занятая ширина в контейнере
            int summHeight = 0;//общая занятая длина в столбце
            //int[,] mass = new int[500, 2];//входной массив элементов
            Random ran = new Random((int)DateTime.Now.Ticks);
            /*for (int i = 0; i < mass.Length; i++)
            {
                mass[i, 0] = i;
                mass[i, 1] = ran.Next(0, 1);
            }*/

            int posOrientationW = 0; //если 0 - то так как есть, если 1 - то ширина = длина, длина = ширина(ракеровка)
            int posOrientationH = 1; //если 0 - то так как есть, если 1 - то ширина = длина, длина = ширина(ракеровка)

            int x = 0, y = 0;
            for (int i = 0; i < colRows; i++)
            {
                //System.Threading.Thread.Sleep(10);
                if (mass[i, 1] == 1)
                {
                    posOrientationH = 0;
                    posOrientationW = 1;
                }
                else
                {
                    posOrientationH = 1;
                    posOrientationW = 0;
                }

                if ((y + Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value)) > pictureBox1.Size.Height)//если места нет, то надо передвинуть на следующий столбец
                {
                    x += maxWidth;
                    summHeight = 0;
                    y = 0;
                    maxWidth = 0;
                }

                if ((x + Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value)) > pictureBox1.Size.Width)
                {
                    //MessageBox.Show("Элемент -"+mass[i,0]+" не помещается в ширину формы");
                    notInclude++;
                    continue;
                }

                Draw(bmp, Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value), Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value), x + 2, y + 2);

                //MessageBox.Show("Отрисовали элемент - "+mass[i, 0]);
                //System.Console.WriteLine("Отрисовали элемент - "+mass[i,0]);

                if (Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value) > maxWidth) maxWidth = Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value);

                y += Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value);

                summHeight += Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationH].Value);
                summWidth += Convert.ToInt16(dataGridView1.Rows[mass[i, 0]].Cells[posOrientationW].Value);
            }
            return notInclude;
        }

        private void светлячкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MethodInvoker simpleDelegate = new MethodInvoker(genetickAlhorihm);
            /*for (int i = 0; i < 100; i++)
            {
                genetickAlhorihm();
                //simpleDelegate.BeginInvoke(null, null);
            }*/
            tabControl1.Enabled = false;
            genetickAlhorihm();
            tabControl1.Enabled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
            textBox11.Text = "0";
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
            textBox10.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
