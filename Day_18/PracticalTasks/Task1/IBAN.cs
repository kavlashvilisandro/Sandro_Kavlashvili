using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public abstract class IBAN
    {
        protected string PersonalNumber { get; set; }
        protected string Iban { get; set; }
        public abstract string GetIban();
        public abstract string GetPersonalNumber();
        public abstract void AddMoney(int amount);
        public abstract void WithDraw(int amount);
        public IBAN(string iban,string personalNumber)
        {
            this.Iban = iban;
            this.PersonalNumber = personalNumber;
        }
    }
}
