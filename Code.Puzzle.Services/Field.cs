using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Puzzle.Services
{
    public class Field
    {
        public string Name { get; set; }
        public List<Field> Children { get; set; } = new List<Field>();
    }
}
