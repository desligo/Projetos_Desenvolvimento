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

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult Update(int id, NetCore6_0WebApi.Models.Pizza pizza)
        {
            var oldPizza = NetCore6_0WebApi.Services.PizzaService.GetPizza(id);
            if (oldPizza is null)
            {
                return NotFound();
            }
            try
            {
                NetCore6_0WebApi.Services.PizzaService.Update(pizza);

            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pizza = NetCore6_0WebApi.Services.PizzaService.GetPizza(id);
            if (pizza is null)
            {
                return NotFound();
            }
            try
            {
                NetCore6_0WebApi.Services.PizzaService.DeletePizza(id);
            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok();
        }


    }

}