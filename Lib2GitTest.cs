using LibGit2Sharp;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class Lib2GitTest
    {
        [Fact]
        public void test1()
        {
            var x = Repository.Clone("https://github.com/zhengqiangzheng/git001.git", @"C:\Users\v-qiazhe\test\repo1");
            using (var repo = new Repository(@"C:\Users\v-qiazhe\test\repo1"))
            {
                var branches = repo.Branches;
                foreach (var b in branches)
                {
                    Console.WriteLine(b.FriendlyName);
                }
                var cits = repo.Commits;
                var masterBranch = repo.Branches["master"];
                var latestCommit = masterBranch.Tip;
                var fileHist = repo.Commits.QueryBy(@"branch.txt").Select(x => x.Commit).ToList();

                var blob = latestCommit[@"branch.txt"].Target as Blob;

            }
        }

    }
}
