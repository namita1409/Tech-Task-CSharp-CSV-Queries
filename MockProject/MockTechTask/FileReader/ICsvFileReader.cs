using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTechTask.Model
{
    public interface ICsvFileReader
    {
        public List<Person> FileReader(string file);
    }
}
