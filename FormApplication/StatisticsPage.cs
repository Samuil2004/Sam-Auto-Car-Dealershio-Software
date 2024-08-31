using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;
using OxyPlot;
using OxyPlot.Series;
using Classes;
using System.Drawing.Drawing2D;
using TheArtOfDev.HtmlRenderer.Adapters;
using OxyPlot.Axes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using BarItem = OxyPlot.Series.BarItem;
using System.Globalization;
using System.Windows.Media.Media3D;
using DataAccessLayer;
using LogicLayer.InterfacesLL;
using DataAccessLayer.CustomExceptions;


namespace FormApplication
{
    public partial class StatisticsPage : Form
    {
        private readonly IStatisticsInterfaceLogicLayer _statisticsManager;
        
        private MenuPageStaff menuPageStaff;
        private bool close_application;

        public StatisticsPage(MenuPageStaff menuPageStaff,IStatisticsInterfaceLogicLayer statisticsManaer)
        {
            InitializeComponent();
            this.menuPageStaff = menuPageStaff;
            this._statisticsManager = statisticsManaer;
            ButtonBackground(btnCategoryAvailability);
            GeneratePieChartVehicleTypeAvailability();
            close_application = true;
        }
        private void GeneratePieChartVehicleTypeAvailability()
        {
            List<int> numbersPerCategory = _statisticsManager.GetNumberOfVehiclePerCategory();

            var plotModel = new PlotModel() { Title = $"Availability per category" };
            var pieSeries = new PieSeries();

            pieSeries.Slices.Add(new PieSlice("Cars", numbersPerCategory[0]));
            pieSeries.Slices.Add(new PieSlice("Motorcycles", numbersPerCategory[1]));
            pieSeries.Slices.Add(new PieSlice("Trucks", numbersPerCategory[2]));
            plotModel.Series.Add(pieSeries);

            plotView1.Model = plotModel;
            Controls.Add(plotView1);
    }

        private void GenerateBarChartMonthlyRevenus()
        {
            var model = new PlotModel { Title = $"Month Revenue {DateTime.Today.Year}" };

            Dictionary<int, decimal> MonthRevenue = _statisticsManager.GetMontlyRevenue(DateTime.Today);

            var barItems = new List<BarItem>();
            var barNames = new List<string>();

            foreach (var item in MonthRevenue)
            {
                var barItem = new BarItem { Value = (double)item.Value };
                barItems.Add(barItem);
                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key);
                barNames.Add(monthName.ToString());
            }


            var barSeries = new BarSeries
            {
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:N2}",

                ItemsSource = barItems
            };

            model.Series.Add(barSeries);

            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Months",
                ItemsSource = barNames
            });
            plotView1.Model = model;
            Controls.Add(plotView1);
        }

        private void GeneratePieChartForBelowAndAboveRating()
        {
            plotView1.Model = null;
            List<int> ratings = _statisticsManager.GetAboveAndBelowAverageRatings();

            var plotModel = new PlotModel() { Title = $"Rating vehicles receive" };
            var pieSeries = new PieSeries();

            pieSeries.Slices.Add(new PieSlice("Above Average", ratings[0]));
            pieSeries.Slices.Add(new PieSlice("Equal or less than Average", ratings[1]));
            plotModel.Series.Add(pieSeries);

            plotView1.Model = plotModel;
            Controls.Add(plotView1);
        }

        private void PieChartFOrCarProductionYear()
        {
            var model = new PlotModel { Title = $"Available cars year of production" };

            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            foreach(var item in _statisticsManager.GetCarsProductionYear())
            {
                seriesP1.Slices.Add(new PieSlice(item.Key.ToString(), item.Value) { IsExploded = false, Fill = OxyColors.LightSeaGreen });
            }

            model.Series.Add(seriesP1);
            plotView1.Model = model;
            Controls.Add(plotView1);
        }

        private void ButtonBackground(Button selectedButton)
        {
            var allButtons = this.Controls.Cast<Control>()
                                     .Where(c => c is Button && c != selectedButton);
            selectedButton.BackColor = Color.FromArgb(94, 94, 94);
            selectedButton.FlatAppearance.BorderSize = 0;
            foreach (Button button in allButtons)
            {
                button.BackColor = Color.FromArgb(159, 160, 255);
                button.FlatAppearance.BorderSize = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonBackground(btnMonthsRevenue);
                plotView1.Model = null;
                GenerateBarChartMonthlyRevenus();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonBackground(CarsYearsofProduction);
                plotView1.Model = null;
                PieChartFOrCarProductionYear();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button234_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonBackground(button234);
                plotView1.Model = null;
                GeneratePieChartForBelowAndAboveRating();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCategoryAvailability_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonBackground(btnCategoryAvailability);
                GeneratePieChartVehicleTypeAvailability();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbBackToMenu_Click(object sender, EventArgs e)
        {
            close_application = false;
            menuPageStaff.Show();
            this.Close();
        }
        private void AnyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close_application)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
