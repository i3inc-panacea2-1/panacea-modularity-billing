using Panacea.Models;
using Panacea.Multilinguality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    [DataContract]
    public class Service : ServerItem
    {
        private double _price;
        private bool _isMore;

        public Service()
        {
            Currency = "$";
        }

        [IsTranslatable]
        [DataMember(Name = "description")]
        public string Description
        {
            get => GetTranslation();
            set => SetTranslation(value);
        }

        int _duration;
        [DataMember(Name = "duration")]
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged("DurationInDaysString");
            }
        }

        public bool IsMore
        {
            get { return _isMore; }
            set
            {
                _isMore = value;
                OnPropertyChanged("IsMore");
            }
        }

        public TranslatableObject DurationInDaysString => DurationToString(Duration);

        private static TranslatableObject DurationToString(int duration)
        {
            if (duration == -1) return new TranslatableObject("Unlimited", new Translator("core"));

            var ts = new TimeSpan(0, 0, (int)duration, 0);
            if (ts.Days > 1)
            {
                if (ts.Hours > 1)
                {
                    return new TranslatableObject("{0} days and {1} hours", new Translator("core"),
                        ts.Days, ts.Hours);
                }
                if (ts.Hours == 1)
                {
                    return new TranslatableObject("{0} days and 1 hour", new Translator("core"),
                        ts.Days);
                }
                return new TranslatableObject("{0} days", new Translator("core"),
                    ts.Days);
            }

            if (ts.Days == 1)
            {

                if (ts.Hours > 1)
                {
                    return new TranslatableObject("1 day and {1} hours", new Translator("core"),
                        ts.Days, ts.Hours);
                }
                if (ts.Hours == 1)
                {
                    return new TranslatableObject("1 day and 1 hour", new Translator("core"));
                }
                return new TranslatableObject("1 day", new Translator("core"),
                    ts.Days);
            }

            if (ts.Hours > 1)
            {
                if (ts.Minutes > 1)
                {
                    return new TranslatableObject("{0} hours and {1} minutes", new Translator("core"),
                        ts.Hours, ts.Minutes);
                }
                if (ts.Minutes == 1)
                {
                    return new TranslatableObject("{0} hours and 1 minute", new Translator("core"),
                        ts.Hours);
                }
                return new TranslatableObject("{0} hours", new Translator("core"),
                    ts.Hours);
            }

            if (ts.Hours == 1)
            {
                if (ts.Minutes > 1)
                {
                    return new TranslatableObject("1 hour and {0} minutes", new Translator("core"),
                        ts.Minutes);
                }
                if (ts.Minutes == 1)
                {
                    return new TranslatableObject("1 hour and 1 minute", new Translator("core"));
                }
                return new TranslatableObject("1 hour", new Translator("core"));
            }

            if (ts.Minutes == 1)
                return new TranslatableObject("1 minute", new Translator("core"));

            return new TranslatableObject("{0} minutes", new Translator("core"),
                ts.Minutes);
        }

        [IsTranslatable]
        [DataMember(Name = "supportText")]
        public string SupportText
        {
            get => GetTranslation();
            set => SetTranslation(value);
        }

        [DataMember(Name = "imageThumbnail")]
        public Thumbnail ImageThumbnail { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "pricePerDay")]
        public bool IsPricePerDay { get; set; }

        [DataMember(Name = "quantityPerDay")]
        public bool IsQuantityPerDay { get; set; }

        [DataMember(Name = "standAlone")]
        public bool StandAlone { get; set; }

        [DataMember(Name = "totalPrice")]
        public double TotalPrice { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "plugin")]
        public string Plugin { get; set; }

        [DataMember(Name = "items")]
        public List<string> Items { get; set; }

        [DataMember(Name = "serviceHistory")]
        public List<HistoryItem> ServiceHistory { get; set; }

        [DataMember(Name = "expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [DataMember(Name = "extra")]
        public string Extra { get; set; }

        [DataMember(Name = "restDuration")]
        public double RestDuration { get; set; }

        public double VisiblePrice
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("VisiblePrice");
                OnPropertyChanged("VisiblePriceDecimalPart");
            }
        }

        public string VisiblePriceDecimalPart => 0.0.ToString("#0.0", LanguageContext.Instance.Culture).Substring(1, 1) + ((_price - (int)_price) * 100).ToString("#00");

        public string VisiblePricePart => Math.Floor(_price).ToString("#0");

        private bool _ischecked;
        public bool IsChecked { get { return _ischecked; } set { _ischecked = value; OnPropertyChanged("IsChecked"); } }

        public TranslatableObject ExpiresText => DurationToString((int)RestDuration);

        public TranslatableObject RemainingQuantityText
        {
            get
            {
                if (Quantity != -1 && !IsQuantityPerDay)
                {
                    return new TranslatableObject("Remaining {0} item(s)", new Translator("core"), Quantity);
                }
                if (Quantity == -1 && !IsQuantityPerDay)
                {
                    return new TranslatableObject("Unlimited", new Translator("core"));
                }

                return new TranslatableObject("Remaining {0} item(s)", new Translator("core"),
                    ServiceHistory.Any(sh => sh.Timestamp.Date == DateTime.Now.Date)
                        ? Quantity - ServiceHistory.Count(sh => sh.Timestamp.Date == DateTime.Now.Date)
                        : Quantity);

            }
        }
        public Action Action { get; set; }
    }

    [DataContract]
    public class HistoryItem
    {
        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "item")]
        public string Item { get; set; }
    }


    [DataContract]
    public class ServicePriority : ServerItem
    {
        [DataMember(Name = "service")]
        public Service Service { get; set; }
    }

}
