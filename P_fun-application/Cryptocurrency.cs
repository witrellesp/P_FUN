using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace P_fun_application
//{
//    class Cryptocurrency
//    {

//        public Cryptocurrency(int id, DateTime date, DateTime dateOpen, DateTime dateClose, int highPrice, int lowPrice, int volume, int currency, string pathCSV)
//        {
//            this.id = id;
//            this.date = date;
//            this.dateOpen = dateOpen;
//            this.dateClose = dateClose;
//            this.highPrice = highPrice;
//            this.lowPrice = lowPrice;
//            this.volume = volume;
//            this.currency = currency;
//            this.pathCSV = pathCSV;
//        }

//        int id { get; set; }
//        DateTime date;
//        DateTime dateOpen;
//        DateTime dateClose;
//        int highPrice;
//        int lowPrice;
//        int volume;
//        int currency;
//        string pathCSV;


//        public void CreateChart(DateTime date, int y, string path)
//        {



//            var lines = File.ReadAllLines(path);
//            foreach (var line in lines)
//            {
//                var columns = line.Split(',');
//                if (columns.Length > 0)
//                {
//                    if (DateTime.TryParse(columns[0], out DateTime dateValue))
//                    {
//                        date.Add(dateValue);
//                    }
//                }

//            }
//            DateTime[] pdValues = date.ToArray();




//            double[] dataX = pdValues.Select(date => date.ToOADate()).ToArray();
//            double[] dataY = new double[] { 0, 1, 2, 3, 4, 5, 6 }; //value

//            var xlength = dataX.Length;
//            var ylength = dataY.Length;



//            formsPlot1.Plot.AddScatter(dataX, dataX); //test
//            formsPlot1.Refresh();






//        }
//    }


//}












////void createChart()
////{
////    string path = @"BitcoinSV.csv";
////    var lines = File.ReadAllLines(path);
////    List<DateTime> pdValuesList = new List<DateTime>();

////    double pdValue;


////    foreach (var line in lines.Skip(1))
////    {
////        var columns = line.Split(',');

////        if (columns.Length > 0)
////        {
////            if (DateTime.TryParse(columns[0], out DateTime dateValue))
////            {
////                pdValuesList.Add(dateValue);
////            }
////        }
////    }

////    DateTime[] pdValues = pdValuesList.ToArray();




////    double[] dataX = pdValues.Select(date => date.ToOADate()).ToArray();
////    double[] dataY = new double[] { 0, 1, 2, 3, 4, 5, 6 }; //value

////    var xlength = dataX.Length;
////    var ylength = dataY.Length;

////    formsPlot1.Plot.AddScatter(dataX, dataX); //test
////    formsPlot1.Refresh();




////}