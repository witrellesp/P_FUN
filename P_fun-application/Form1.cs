
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
            createChart();
        }
        void createChart()
        {
            string path = @"BitcoinSV.csv";
            var lines = File.ReadAllLines(path);

            List<DateTime> date = new List<DateTime>();
            
            List<double> price = new List<double>();


            foreach (var line in lines.Skip(1))
            {
                var columns = line.Split(',');

                if (columns.Length > 0)
                {
                    if (DateTime.TryParse(columns[0], out DateTime dateValue))
                    {
                        date.Add(dateValue);
                    }
                    if (double.TryParse(columns[5], out double priceValue))
                    {
                        price.Add(priceValue);
                    }
                }
            }

            DateTime[] dates = date.ToArray();




            double[] dataX = dates.Select(date => date.ToOADate()).ToArray();
            double[] dataY = price.ToArray();

            var xlength = dataX.Length;
            var ylength = dataY.Length;



            formsPlot1.Plot.XLabel("Date");
            formsPlot1.Plot.YLabel("Valeur");

            formsPlot1.Plot.AddSignal(dataY);
           
            formsPlot1.Plot.XAxis.DateTimeFormat(true);



            DateTime startDate = date.First();
            DateTime endDate = date.Last();
            
  

            formsplot1.SetAxisLimits(xMin: startDate, xMax: endDate);



            formsPlot1.Refresh();




        }
    }
    class Cryptocurrency
    {
        string name;
        
        

    }
}