using ScottPlot;
using ScottPlot.Plottable;
using System.Globalization;
using P_fun_application;
using System.Collections.Generic;

namespace P_fun_application
{
    public class Cryptocurrency
    {
        
        public Cryptocurrency(Color color)
        {
            Dates = new List<DateTime>();
            Prices = new List<double>();
            Color = color;
        }

        public IPlottable? currentPlot;
        public List<DateTime> Dates { get; private set; }
        public List<double> Prices { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public object ToolTip { get; internal set; }

        private ScatterPlot? scatterPlot;
        private ToolTip? tooltip;
        public Color Color { get; set; }

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
                    //Sur certains systeme il y a une erreur avec le format des valeurs 'prices'
                    //if (double.TryParse(columns[4].Trim(), out double priceValue)|| double.TryParse(columns[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    //{
                    //    Prices.Add(priceValue);
                    //}

                    if (double.TryParse(columns[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double priceValue))
                    {
                        Prices.Add(priceValue);
                    }
                }
            }

        }

        public void CreateChart(FormsPlot formsPlot, bool isActivated, List<DateTime> filteredDates = null, List<double> filteredPrices = null)
        {
            var plt = formsPlot.Plot;
            if (isActivated)
            {
                double[] dataX = (filteredDates ?? Dates).Select(date => date.ToOADate()).ToArray();
                double[] dataY = (filteredPrices ?? Prices).ToArray();

                plt.Title("Crypto-analyzer");
                plt.XLabel("Date");
                plt.YLabel("High-Price");

                // Supprimer l'ancienne courbe, si elle existe
                if (currentPlot != null)
                {
                    plt.Remove(currentPlot);
                    currentPlot = null;
                }

                currentPlot = scatterPlot = plt.AddScatter(dataX, dataY,color: Color);

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
                plt.YAxis.SetBoundary(newYMin , newYMax + 50);
                

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

        public void FilterAndDisplay(DateTime startDate, DateTime endDate, FormsPlot formsPlot)
        {
            var filteredData = Dates
                .Select((date, index) => new { Date = date, Price = Prices[index] })
                .Where(data => data.Date >= startDate && data.Date <= endDate)
                .ToList();

            
            var filteredDates = filteredData.Select(data => data.Date).ToList();
            var filteredPrices = filteredData.Select(data => data.Price).ToList();

            
            if (filteredDates.Count == 0 || filteredPrices.Count == 0)
            {
                MessageBox.Show("There is not data to the date range selected.");
                return;
            }

          
            CreateChart(formsPlot, true, filteredDates, filteredPrices);
        }
        public void MousePoint(object sender, MouseEventArgs e, FormsPlot formsPlot)
        {
            if (scatterPlot == null) return;

            (double mouseX, double mouseY) = formsPlot.GetMouseCoordinates();
            var (index, nearestX, nearestY) = scatterPlot.GetPointNearest(mouseX, mouseY);
            double dist = Math.Sqrt(Math.Pow(nearestX - mouseX, 2) + Math.Pow(nearestY - mouseY, 2));

            if (tooltip == null)
            {
                tooltip = new ToolTip();
            }
                
            
            if (nearestX > 0)
            {
               
                try
                {
                    DateTime dateFromNearestX = DateTime.FromOADate(nearestX);
                    Console.WriteLine($"MouseX: {mouseX}, NearestX: {nearestX}, Date: {dateFromNearestX}, Price: {nearestY}");
                    tooltip.Show($"Date: {Dates[(int)nearestX+450]:d}, Price:{Prices[(int)nearestY]:F2}", formsPlot, e.Location.X + 15, e.Location.Y + 15);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting nearestX to DateTime: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"nearestX is not valid: {nearestX}");
                tooltip.Hide(formsPlot);
            }
        }


    }


}










