using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class Linqtest
    {
        [Fact]
        public void EnumAppendTest()
        {
            var l1 = new List<string> { "123" };
            var l2 = Enumerable.Append(l1, "11111");
            var l3 = Enumerable.Prepend(l1, "2222");
        }
    }
}
