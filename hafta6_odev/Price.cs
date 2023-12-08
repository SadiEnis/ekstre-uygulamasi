using System;

namespace hafta6_odev
{
    public class Price
    {
        public int Value;
        public const string Type = "TL";
        // Bu bir constant kullanımıdır. Bu değişken olmaz artık ve değeri asla başka bir yerde değiştirilemez.
        public DateTime Date;
        public string Mesage;
        public Price(int _price) { this.Value = _price; }
    }
}
