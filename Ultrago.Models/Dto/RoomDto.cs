namespace Ultrago.Models.Dto
{
    public class RoomDto
    {
     
        public string  Hotel  { get; set; }
        public string? TypeRoom  { get; set; }
        public decimal?  CostBase  { get; set; }
        public decimal? Taxes  { get; set; }
        public bool Enabled  { get; set; } = false;
        public string? LocationRoom { get; set; }
    }
}
