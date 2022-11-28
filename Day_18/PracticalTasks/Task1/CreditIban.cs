using System;
using System.Collections.Generic;
using System.Text;
using Task1.Exceptions;


namespace Task1
{
    public class CreditIban : IBAN
    {
        public decimal Money { get; private set;  }
        public CreditIban(string iban,string personalNumber) : base(iban,personalNumber)
        {

        }
        public override void AddMoney(int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountOfMoneyException();
            }
            this.Money = this.Money + amount;
        }
        public override void WithDraw(int amount)
        {
            if(amount  <= 0 || amount > this.Money)
            {
                throw new InvalidAmountOfMoneyException();
            }
            else
            {
                this.Money = this.Money - amount;
            }
        }
        public override string GetPersonalNumber()
        {
            return base.PersonalNumber;
        }
        public override string GetIban()
        {
            return base.Iban;
        }
    }
}
