namespace iQuest.VendingMachine.Business
{
    public class CardValidator
    {

        public bool ValidateCardNumber(string userInput)
        {
            int cardNumberLength = userInput.Length;
            int sum = 0;
            bool parity = cardNumberLength % 2 == 0;

            int[] cardNumber = new int[cardNumberLength];
            for (int i = 0; i < cardNumberLength; i++)
                cardNumber[cardNumberLength - 1 - i] = int.Parse(Char.ToString(userInput[i]));

            for (int i = 0; i < cardNumberLength; i++)
            {
                bool isOddPositionInNumber = i % 2 != 0;

                if (!isOddPositionInNumber)
                    sum = sum + cardNumber[i];
                else
                {
                    int newNumberOfOddPosition = cardNumber[i] * 2;

                    if (newNumberOfOddPosition > 9)
                    {
                        sum += SumOfDigits(newNumberOfOddPosition);
                    }
                    else
                        sum = sum + newNumberOfOddPosition;
                }
            }
            return sum % 10 == 0;
        }

        private int SumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10;

                sum += lastDigit;
            }
            return sum;
        }
    }
}
