namespace Diplom
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Filepath_tb = new System.Windows.Forms.TextBox();
            this.Filepath_button = new System.Windows.Forms.Button();
            this.Check_hash_btn = new System.Windows.Forms.Button();
            this.Info_lb = new System.Windows.Forms.ListBox();
            this.Hash_check_pb = new System.Windows.Forms.ProgressBar();
            this.Checking_File_Label = new System.Windows.Forms.Label();
            this.Compare_hash_btn = new System.Windows.Forms.Button();
            this.Start_file_btn = new System.Windows.Forms.Button();
            this.Processes_lb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Network_cb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Registry_lb = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Network_lb = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.CPU_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Memory_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPU_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Memory_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Filepath_tb
            // 
            this.Filepath_tb.Location = new System.Drawing.Point(11, 65);
            this.Filepath_tb.Name = "Filepath_tb";
            this.Filepath_tb.Size = new System.Drawing.Size(409, 20);
            this.Filepath_tb.TabIndex = 0;
            // 
            // Filepath_button
            // 
            this.Filepath_button.Location = new System.Drawing.Point(426, 63);
            this.Filepath_button.Name = "Filepath_button";
            this.Filepath_button.Size = new System.Drawing.Size(48, 23);
            this.Filepath_button.TabIndex = 1;
            this.Filepath_button.Text = "Обзор";
            this.Filepath_button.UseVisualStyleBackColor = true;
            this.Filepath_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Check_hash_btn
            // 
            this.Check_hash_btn.Location = new System.Drawing.Point(12, 7);
            this.Check_hash_btn.Name = "Check_hash_btn";
            this.Check_hash_btn.Size = new System.Drawing.Size(98, 23);
            this.Check_hash_btn.TabIndex = 2;
            this.Check_hash_btn.Text = "Посчитать хэш";
            this.Check_hash_btn.UseVisualStyleBackColor = true;
            this.Check_hash_btn.Click += new System.EventHandler(this.Check_hash_Click);
            // 
            // Info_lb
            // 
            this.Info_lb.FormattingEnabled = true;
            this.Info_lb.Location = new System.Drawing.Point(12, 361);
            this.Info_lb.Name = "Info_lb";
            this.Info_lb.Size = new System.Drawing.Size(977, 199);
            this.Info_lb.TabIndex = 3;
            // 
            // Hash_check_pb
            // 
            this.Hash_check_pb.Location = new System.Drawing.Point(12, 36);
            this.Hash_check_pb.Name = "Hash_check_pb";
            this.Hash_check_pb.Size = new System.Drawing.Size(462, 23);
            this.Hash_check_pb.TabIndex = 4;
            // 
            // Checking_File_Label
            // 
            this.Checking_File_Label.AutoSize = true;
            this.Checking_File_Label.Location = new System.Drawing.Point(208, 12);
            this.Checking_File_Label.Name = "Checking_File_Label";
            this.Checking_File_Label.Size = new System.Drawing.Size(84, 13);
            this.Checking_File_Label.TabIndex = 5;
            this.Checking_File_Label.Text = "Текущий файл:";
            // 
            // Compare_hash_btn
            // 
            this.Compare_hash_btn.Location = new System.Drawing.Point(115, 7);
            this.Compare_hash_btn.Name = "Compare_hash_btn";
            this.Compare_hash_btn.Size = new System.Drawing.Size(87, 23);
            this.Compare_hash_btn.TabIndex = 6;
            this.Compare_hash_btn.Text = "Сравнить хэш";
            this.Compare_hash_btn.UseVisualStyleBackColor = true;
            this.Compare_hash_btn.Click += new System.EventHandler(this.Compare_hash_btn_Click);
            // 
            // Start_file_btn
            // 
            this.Start_file_btn.Location = new System.Drawing.Point(13, 97);
            this.Start_file_btn.Name = "Start_file_btn";
            this.Start_file_btn.Size = new System.Drawing.Size(87, 23);
            this.Start_file_btn.TabIndex = 7;
            this.Start_file_btn.Text = "Запуск файла";
            this.Start_file_btn.UseVisualStyleBackColor = true;
            this.Start_file_btn.Click += new System.EventHandler(this.Start_file_btn_Click);
            // 
            // Processes_lb
            // 
            this.Processes_lb.FormattingEnabled = true;
            this.Processes_lb.Location = new System.Drawing.Point(190, 96);
            this.Processes_lb.Name = "Processes_lb";
            this.Processes_lb.Size = new System.Drawing.Size(284, 95);
            this.Processes_lb.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Запущенные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "процессы:";
            // 
            // Network_cb
            // 
            this.Network_cb.FormattingEnabled = true;
            this.Network_cb.Location = new System.Drawing.Point(16, 170);
            this.Network_cb.Name = "Network_cb";
            this.Network_cb.Size = new System.Drawing.Size(168, 21);
            this.Network_cb.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Выберите сетевой адаптер:";
            // 
            // Registry_lb
            // 
            this.Registry_lb.FormattingEnabled = true;
            this.Registry_lb.Location = new System.Drawing.Point(485, 57);
            this.Registry_lb.Name = "Registry_lb";
            this.Registry_lb.Size = new System.Drawing.Size(504, 134);
            this.Registry_lb.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Рекомендации:";
            // 
            // Network_lb
            // 
            this.Network_lb.FormattingEnabled = true;
            this.Network_lb.Location = new System.Drawing.Point(190, 198);
            this.Network_lb.Name = "Network_lb";
            this.Network_lb.Size = new System.Drawing.Size(284, 147);
            this.Network_lb.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Использование";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "сети:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(485, 198);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(504, 147);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CPU_chart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(496, 121);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ЦП";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Memory_chart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(496, 121);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Память";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Информация:";
            // 
            // CPU_chart
            // 
            chartArea3.Name = "ChartArea1";
            this.CPU_chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.CPU_chart.Legends.Add(legend3);
            this.CPU_chart.Location = new System.Drawing.Point(0, 0);
            this.CPU_chart.Name = "CPU_chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "CPU";
            this.CPU_chart.Series.Add(series3);
            this.CPU_chart.Size = new System.Drawing.Size(496, 121);
            this.CPU_chart.TabIndex = 0;
            this.CPU_chart.Text = "chart1";
            // 
            // Memory_chart
            // 
            chartArea4.Name = "ChartArea1";
            this.Memory_chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.Memory_chart.Legends.Add(legend4);
            this.Memory_chart.Location = new System.Drawing.Point(0, 0);
            this.Memory_chart.Name = "Memory_chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Memory";
            this.Memory_chart.Series.Add(series4);
            this.Memory_chart.Size = new System.Drawing.Size(496, 121);
            this.Memory_chart.TabIndex = 0;
            this.Memory_chart.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 572);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Network_lb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Registry_lb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Network_cb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Processes_lb);
            this.Controls.Add(this.Start_file_btn);
            this.Controls.Add(this.Compare_hash_btn);
            this.Controls.Add(this.Checking_File_Label);
            this.Controls.Add(this.Hash_check_pb);
            this.Controls.Add(this.Info_lb);
            this.Controls.Add(this.Check_hash_btn);
            this.Controls.Add(this.Filepath_button);
            this.Controls.Add(this.Filepath_tb);
            this.Name = "Form1";
            this.Text = "Program Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CPU_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Memory_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Filepath_tb;
        private System.Windows.Forms.Button Filepath_button;
        private System.Windows.Forms.Button Check_hash_btn;
        private System.Windows.Forms.ListBox Info_lb;
        private System.Windows.Forms.ProgressBar Hash_check_pb;
        private System.Windows.Forms.Label Checking_File_Label;
        private System.Windows.Forms.Button Compare_hash_btn;
        private System.Windows.Forms.Button Start_file_btn;
        private System.Windows.Forms.ListBox Processes_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Network_cb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox Registry_lb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Network_lb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart CPU_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart Memory_chart;
    }
}

