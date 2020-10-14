using FizzBuzz.Interface;
using FizzBuzz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Factory
{
    public class FizzRuleFactory : RuleServiceFactory
    {
        public override IRulesService RulesCheck() => new  FizzRule();
       
    }
}
