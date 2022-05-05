
namespace MinimalApis.Entities
{
    public class OrderTopping
    {
        public int Id { get; set; }
        // foreign key
        public int WaffleId { get; set; }
        //public virtual Waffle Waffle { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
