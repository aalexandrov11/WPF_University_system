using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //textBlock1.Text = "Text1";
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length > 2)
                MessageBox.Show("Hello!!! This is Spartaaaaa..." + txtName.Text);
            else
                MessageBox.Show("Enter more than 2 symbols.");

            String s = null;

            foreach(var item in NameGrid.Children)
            {
                if(item is TextBox)
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
            }

            MessageBox.Show("Hello\n" + s);

            //MessageBox.Show("Hello!!! This is Spartaaaaa..." + txtName1.Text + "\n");
            //MessageBox.Show("Hello!!! This is Spartaaaaa..." + txtName2.Text + "\n");
        }

        private int fact(int n)
        {
            if (n <= 1)
                return 1;
            return n * fact(n - 1);
        }

        private void CalcFact_Click(object sender, RoutedEventArgs e)
        {
            int nf = Convert.ToInt32(txtFact.Text);//int.Parse(txtFact.Text);
            int result = fact(nf);
            txtFactResult.Text = result.ToString();
        }

        private void CalcAB_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            double result = Math.Pow(a, b);
            txtAB.Text = result.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello 1");
            textBlock1.Text = DateTime.Now.ToString();
        }
    }
}
