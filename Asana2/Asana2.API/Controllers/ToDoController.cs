using Asana2.API.Database;
using Asana2.API.Enterprise;
using Asana2.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asana2.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return new ToDoEC().GetToDos();
        }
    }
}
