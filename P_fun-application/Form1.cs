
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
        public Form1()
        {
            InitializeComponent();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {


            var Bitcoin = new Cryptocurrency();
            Bitcoin.LoadData(@"BitcoinSV.csv");
            Bitcoin.CreateChart(formsPlot1);


            var Fantom = new Cryptocurrency();
            Fantom.LoadData(@"Fantom.csv");
            Fantom.CreateChart(formsPlot1);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cryptoSelected.Text= menuOptions.Text;


        }
    }

}