using PruebaDotNet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDotNet.Models.Interface
{
    public interface Interoperability
    {

        public Task<List<Memployees>> Consume();
    }


}
