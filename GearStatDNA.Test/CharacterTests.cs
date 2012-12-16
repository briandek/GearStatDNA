using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GearStatDNA.Test
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void GetCharacterBriandekFromSkullcrusherTest()
        {
            WowExplorer explorer = new WowExplorer(Region.US, Locale.en_US);
            Character c1 = explorer.GetCharacterDetails("skullcrusher", "briandek");

            Assert.AreEqual(85, c1.level);
            Assert.AreEqual(1, c1.@class);
        }

        [TestMethod]
        public void GetCharacterFleasFromSkullcrusherTest()
        {
            WowExplorer explorer = new WowExplorer(Region.US, Locale.en_US);
            Character c1 = explorer.GetCharacterDetails("skullcrusher", "fleas");

            Assert.AreEqual(90, c1.level);
            Assert.AreEqual(11, c1.@class);
        }
    }
}
