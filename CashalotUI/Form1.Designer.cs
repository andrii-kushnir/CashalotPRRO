
namespace CashalotUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._tbNumFiscal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbNumCheck = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(416, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(310, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Встановити налаштування ПРРО";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Фіскальний номер:";
            // 
            // _tbNumFiscal
            // 
            this._tbNumFiscal.Location = new System.Drawing.Point(139, 22);
            this._tbNumFiscal.Name = "_tbNumFiscal";
            this._tbNumFiscal.Size = new System.Drawing.Size(111, 20);
            this._tbNumFiscal.TabIndex = 3;
            this._tbNumFiscal.Text = "4001004105";
            this._tbNumFiscal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер чеку:";
            // 
            // _tbNumCheck
            // 
            this._tbNumCheck.Location = new System.Drawing.Point(139, 49);
            this._tbNumCheck.Name = "_tbNumCheck";
            this._tbNumCheck.Size = new System.Drawing.Size(111, 20);
            this._tbNumCheck.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(416, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(310, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "Отримати чек";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(416, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(310, 30);
            this.button4.TabIndex = 7;
            this.button4.Text = "Фіскалізувати";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(416, 119);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(310, 30);
            this.button5.TabIndex = 8;
            this.button5.Text = "X - звіт";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 384);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this._tbNumCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbNumFiscal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbNumFiscal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbNumCheck;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

