using System.Windows;
using System.Windows.Controls;

namespace Analogwertrechner;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FaktorCalc(txtBoxMinWertSps, txtBoxMaxWertSps, txtBoxMesswertSps, txtFaktorSps, "SPS", _factorSps);
        FaktorCalc(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBoxMesswertAnalog, txtFaktorAnalog, "Analog", _factorAnalog);
        FaktorCalc(txtBoxMinWertReal, txtBoxMaxWertReal, txtBoxMesswertReal, txtFaktorReal, "Real", _factorRealWorld);
    }

    private void SpsWert_lostFocus(object sender, RoutedEventArgs e)
    {
        FaktorCalc(txtBoxMinWertSps, txtBoxMaxWertSps, txtBoxMesswertSps, txtFaktorSps, "SPS", _factorSps);
    }

    private void AnalogWert_lostFocus(object sender, RoutedEventArgs e)
    {
        FaktorCalc(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBoxMesswertAnalog, txtFaktorAnalog, "Analog", _factorAnalog);
    }

    private void RealerWert_lostFocus(object sender, RoutedEventArgs e)
    {
        FaktorCalc(txtBoxMinWertReal, txtBoxMaxWertReal, txtBoxMesswertReal, txtFaktorReal, "Real", _factorRealWorld);
    }

    private float _factorSps, _factorAnalog, _factorRealWorld;

    private void FaktorCalc(TextBox txtBoxMinRange, TextBox txtBoxMaxRange, TextBox txtBoxValue, TextBlock txtBoxFactor, string category, float factor)
    {
        try
        {
            if (txtBoxMinRange.Text == "") throw new ArgumentException($"{category} Bereich Min ohne Eingabe");
            if (txtBoxMaxRange.Text == "") throw new ArgumentException($"{category} Bereich Max ohne Eingabe");
            if (txtBoxValue.Text == "") throw new ArgumentException($"{category} Messwert ohne Eingabe");

            float minRange, maxRange, value;

            if (!float.TryParse(txtBoxMinRange.Text, out minRange)) throw new ArgumentException($"{category} Bereich Min ist keine Zahl");
            if (!float.TryParse(txtBoxMaxRange.Text, out maxRange)) throw new ArgumentException($"{category} Bereich Max ist keine Zahl");
            if (!float.TryParse(txtBoxValue.Text, out value)) throw new ArgumentException($"{category} Messwert ist keine Zahl");

            if (minRange > maxRange || minRange < 0 || minRange > value || minRange == maxRange)
                throw new ArgumentException($"{category} Wert/Grenzen haben eine ungültige konstelation");

            factor = (value - minRange) / (maxRange - minRange);
            txtBoxFactor.Text = string.Format("{0:N2}", factor);
        }
        catch
        {
            txtBoxFactor.Text = "?";
        }
    }
}