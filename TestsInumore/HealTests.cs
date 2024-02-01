using Inumore.items;

namespace TestsInumore
{
    public class HealTests
    {
        [Fact]
        public void CreateHealItem()
        {
            HealItem healItem = new HealItem("Corn", 25, 3);
            ItemFactory factory = new ItemFactory();
            Assert.NotNull(healItem);
            Assert.Equal(healItem.ToString(), factory.generateItem("heal", "Corn", 25, 3).ToString());
        }
    }
}