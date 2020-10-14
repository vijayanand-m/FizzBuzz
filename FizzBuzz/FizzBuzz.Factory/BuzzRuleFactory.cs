using FizzBuzz.Interface;
using FizzBuzz.Services;

namespace FizzBuzz.Factory
{
    public class BuzzRuleFactory : RuleServiceFactory
    {
        public override IRulesService RulesCheck() => new BuzzRule();
    }
}
