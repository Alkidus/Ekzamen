namespace Task_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddNewList_btn = new System.Windows.Forms.Button();
            this.AddNewDo_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenFile_btn = new System.Windows.Forms.Button();
            this.Save_btn = new System.Windows.Forms.Button();
            this.DelList_btn = new System.Windows.Forms.Button();
            this.DelSomeDo_btn = new System.Windows.Forms.Button();
            this.Find_btn = new System.Windows.Forms.Button();
            this.ShowList_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.CheckBoxes = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(381, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(663, 616);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AddNewList_btn
            // 
            this.AddNewList_btn.BackColor = System.Drawing.Color.Transparent;
            this.AddNewList_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddNewList_btn.FlatAppearance.BorderSize = 0;
            this.AddNewList_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewList_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewList_btn.Location = new System.Drawing.Point(1, 3);
            this.AddNewList_btn.Name = "AddNewList_btn";
            this.AddNewList_btn.Size = new System.Drawing.Size(370, 80);
            this.AddNewList_btn.TabIndex = 2;
            this.AddNewList_btn.Text = "Создать список дел...";
            this.AddNewList_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddNewList_btn.UseVisualStyleBackColor = false;
            this.AddNewList_btn.Click += new System.EventHandler(this.AddNewList_btn_Click);
            // 
            // AddNewDo_btn
            // 
            this.AddNewDo_btn.BackColor = System.Drawing.Color.Transparent;
            this.AddNewDo_btn.FlatAppearance.BorderSize = 0;
            this.AddNewDo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDo_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDo_btn.Location = new System.Drawing.Point(377, 651);
            this.AddNewDo_btn.Name = "AddNewDo_btn";
            this.AddNewDo_btn.Size = new System.Drawing.Size(244, 39);
            this.AddNewDo_btn.TabIndex = 3;
            this.AddNewDo_btn.Text = "Добавить событие...";
            this.AddNewDo_btn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.AddNewDo_btn.UseVisualStyleBackColor = false;
            this.AddNewDo_btn.Click += new System.EventHandler(this.AddNewDo_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.OpenFile_btn);
            this.panel1.Controls.Add(this.Save_btn);
            this.panel1.Controls.Add(this.DelList_btn);
            this.panel1.Controls.Add(this.DelSomeDo_btn);
            this.panel1.Controls.Add(this.Find_btn);
            this.panel1.Controls.Add(this.ShowList_btn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.AddNewList_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 690);
            this.panel1.TabIndex = 5;
            // 
            // OpenFile_btn
            // 
            this.OpenFile_btn.BackColor = System.Drawing.Color.Transparent;
            this.OpenFile_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenFile_btn.FlatAppearance.BorderSize = 0;
            this.OpenFile_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFile_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFile_btn.Location = new System.Drawing.Point(1, 519);
            this.OpenFile_btn.Name = "OpenFile_btn";
            this.OpenFile_btn.Size = new System.Drawing.Size(370, 80);
            this.OpenFile_btn.TabIndex = 10;
            this.OpenFile_btn.Text = "Открыть прикрепленный файл";
            this.OpenFile_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpenFile_btn.UseVisualStyleBackColor = false;
            this.OpenFile_btn.Click += new System.EventHandler(this.OpenFile_btn_Click);
            // 
            // Save_btn
            // 
            this.Save_btn.BackColor = System.Drawing.Color.Transparent;
            this.Save_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Save_btn.FlatAppearance.BorderSize = 0;
            this.Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_btn.Location = new System.Drawing.Point(3, 433);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(370, 80);
            this.Save_btn.TabIndex = 8;
            this.Save_btn.Text = "Сохранить список дел";
            this.Save_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Save_btn.UseVisualStyleBackColor = false;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // DelList_btn
            // 
            this.DelList_btn.BackColor = System.Drawing.Color.Transparent;
            this.DelList_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DelList_btn.FlatAppearance.BorderSize = 0;
            this.DelList_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelList_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelList_btn.Location = new System.Drawing.Point(1, 347);
            this.DelList_btn.Name = "DelList_btn";
            this.DelList_btn.Size = new System.Drawing.Size(370, 80);
            this.DelList_btn.TabIndex = 7;
            this.DelList_btn.Text = "Удаление списка дел";
            this.DelList_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DelList_btn.UseVisualStyleBackColor = false;
            this.DelList_btn.Click += new System.EventHandler(this.DelList_btn_Click);
            // 
            // DelSomeDo_btn
            // 
            this.DelSomeDo_btn.BackColor = System.Drawing.Color.Transparent;
            this.DelSomeDo_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DelSomeDo_btn.FlatAppearance.BorderSize = 0;
            this.DelSomeDo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelSomeDo_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelSomeDo_btn.Location = new System.Drawing.Point(1, 261);
            this.DelSomeDo_btn.Name = "DelSomeDo_btn";
            this.DelSomeDo_btn.Size = new System.Drawing.Size(370, 80);
            this.DelSomeDo_btn.TabIndex = 6;
            this.DelSomeDo_btn.Text = "Удаление события";
            this.DelSomeDo_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DelSomeDo_btn.UseVisualStyleBackColor = false;
            this.DelSomeDo_btn.Click += new System.EventHandler(this.DelSomeDo_btn_Click);
            // 
            // Find_btn
            // 
            this.Find_btn.BackColor = System.Drawing.Color.Transparent;
            this.Find_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Find_btn.FlatAppearance.BorderSize = 0;
            this.Find_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Find_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Find_btn.Location = new System.Drawing.Point(1, 175);
            this.Find_btn.Name = "Find_btn";
            this.Find_btn.Size = new System.Drawing.Size(370, 80);
            this.Find_btn.TabIndex = 5;
            this.Find_btn.Text = "Поиск события";
            this.Find_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Find_btn.UseVisualStyleBackColor = false;
            this.Find_btn.Click += new System.EventHandler(this.Find_btn_Click);
            // 
            // ShowList_btn
            // 
            this.ShowList_btn.BackColor = System.Drawing.Color.Transparent;
            this.ShowList_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShowList_btn.FlatAppearance.BorderSize = 0;
            this.ShowList_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowList_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowList_btn.Location = new System.Drawing.Point(1, 89);
            this.ShowList_btn.Name = "ShowList_btn";
            this.ShowList_btn.Size = new System.Drawing.Size(370, 80);
            this.ShowList_btn.TabIndex = 4;
            this.ShowList_btn.Text = "Отобразить дела за...";
            this.ShowList_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ShowList_btn.UseVisualStyleBackColor = false;
            this.ShowList_btn.Click += new System.EventHandler(this.ShowList_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "?";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Location = new System.Drawing.Point(377, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 642);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.DragOver += new System.Windows.Forms.DragEventHandler(this.tabControl1_DragOver);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(627, 655);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1, 605);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(370, 80);
            this.button2.TabIndex = 11;
            this.button2.Text = "Загрузить список дел";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 690);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddNewDo_btn);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button AddNewList_btn;
        private System.Windows.Forms.Button AddNewDo_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DelSomeDo_btn;
        private System.Windows.Forms.Button Find_btn;
        private System.Windows.Forms.Button ShowList_btn;
        private System.Windows.Forms.Button DelList_btn;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenFile_btn;
        private System.Windows.Forms.Button button2;
    }
}

