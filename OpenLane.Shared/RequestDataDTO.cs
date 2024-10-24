namespace Openlane.Shared
{
    public class RequestDataDTO
    {
        public Guid MessageId { get; set; }
        public string Type { get; set; }
        public DateTime TimestampUtc { get; set; }
        public string Resource { get; set; }
        public ResourceDataDTO ResourceData { get; set; }
    }

}
