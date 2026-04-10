using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asana2.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? CompletePercent { get; set; }
        public List<ToDo>? ToDos { get; set; }
        public int? Priority { get; set; }


        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description} - {CompletePercent}% Completed";
        }
    }
}
