namespace P_fun_application
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            formsPlot1 = new ScottPlot.FormsPlot();
            menuOptions = new ComboBox();
            cryptoSelected = new Label();
            crypto2 = new CheckBox();
            crypto3 = new CheckBox();
            crypto1 = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            startDate = new Label();
            endDate = new Label();
            dateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(3, 39);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(645, 411);
            formsPlot1.TabIndex = 0;
            formsPlot1.Load += formsPlot1_Load;
            // 
            // menuOptions
            // 
            menuOptions.AutoCompleteMode = AutoCompleteMode.Suggest;
            menuOptions.FormattingEnabled = true;
            menuOptions.Items.AddRange(new object[] { "Bitcoin", "Fantom" });
            menuOptions.Location = new Point(655, 59);
            menuOptions.Margin = new Padding(3, 2, 3, 2);
            menuOptions.Name = "menuOptions";
            menuOptions.Size = new Size(133, 23);
            menuOptions.TabIndex = 1;
            menuOptions.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cryptoSelected
            // 
            cryptoSelected.AutoSize = true;
            cryptoSelected.Location = new Point(687, 140);
            cryptoSelected.Name = "cryptoSelected";
            cryptoSelected.Size = new Size(0, 15);
            cryptoSelected.TabIndex = 2;
            // 
            // crypto2
            // 
            crypto2.AutoSize = true;
            crypto2.Location = new Point(653, 140);
            crypto2.Name = "crypto2";
            crypto2.Size = new Size(77, 19);
            crypto2.TabIndex = 4;
            crypto2.Text = "Ethereum";
            crypto2.UseVisualStyleBackColor = true;
            crypto2.CheckedChanged += crypto2_CheckedChanged;
            // 
            // crypto3
            // 
            crypto3.AutoSize = true;
            crypto3.Location = new Point(653, 165);
            crypto3.Name = "crypto3";
            crypto3.Size = new Size(49, 19);
            crypto3.TabIndex = 5;
            crypto3.Text = "BNB";
            crypto3.UseVisualStyleBackColor = true;
            crypto3.CheckedChanged += crypt3_CheckedChanged;
            // 
            // crypto1
            // 
            crypto1.AutoSize = true;
            crypto1.Location = new Point(653, 116);
            crypto1.Name = "crypto1";
            crypto1.Size = new Size(63, 19);
            crypto1.TabIndex = 6;
            crypto1.Text = "Bitcoin";
            crypto1.UseVisualStyleBackColor = true;
            crypto1.CheckedChanged += crypto1_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(14, 475);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(93, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // startDate
            // 
            startDate.AutoSize = true;
            startDate.Location = new Point(12, 453);
            startDate.Name = "startDate";
            startDate.Size = new Size(58, 15);
            startDate.TabIndex = 8;
            startDate.Text = "Start Date";
            startDate.Click += startDate_Click;
            // 
            // endDate
            // 
            endDate.AutoSize = true;
            endDate.Location = new Point(162, 455);
            endDate.Name = "endDate";
            endDate.Size = new Size(54, 15);
            endDate.TabIndex = 9;
            endDate.Text = "End Date";
            endDate.Click += endDate_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(166, 475);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(94, 23);
            dateTimePicker2.TabIndex = 10;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(dateTimePicker2);
            Controls.Add(endDate);
            Controls.Add(startDate);
            Controls.Add(dateTimePicker1);
            Controls.Add(crypto1);
            Controls.Add(crypto3);
            Controls.Add(crypto2);
            Controls.Add(cryptoSelected);
            Controls.Add(menuOptions);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private ComboBox menuOptions;
        private Label cryptoSelected;
        private CheckBox crypto2;
        private CheckBox crypto3;
        private CheckBox crypto1;
        private DateTimePicker dateTimePicker1;
        private Label startDate;
        private Label endDate;
        private DateTimePicker dateTimePicker2;
    }
}