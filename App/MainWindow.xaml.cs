using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Analogwertrechner;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CalcFactor(txtBoxMinWertSps, txtBoxMaxWertSps, txtBoxMesswertSps, txtBlockFaktorSps, "SPS", _factorSps);
        CalcFactor(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBoxMesswertAnalog, txtBlockFaktorAnalog, "Analog", _factorAnalog);
        CalcFactor(txtBoxMinWertReal, txtBoxMaxWertReal, txtBoxMesswertReal, txtBlockFaktorReal, "Real", _factorRealWorld);
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorSps, txtBoxEinheitAnalog.Text, txtBlockSpsAnalog, "Analog", "SPS", false);    // SPS/Analog
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorSps, txtBoxEinheitReal.Text, txtBlockSpsReal, "Analog", "SPS", false);            // SPS/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorAnalog, "", txtBlockAnalogSps, "Analog", "SPS", true);                              // Analog/SPS
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorAnalog, txtBoxEinheitReal.Text, txtBlockAnalogReal, "Analog", "SPS", false);      // Analog/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorReal, "", txtBlockRealSps, "Analog", "SPS", true);                                  // Real/SPS
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorReal, txtBoxEinheitAnalog.Text, txtBlockRealAnalog, "Analog", "SPS", false);  // Real/Analog
        CheckInputError();
    }

    private void SpsWert_lostFocus(object sender, RoutedEventArgs e)
    {
        CalcFactor(txtBoxMinWertSps, txtBoxMaxWertSps, txtBoxMesswertSps, txtBlockFaktorSps, "SPS", _factorSps);
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorSps, txtBoxEinheitAnalog.Text, txtBlockSpsAnalog, "Analog", "SPS", false);    // SPS/Analog
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorSps, txtBoxEinheitReal.Text, txtBlockSpsReal, "Analog", "SPS", false);            // SPS/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorAnalog, "", txtBlockAnalogSps, "Analog", "SPS", true);                              // Analog/SPS
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorAnalog, txtBoxEinheitReal.Text, txtBlockAnalogReal, "Analog", "SPS", false);      // Analog/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorReal, "", txtBlockRealSps, "Analog", "SPS", true);                                  // Real/SPS
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorReal, txtBoxEinheitAnalog.Text, txtBlockRealAnalog, "Analog", "SPS", false);  // Real/Analog
        CheckInputError();
    }

    private void AnalogWert_lostFocus(object sender, RoutedEventArgs e)
    {
        CalcFactor(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBoxMesswertAnalog, txtBlockFaktorAnalog, "Analog", _factorAnalog);
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorSps, txtBoxEinheitAnalog.Text, txtBlockSpsAnalog, "Analog", "SPS", false);    // SPS/Analog
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorSps, txtBoxEinheitReal.Text, txtBlockSpsReal, "Analog", "SPS", false);            // SPS/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorAnalog, "", txtBlockAnalogSps, "Analog", "SPS", true);                              // Analog/SPS
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorAnalog, txtBoxEinheitReal.Text, txtBlockAnalogReal, "Analog", "SPS", false);      // Analog/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorReal, "", txtBlockRealSps, "Analog", "SPS", true);                                  // Real/SPS
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorReal, txtBoxEinheitAnalog.Text, txtBlockRealAnalog, "Analog", "SPS", false);  // Real/Analog
        CheckInputError();
    }

    private void RealerWert_lostFocus(object sender, RoutedEventArgs e)
    {
        CalcFactor(txtBoxMinWertReal, txtBoxMaxWertReal, txtBoxMesswertReal, txtBlockFaktorReal, "Real", _factorRealWorld);
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorSps, txtBoxEinheitAnalog.Text, txtBlockSpsAnalog, "Analog", "SPS", false);    // SPS/Analog
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorSps, txtBoxEinheitReal.Text, txtBlockSpsReal, "Analog", "SPS", false);            // SPS/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorAnalog, "", txtBlockAnalogSps, "Analog", "SPS", true);                              // Analog/SPS
        CalcValue(txtBoxMinWertReal, txtBoxMaxWertReal, txtBlockFaktorAnalog, txtBoxEinheitReal.Text, txtBlockAnalogReal, "Analog", "SPS", false);      // Analog/Real
        CalcValue(txtBoxMinWertSps, txtBoxMaxWertSps, txtBlockFaktorReal, "", txtBlockRealSps, "Analog", "SPS", true);                                  // Real/SPS
        CalcValue(txtBoxMinWertAnalog, txtBoxMaxWertAnalog, txtBlockFaktorReal, txtBoxEinheitAnalog.Text, txtBlockRealAnalog, "Analog", "SPS", false);  // Real/Analog
        CheckInputError();
    }

    private float _factorSps, _factorAnalog, _factorRealWorld;

    private void CheckInputError()
    {
        try
        {
            if (txtBlockFaktorSps.Text == "?") throw new ArgumentException("SPS Faktor nicht berechenbar");
            if (txtBlockFaktorAnalog.Text == "?") throw new ArgumentException("Analog Faktor nicht berechenbar");
            if (txtBlockFaktorReal.Text == "?") throw new ArgumentException("Real Faktor nicht berechenbar");

            if (txtBlockSpsAnalog.Text == "?") throw new ArgumentException("SPS/Analog Wert nicht berechenbar");
            if (txtBlockSpsReal.Text == "?") throw new ArgumentException("SPS/Real Wert nicht berechenbar");

            if (txtBlockAnalogSps.Text == "?") throw new ArgumentException("Analog/SPS Wert nicht berechenbar");
            if (txtBlockAnalogReal.Text == "?") throw new ArgumentException("Analog/Real Wert nicht berechenbar");

            if (txtBlockRealSps.Text == "?") throw new ArgumentException("Real/SPS Wert nicht berechenbar");
            if (txtBlockRealAnalog.Text == "?") throw new ArgumentException("Real/Analog Wert nicht berechenbar");

            txtInvalid.Foreground = Brushes.White;
        }
        catch
        {
            txtInvalid.Foreground = Brushes.Red;
        }
        
    }

    private static void CalcValue(TextBox txtBoxMinRange, TextBox txtBoxMaxRange, TextBlock txtBlockFactor, string unit, TextBlock txtBlockOutput, string categoryRange, string categoryFactor, bool outputInt)
    {
        try
        {
            if (string.IsNullOrEmpty(txtBoxMinRange.Text)) throw new ArgumentException($"{categoryRange} Bereich Min ohne Eingabe");
            if (string.IsNullOrEmpty(txtBoxMaxRange.Text)) throw new ArgumentException($"{categoryRange} Bereich Max ohne Eingabe");
            if (txtBlockFactor.Text == "?") throw new ArgumentException($"{categoryFactor} Faktor ohne gültigen Wert");

            float minRange, maxRange, factor, value;

            if (!float.TryParse(txtBoxMinRange.Text, out minRange)) throw new ArgumentException($"{categoryRange} Bereich Min ist keine Zahl");
            if (!float.TryParse(txtBoxMaxRange.Text, out maxRange)) throw new ArgumentException($"{categoryRange} Bereich Max ist keine Zahl");
            if (!float.TryParse(txtBlockFactor.Text, out factor)) throw new ArgumentException($"{categoryFactor} Messwert ist keine Zahl");

            if (minRange > maxRange || minRange < 0 || minRange == maxRange)
                throw new ArgumentException($"{categoryRange} Wert/Grenzen haben eine ungültige konstelation");

            value = (factor * (maxRange - minRange)) + minRange;

            if (string.IsNullOrEmpty(unit) && !outputInt)
            {
                txtBlockOutput.Text = string.Format($"{value:N2}");         // no unit and float
            }
            else if (string.IsNullOrEmpty(unit) && outputInt)
            {   
                txtBlockOutput.Text = string.Format($"{(int)value}");       // no unit and int
            }
            else if (!outputInt)
            {
                txtBlockOutput.Text = string.Format($"{value:N2} {unit}");  // unit and float
            }
            else
            {
                txtBlockOutput.Text = string.Format($"{(int)value} {unit}");  // unit and int
            }
        }
        catch
        {
            txtBlockOutput.Text = "?";
        }
    }

    private static void CalcFactor(TextBox txtBoxMinRange, TextBox txtBoxMaxRange, TextBox txtBoxValue, TextBlock txtBoxFactor, string category, float factor)
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