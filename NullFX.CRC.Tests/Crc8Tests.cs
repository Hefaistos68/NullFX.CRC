//
// Crc8Tests.cs
//
// Author:
//       steve whitley <steve@nullfx.com>
//
// Copyright (c) 2017 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NullFX.CRC.Tests {
    [TestClass]
    public class Crc8Tests {
        static byte[] TestBuffer = { 0x74, 0x65, 0x73, 0x74, 0x20, 0x62, 0x75, 0x66, 0x66, 0x65, 0x72 };
        static byte[] ExtendedTestBuffer = { 0x00, 0x01, 0x02, 0x74, 0x65, 0x73, 0x74, 0x20, 0x62, 0x75, 0x66, 0x66, 0x65, 0x72, 0x03, 0x04 };
        static byte Crc8Crc = 0xF9;
        static byte Crc8StartLessThanLength = 0x0D;

        [TestMethod]
        public void Crc8Validation ( ) {
            Assert.AreEqual ( Crc8.ComputeChecksum ( TestBuffer ), Crc8Crc );
        }

        [TestMethod]
        public void Crc8SegmentValidation ( ) {
            Assert.AreEqual ( Crc8.ComputeChecksum ( ExtendedTestBuffer, 3, 11 ), Crc8Crc );
        }

        [TestMethod] // tests for bug fix where start < length returning crc = 0
        public void Crc8SegmentValidation_StartLessThanLength ( ) {
            Assert.AreEqual ( Crc8.ComputeChecksum ( ExtendedTestBuffer, 9, 5 ), Crc8StartLessThanLength );
        }
    }
}
