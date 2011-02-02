using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeftButtonContextSliders
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private ObservableCollection<CellConfig> cellConfigItems = new ObservableCollection<CellConfig>();
        private ContextMenu colorMenu;
        private List<Color> defaultColors = new List<Color>();
        
        public MainWindow()
		{
            // ColorBrewer2 Set1
            defaultColors.Add(Color.FromRgb(228, 26, 28));
            defaultColors.Add(Color.FromRgb(55, 126, 184));
            defaultColors.Add(Color.FromRgb(77, 175, 74));
            defaultColors.Add(Color.FromRgb(152, 78, 163));
            defaultColors.Add(Color.FromRgb(255, 127, 0));
            defaultColors.Add(Color.FromRgb(255, 255, 51));
            defaultColors.Add(Color.FromRgb(166, 86, 40));
            defaultColors.Add(Color.FromRgb(247, 129, 191));
            defaultColors.Add(Color.FromRgb(153, 153, 153));

            LoadCellGroups();
            this.InitializeComponent();
			
            // Insert code required on object creation below this point.
            // Setting default color picker style
            colorMenu = (ContextMenu)(this.Resources["leftClickHSVMenu"]);
            // colorMenu = (ContextMenu)(this.Resources["leftClickRGBMenu"]);

            // Should be able to do this in the xaml...
            CollectionViewSource ldv = this.Resources["listingDataView"] as CollectionViewSource;
            if (ldv != null)
            {
                ldv.Source = CellConfigItems;
            }
        }

        public ObservableCollection<CellConfig> CellConfigItems
        {
            get { return this.cellConfigItems; }
            set { this.cellConfigItems = value; }
        }

        private void LoadCellGroups()
        {
            for (int ii = 0; ii < defaultColors.Count; ++ii)
            {
                CellConfig tmpCell1 = new CellConfig("Cell " + ii, (ushort)(ii*10));
                var c = defaultColors[ii];
                tmpCell1.CellColor = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
                this.cellConfigItems.Add(tmpCell1);
            }

        }

        private void ButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            colorMenu.DataContext = Master.SelectedItem;
            colorMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            colorMenu.HorizontalOffset = -40;
            colorMenu.PlacementTarget = Detail;
            colorMenu.IsOpen = true;
        }

        private void RGB_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            colorMenu.IsOpen = false;
            colorMenu = (ContextMenu)(this.Resources["leftClickRGBMenu"]);
            colorMenu.DataContext = Master.SelectedItem;
            colorMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            colorMenu.HorizontalOffset = -40;
            colorMenu.PlacementTarget = Detail;
            colorMenu.IsOpen = true;
        }

        private void HSV_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            colorMenu.IsOpen = false;
            colorMenu = (ContextMenu)(this.Resources["leftClickHSVMenu"]);
            colorMenu.DataContext = Master.SelectedItem;
            colorMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            colorMenu.HorizontalOffset = -40;
            colorMenu.PlacementTarget = Detail;
            colorMenu.IsOpen = true;
        }
    }
}