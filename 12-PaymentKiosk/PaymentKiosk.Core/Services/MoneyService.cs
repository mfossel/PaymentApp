using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentKiosk.Core;
using Stripe;
using PaymentKiosk.Core.Domain;

namespace PaymentKiosk.Core.Services
{
    public class MoneyService
    {
        private const string StripeApiKey = "sk_test_oqIJ4a3I8qsSi2P9RTh8ogBJ";

        public static bool Charge(Customer customer, CreditCard creditcard, decimal amount)
        {
            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = (int)amount*100;
            myCharge.Currency = "usd";

            // setting up the card
            myCharge.Source = new StripeSourceOptions()
            {
                Object = "card",
                Number = creditcard.creditCardNumber,
                ExpirationMonth = creditcard.expiryDateMonth,
                ExpirationYear = creditcard.expiryDateYear,
                Cvc = creditcard.securityCode                          // optional
            };
            
            var chargeService = new StripeChargeService(StripeApiKey);
            StripeCharge apiResponse = chargeService.Create(myCharge);

            if(apiResponse.Paid == false)
            {
                throw new Exception(apiResponse.FailureMessage);
            }


           
            return apiResponse.Paid;
          


        }
    }
}
