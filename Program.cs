using System;

namespace ConsoleApp
{
    class Program
    {
        static int[] Recount(int pence)
        {
            int[] moneyList = new int[3];
            moneyList[0] = pence / 240;
            pence %= 240;
            moneyList[1] = pence / 12;
            pence %= 12;
            moneyList[2] = pence;
            return moneyList;
        }

        static int GetPence(int[] moneyList)
        {
            int pence = moneyList[0] * 240 + moneyList[1] * 12 + moneyList[2];
            return pence;
        }

        static string CountSdacha(int penceS)
        {
            int[] cashRegister = { 100, 100, 100 };
            int[] moneyList = new int[3];
            int poundsCount = penceS / 240;
            if (poundsCount > cashRegister[0])
            {
                poundsCount = cashRegister[0];
            }
            moneyList[0] = poundsCount;
            penceS -= poundsCount * 240;

            int shCount = penceS / 12;
            if (shCount > cashRegister[1])
            {
                shCount = cashRegister[1];
            }
            moneyList[1] = shCount;
            penceS -= shCount * 12;

            if (penceS > cashRegister[2])
            {
                return "Сдачу нельзя выдать с такой кассой сейчас((( \n" +
                       "Уважаемый покупатель, подождите немного, когда другие люди рассчитаются и появятся деньги для вашей сдачи!<3";
            }
            moneyList[2] = penceS;
            return $"Сдача такова: \n" +
                   $"{moneyList[0]} фунтов\n" +
                   $"{moneyList[1]} шиллингов \n" +
                   $"{moneyList[2]} пенсов";
        }

        static string GetSdacha(int[] cost, int[] customerSum)
        {
            int penceCost = GetPence(cost);
            int penceCustomerSum = GetPence(customerSum);

            if (penceCost == penceCustomerSum)
            {
                return "Нет сдачи";
            }
            if (penceCost > penceCustomerSum)
            {
                return "Ошибка";
            }
            int difference = penceCustomerSum - penceCost;
            return CountSdacha(difference);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите стоимость товара в формате: фунты шиллинги пенсы (через пробел): ");
            int[] cost = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Введите сумму, которую внёс покупатель, в формате: фунты шиллинги пенсы (через пробел): ");
            int[] customerSum = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            string sdacha = GetSdacha(cost, customerSum);
            Console.WriteLine(sdacha);
            Console.ReadLine();
        }
    }
}
