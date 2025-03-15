using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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

		//added event handler
		//Event Handler for Math Calculator
		//navigation to Math calculator already added KT 10/03/25
		private void OpenMainPage(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		// Event Handler for Mortgage Calculator button
		//Navigation to Mortgage calculator already added KT 10/03/25
		private void OpenMortgageCalculator(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator));
		}

		// Event Handler for Currency Calculator button
		//Navigation to currency calculator already added KT 10/03/25
		private void OpenCurrencyCalculator(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyCalculator));
		}

		// Event Handler for Units Converter button
		//Navigation to units calculator already added KT 10/03/25
		private void OpenUnitsConverter(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(UnitsConverter));
		}

		// Event Handler for Exit button
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			var message = new MessageDialog("Trip Calculator C# code will be developed later.");
			await message.ShowAsync();
			return;
		}
    }
}
