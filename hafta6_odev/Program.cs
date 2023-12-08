using System;

namespace hafta6_odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ekstre";
            // Ödevde dinamik çalışması istenmemiş değerleri kendim giriyorum.
            // Dinamik istenmiş olsaydı yapmamız gereken bir menu oluşturmak ve anlaşılır bir arayüz ile kullanıcıdan harcama yapması istenirdi.
            // Yani aynı sınıflarla ödev dinamik olarak veri girilebilir hale getirilebilirdi.

            Ekstre();

            Console.WriteLine();
            Console.WriteLine("Çıkmak için bir tuşa basınız.");
            Console.ReadKey();
        }
        private static void Ekstre()
        {
            DigitalCard DIGITALCARD = new DigitalCard();
            DIGITALCARD.MakePrice(new Price(1200));
            DIGITALCARD.MakePrice(new Price(700));
            DIGITALCARD.MakePrice(new Price(1000));
            DIGITALCARD.MakePrice(new Price(1200));
            DIGITALCARD.MakePrice(new Price(600));

            TransportationCard traCard = new TransportationCard(DIGITALCARD);
            traCard.MakePrice(new Price(100));
            traCard.MakePrice(new Price(300));
            traCard.MakePrice(new Price(150));
            traCard.MakePrice(new Price(1000));
            traCard.MakePrice(new Price(250));

            EntertainmentCard entCard = new EntertainmentCard(DIGITALCARD);
            entCard.MakePrice(new Price(350));
            entCard.MakePrice(new Price(550));
            entCard.MakePrice(new Price(650));
            entCard.MakePrice(new Price(750));
            entCard.MakePrice(new Price(850));

            ClothingCard cloCard = new ClothingCard(DIGITALCARD);
            cloCard.MakePrice(new Price(650));
            cloCard.MakePrice(new Price(750));
            cloCard.MakePrice(new Price(850));
            cloCard.MakePrice(new Price(850));
            cloCard.MakePrice(new Price(950));

            FoodCard fooCard = new FoodCard(DIGITALCARD);
            fooCard.MakePrice(new Price(850));
            fooCard.MakePrice(new Price(950));
            fooCard.MakePrice(new Price(1050));
            fooCard.MakePrice(new Price(1150));
            fooCard.MakePrice(new Price(1250));

            Console.ForegroundColor = ConsoleColor.DarkRed; // Bunlar özgünlük sağlamak için.
            Console.WriteLine("--------------------");
            Console.WriteLine("|      Ekstre      |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < DIGITALCARD.priceList.Count; i++)
                Console.WriteLine(DIGITALCARD.priceList[i].Mesage);
            for (int i = 0; i < traCard.priceList.Count; i++)
                Console.WriteLine(traCard.priceList[i].Mesage);
            for (int i = 0; i < entCard.priceList.Count; i++)
                Console.WriteLine(entCard.priceList[i].Mesage);
            for (int i = 0; i < cloCard.priceList.Count; i++)
                Console.WriteLine(cloCard.priceList[i].Mesage);
            for (int i = 0; i < fooCard.priceList.Count; i++)
                Console.WriteLine(fooCard.priceList[i].Mesage);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n");
            Console.WriteLine("Kartın limit: " + DIGITALCARD.cardLimit);
            Console.ResetColor();
        }
    }
}
