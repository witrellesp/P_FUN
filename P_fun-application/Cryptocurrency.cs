using ScottPlot;
using ScottPlot.Plottable;
using System.Globalization;
using P_fun_application;

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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


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
                    if (double.TryParse(columns[4].Trim(), out double priceValue))
                    {
                        Prices.Add(priceValue);
                    }
                    //if (double.TryParse(columns[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    //{
                    //    Prices.Add(value);
                    //}
                }
            }

        }

        public void CreateChart(FormsPlot formsPlot, bool isActivated)
        {

            var plt = formsPlot.Plot;



            if (isActivated)
            {
                double[] dataX = Dates.Select(date => date.ToOADate()).ToArray();
                double[] dataY = Prices.ToArray();

                plt.Title("Crypto-analyzer");
                plt.XLabel("Date");
                plt.YLabel("High-Price");

                // Supprimer l'ancienne courbe, si elle existe
                if (currentPlot != null)
                {
                    plt.Remove(currentPlot);
                    currentPlot = null;
                }

                currentPlot = plt.AddScatter(dataX, dataY);

                //Limiter le déplacement des axes
                var limits = plt.GetAxisLimits();

                double newXMin = Math.Min(limits.XMin, dataX[0]);
                double newXMax = Math.Max(limits.XMax, dataX[dataX.Length - 1]);
                double newYMin = Math.Min(limits.YMin, dataY.Min());
                double newYMax = Math.Max(limits.YMax, dataY.Max());

                

                // Appliquer les nouvelles limites
                if (newXMin < 0)
                {
                    plt.XAxis.SetBoundary(dataX[0], newXMax);
                }
                else
                {
                    plt.XAxis.SetBoundary(newXMin, newXMax);
                }
                plt.YAxis.SetBoundary(newYMin, newYMax + 100);

                plt.XAxis.DateTimeFormat(true);
            }
            else
            {
                // Supprimer la courbe spécifique si elle existe
                if (currentPlot != null)
                {
                    plt.Remove(currentPlot);

                    var limits = plt.GetAxisLimits();
                    // Réinitialiser la référence
                    currentPlot = null;
                }
            }

            formsPlot.Refresh();

        }

        public void FilterByDate()
        {

        }


    }


}










