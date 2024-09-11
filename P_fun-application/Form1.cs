
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
        private Cryptocurrency fantom = new Cryptocurrency();
        private Cryptocurrency xrp = new Cryptocurrency();

        public Form1()
        {
            InitializeComponent();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

           
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



            bitcoin.CreateChart(formsPlot1, graphOn);



        }

        private void crypto2_CheckedChanged(object sender, EventArgs e)
        {
       
            bool graphOn= crypto2.Checked;
            if (crypto2.Checked)
            {
                
                fantom.LoadData(@"Fantom.csv");
                fantom.CreateChart(formsPlot1, graphOn);


            }
                fantom.CreateChart(formsPlot1, graphOn);
        }

        private void crypt3_CheckedChanged(object sender, EventArgs e)
        {

          
            bool graphOn;
            if (crypto3.Checked)
            {
                graphOn = true;
                xrp.LoadData(@"xrp.csv");
                xrp.CreateChart(formsPlot1, graphOn);


            }
            else if (crypto3.Checked == false)
            {
                graphOn = false;
                xrp.CreateChart(formsPlot1, graphOn);

            }
        }
    }

}
