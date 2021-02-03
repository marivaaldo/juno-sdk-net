using Juno.Sdk.Models.DirectCheckouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.DirectCheckouts
{
    public static class CardUtils
    {
        public static string GetType(this Card card)
        {
            return GetCardType(card.CardNumber)?.Name;
        }

        public static bool ValidateCVC(this Card card)
        {
            return ValidateCVC(card.CardNumber, card.SecurityCode);
        }

        public static bool ValidateNumber(this Card card)
        {
            return ValidateNumber(card.CardNumber);
        }

        public static bool ValidateExpireDate(this Card card)
        {
            return ValidateExpireDate(card.ExpirationMonth, card.ExpirationYear);
        }

        public static CardLabel GetCardType(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            return CardLabel
                .GetOrderedLabels()
                .FirstOrDefault(o => o.Detector.IsMatch(cardNumber));
        }

        public static bool ValidateCVC(string cardNumber, string cvc)
        {
            var cardType = GetCardType(cardNumber);

            if (cardType == null)
                return false;

            return cvc.Length == cardType.CvcLength;
        }

        public static bool ValidateNumber(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            var cardType = GetCardType(cardNumber);

            return cardType != null && cardType.CardLength == cardNumber.Length && _ValidateNumber(cardNumber);
        }

        public static bool ValidateExpireDate(string expirationMonthText, string expirationYearText)
        {
            var today = DateTime.Now;
            var month = today.Month;
            var year = today.Year;

            int expirationMonth = int.Parse(expirationMonthText);
            int expirationYear = int.Parse(expirationYearText);

            if (expirationMonth > 0 && expirationYear > 0 && expirationYear >= year)
            {
                if (expirationYear == year)
                {
                    return (expirationMonth > month);
                }
            }

            return false;
        }

        private static bool _ValidateNumber(string cardNumber)
        {
            int checkSumTotal = 0;

            for (int digitCounter = 0; digitCounter < cardNumber.Length; digitCounter += 2)
            {
                checkSumTotal += int.Parse("" + cardNumber[digitCounter]);

                try
                {
                    foreach (var c in (int.Parse("" + (cardNumber[digitCounter] - 1)) * 2).ToString())
                    {
                        checkSumTotal += int.Parse("" + c);
                    }
                }
                catch { }
            }

            return (checkSumTotal % 10 == 0);
        }
    }
}
