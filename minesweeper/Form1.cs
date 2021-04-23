using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

//© 2021 Nichita Macovei
//ALL RIGHTS RESERVED
//COPYRIGHT PROTECTED BY REPUBLIC OF MOLDOVA'S LAW №139 AT 02-07-2010 "ABOUT COPYRIGHT AND RELATED RIGHTS"
//UNAUTHORIZED COPYING AND REDISTRIBUTING IS PROHIBITED
//VIOLATORS ARE SUBJECT TO CRIMINAL PROSECUTION

namespace minesweeper
{
     public partial class Form1 : Form
     {
          //Field size & nr. of bombs
          static int nr_rows = 8;
          static int nr_cols = 10;
          static int nr_bombs = 10;

          //Logic values
          int nr_flags = nr_bombs;
          int free_cells = (nr_rows * nr_cols) - nr_bombs;
          int opened_cells = 0;

          //Logic field & display field
          int[,] field = new int[nr_rows, nr_cols];
          bool[,] isOpened = new bool[nr_rows, nr_cols];

          //Setting time measuring tools
          //Stopwatch will measure actual time in game
          //Timer will update label with stopwatch value
          Stopwatch stopwatch = new Stopwatch();
          Timer timer = new Timer();

          //Filling logic field
          void generate_field()
          {
               //Initialising random number generator
               Random rng = new Random();

               //Random placing of 10 bombs on the field
               while (nr_bombs > 0)
               {
                    //Generating random values for field coordinates
                    int x = rng.Next(nr_rows);
                    int y = rng.Next(nr_cols);
                         
                    if (field[x, y] != -1)
                    {
                         field[x, y] = -1;
                         nr_bombs--;
                    }
               }

               //Placing nr. of adjacent bombs for each cell
               for (int x = 0; x < nr_rows; x++)
               {
                    for (int y = 0; y < nr_cols; y++)
                    {
                         if (field[x, y] != -1)
                              field[x, y] = adjacent_mines(x, y);
                    }
               }
          }

          //Determining nr. of bombs in 8 adjacent cells for cell located in (x, y)
          int adjacent_mines(int x, int y)
          {
               int nr_of_mines = 0;

               if (x - 1 >= 0 && y - 1 >= 0 && field[x - 1, y - 1] == -1)
                    nr_of_mines++;
               if (x - 1 >= 0 && field[x - 1, y] == -1)
                    nr_of_mines++;
               if (x - 1 >= 0 && y + 1 < nr_cols && field[x - 1, y + 1] == -1)
                    nr_of_mines++;
               if (y - 1 >= 0 && field[x, y - 1] == -1)
                    nr_of_mines++;
               if (y + 1 < nr_cols && field[x, y + 1] == -1)
                    nr_of_mines++;
               if (x + 1 < nr_rows && y - 1 >= 0 && field[x + 1, y - 1] == -1)
                    nr_of_mines++;
               if (x + 1 < nr_rows && field[x + 1, y] == -1)
                    nr_of_mines++;
               if (x + 1 < nr_rows && y + 1 < nr_cols && field[x + 1, y + 1] == -1)
                    nr_of_mines++;

               return nr_of_mines;
          }

