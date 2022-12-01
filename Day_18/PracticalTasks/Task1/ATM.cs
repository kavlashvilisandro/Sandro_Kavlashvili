using System;
using System.Collections.Generic;
using System.Text;
using Task1.Exceptions;

namespace Task1
{
    public enum IbanType
    {
        CreditIban,
        DebitIban,
    }
    public static class ATM
    {

        public static Random random = new Random();
        public static List<CreditIban> CreditCase = new List<CreditIban>();
        public static List<DebitIban> DebitCase = new List<DebitIban>();

        public static void ATMProgram()
        {
            bool ProgramInProgress = true;
            while (ProgramInProgress)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Operations: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("1)My Account | 2)withdraw money | 3)Fill money ");
                    Console.WriteLine("4)Create Account ");
                    Console.Write("Input: ");
                    int operation = int.Parse(Console.ReadLine());
                    if(operation == 1)
                    {
                        ShowMeAccount();
                    }else if(operation == 2)
                    {
                        WithDrawMoney();
                    }else if(operation == 3)
                    {
                        FillAcount();
                    }else if(operation == 4)
                    {
                        CreateAccount();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }catch(InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor= ConsoleColor.Gray;
                    continue;
                }catch(AccountAlreadyExists ex)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        public static void FillAcount()
        {
            Console.Write("1) Debit | 2) Credit : ");
            int option = int.Parse(Console.ReadLine());
            Console.Write("Enter personal number: ");
            string personalNumber = Console.ReadLine();
            if(option == 1)
            {
                if (CheckPersonalNumber(personalNumber))
                {
                    Console.Write("Enter amount of money: ");
                    int amount = int.Parse(Console.ReadLine());
                    DebitIban DebitAcc = null;
                    for(int i = 0; i  < DebitCase.Count; i++)
                    {
                        if (DebitCase[i].GetPersonalNumber().Equals(personalNumber))
                        {
                            DebitAcc = DebitCase[i];
                            break;
                        }
                    }
                    DebitAcc.AddMoney(amount);
                    Console.WriteLine("Operation finished");
                }
                else
                {
                    throw new AccountDoesnotAxists();
                }
            }
            else if (option == 2)
            {
                if (CheckPersonalNumber(personalNumber))
                {
                    Console.Write("Enter amount of money: ");
                    int amount = int.Parse(Console.ReadLine());
                    CreditIban CreditAcc = null;
                    for (int i = 0; i < CreditCase.Count; i++)
                    {
                        if (CreditCase[i].GetPersonalNumber().Equals(personalNumber))
                        {
                            CreditAcc = CreditCase[i];
                            break;
                        }
                    }
                    CreditAcc.AddMoney(amount);
                    Console.WriteLine("Operation finished");
                }
                else
                {
                    throw new AccountDoesnotAxists();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void WithDrawMoney()
        {
            Console.Write("1) Debit | 2) Credit: ");
            int option= int.Parse(Console.ReadLine());
            Console.Write("Enter user personal number: ");
            string personalNumber = Console.ReadLine();
            if (CheckPersonalNumber(personalNumber))
            {
                if(option == 1)
                {
                    DebitIban Acc = null;
                    for(int i = 0; i < DebitCase.Count; i++)
                    {
                        if (DebitCase[i].GetPersonalNumber().Equals(personalNumber))
                        {
                            Acc = DebitCase[i];
                            break;
                        }
                    }
                    Console.Write("Amount of money: ");
                    int amount = int.Parse(Console.ReadLine());
                    Acc.WithDraw(amount);
                }else if(option == 2)
                {
                    CreditIban Acc = null;
                    for (int i = 0; i < CreditCase.Count; i++)
                    {
                        if (CreditCase[i].GetPersonalNumber().Equals(personalNumber))
                        {
                            Acc = CreditCase[i];
                            break;
                        }
                    }
                    Console.Write("Amount of money: ");
                    int amount = int.Parse(Console.ReadLine());
                    Acc.WithDraw(amount);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Operation Finished");
                Console.ForegroundColor= ConsoleColor.Gray;
            }
            else
            {
                throw new AccountDoesnotAxists();
            }
            
            
        }

        public static void CreateAccount()
        {
            Console.Write("Enter user personal number: ");
            string personalNumber = Console.ReadLine();
            if (CheckPersonalNumber(personalNumber))
            {
                throw new AccountAlreadyExists();
            }
            CreateCredit(personalNumber);
            CreateDebit(personalNumber);
        }
        public static bool CheckPersonalNumber(string personalNumber)
        {
            for(int i = 0; i < CreditCase.Count; i++)
            {
                if (CreditCase[i].GetPersonalNumber().Equals(personalNumber))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ShowMeAccount()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("Enter personal number: ");
            string personalNumber = Console.ReadLine();
            CreditIban CreditAcc = null;
            DebitIban DebitAcc = null;
            if (CheckPersonalNumber(personalNumber))
            {
                for (int i = 0; i < CreditCase.Count; i++)
                {
                    if (CreditCase[i].GetPersonalNumber().Equals(personalNumber))
                    {
                        CreditAcc = CreditCase[i];
                    }
                }
                for (int i = 0; i < DebitCase.Count; i++)
                {
                    if (DebitCase[i].GetPersonalNumber().Equals(personalNumber))
                    {
                        DebitAcc = DebitCase[i];
                    }
                }
                Console.WriteLine($"personal number: {CreditAcc.GetPersonalNumber()}");
                Console.WriteLine($"debit iban: {DebitAcc.GetIban()} | money: {DebitAcc.Money}");
                Console.WriteLine($"Credit iban: {CreditAcc.GetIban()} | money: {CreditAcc.Money}");
                return;
            }
            else
            {
                throw new AccountDoesnotAxists();
            }
        }
        public static void CreateDebit(string personalNumber)
        {
            DebitIban account = new DebitIban(GenerateIban(IbanType.DebitIban),personalNumber);
            DebitCase.Add(account);
        }
        public static void CreateCredit(string personalNumber)
        {
            CreditIban account = new CreditIban(GenerateIban(IbanType.CreditIban), personalNumber);
            CreditCase.Add(account);
        }
        public static string GenerateIban(IbanType type)
        {
            string BankCode = "TBC";
            string answer = "GE" + random.Next(10,100) + BankCode + random.Next(100000,1000000) + random.Next(100000, 1000000);
            if (Convert.ToBoolean((int)type))//Debit
            {
                if (CollisionChecker(DebitCase, answer))
                {
                    return GenerateIban(type);
                }
                else
                {
                    return answer;
                }
            }
            else
            {
                if (CollisionChecker(CreditCase, answer))
                {
                    return GenerateIban(type);
                }
                else
                {
                    return answer;
                }
            }
        }
        public static bool CollisionChecker(List<DebitIban> ibans,string IBAN)
        {
            for(int i = 0; i < ibans.Count; i++)
            {
                if (ibans[i].GetIban().Equals(IBAN))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CollisionChecker(List<CreditIban> ibans, string IBAN)
        {
            for (int i = 0; i < ibans.Count; i++)
            {
                if (ibans[i].GetIban().Equals(IBAN))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
