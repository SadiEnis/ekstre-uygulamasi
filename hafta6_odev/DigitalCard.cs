using System;
using System.Collections.Generic;



namespace hafta6_odev
{
    public class DigitalCard
    {
        public int cardLimit = 20000; 
        public List<Price> priceList = new List<Price>();
        // Harcamaların tutulduğu liste
        public virtual void MakePrice(Price price)
        { // Harcama yapıma işlevine sahip metot -virtual tanımlandı-
            if (price.Value <= cardLimit)
            { // Aşağıdaki kısmı bir kez satır satır açıkladım. Diğer sınıflarda farklar dışında açıklamadım. Hemen hemen aynı zaten.
                cardLimit -= price.Value;
                price.Date = DateTime.Now;
                price.Mesage = $"{price.Date} - Harcama işleminiz gerçekleştirilmiştir: {price.Value}"; // Yapılan alışveriş hakkında bir mesaj.
                // Bu kullanım daha önce ödevlerimde kullanmadığım bir kullanım. Aslında String'in yaptığı işlev dışında farklı bir şey yapmıyor.
                priceList.Add(price); // Listeye de ekliyor. En son ekstre olarak kullanılacak.
            }
            else
                Console.WriteLine("Yeterli limit yok.");
        }
    }
    public class TransportationCard : DigitalCard
    {
        DigitalCard dCard;
        public TransportationCard(DigitalCard _dCard) { dCard = _dCard; }
        // Aslında böyle yapmayacaktım. DigitalCard sınıfı içinde subclass olan diğer kartları da nesne olarak tanımladım ancak..
        // sınıflar sürekli birbirini çağırarak StackOverflowException(bellek taşması) sorunu ile karşılaştım ve aklıam uzun(üç gün) uğraş sonucu bu çözüm(aslında epey bi stack sorunu nasıl çözerim diye düşündüm) geldi.

        private int thisCardLimit = 3500;
        public override void MakePrice(Price price)
        { // Üst sınıftaki MakePrice metodunu yeniden daha farklı bir kullanıma sahip olmasını sağlayan kullanım.
            price.Date = DateTime.Now;
            if (price.Value <= thisCardLimit && price.Value <= dCard.cardLimit)
            { // Eğer bu kartın limitinden VE asıl kartın limitinden küçükse harcama işlem yapsın
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value; // Asıl kartın limitinden de kısıyor.
                price.Mesage = $"{price.Date} - Ulaşım harcaması gerçekleşti: {price.Value}";
            }
            else if (price.Value <= thisCardLimit + 800 && price.Value <= dCard.cardLimit)
            { // Eğer bu kartından limitinden 800 fazla ise VE asıl kartın limitinden küçükse harcama işlemi yapsın 
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - 3500 lira limitiniz tükenmiş olup ulaşım harcaması 800 lira ek limitten gerçekleştirilmiştir: {price.Value}";
            }
            else
                price.Mesage = $"{price.Date} - Yeterli limite sahip değildiniz. {price.Value} değerindeki işlem gerçekleştirilemedi.";
            // Limitler kısıtlı ise Yetersiz mesajı girelim.

            priceList.Add(price); // Üst if ile farkı mesaj çünkü aşım olduğu taktirde kullanıya ekstre mesajı olarak öyle sunmalıyız.
        }
    }
    public class EntertainmentCard : DigitalCard
    {
        DigitalCard dCard;
        public EntertainmentCard(DigitalCard _dCard) { dCard = _dCard; }

        private int thisCardLimit = 3500;
        public override void MakePrice(Price price)
        {
            price.Date = DateTime.Now;
            if (price.Value <= thisCardLimit && price.Value <= dCard.cardLimit)
            {
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - Eğlence harcaması gerçekleşti: {price.Value}";
            }
            else if (price.Value <= thisCardLimit + 800 && price.Value <= dCard.cardLimit)
            {
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - 3500 lira limitiniz tükenmiş olup eğlence harcaması 800 lira ek limitten gerçekleştirilmiştir: {price.Value}";
            }
            else
                price.Mesage = $"{price.Date} - Yeterli limite sahip değildiniz. {price.Value} değerindeki işlem gerçekleştirilemedi.";
            priceList.Add(price);
        }
    }
    public class ClothingCard : DigitalCard
    {
        DigitalCard dCard;
        public ClothingCard(DigitalCard _dCard) { dCard = _dCard; }

        private int thisCardLimit = 3500;
        public override void MakePrice(Price price)
        {
            price.Date = DateTime.Now;
            if (price.Value <= thisCardLimit && price.Value <= dCard.cardLimit)
            {
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - Giyim harcaması gerçekleşti: {price.Value}";
            }
            else if (price.Value <= thisCardLimit + 800 && price.Value <= dCard.cardLimit)
            {
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - 3500 lira limitiniz tükenmiş olup giyim harcaması 800 lira ek limitten gerçekleştirilmiştir: {price.Value}";
            }
            else
                price.Mesage = $"{price.Date} - Yeterli limite sahip değildiniz. {price.Value} değerindeki işlem gerçekleştirilemedi.";
            priceList.Add(price);
        }
    }
    public class FoodCard : DigitalCard
    {
        DigitalCard dCard;
        public FoodCard(DigitalCard _dCard) { dCard = _dCard; }

        private int thisCardLimit = 3500;
        public override void MakePrice(Price price)
        {
            price.Date = DateTime.Now;
            if (price.Value <= thisCardLimit && price.Value <= dCard.cardLimit)
            {
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - Yemek harcaması gerçekleşti: {price.Value}";
            }
            else if (price.Value <= thisCardLimit + 800 && price.Value <= dCard.cardLimit)
            {
                thisCardLimit -= price.Value;
                dCard.cardLimit -= price.Value;
                price.Mesage = $"{price.Date} - 3500 lira limitiniz tükenmiş olup yemel harcaması 800 lira ek limitten gerçekleştirilmiştir: {price.Value}";
            }
            else
                price.Mesage = $"{price.Date}  - Yeterli limite sahip değildiniz. {price.Value} değerindeki işlem gerçekleştirilemedi.";
            priceList.Add(price);
        }
    }
}
