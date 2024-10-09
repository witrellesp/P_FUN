
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using P_fun_application;
using System.Drawing;
namespace P_fun_application
{
    public partial class Form1 : Form
    {
        



        private Cryptocurrency bitcoin = new Cryptocurrency(Color.FromArgb(255, 0, 0)); // rouge
        private Cryptocurrency ethereum = new Cryptocurrency(Color.FromArgb(0, 255, 0)); // vert
        private Cryptocurrency bnb = new Cryptocurrency(Color.FromArgb(0, 0, 255)); // bleu
        public DateTime StartDate;
        public DateTime EndDate;
        


        public Form1()
        {
            InitializeComponent();


        }

        private void crypto1_CheckedChanged(object sender, EventArgs e)
        {
            bool graphOn = crypto1.Checked;
            if (graphOn)
            {
                bitcoin.LoadData(@"BitcoinSV.csv");
                bitcoin.CreateChart(formsPlot1, graphOn);
                formsPlot1.MouseMove += (s, mouseEvent) => bitcoin.MousePoint(s, mouseEvent, formsPlot1);
            }
            else if (crypto1.Checked == false)
            {
                graphOn = false;
                bitcoin.CreateChart(formsPlot1, graphOn);
            }
        }

        private void crypto2_CheckedChanged(object sender, EventArgs e)
        {
            bool graphOn = crypto2.Checked;
            if (crypto2.Checked)
            {
                ethereum.LoadData(@"ethereum.csv");
                ethereum.CreateChart(formsPlot1, graphOn);
                formsPlot1.MouseMove += (s, mouseEvent) => ethereum.MousePoint(s, mouseEvent, formsPlot1);
            }
            else if (crypto2.Checked == false)
            {
                graphOn = false;
                ethereum.CreateChart(formsPlot1, graphOn);
            }
        }

        private void crypt3_CheckedChanged(object sender, EventArgs e)
        {
            bool graphOn;
            if (crypto3.Checked)
            {
                graphOn = true;
                bnb.LoadData(@"BNB.csv");
                bnb.CreateChart(formsPlot1, graphOn);
                formsPlot1.MouseMove += (s, mouseEvent) => bnb.MousePoint(s, mouseEvent, formsPlot1);
            }
            else if (crypto3.Checked == false)
            {
                graphOn = false;
                bnb.CreateChart(formsPlot1, graphOn);
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            StartDate = dateTimePicker1.Value;
            UpdateFilter();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            EndDate = dateTimePicker2.Value;
            UpdateFilter();
        }
        private void UpdateFilter()
        {
            if (StartDate > EndDate)
            {
                MessageBox.Show("The start date cannot be later than the end date.");
                return;
            }    
            if (crypto1.Checked)
            {
                bitcoin.FilterAndDisplay(StartDate, EndDate, formsPlot1);
            }
            if (crypto2.Checked)
            {
                ethereum.FilterAndDisplay(StartDate, EndDate, formsPlot1);
            }
            if (crypto3.Checked)
            {
                bnb.FilterAndDisplay(StartDate, EndDate, formsPlot1);
            }
            formsPlot1.Refresh();
        }

        private void startDate_Click(object sender, EventArgs e)
        {
           
        }


        private void endDate_Click(object sender, EventArgs e)
        {

        }
        private void formsPlot1_Load(object sender, EventArgs e)
        {
            /*A modifier*/


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {





        }
    }

}
