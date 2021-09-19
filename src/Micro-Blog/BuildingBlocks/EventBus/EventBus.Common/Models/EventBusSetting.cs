namespace EventBus.Common.Models
{
    public record EventBusSetting
    {
        public string HostName { get; set; }
        public EventBusSetting(string hostName)
        {
            HostName = hostName;
        }
    }
}
