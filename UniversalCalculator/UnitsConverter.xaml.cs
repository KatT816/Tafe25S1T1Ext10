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
	public sealed partial class UnitsConverter : Page
	{
		public UnitsConverter()
		{
			this.InitializeComponent();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			// Initially disable the "SelectUnitType" ComboBox until a selection is made in "FromUnitType"
			SelectUnitType.IsEnabled = false;
		}

		// Variable to hold the unit type selected in the "FromUnitType" ComboBox
		private string selectedFromUnitType = string.Empty;

		// Handle the selection change of the "FromUnitType" ComboBox
		private void UnitTypeChanged(object sender, SelectionChangedEventArgs e)
		{
			// Get the selected item from the "FromUnitType" ComboBox
			ComboBox comboBox = sender as ComboBox;
			ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
			selectedFromUnitType = selectedItem?.Content.ToString();

			// Enable the "SelectUnitType" ComboBox and show relevant options
			SelectUnitType.IsEnabled = true;
			UpdateUnitTypeOptions();
		}

		// Update the "SelectUnitType" ComboBox based on the selected "FromUnitType"
		private void UpdateUnitTypeOptions()
		{
			SelectUnitType.Items.Clear();

			switch (selectedFromUnitType)
			{
				case "Temperature":
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Celsius" });
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Fahrenheit" });
					break;
				case "Distance":
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Meter" });
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Foot" });
					break;
				case "Mass":
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Kilogram" });
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Pound" });
					break;
				case "Pressure":
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "Kpa" });
					SelectUnitType.Items.Add(new ComboBoxItem { Content = "PSI" });
					break;
				default:
					break;
			}
		}

		// Handle the selection change of the "SelectUnitType" ComboBox
		private void UnitChanged(object sender, SelectionChangedEventArgs e)
		{
			// You can add any further logic here if needed for specific unit selection
		}

		// Handle the click of the "ConvertButton"
		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			// Declare the inputAmount variable here
			double inputAmount = 0;
			string errorMessage = string.Empty;

			// Validate ConvertFromTextBox input
			if (string.IsNullOrWhiteSpace(ConvertFromTextBox.Text))
			{
				errorMessage = "Must have Input";
			}
			else if (!double.TryParse(ConvertFromTextBox.Text, out inputAmount)) // Ensure it's parsed here
			{
				errorMessage = "Must be a Valid Number";
			}

			// Validate that a unit is selected
			if (SelectUnitType.SelectedItem == null)
			{
				errorMessage = "A unit must be selected";
			}

			// Display error message if any validation failed
			if (!string.IsNullOrEmpty(errorMessage))
			{
				ResultTextBlock.Text = errorMessage;
				return;
			}

			// Perform conversion based on selected units
			string resultText = string.Empty;
			string selectedUnit = (SelectUnitType.SelectedItem as ComboBoxItem).Content.ToString();

			switch (selectedFromUnitType)
			{
				case "Temperature":
					if (selectedUnit == "Celsius")
					{
						// Convert to Fahrenheit
						resultText = $"{(inputAmount * 1.8) + 32} Fahrenheit";
					}
					else if (selectedUnit == "Fahrenheit")
					{
						// Convert to Celsius
						resultText = $"{(inputAmount - 32) / 1.8} Celsius";
					}
					break;

				case "Distance":
					if (selectedUnit == "Meter")
					{
						// Convert to Foot
						resultText = $"{inputAmount * 3.28084} Foot";
					}
					else if (selectedUnit == "Foot")
					{
						// Convert to Meter
						resultText = $"{inputAmount * 0.3048} Meter";
					}
					break;

				case "Mass":
					if (selectedUnit == "Kilogram")
					{
						// Convert to Pound
						resultText = $"{inputAmount * 2.20462} Pound";
					}
					else if (selectedUnit == "Pound")
					{
						// Convert to Kilogram
						resultText = $"{inputAmount * 0.453592} Kilogram";
					}
					break;

				case "Pressure":
					if (selectedUnit == "Kpa")
					{
						// Convert to PSI
						resultText = $"{inputAmount * 0.145038} PSI";
					}
					else if (selectedUnit == "PSI")
					{
						// Convert to Kpa
						resultText = $"{inputAmount * 6.89476} Kpa";
					}
					break;

				default:
					resultText = "Invalid Unit Type";
					break;
			}

			// Show the result
			ResultTextBlock.Text = resultText;
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CalculatorMenu));
		}
	}
}