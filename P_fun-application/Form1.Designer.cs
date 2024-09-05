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
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(160, 52);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(534, 461);
            formsPlot1.TabIndex = 0;
            formsPlot1.Load += formsPlot1_Load;
            // 
            // menuOptions
            // 
            menuOptions.AutoCompleteMode = AutoCompleteMode.Suggest;
            menuOptions.FormattingEnabled = true;
            menuOptions.Items.AddRange(new object[] { "Bitcoin", "Fantom" });
            menuOptions.Location = new Point(720, 138);
            menuOptions.Name = "menuOptions";
            menuOptions.Size = new Size(151, 28);
            menuOptions.TabIndex = 1;
            menuOptions.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cryptoSelected
            // 
            cryptoSelected.AutoSize = true;
            cryptoSelected.Location = new Point(785, 186);
            cryptoSelected.Name = "cryptoSelected";
            cryptoSelected.Size = new Size(0, 20);
            cryptoSelected.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(cryptoSelected);
            Controls.Add(menuOptions);
            Controls.Add(formsPlot1);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}