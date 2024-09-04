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
            List<DateTime> pdValuesList = new List<DateTime>();

            double pdValue;
        
            
            foreach(var line in lines.Skip(1))
            {
                var columns = line.Split(',');

                if(columns.Length > 0)
                {
                    if (DateTime.TryParse(columns[0],out DateTime dateValue))
                    {
                        pdValuesList.Add(dateValue);
                    }
                }
            }

            DateTime[] pdValues = pdValuesList.ToArray();




            double[] dataX = pdValues.Select(date => date.ToOADate()).ToArray();
            double[] dataY = new double[] { 0, 1, 2, 3, 4, 5, 6 }; //value

            var xlength = dataX.Length;
            var ylength = dataY.Length;

            formsPlot1.Plot.AddScatter(dataX, dataX); //test
            formsPlot1.Refresh();


           

        }
    }
}