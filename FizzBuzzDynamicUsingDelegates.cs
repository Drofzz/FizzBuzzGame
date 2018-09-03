using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzGame
{
    class FizzBuzzDynamicUsingDelegates : IFizzBuzzGame
    {
        private readonly IEnumerable<int> _sequence;
        private readonly Func<int, string>[] _passes;

        public FizzBuzzDynamicUsingDelegates(IEnumerable<int> sequence, params Func<int, string>[] passes)
        {
            _sequence = sequence;
            _passes = passes;
        }

        public IEnumerable<(int,string)> GetFizzBuzz()
        {
            foreach (var i in _sequence)
            {
                var result = _passes.Aggregate("", (current, pass) => current + pass.Invoke(i));

                if (string.IsNullOrEmpty(result)) result = i.ToString();
                yield return (i,result);
            }
        }
    }
}