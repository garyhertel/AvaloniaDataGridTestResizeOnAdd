using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System.Collections.Generic;

namespace AvaloniaDataGrid
{
	public class MainWindow : Window
	{
		private List<TestItem> testItems;
		private DataGridCollectionView collectionView;

		private Grid grid;
		private DataGrid dataGrid;

		public MainWindow()
		{
			InitializeComponent();
#if DEBUG
			this.AttachDevTools();
#endif
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
			grid = this.FindControl<Grid>("Grid");

			testItems = new List<TestItem>();
			for (int i = 0; i < 2; i++)
				testItems.Add(new TestItem());

			collectionView = new DataGridCollectionView(testItems);

			dataGrid = new DataGrid()
			{
				//HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
				//VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch,
				Background = new SolidColorBrush(Colors.White),
				RowBackground = new SolidColorBrush(Colors.White),
				AlternatingRowBackground = new SolidColorBrush(Colors.White),
				Items = collectionView,
				AutoGenerateColumns = true,
			};

			//TestsStackPanel(); // resizes correctly
			TestGrid(); // doesn't resize correctly

			this.Tapped += MainWindow_Tapped;
		}

		private void TestGrid()
		{
			grid.Children.Add(dataGrid);
		}

		private void TestsStackPanel()
		{
			StackPanel stackPanel = new StackPanel()
			{
				Orientation = Orientation.Vertical,
				Background = new SolidColorBrush(Colors.Orange),
			};
			stackPanel.Children.Add(dataGrid);
			Content = stackPanel;
		}

		private void MainWindow_Tapped(object sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			for (int i = 0; i < 1; i++)
				testItems.Add(new TestItem());

			collectionView.Refresh(); 

			/*dataGrid.Measure(Bounds.Size);
			Size desiredSize = grid.DesiredSize;
			Size dataGridDesiredSize = dataGrid.DesiredSize;
			grid.InvalidateMeasure();
			grid.InvalidateArrange();
			dataGrid.InvalidateMeasure();
			dataGrid.InvalidateArrange();
			InvalidateMeasure();
			InvalidateArrange();*/
		}
	}
}
