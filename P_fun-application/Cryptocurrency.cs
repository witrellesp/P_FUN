using ScottPlot;
using ScottPlot.Plottable;
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

        public IPlottable? currentPlot;
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
                    //    Prices.Add(priceValue);
                    //}
                    if (double.TryParse(columns[5].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        Prices.Add(value);
                    }
                }
            }

        }

        public void CreateChart(FormsPlot formsPlot, bool isActivated)
        {
            var plt = formsPlot.Plot;

            plt.Style(Style.Black);

            if (isActivated)
            {
                double[] dataX = Dates.Select(date => date.ToOADate()).ToArray();
                double[] dataY = Prices.ToArray();

                plt.Title("Crypto-analyzer");
                plt.XLabel("Date");
                plt.YLabel("Price");

                // Supprimer l'ancienne courbe, si elle existe
                if (currentPlot == null)
                {
                    plt.Remove(currentPlot);
                    currentPlot = null;  

                    currentPlot = plt.AddScatter(dataX, dataY);
                    plt.XAxis.DateTimeFormat(true);
                   
                }

                
            }
            else
            {
                // Supprimer la courbe spécifique si elle existe
                if (currentPlot != null)
                {
                    plt.Remove(currentPlot);

                    var limits = plt.GetAxisLimits();
                    currentPlot = null;  // Réinitialiser la référence
                }
            }

            formsPlot.Refresh();

        }


    }


}










