using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollSystemServices;

namespace TollSystem.Tests
{
    class UIHelperTests
    {
        [Test]
        public void ChangeColorBrightness_ReturnValidResult()
        {
            var result = UIHelper.ChangeColorBrightness(Color.Red, 20);

            Assert.That(result.A == 255 && result.B == 236 && 
                        result.G == 236 && result.R == 255);
        }
    }
}
