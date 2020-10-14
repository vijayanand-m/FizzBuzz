using FizzBuzz.Interface;
using FizzBuzz.Services;

namespace FizzBuzz.Factory
{
    public class FizzBuzzRuleFactory : RuleServiceFactory
    {
        public override IRulesService RulesCheck() => new FizzBuzzRule();
    }
}
