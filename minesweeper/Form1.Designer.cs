
namespace minesweeper
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
               this.dataGridView1 = new System.Windows.Forms.DataGridView();
               this.label1 = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.label3 = new System.Windows.Forms.Label();
               this.label4 = new System.Windows.Forms.Label();
               this.label5 = new System.Windows.Forms.Label();
               this.label6 = new System.Windows.Forms.Label();
               this.label7 = new System.Windows.Forms.Label();
               this.label8 = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
               this.SuspendLayout();
               // 
               // dataGridView1
               // 
               this.dataGridView1.AllowUserToAddRows = false;
               this.dataGridView1.AllowUserToDeleteRows = false;
               this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.dataGridView1.Location = new System.Drawing.Point(12, 12);
               this.dataGridView1.Name = "dataGridView1";
               this.dataGridView1.ReadOnly = true;
               this.dataGridView1.RowHeadersWidth = 51;
               this.dataGridView1.RowTemplate.Height = 24;
               this.dataGridView1.Size = new System.Drawing.Size(546, 398);
               this.dataGridView1.TabIndex = 0;
               this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
               this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(611, 129);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(95, 17);
               this.label1.TabIndex = 1;
               this.label1.Text = "Opened cells:";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(713, 129);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(36, 17);
               this.label2.TabIndex = 2;
               this.label2.Text = "0/70";
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Location = new System.Drawing.Point(611, 192);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(93, 17);
               this.label3.TabIndex = 3;
               this.label3.Text = "Flags remain:";
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Location = new System.Drawing.Point(713, 192);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(16, 17);
               this.label4.TabIndex = 4;
               this.label4.Text = "0";
               // 
               // label5
               // 
               this.label5.AutoSize = true;
               this.label5.Location = new System.Drawing.Point(564, 353);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(210, 17);
               this.label5.TabIndex = 5;
               this.label5.Text = "© 2021 Nichita Macovei, TI-193.";
               // 
               // label6
               // 
               this.label6.AutoSize = true;
               this.label6.Location = new System.Drawing.Point(611, 370);
               this.label6.Name = "label6";
               this.label6.Size = new System.Drawing.Size(126, 17);
               this.label6.TabIndex = 6;
               this.label6.Text = "All rights reserved.";
               this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label7
               // 
               this.label7.AutoSize = true;
               this.label7.Location = new System.Drawing.Point(611, 71);
               this.label7.Name = "label7";
               this.label7.Size = new System.Drawing.Size(97, 17);
               this.label7.TabIndex = 7;
               this.label7.Text = "Time elapsed:";
               // 
               // label8
               // 
               this.label8.AutoSize = true;
               this.label8.Location = new System.Drawing.Point(713, 71);
               this.label8.Name = "label8";
               this.label8.Size = new System.Drawing.Size(16, 17);
               this.label8.TabIndex = 8;
               this.label8.Text = "0";
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(791, 422);
               this.Controls.Add(this.label8);
               this.Controls.Add(this.label7);
               this.Controls.Add(this.label6);
               this.Controls.Add(this.label5);
               this.Controls.Add(this.label4);
               this.Controls.Add(this.label3);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.dataGridView1);
               this.Name = "Form1";
               this.Text = "Minesweeper";
               this.Load += new System.EventHandler(this.Form1_Load);
               ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

        }

          #endregion

          private System.Windows.Forms.DataGridView dataGridView1;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.Label label6;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.Label label8;
     }
}

