using System;
using System.Drawing;
using System.Windows.Forms;

namespace minesweeper
{
     public partial class Form2 : Form
     {
          //Following code makes Game Over window unmovable on main game screen
          const int WM_SYSCOMMAND = 0x0112;
          const int SC_MOVE = 0xF010;
          protected override void WndProc(ref Message message)
          {
               switch (message.Msg)
               {
                    case WM_SYSCOMMAND:
                         int command = message.WParam.ToInt32() & 0xfff0;
                         if (command == SC_MOVE)
                              return;
                         break;
               }
               base.WndProc(ref message);
          }

          //Game Over form initialization
          public Form2()
          {
               InitializeComponent();

               ShowInTaskbar = false;
               FormBorderStyle = FormBorderStyle.FixedDialog;
               ControlBox = false;
               MinimizeBox = false;
               MaximizeBox = false;
               Text = "Game Over";
               label1.TextAlign = ContentAlignment.MiddleCenter;
               button1.Text = "Play Again";
               button2.Text = "Exit";
          }

          //Handle for "Play Again"
          private void button1_Click(object sender, EventArgs e)
          {
               Application.Restart();
          }

          //Handle for "Exit" button
          private void button2_Click(object sender, EventArgs e)
          {
               Application.Exit();
          }

          //Closing Game Over form also closes whole application
          private void Form2_FormClosing(object sender, FormClosingEventArgs e)
          {
               switch(e.CloseReason)
               {
                    case CloseReason.UserClosing:
                    case CloseReason.TaskManagerClosing:
                    case CloseReason.WindowsShutDown:
                         Application.Exit();
                         break;
               }
          }
     }
}
