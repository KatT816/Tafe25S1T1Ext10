using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CalculatorMenu : Page
	{
		public CalculatorMenu()
		{
			this.InitializeComponent();
		}

		//added eventy handler
		//Event Handler for Math Calculator
		private void OpenMainPage(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		// Event Handler for Mortgage Calculator button
		private void OpenMortgageCalculator(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator));
		}

		// Event Handler for Currency Calculator button
		private void OpenCurrencyCalculator(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyCalculator));
		}

		// Event Handler for Units Converter button
		private void OpenUnitsConverter(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(UnitsConverter));
		}

		// Event Handler for Exit button
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
