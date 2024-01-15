namespace ItemBlazor.Models
{
    public class TimeSeries
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime Datetime { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
    }
}
