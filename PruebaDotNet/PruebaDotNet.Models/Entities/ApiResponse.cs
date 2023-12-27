using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDotNet.Models.Entities
{
    public class ApiResponse<T>
    {

        public string Status { get; set; }
        public List<Memployees> Data { get; set; }
        public string Message { get; set; }

    }
}
