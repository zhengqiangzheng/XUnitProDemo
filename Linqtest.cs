using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        [Fact]
        public void SelecetTeset()
        {
            var l1 = new List<string> { "zs", "ls", "ww" };
            var res = l1.Select((item, i) => $"{i}.{item}").ToList();

        }
        [Fact]
        public void QueryCharacter()
        {
            string aString = "ABCDE99F-J74-12-89A";
            IEnumerable<char> stringQuery = aString.Where(x => Char.IsDigit(x));
            IEnumerable<char> stringQuery2 = aString.TakeWhile(x => x != '-');
        }
        [Fact]
        public void LinqWithRegex()
        {
            IEnumerable<System.IO.FileInfo> fileList = GetFiles(@"C:\Program Files (x86)\Microsoft Visual Studio\2019");
            Regex searchTerm = new Regex(@"Visual (Basic|C#|C\+\+|Studio)");

            var queryMatchFiles = from file in fileList
                                  where file.Extension == ".html"
                                  let fileText = File.ReadAllText(file.FullName)
                                  let matchs = searchTerm.Matches(fileText)
                                  where matchs.Count > 0
                                  select new
                                  {
                                      name = file.FullName,
                                      matchValues = from match in matchs
                                                    select match.Value
                                  };
            foreach (var item in queryMatchFiles)
            {
                Console.WriteLine(item);
            }

        }
        [Fact]
        public void OrderTest()
        {
            var source = File.ReadAllLines(@"data/scores.csv");
            var source2 = File.ReadAllLines(@"data/spreadsheet1.csv");
            var ordersource = from line in source
                              orderby line.Split(',')[1]
                              select line;

            var reordersource2 = source2.OrderBy(x => x.Split(',')[2]).Select(y => $"{y.Split(',')[2]},{y.Split(',')[1]} {y.Split(',')[0]}");
            IEnumerable<string> query =
                                       from line in source2
                                       let x = line.Split(',')
                                       orderby x[2]
                                       select x[2] + ", " + (x[1] + " " + x[0]);


        }
        [Fact]
        public void mutiplesourcelinqtest()
        {
            var scores = File.ReadAllLines(@"data/scores.csv");
            var names = File.ReadAllLines(@"data/names.csv");
            var res = from score in scores
                      let num = score.Split(',')
                      from name in names
                      let correspnum = name.Split(',')
                      where Convert.ToInt32(num[0]) == Convert.ToInt32(correspnum[2])
                      select new Student
                      {
                          FirstName = name.Split(',')[0],
                          LastName = name.Split(',')[1],
                          ID = Convert.ToInt32(name.Split(',').LastOrDefault()),
                          ExamScores = (from x in score.Split(',').Skip(1)
                                        select Convert.ToInt32(x)
                          ).ToList()
                      };
        }

        [Fact]
        public void GroupTest()
        {
            var names1 = File.ReadAllLines(@"data/names1.txt");
            var names2 = File.ReadAllLines(@"data/names2.txt");
            var mergequery = names1.Union(names2);
            var groupres1 = mergequery.GroupBy(name => name.Split(',')[0][0]
            , (key, g) => new { GroupId = key, res = g.ToList() }
            ).OrderBy(x => x.GroupId).ToList();

            var groupres2 = from x in mergequery
                            group x by x.Split(',')[0][0] into g
                            orderby g.Key
                            select g;

            Dictionary<int, string> dic = new Dictionary<int, string>() { [1]="1"};


        }
        private IEnumerable<FileInfo> GetFiles(string v)
        {
            if (!Directory.Exists(v))
            {
                throw new System.IO.DirectoryNotFoundException();
            }
            string[] fileNames = null;
            List<FileInfo> files = new List<FileInfo>();
            fileNames = Directory.GetFiles(v, "*.*", SearchOption.AllDirectories);
            foreach (var item in fileNames)
            {
                files.Add(new FileInfo(item));

            }
            return files;


        }
    }
}
