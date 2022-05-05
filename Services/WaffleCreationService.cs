using MinimalApis.Entities;

namespace MinimalApis.Services
{
    public class WaffleCreationService
    {
        private readonly WaffleIngredientService _waffleIngredientService;
        private readonly Order _defaultOrder;

        public WaffleCreationService(WaffleIngredientService waffleIngredientService)
        {
            _waffleIngredientService =

                waffleIngredientService
                ?? throw new ArgumentNullException(nameof(waffleIngredientService));

            _defaultOrder = new Order
            {
                Id = 0,
                UserId = 0
            };
        }

        public async Task<(List<OrderTopping> toppings, List<string> bases)> StartWaffleCreation()
        {
            var ingredientDtos = await _waffleIngredientService.GetIngredients();
            var toppings = new List<OrderTopping>();

            toppings = ingredientDtos
                .Select(i => new OrderTopping { Id = i.Id, Name = i.Name}).ToList();

            List<string> bases = new() { "round", "square", "heart" };
            //named tuples
            return (toppings, bases);
        }

        public Task<Order> CreateWaffle(Order order)
        {

            if (order == null)
            {
                order = _defaultOrder;
            }

            // do some waffling
            throw new NotImplementedException();
        }

    }
}
