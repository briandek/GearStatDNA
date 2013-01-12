using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GearStatDNA.Test
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void GetSpiritsOfTheSunItemTest()
        {
            WowExplorer explorer = new WowExplorer();
            Item i1 = explorer.GetItemDetails(86885);

            Assert.AreEqual("Spirits of the Sun", i1.name);
        }

        [TestMethod]
        public void GetHoodOfStilledWindsItemTest()
        {
            WowExplorer explorer = new WowExplorer();
            Item i1 = explorer.GetItemDetails(89922);
            Assert.AreEqual("Hood of Stilled Winds", i1.name);
        }
    }


}
