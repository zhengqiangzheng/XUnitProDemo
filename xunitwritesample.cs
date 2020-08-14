using LibGit2Sharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace XUnitTestProject1
{
    public class xunitwritesample
    {
        public bool HasMobile(Person person)
        {
            return !string.IsNullOrWhiteSpace(person.Mobile);
        }
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new Person() { Id = 1, Name = "周三" }, false };
            yield return new object[] { new Person() { Id = 2, Name = "王石", Mobile = "139XXXXXXXX" }, true };
            yield return new object[] { new Person() { Id = 3, Name = "赵坎", Mobile = "" }, false };
        }
        [Theory]
        [InlineData("1")]
        public void test1(string s1)
        {
            Assert.True(string.IsNullOrWhiteSpace(s1));

        }
        [Theory]
        [ClassData(typeof(DataForTest))]
        public void test2(Person person, bool hasMobile)
        {
            Assert.Equal(hasMobile, HasMobile(person));
        }
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void test3(Person person, bool hasMobile)
        {
            Assert.Equal(hasMobile, HasMobile(person));

        }





    }

    public class DataForTest : IEnumerable<object[]>
    {

        private readonly IEnumerable<object[]> _data = new List<object[]>
        {
             new object[] { new Person() { Id=1,Name="周三"},false },
             new object[] { new Person() { Id=2,Name="王石", Mobile = "139XXXXXXXX"},true },
             new object[] { new Person() { Id=3,Name="赵坎", Mobile = ""},false },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
    }
}
