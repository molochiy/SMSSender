namespace SMSSender.Entities.Dtos
{
    public class EvenProviderSentSmsInfo : SentSmsInfo
    {
        public string From { get; set; }

        public string To { get; set; }
    }
}
