
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using P_fun_application;
namespace P_fun_application
{
    public partial class Form1 : Form
    {

        private Cryptocurrency bitcoin = new Cryptocurrency();
        private Cryptocurrency ethereum = new Cryptocurrency();
        private Cryptocurrency bnb = new Cryptocurrency();
        //public List<DateTime> StartDate { get; private set; }
        public DateTime StartDate;
        public DateTime EndDate;

        public Form1()
        {
            InitializeComponent();


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



        private void crypto1_CheckedChanged(object sender, EventArgs e)
        {
            bool graphOn = crypto1.Checked;
            if (graphOn)
            {
                bitcoin.LoadData(@"BitcoinSV.csv");
                bitcoin.CreateChart(formsPlot1, graphOn);

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
            MessageBox.Show("The selected value is " + dateTimePicker1.Text);
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
            StartDate = dateTimePicker2.Value;
            MessageBox.Show("The selected value is " + dateTimePicker2.Text);

        }
        private void startDate_Click(object sender, EventArgs e)
        {
           
        }


        private void endDate_Click(object sender, EventArgs e)
        {

        }
    }

}
