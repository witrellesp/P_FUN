using ScottPlot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_fun_application
{
    public class Cryptocurrency
    {
        public Cryptocurrency()
        {
            Dates = new List<DateTime>();
            Prices = new List<double>();
        }

        public List<DateTime> Dates { get; private set; }
        public List<double> Prices { get; private set; }

        public void LoadData(string path)
        {

            var lines = File.ReadAllLines(path);
            Dates.Clear();
            Prices.Clear();


            foreach (var line in lines.Skip(1))
            {
                var columns = line.Split(',');

                if (columns.Length > 0)
                {
                    if (DateTime.TryParse(columns[0], out DateTime dateValue))
                    {
                        Dates.Add(dateValue);
                    }
                    //if (double.TryParse(columns[5].Trim(), out double priceValue))
                    //{
                    //    price.Add(priceValue);
                    //}
                    if (double.TryParse(columns[5].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        Prices.Add(value);
                    }
                }
            }

        }
        public void CreateChart(FormsPlot formsPlot)
        {

            var plt = formsPlot.Plot;

            double[] dataX = Dates.Select(date => date.ToOADate()).ToArray();
            double[] dataY = Prices.ToArray();

            var xlength = dataX.Length;
            var ylength = dataY.Length;



            plt.XLabel("Date");
            plt.YLabel("Price");

            plt.AddScatter(dataX, dataY);

            plt.XAxis.DateTimeFormat(true);


            formsPlot.Refresh();

        }


    }


}










