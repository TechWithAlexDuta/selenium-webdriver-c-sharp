using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Common;

namespace Tests.Tests
{
    internal class WebFormTests : TestBase
    {
        [Test]
        public void WriteToTextAreaTest()
        {
            var text = Guid.NewGuid().ToString();
            var expectedMessage = "Received!";

            var message =
                 WebForm
                 .WriteTextToTextArea(text)
                 .SubmitForm()
                 .GetMessage();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}
