using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak_infojegyzet_eredeti.Repository.Models
{
    internal interface IModel
    {
        public IModel Serialize(string line);
    }
}
