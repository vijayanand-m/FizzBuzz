using FizzBuzz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Factory
{
    public abstract class RuleServiceFactory
    {
      public  abstract IRulesService RulesCheck();
    }
}
