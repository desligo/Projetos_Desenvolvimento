using Microsoft.AspNetCore.Mvc;



namespace NetCore6_0WebApi.Services
{

    [ApiController]
    [Route("[controller]")]
    public class PizzaControler : ControllerBase
    {
        public PizzaControler()
        {

        }


        [HttpGet]
        public ActionResult<List<NetCore6_0WebApi.Models.Pizza>> GetAll() => NetCore6_0WebApi.Services.PizzaService.GetAllPizzas();

        [HttpGet("{id}")]
        public ActionResult<NetCore6_0WebApi.Models.Pizza> Get(int id)
        {

            var pizza = NetCore6_0WebApi.Services.PizzaService.GetPizza(id);

            if (pizza is null)
            {
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public IActionResult Create(NetCore6_0WebApi.Models.Pizza pizza)
        {
            try
            {
                NetCore6_0WebApi.Services.PizzaService.AddPizza(pizza);

                return CreatedAtAction(nameof(Create), new {id = pizza.Id}, pizza);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, NetCore6_0WebApi.Models.Pizza pizza)
        {
            if(id != pizza.Id)
                return BadRequest();

            var oldPizza = NetCore6_0WebApi.Services.PizzaService.GetPizza(id);
           
            if (oldPizza is null)
            {
                return NotFound();
            }
          
                NetCore6_0WebApi.Services.PizzaService.Update(pizza);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = NetCore6_0WebApi.Services.PizzaService.GetPizza(id);
            
            if (pizza is null)
            {
                return NotFound();
            }
             NetCore6_0WebApi.Services.PizzaService.DeletePizza(id);
         
            return NoContent();
        }


    }

}