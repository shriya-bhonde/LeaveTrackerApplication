using System;
using Xunit;

namespace LeaveTracker.Tests
{
    public class UnitTest1
    {
        
        [Fact]
        public void Test1()
        {
            bool actual;
            bool expected=true;
            actual=new Program().PathGetter();
            Assert.Equal(actual,expected);


        }
    }
}
