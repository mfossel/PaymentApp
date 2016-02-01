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
using PaymentKiosk.Core.Domain;
using PaymentKiosk.Core.Services;

namespace _12_PaymentKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void completeTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer
            {
                name = nameTextBox.Text,
                phoneNumber = phoneNumberTextBox.Text
            };
            CreditCard creditCard = new CreditCard
            {
                creditCardNumber = creditCardNumberTextBox.Text,
                expiryDateMonth = expiryMonthTextBox.Text,
                expiryDateYear = expiryYearTextBox.Text,
                securityCode = securityTextBox.Text
            };

            try
            {
                bool success = MoneyService.Charge(customer, creditCard, decimal.Parse(amountTextBox.Text));

                if (success)
                {
                    
                    MessageBox.Show("Payment from " + customer.name + " succesful.");
                    MessageService.Text("You have received $" + amountTextBox.Text +" from " + customer.name + ".");               
                }
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }
    }
}
