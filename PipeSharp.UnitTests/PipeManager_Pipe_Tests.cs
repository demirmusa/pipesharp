using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace PipeSharp.UnitTests
{
    public class PipeManager_Pipe_Tests
    {
        [Fact]
        public void Should_Multiple_Pipe_Work_Like_Single()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list = list
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem)
                .Pipe(GetNewListWithOutFirstItem);

            list.ShouldBeEmpty();
        }

        [Fact]
        public void Pipe_Test()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list = list
                .Pipe(
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem,
                    GetNewListWithOutFirstItem
                );

            list.ShouldBeEmpty();
        }

        private List<int> GetNewListWithOutFirstItem(List<int> list)
        {
            if (list.Count == 0)
            {
                return new List<int>();
            }

            var first = list.FirstOrDefault();

            return list.Where(x => x != first).ToList();
        }

        [Fact]
        public void Pipe_Object_Converting_Test()
        {
            var intNumber = 5.Pipe(
                 MakeMeString,
                 MakeMeInt,
                 MakeMeString,
                 MakeMeInt,
                 MakeMeString,
                 MakeMeInt,
                 MakeMeString,
                 MakeMeInt,
                 MakeMeString,
                 MakeMeInt
             );
            intNumber.GetType().FullName.ShouldBe(5.GetType().FullName);

            var stringNumber = 5.Pipe(
                MakeMeString,
                MakeMeInt,
                MakeMeString,
                MakeMeInt,
                MakeMeString,
                MakeMeInt,
                MakeMeString,
                MakeMeInt,
                MakeMeString
            );
            stringNumber.GetType().FullName.ShouldBe("boring".GetType().FullName);
        }

        private string MakeMeString(int number)
        {
            return number.ToString();
        }

        private int MakeMeInt(string number)
        {
            return int.Parse(number);
        }
    }
}
