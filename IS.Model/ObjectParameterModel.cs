using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model
{
    public class ObjectParameterModel
    {
        public object Id { get; set; }
        public string Key { get; set; }
        public int Active { get; set; }
        public int UserType { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
}
