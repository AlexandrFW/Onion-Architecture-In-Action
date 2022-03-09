using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit;

namespace module_10.Integration.Tests
{
    internal class DisplayNameOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(
               IEnumerable<ITestCollection> testCollections) =>
                     testCollections.OrderBy(collection => collection.DisplayName);
    }
}