          //Function for cascade-opening of empty cells
          void open_cells(int x, int y)
          {
               //Setting clicked cell as current and de-selecting it
               dataGridView1.ClearSelection();
               dataGridView1.CurrentCell = dataGridView1.Rows[x].Cells[y];
               dataGridView1.CurrentCell.Selected = false;

               //If cell isn't opened yet, then add +1 to counter of opened cells and update number on display
               if (!isOpened[x, y])
               {
                    opened_cells++;
                    label2.Text = opened_cells.ToString() + "/" + free_cells.ToString();

                    //If number of opened cells equals total number of cells minus number of bombs,
                    //then show content of last cell and call Game Over message
                    if (opened_cells == free_cells)
                    {
                         timer.Stop();
                         stopwatch.Stop();
                         timer.Dispose();
                         open_cells(x, y);
                         string message = "You won!\nYour time: " + label8.Text + " seconds";
                         gameover(message);
                    }
               }

               //Marking cell as opened
               isOpened[x, y] = true;

               //Placing content from logic field into display field
               if (field[x, y] == 0)
               {
                    dataGridView1.CurrentCell.Style.BackColor = Color.White;
               }
               else
               {
                    dataGridView1.CurrentCell.Value = field[x, y].ToString();
                    dataGridView1.CurrentCell.Style.BackColor = Color.White;
                    return;
               }

               //Recursive opening of all avaliable adjacent cells
               if (x - 1 >= 0 && y - 1 >= 0 && field[x - 1, y - 1] != -1 && !(isOpened[x - 1, y - 1]))
               {
                    open_cells(x - 1, y - 1);
               }
               if (x - 1 >= 0 && field[x - 1, y] != -1 && !(isOpened[x - 1, y]))
               {
                    open_cells(x - 1, y);
               }
               if (x - 1 >= 0 && y + 1 < nr_cols && field[x - 1, y + 1] != -1 && !(isOpened[x - 1, y + 1]))
               {
                    open_cells(x - 1, y + 1);
               }
               if (y - 1 >= 0 && field[x, y - 1] != -1 && isOpened[x, y - 1] == false)
               {
                    open_cells(x, y - 1);
               }
               if (y + 1 < nr_rows && field[x, y + 1] != -1 && isOpened[x, y + 1] == false)
               {
                    open_cells(x, y + 1);
               }
               if (x + 1 < nr_rows && y - 1 >= 0 && field[x + 1, y - 1] != -1 && isOpened[x + 1, y - 1] == false)
               {
                    open_cells(x + 1, y - 1);
               }
               if (x + 1 < nr_rows && field[x + 1, y] != -1 && isOpened[x + 1, y] == false)
               {
                    open_cells(x + 1, y);
               }
               if (x + 1 < nr_rows && y + 1 < nr_cols && field[x + 1, y + 1] != -1 && isOpened[x + 1, y + 1] == false)
               {
                    open_cells(x + 1, y + 1);
               }
          }

          //Filling DataGridView element
          void fill_table()
          {
               //Creating a bidimensional vector of strings filled with spaces
               string[,] tmp = new string[nr_rows, nr_cols];

               for (int x = 0; x < nr_rows; x++)
               {
                    for (int y = 0; y < nr_cols; y++)
                    {
                         tmp[x, y] = " ";
                    }
               }

               //Setting all cells as unvisited
               for (int x = 0; x < nr_rows; x++)
               {
                    for (int y = 0; y < nr_cols; y++)
                    {
                         isOpened[x, y] = false;
                    }
               }

               //Setting DataGridView size, disabling columns and rows headers and forbiding columns and rows resizing
               dataGridView1.Width = 403;
               dataGridView1.Height = 323;
               dataGridView1.ColumnHeadersVisible = false;
               dataGridView1.RowHeadersVisible = false;
               dataGridView1.AllowUserToResizeRows = false;
               dataGridView1.AllowUserToResizeColumns = false;
               dataGridView1.MultiSelect = false;

               //Setting cell height
               dataGridView1.RowTemplate.Height = 40;

               //Adding columns and setting style of text inside cells
               for (int c = 0; c < nr_cols; c++)
               {
                    dataGridView1.Columns.Add("col" + c, c.ToString());
                    dataGridView1.Columns[c].Width = 40;
                    dataGridView1.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[c].DefaultCellStyle.Font = new Font("Arial", 20F, GraphicsUnit.Pixel);
               }

               //Filling DataGridView with data
               for (int i = 0; i < nr_rows; i++)
               {
                    string[] line = new string[nr_cols];

                    for (int j = 0; j < nr_cols; j++)
                    {
                         line[j] = tmp[i, j];
                    }

                    dataGridView1.Rows.Add(line);
               }

               //Setting cells backgorund color
               for (int i = 0; i < nr_rows; i++)
               {
                    for (int j = 0; j < nr_cols; j++)
                    {
                         //That commented if-else below, if decommented, reveals bombs' location on app launch
                         //I made it as a debug feature to speed up testing win condition
                         //Using it renders cell marking obsolete since marking function cannot mark red cells

                         //if (field[i, j] == -1)
                         //     dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                         //else
                         dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    }
               }
          }

