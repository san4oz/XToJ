using System;
using System.Collections.Generic;
using System.Linq;
using XtoJ.Core.DataAccessors;

namespace XtoJ.Core.DataAccessors.Factories
{
    public static class InputRetreiverFactory
    {
        private static Dictionary<Func<string, bool>, IInputRetreiver> inputRetreivers = new Dictionary<Func<string, bool>, IInputRetreiver>();

        public static void RegisterInputRetreiver(Func<string, bool> evaluator, IInputRetreiver retreiver)
        {
            inputRetreivers.Add(evaluator, retreiver);
        }

        public static IInputRetreiver ForFileName(string filename)
        {
            return inputRetreivers.First(x => x.Key(filename)).Value;
        }
    }
}
