using Asana2.API.Database;
using Asana2.Library.Models;

namespace Asana2.API.Enterprise
{
    public class ToDoEC
    {
        public IEnumerable<ToDo> GetToDos()
        {
            return new FakeDatabase().ToDos;
        }
    }
}
