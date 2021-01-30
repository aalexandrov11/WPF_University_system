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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseltHome.xaml
    /// </summary>
    public partial class ExpenseltHome : Page, INotifyPropertyChanged
    {
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
            }
        }

        public ObservableCollection<string> PersonsChecked
        { get; set; }

        public ExpenseltHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
            //peopleListBox.Items.Add("James");
            //peopleListBox.Items.Add("David");
            //ListBoxItem james = new ListBoxItem();
            //james.Content = "James";
            //peopleListBox.Items.Add(james);

            //ListBoxItem david = new ListBoxItem();
            //david.Content = "David";
            //peopleListBox.Items.Add(david);

            //peopleListBox.SelectedItem = james;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String greetingsMsg;
            //greetingsMsg = peopleListBox.SelectedItem.ToString();
            greetingsMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingsMsg);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ExpenseReportPage expenseReportPage = new ExpenseReportPage();
            //this.NavigationService.Navigate(expenseReportPage);
            ExpenseReportPage expenseReportPage = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(expenseReportPage);
        }

        private void PeopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
        }
    }
}
