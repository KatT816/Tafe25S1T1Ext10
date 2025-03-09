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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CalculatorMenu));
		}

		
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double p, yearlyInterestRate, monthlyRepayment, i;
			int n, m, y;

			//these lines validates input in principalTextBox
			try
			{
				p = double.Parse(principalTextBox.Text);

				if (p < 0)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				var message = new MessageDialog("Accepting only decimal numbers more than 0.");
				await message.ShowAsync();
				principalTextBox.Focus(FocusState.Programmatic);
				principalTextBox.SelectAll();
				return;
			}

			//these lines validates input in yearTextBox
			try
			{
				y = int.Parse(yearTextBox.Text);

				if (y < 0)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				var message = new MessageDialog("Accepting only whole numbers more than 0");
				await message.ShowAsync();
				yearTextBox.Focus(FocusState.Programmatic);
				yearTextBox.SelectAll();
				return;
			}

			//these lines validates input in monthsTextBox
			try
			{
				m = int.Parse(monthsTextBox.Text);

				if (m > 11)
				{
					int m2;
					int y2;
					decimal yearsAdded = m / 12;
					int excessYear = (int)Math.Floor(yearsAdded);
					y2 = y + excessYear;
					int excess = (int)Math.Floor(yearsAdded) * 12;
					m2 = m - excess;

					var message = new MessageDialog(
						"Since months is more than 11, excess of " +
						excess.ToString() +
						" to year equivalent of " +
						excessYear.ToString() + "." +
						"\n\nPrevious " +
						y.ToString() +
						" year/s and " +
						m.ToString() +
						" month/s is now converted to " +
						y2.ToString() +
						" year/s and  " +
						m2.ToString() +
						" month/s.");						
					await message.ShowAsync();

					m = m2;
					y = y2;

					monthsTextBox.Text = m.ToString();
					yearTextBox.Text = y.ToString();

				}

				if (m < 0)
				{
					throw new Exception();
				}

			}
			catch (Exception)
			{
				var message = new MessageDialog("Accepting whole numbers more than 0.");
				await message.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}


			//these lines validates input in yearlyInterestTextBox
			try
			{
				yearlyInterestRate = double.Parse(yearlyInterestTextBox.Text);

				if (yearlyInterestRate < 0 || yearlyInterestRate > 100)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				var message = new MessageDialog("Accepting only decimal number between the range of 0.0 and 100.0");
				await message.ShowAsync();
				yearlyInterestTextBox.Focus(FocusState.Programmatic);
				yearlyInterestTextBox.SelectAll();
				return;
			}


			//this line catches blank fields
			try
			{
				y = int.Parse(yearTextBox.Text);
				m = int.Parse(monthsTextBox.Text);

				n = y * 12 + m;
				yearlyInterestRate = double.Parse(yearlyInterestTextBox.Text) / 100;
				i = yearlyInterestRate / 12;

				monthlyRepayment = p * (i * Math.Pow((1 + i), n)) / (Math.Pow((1 + i), n) - 1);

				monthlyInterestTextBox.Text = i.ToString("P");
				repaymentTextBox.Text = monthlyRepayment.ToString("C");
			}
			catch (Exception)
			{
				var message = new MessageDialog("Do not leave blank field");
				await message.ShowAsync();
				if (principalTextBox.Text == "")
				{
					principalTextBox.Focus(FocusState.Programmatic);
					principalTextBox.SelectAll();
					return;
				}
				else if (yearTextBox.Text == "")
				{
					yearTextBox.Focus(FocusState.Programmatic);
					yearTextBox.SelectAll();
					return;
				}
				else if (monthsTextBox.Text == "")
				{
					monthsTextBox.Focus(FocusState.Programmatic);
					monthsTextBox.SelectAll();
					return;
				}
				else if (yearlyInterestTextBox.Text == "")
				{
					yearlyInterestTextBox.Focus(FocusState.Programmatic);
					yearlyInterestTextBox.SelectAll();
					return;
				}

			}


		}

	}
}
