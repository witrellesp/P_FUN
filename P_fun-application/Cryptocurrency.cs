using ScottPlot;
using ScottPlot.Plottable;
using System.Globalization;
using P_fun_application;
using System.Collections.Generic;

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
        public object ToolTip { get; internal set; }

        private ScatterPlot? scatterPlot;
        private ToolTip? tooltip;

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

                currentPlot = scatterPlot = plt.AddScatter(dataX, dataY);



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
                plt.YAxis.SetBoundary(newYMin +25, newYMax + 100);

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
        public void MousePoint(object sender, MouseEventArgs e, FormsPlot formsPlot)
        {
            if (scatterPlot == null) return;

            (double mouseX, double mouseY) = formsPlot.GetMouseCoordinates();
            var (index, nearestX, nearestY) = scatterPlot.GetPointNearest(mouseX, mouseY);
            double dist = Math.Sqrt(Math.Pow(nearestX - mouseX, 2) + Math.Pow(nearestY - mouseY, 2));

            var a = nearestX;

            if (tooltip == null)
            {
                tooltip = new ToolTip();
            }

            if (dist < 45159)
            {
                DateTime dateFromNearestX = DateTime.FromOADate(nearestX);
                Console.WriteLine($"MouseX: {mouseX}, NearestX: {Dates}, Date: {dateFromNearestX}, Price: {nearestY}");
                tooltip.Show($"Date: {Dates[(int)nearestX+19]}, Price:{Prices[nearestY]:F2}", formsPlot, e.Location.X + 15, e.Location.Y + 15);
            }
            else
            {
                tooltip.Hide(formsPlot);
            }

        }


    }


}










