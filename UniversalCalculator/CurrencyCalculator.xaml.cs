using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

//Developed by Kateryna Tyshchenko 7/03/25

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator : Page
	{
		// Exchange rates with full precision
		private double usdToEur = 0.85189982;
		private double usdToGbp = 0.72872436;
		private double usdToInr = 74.257327;

		private double eurToUsd = 1.1739732;
		private double eurToGbp = 0.8556672;
		private double eurToInr = 87.00755;

		private double gbpToUsd = 1.371907;
		private double gbpToEur = 1.1686692;
		private double gbpToInr = 101.68635;

		private double inrToUsd = 0.011492628;
		private double inrToEur = 0.013492774;
		private double inrToGbp = 0.0098339397;

		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}

		//the code I've developed so far
		// Calculate the currency conversion when the user clicks the "Currency Conversion" button
		private async void btnConvert_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Get the user input
				double amount = Convert.ToDouble(txtAmount.Text);

				// Get the currencies selected
				string fromCurrency = cmbFromCurrency.SelectedItem.ToString();
				string toCurrency = cmbToCurrency.SelectedItem.ToString();

				// Call the method to calculate the conversion
				double conversionRate = GetExchangeRate(fromCurrency, toCurrency);
				double convertedAmount = amount * conversionRate;

				// Display results
				txtConvertedAmount.Text = convertedAmount.ToString();

				// Display appropriate exchange rate
				txtExchangeRate.Text = conversionRate.ToString();
			}

			//Try catch errors
			catch (FormatException)
			{
				var dialogMessage = new MessageDialog("Error: Invalid input. Please enter a valid number.", "Input Error");
				await dialogMessage.ShowAsync();
				txtAmount.Focus(FocusState.Programmatic);
				return;
			}
			catch (NullReferenceException)
			{
				var dialogMessage = new MessageDialog("Error: No currency selected. Please select both a 'From' and 'To' currency.", "Selection Error");
				await dialogMessage.ShowAsync();
				cmbFromCurrency.Focus(FocusState.Programmatic);
				return;
			}

		}

		// Getting appropriate exchange rate baseed on the currencies selected
		private double GetExchangeRate(string fromCurrency, string toCurrency)
		{
			if (fromCurrency == "USD" && toCurrency == "EUR")
				return usdToEur;
			else if (fromCurrency == "USD" && toCurrency == "GBP")
				return usdToGbp;
			else if (fromCurrency == "USD" && toCurrency == "INR")
				return usdToInr;
			else if (fromCurrency == "EUR" && toCurrency == "USD")
				return eurToUsd;
			else if (fromCurrency == "EUR" && toCurrency == "GBP")
				return eurToGbp;
			else if (fromCurrency == "EUR" && toCurrency == "INR")
				return eurToInr;
			else if (fromCurrency == "GBP" && toCurrency == "USD")
				return gbpToUsd;
			else if (fromCurrency == "GBP" && toCurrency == "EUR")
				return gbpToEur;
			else if (fromCurrency == "GBP" && toCurrency == "INR")
				return gbpToInr;
			else if (fromCurrency == "INR" && toCurrency == "USD")
				return inrToUsd;
			else if (fromCurrency == "INR" && toCurrency == "EUR")
				return inrToEur;
			else if (fromCurrency == "INR" && toCurrency == "GBP")
				return inrToGbp;

			// Default if no match
			throw new Exception("Exchange rate not available.");
		}

		// Handle the Exit button click to Navigate back to the previous page (CalculatorMenu.xaml)
		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CalculatorMenu));
		}
	}
}