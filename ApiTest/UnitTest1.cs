using System;
using Xunit;

namespace ApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void DeleteTest()
        {
            ICRUDAchievementRepository repository = new MemoryAchievementRepository();
        }
    }
}
