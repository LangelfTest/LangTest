using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        Field playField;
        List<Label> Cells = new List<Label>();
        Player human;
        Player ai;
        public Form1()
        {
            InitializeComponent();
            load_Labels();
            playField = new Field(3);
            human = new Human('X');
            ai = new AI('O');
            pictureBox1.Image = Image.FromFile("E:\\Player.png");
            pictureBox2.Image = Image.FromFile("E:\\AI.png");
        }

        private void load_Labels()
        {
            Cells.Add(label1);
            Cells.Add(label2);
            Cells.Add(label3);
            Cells.Add(label4);
            Cells.Add(label5);
            Cells.Add(label6);
            Cells.Add(label7);
            Cells.Add(label8);
            Cells.Add(label9);
        }
        private void update_Labels(char[,] field, int size)
        {
            int add = 0;
            inverse_visibility();
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    if (field[row, column] != '_')
                    {
                        if (field[row, column] == human.signature)
                        {
                            Cells[add].ForeColor = Color.MediumSeaGreen;
                            Cells[add].Cursor = Cursors.No;
                        }

                        else
                        {
                            Cells[add].ForeColor = Color.SaddleBrown;
                            Cells[add].Cursor = Cursors.No;
                        }
                        Cells[add].Text = field[row, column].ToString();
                        Cells[add].Refresh();
                    }
                    add++;
                }
            }
        }

        private void highlight_Cells(char[,] field, int size, Player player)
        {
            for (int row = 0; row < size; row++)
            {
                if (field[row, 0] == field[row, 1] &&
                    field[row, 1] == field[row, 2])
                {
                    if (field[row, 0] == player.signature)
                    {
                        Cells[row * 3].ForeColor = Color.Red;
                        Cells[row * 3 + 1].ForeColor = Color.Red;
                        Cells[row * 3 + 2].ForeColor = Color.Red;
                    }
                }
            }

            for (int column = 0; column < size; column++)
            {
                if (field[0, column] == field[1, column] &&
                    field[1, column] == field[2, column])
                {
                    if (field[0, column] == player.signature)
                    {
                        Cells[column].ForeColor = Color.Red;
                        Cells[column + 3].ForeColor = Color.Red;
                        Cells[column + 6].ForeColor = Color.Red;
                    }
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2])
            {
                if (field[0, 0] == player.signature)
                {
                    Cells[0].ForeColor = Color.Red;
                    Cells[4].ForeColor = Color.Red;
                    Cells[8].ForeColor = Color.Red;
                }
            }


            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0])
            {
                if (field[0, 2] == player.signature)
                {
                    Cells[2].ForeColor = Color.Red;
                    Cells[4].ForeColor = Color.Red;
                    Cells[6].ForeColor = Color.Red;
                }
            }
        }
    

        private void check()
        {
            if (Field.evaluate(playField.field, playField.size, human) == -10)
            {
                label10.ForeColor = Color.Red;
                label10.Text = "You have lost!";
                label10.Visible = true;
                label12.Visible = false;
                highlight_Cells(playField.field,playField.size,ai);

            }
            else if (!Field.isMovesLeft(playField.field, playField.size))
            {
                label10.ForeColor = Color.DimGray;
                label10.Text = "Draw";
                label10.Visible = true;
                label13.Visible = false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(0, 0), human);
                label1.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();

                System.Threading.Thread.Sleep(700);
                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }

            }

        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(0, 1), human);
                label2.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }



        }
        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(0, 2), human);
                label3.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (label4.Text == "" && label10.Text == "")
            {

                playField.move(new Tuple<int, int>(1, 0), human);
                label4.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }

        }
        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(1, 1), human);
                label5.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(1, 2), human);
                label6.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            if (label7.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(2, 0), human);
                label7.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            if (label8.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(2, 1), human);
                label8.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();
                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }

        }
        private void label9_Click(object sender, EventArgs e)
        {
            if (label9.Text == "" && label10.Text == "")
            {
                playField.move(new Tuple<int, int>(2, 2), human);
                label9.Text = human.signature.ToString();
                update_Labels(playField.field, playField.size);
                check();

                System.Threading.Thread.Sleep(700);

                if (Field.isMovesLeft(playField.field, playField.size))
                {
                    playField.move(ai.makeMove(playField.field, playField.size), ai);
                    update_Labels(playField.field, playField.size);
                    check();
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            label10.Visible = false;
            label13.Visible = false;
            label12.Visible = true;
            label12.Refresh();
            label13.Refresh();

            foreach (Label label in Cells)
            {
                label.Text = "";
                label.ForeColor = Color.Black;
                label.Cursor = Cursors.Hand;
            }

            playField = new Field(3);
            human = new Human('X');
            ai = new AI('O');

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            label10.Visible = false;
            label13.Visible = true;
            label12.Visible = false;
            label12.Refresh();
            label13.Refresh();
           // inverse_visibility();
            foreach (Label label in Cells)
            {
                label.ForeColor = Color.Black;
                label.Cursor = Cursors.Hand;
                label.Text = "";
            }

            playField = new Field(3);
            human = new Human('O');
            ai = new AI('X');
            Random rand = new Random();

            System.Threading.Thread.Sleep(700);

            int randomize = rand.Next(1, 5);
            if (randomize == 1)
            {
                playField.move(new Tuple<int, int>(0, 0), ai);
            }
            if (randomize == 2)
            {
                playField.move(new Tuple<int, int>(0, 2), ai);
            }
            if (randomize == 3)
            {
                playField.move(new Tuple<int, int>(2, 0), ai);
            }
            if (randomize == 4)
            {
                playField.move(new Tuple<int, int>(2, 2), ai);
            }
            // playField.move(ai.makeMove(playField.field,playField.size),ai);
            update_Labels(playField.field, playField.size);

        }

        private void inverse_visibility()
        {
            label12.Visible = !label12.Visible;
            label12.Refresh();
            label13.Visible = !label13.Visible;
            label13.Refresh();
        }
    }
}
