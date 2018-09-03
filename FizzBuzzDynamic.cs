using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzGame
{
    class FizzBuzzDynamic : IFizzBuzzGame
    {
        private readonly IEnumerable<int> _sequence;
        private readonly (int Number, string Word)[] _triggers;
        public FizzBuzzDynamic(IEnumerable<int> sequence, (int,string)[] triggers)
        {
            _sequence = sequence;
            _triggers = triggers;
        }

        public IEnumerable<string> GetFizzBuzz()
        {
            foreach (var i in _sequence)
            {
                var result = _triggers.Where(trigger => i % trigger.Number == 0).Aggregate("", (current, trigger) => current + trigger.Word);

                if (string.IsNullOrEmpty(result)) result = i.ToString();
                yield return result;
            }
        }
    }
}