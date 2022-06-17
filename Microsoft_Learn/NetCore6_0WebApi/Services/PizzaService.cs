

namespace NetCore6_0WebApi.Services;

public static class PizzaService{
        static List<NetCore6_0WebApi.Models.Pizza> Pizzas {get;}
        static int NextId  = 3;

        static PizzaService(){
            Pizzas = new List<Models.Pizza> {
                new NetCore6_0WebApi.Models.Pizza {Id = 1, Name = "Italiana", isGlutenFree =  true},
                new NetCore6_0WebApi.Models.Pizza {Id = 2, Name = "Indiana",  isGlutenFree = false}
            };
        }

        public static List<NetCore6_0WebApi.Models.Pizza> GetAllPizzas () => Pizzas;

        public static NetCore6_0WebApi.Models.Pizza? GetPizza(int id) => Pizzas.FirstOrDefault(p=>p.Id == id);

        public static void AddPizza(NetCore6_0WebApi.Models.Pizza pizza)
        {
            pizza.Id = NextId++ ;
            Pizzas.Add(pizza);

        }

        public static void DeletePizza(int id)
        {
            var pizza = GetPizza(id);
            if (pizza is null)
            {
                return;
            }
            Pizzas.Remove(pizza);
        }


        public static void Update(NetCore6_0WebApi.Models.Pizza pizza)
        {
            var index = Pizzas.FindIndex(p=>p.Id == pizza.Id);
            if (index == -1)
            {
                return;
            }
            Pizzas[index] = pizza;
        }


}