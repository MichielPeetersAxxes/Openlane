namespace Openlane.Shared
{
    public class BikeDTO
    {
        public string Id { get; set; }
        public string BikeContainerId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public bool IncludesAllTaxes { get; set; }
        public string Version { get; set; }
        public string Category { get; set; }
        public string? AdditionalInformation { get; set; }
        public string RegistrationNumber { get; set; }
        public string FirstRegistrationDate { get; set; }
        public List<string> Equipments { get; set; }
        public string MainImageUrl { get; set; }
        public List<DocumentDTO> Documents { get; set; }
        public List<TaxesDTO> Taxes { get; set; }
        public string? Comments { get; set; }
    }
}
