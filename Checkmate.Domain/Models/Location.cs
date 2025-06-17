namespace Checkmate.Domain.Models
{
	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }

		// Navigation properties
		public List<Tournament> Tournaments { get; set; } = [];
	}
}
