using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samhain.components.Models
{
    public class GlobalParameters
    {
        public float Damage { get; private set; }
        public float Health { get; private  set; }
        public float AtackSpeed { get; private  set; }

        public void SumNewParameters(GlobalParameters parameter)
        {
            Damage += parameter.Damage;
            Health += parameter.Health;
            AtackSpeed += parameter.AtackSpeed;
        }
    }
}
