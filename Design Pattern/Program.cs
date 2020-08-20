using Design_Pattern.Abstract_Factory_Pattern;
using Design_Pattern.Factory_Pattern;
using Design_Pattern.Stretegy_Pattern;
using System;

namespace Honeywell.CodePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // calling abstract factory

            IMobilePhone nokiaPhonedetails = new Samsung();
            MobileClient mobileClient = new MobileClient(nokiaPhonedetails);

            Console.WriteLine("********* NOKIA **********");
            Console.WriteLine(mobileClient.GetSmartPhoneModelDetails());
            Console.WriteLine(mobileClient.GetNormalPhoneModelDetails());

            Console.ReadLine();

            // calling factory method

            //CardFactory factory = null;
            //Console.Write("Enter the card type you would like to visit: ");
            //string car = Console.ReadLine();

            //switch (car.ToLower())
            //{
            //    case "moneyback":
            //        factory = new MoneyBackFactory(50000, 0);
            //        break;
            //    case "titanium":
            //        factory = new TitaniumFactory(100000, 500);
            //        break;
            //    case "platinum":
            //        factory = new PlatinumFactory(500000, 1000);
            //        break;
            //    default:
            //        break;
            //}

            //CreditCard creditCard = factory.GetCreditCard();
            //Console.WriteLine("\nYour card details are below : \n");
            //Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",
            //    creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);

            CreateHuman human = null;
            Console.Write("Enter human you would like to create: (Mam/Woman) ");
            string humanType = Console.ReadLine();

            human = GetCreationMetaDataForHumanType(humanType);
            IHumanCreator HumanFactory = human.create();
            Console.WriteLine(HumanFactory.Create());
            Console.ReadLine();


            // Stretegy pattern
            CalculateClient calculate = new CalculateClient(new Plus_Operation());
            Console.WriteLine(calculate.CalculateOperation(10, 5));

            Console.ReadLine();
        }

        public static CreateHuman GetCreationMetaDataForHumanType(string humanType)
        {
            CreateHuman createFactory = null;
            switch (humanType.ToLower())
            {
                case "man":
                    createFactory = new ManFactory();
                    break;
                case "woman":
                    createFactory = new WomanFactory();
                    break;
                default:
                    break;
            }
            return createFactory;

        }



    }
}