          //Game Over message box
          void gameover(string msg)
          {
               Form2 GameOver = new Form2();
               GameOver.label1.Text = msg;
               GameOver.StartPosition = FormStartPosition.CenterParent;
               GameOver.ShowDialog(this);
          }

          //Function that unites initialization of logic field and filling DataGridView with data
          void Game()
          {
               generate_field();
               fill_table();

               stopwatch.Start();
               timer.Interval = 10;
               timer.Tick += new EventHandler(timer_Tick);
               timer.Start();
          }

          //Main game window initialization
          public Form1()
          {
               InitializeComponent();

               this.StartPosition = FormStartPosition.CenterScreen;
               label4.Text = nr_flags.ToString();
               FormBorderStyle = FormBorderStyle.FixedDialog;
               MinimizeBox = false;
               MaximizeBox = false;
               Game();
          }

          //Handle click on cell
          private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
          {
               //Right click:
               //- has no effect on opened cells
               //- marks cell if it is closed
               //- right-click on marked cell unmarks it
               if (e.Button == MouseButtons.Right)
               {
                    dataGridView1.ClearSelection();
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridView1.CurrentCell.Selected = false;

                    if (dataGridView1.CurrentCell.Style.BackColor == Color.White)
                    {
                         dataGridView1.CurrentCell.Selected = false;
                         return;
                    }
                    else if (dataGridView1.CurrentCell.Style.BackColor == Color.Yellow)
                    {
                         dataGridView1.CurrentCell.Style.BackColor = Color.Green;
                         nr_flags++;
                         label4.Text = nr_flags.ToString();
                         dataGridView1.CurrentCell.Selected = false;
                    }
                    else if (dataGridView1.CurrentCell.Style.BackColor == Color.Green)
                    {
                         dataGridView1.CurrentCell.Style.BackColor = Color.Yellow;
                         nr_flags--;
                         label4.Text = nr_flags.ToString();
                         dataGridView1.CurrentCell.Selected = false;
                    }
               }

               //Left click:
               //- has no effect on opened cells and marked cells
               //- opens closed cell:
               //  - if cell contains bomb, game ends
               //  - if cell doesn't contain bomb, calls cascade opening on avaliable adjacent cells
               if (e.Button.HasFlag(MouseButtons.Left))
               {
                    dataGridView1.ClearSelection();
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridView1.CurrentCell.Selected = false;

                    if (dataGridView1.CurrentCell.Style.BackColor == Color.Yellow)
                    {
                         dataGridView1.CurrentCell.Selected = false;
                         return;
                    }
                    else
                    {
                         if (field[e.RowIndex, e.ColumnIndex] == -1)
                         {
                              timer.Stop();
                              stopwatch.Stop();
                              timer.Dispose();
                              dataGridView1.CurrentCell.Style.BackColor = Color.Red;
                              dataGridView1.CurrentCell.Style.SelectionBackColor = dataGridView1.CurrentCell.Style.BackColor;
                              dataGridView1.CurrentCell.Style.SelectionForeColor = dataGridView1.CurrentCell.Style.BackColor;
                              dataGridView1.Enabled = false;
                              string message = "You lost !";
                              gameover(message);
                         }
                         else
                         {
                              dataGridView1.CurrentCell.Selected = false;
                              open_cells(e.RowIndex, e.ColumnIndex);
                         }
                    }
               }
          }

          //Fix for cell staying selected on double-click
          private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
          {
               dataGridView1.ClearSelection();
          }

          //Fix for DataGridView being loaded with selected top left cell
          private void Form1_Load(object sender, EventArgs e)
          {
               dataGridView1.ClearSelection();
          }

          //Workaround for showing stopwatch time to player
          private void timer_Tick(object sender, EventArgs e)
          {
               if (stopwatch.Elapsed.TotalSeconds > 999)
                    label8.Text = ">999";
               else
                    label8.Text = $"{(int)stopwatch.Elapsed.TotalSeconds}";
          }
     }
}