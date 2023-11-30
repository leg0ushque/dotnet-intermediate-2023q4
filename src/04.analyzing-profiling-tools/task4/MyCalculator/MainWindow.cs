using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MyCalculatorv1;

public partial class MainWindow : Window, IComponentConnector
{
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        tb.Text += button.Content.ToString();
    }

    private void Result_click(object sender, RoutedEventArgs e)
    {
        result();
    }

    private void result()
    {
        int num = 0;

        if (tb.Text.Contains("="))
        {
            MessageBox.Show("Input contains \"=\" sign (you probably haven't erased the result of previous operation).\n" +
                "Please, erase it and try again!");
            return;
        }

        var digits = tb.Text.Count(x => char.IsDigit(x));
        if(tb.Text.Length - digits > 1)
        {
            MessageBox.Show("Input contains more than 1 operator sign! Please correct that mistake and try again!");
            return;
        }

        if (tb.Text.Contains("+"))
        {
            num = tb.Text.IndexOf("+");
        }
        else if (tb.Text.Contains("-"))
        {
            num = tb.Text.IndexOf("-");
        }
        else if (tb.Text.Contains("*"))
        {
            num = tb.Text.IndexOf("*");
        }
        else if (tb.Text.Contains("/"))
        {
            num = tb.Text.IndexOf("/");
        }

        string text = tb.Text.Substring(num, 1);
        double num2 = Convert.ToDouble(tb.Text.Substring(0, num));
        double num3 = Convert.ToDouble(tb.Text.Substring(num + 1, tb.Text.Length - num - 1));

        switch (text)
        {
            case "+":
                {
                    TextBox textBox = tb;
                    textBox.Text = textBox.Text + "=" + (num2 + num3);
                    break;
                }
            case "-":
                {
                    TextBox textBox = tb;
                    textBox.Text = textBox.Text + "=" + (num2 - num3);
                    break;
                }
            case "*":
                {
                    TextBox textBox = tb;
                    textBox.Text = textBox.Text + "=" + num2 * num3;
                    break;
                }
            default:
                {
                    TextBox textBox = tb;
                    textBox.Text = textBox.Text + "=" + num2 / num3;
                    break;
                }
        }
    }

    private void Off_Click_1(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Del_Click(object sender, RoutedEventArgs e)
    {
        tb.Text = "";
    }

    private void R_Click(object sender, RoutedEventArgs e)
    {
        if (tb.Text.Length > 0)
        {
            tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
        }
    }
}
