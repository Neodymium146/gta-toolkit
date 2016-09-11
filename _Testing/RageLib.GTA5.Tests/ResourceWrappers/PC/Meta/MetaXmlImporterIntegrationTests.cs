/*
    Copyright(c) 2016 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using NUnit.Framework;
using RageLib.GTA5.ResourceWrappers.PC.Meta;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Descriptions;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Types;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace RageLib.GTA5.Tests.ResourceWrappers.PC.Meta
{
    [TestFixture]
    public class MetaXmlImporterIntegrationTests
    {
        private const string TEST_DATASET = "RageLib.GTA5.Tests.ResourceWrappers.PC.Meta.TestDataset.xml";
        private const string TEST_DATASET_DEFINITIONS = "RageLib.GTA5.Tests.ResourceWrappers.PC.Meta.TestDatasetDefinitions.xml";

        [Test]
        public void Import_Always_CorrectlyImportsXml()
        {
            var def = LoadXmls();

            var importer = new MetaXmlImporter(def);

            var assembly = Assembly.GetExecutingAssembly();

            var expectedDocumentStream = assembly.GetManifestResourceStream(TEST_DATASET);
            var x = importer.Import(expectedDocumentStream);


            var refData = TestDataset.MakeDataset();

            AssertValue(refData, x);
        }

        public MetaInformationXml LoadXmls()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream xmlStream = assembly.GetManifestResourceStream(TEST_DATASET_DEFINITIONS))
            {
                var ser = new XmlSerializer(typeof(MetaInformationXml));
                var xmlInfos = (MetaInformationXml)ser.Deserialize(xmlStream);
                return xmlInfos;
            }
        }

        public void AssertValue(IMetaValue expectedValue, IMetaValue actualValue)
        {
            Assert.AreEqual(expectedValue.GetType(), actualValue.GetType());

            if (expectedValue is MetaArray)
            {
                AssertArray((MetaArray)expectedValue, (MetaArray)actualValue);
            }
            else if (expectedValue is MetaArrayOfBytes)
            {
                AssertArrayOfBytes((MetaArrayOfBytes)expectedValue, (MetaArrayOfBytes)actualValue);
            }
            else if (expectedValue is MetaArrayOfChars)
            {
                AssertArrayOfChars((MetaArrayOfChars)expectedValue, (MetaArrayOfChars)actualValue);
            }
            else if (expectedValue is MetaBoolean)
            {
                AssertBoolean((MetaBoolean)expectedValue, (MetaBoolean)actualValue);
            }
            else if (expectedValue is MetaByte_A)
            {
                AssertByte((MetaByte_A)expectedValue, (MetaByte_A)actualValue);
            }
            else if (expectedValue is MetaByte_B)
            {
                AssertByte((MetaByte_B)expectedValue, (MetaByte_B)actualValue);
            }
            else if (expectedValue is MetaByte_Enum)
            {
                AssertByte((MetaByte_Enum)expectedValue, (MetaByte_Enum)actualValue);
            }
            else if (expectedValue is MetaCharPointer)
            {
                AssertCharPointer((MetaCharPointer)expectedValue, (MetaCharPointer)actualValue);
            }
            else if (expectedValue is MetaDataBlockPointer)
            {
                AssertDataBlockPointer((MetaDataBlockPointer)expectedValue, (MetaDataBlockPointer)actualValue);
            }
            else if (expectedValue is MetaFloat)
            {
                AssertFloat((MetaFloat)expectedValue, (MetaFloat)actualValue);
            }
            else if (expectedValue is MetaFloat4_XYZ)
            {
                AssertFloatVector((MetaFloat4_XYZ)expectedValue, (MetaFloat4_XYZ)actualValue);
            }
            else if (expectedValue is MetaFloat4_XYZW)
            {
                AssertFloatVector((MetaFloat4_XYZW)expectedValue, (MetaFloat4_XYZW)actualValue);
            }
            else if (expectedValue is MetaInt16_A)
            {
                AssertInt16((MetaInt16_A)expectedValue, (MetaInt16_A)actualValue);
            }
            else if (expectedValue is MetaInt16_B)
            {
                AssertInt16((MetaInt16_B)expectedValue, (MetaInt16_B)actualValue);
            }
            else if (expectedValue is MetaInt16_Enum)
            {
                AssertInt16((MetaInt16_Enum)expectedValue, (MetaInt16_Enum)actualValue);
            }
            else if (expectedValue is MetaInt32_A)
            {
                AssertInt32((MetaInt32_A)expectedValue, (MetaInt32_A)actualValue);
            }
            else if (expectedValue is MetaInt32_B)
            {
                AssertInt32((MetaInt32_B)expectedValue, (MetaInt32_B)actualValue);
            }
            else if (expectedValue is MetaInt32_Enum1)
            {
                AssertInt32((MetaInt32_Enum1)expectedValue, (MetaInt32_Enum1)actualValue);
            }
            else if (expectedValue is MetaInt32_Enum2)
            {
                AssertInt32((MetaInt32_Enum2)expectedValue, (MetaInt32_Enum2)actualValue);
            }
            else if (expectedValue is MetaInt32_Enum3)
            {
                AssertInt32((MetaInt32_Enum3)expectedValue, (MetaInt32_Enum3)actualValue);
            }
            else if (expectedValue is MetaInt32_Hash)
            {
                AssertInt32((MetaInt32_Hash)expectedValue, (MetaInt32_Hash)actualValue);
            }
            else if (expectedValue is MetaGeneric)
            {
                AssertPointer((MetaGeneric)expectedValue, (MetaGeneric)actualValue);
            }
            else if (expectedValue is MetaStructure)
            {
                AssertStructure((MetaStructure)expectedValue, (MetaStructure)actualValue);
            }
            else
            {
                Assert.Fail("Illegal values type.");
            }
        }

        public void AssertArray(MetaArray expectedArray, MetaArray actualArray)
        {
            Assert.AreEqual(expectedArray.Entries?.Count, actualArray.Entries?.Count);
            if (expectedArray.Entries != null)
            {
                for (int i = 0; i < expectedArray.Entries.Count; i++)
                {
                    AssertValue(expectedArray.Entries[i], actualArray.Entries[i]);
                }
            }
        }

        public void AssertArrayOfBytes(MetaArrayOfBytes expectedArray, MetaArrayOfBytes actualArray)
        {
            Assert.AreEqual(expectedArray.Value, actualArray.Value);
        }

        public void AssertArrayOfChars(MetaArrayOfChars expectedArray, MetaArrayOfChars actualArray)
        {
            Assert.AreEqual(expectedArray.Value, actualArray.Value);
        }

        public void AssertBoolean(MetaBoolean expectedBoolean, MetaBoolean actualBoolean)
        {
            Assert.AreEqual(expectedBoolean.Value, actualBoolean.Value);
        }

        public void AssertByte(MetaByte_A expectedByte, MetaByte_A actualByte)
        {
            Assert.AreEqual(expectedByte.Value, actualByte.Value);
        }

        public void AssertByte(MetaByte_B expectedByte, MetaByte_B actualByte)
        {
            Assert.AreEqual(expectedByte.Value, actualByte.Value);
        }

        public void AssertByte(MetaByte_Enum expectedByte, MetaByte_Enum actualByte)
        {
            Assert.AreEqual(expectedByte.Value, actualByte.Value);
        }

        public void AssertCharPointer(MetaCharPointer expectedCharPointer, MetaCharPointer actualCharPointer)
        {
            Assert.AreEqual(expectedCharPointer.Value, actualCharPointer.Value);
        }

        public void AssertDataBlockPointer(MetaDataBlockPointer expectedDataBlockPointer, MetaDataBlockPointer actualDataBlockPointer)
        {
            Assert.AreEqual(expectedDataBlockPointer.Data, actualDataBlockPointer.Data);
        }

        public void AssertFloat(MetaFloat expectedFloat, MetaFloat actualFloat)
        {
            Assert.AreEqual(expectedFloat.Value, actualFloat.Value);
        }

        public void AssertFloatVector(MetaFloat4_XYZ expectedFloat, MetaFloat4_XYZ actualFloat)
        {
            Assert.AreEqual(expectedFloat.X, actualFloat.X);
            Assert.AreEqual(expectedFloat.Y, actualFloat.Y);
            Assert.AreEqual(expectedFloat.Z, actualFloat.Z);
        }

        public void AssertFloatVector(MetaFloat4_XYZW expectedFloat, MetaFloat4_XYZW actualFloat)
        {
            Assert.AreEqual(expectedFloat.X, actualFloat.X);
            Assert.AreEqual(expectedFloat.Y, actualFloat.Y);
            Assert.AreEqual(expectedFloat.Z, actualFloat.Z);
            Assert.AreEqual(expectedFloat.W, actualFloat.W);
        }

        public void AssertInt16(MetaInt16_A expectedInt, MetaInt16_A actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt16(MetaInt16_B expectedInt, MetaInt16_B actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt16(MetaInt16_Enum expectedInt, MetaInt16_Enum actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt32(MetaInt32_A expectedInt, MetaInt32_A actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt32(MetaInt32_B expectedInt, MetaInt32_B actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt32(MetaInt32_Enum1 expectedInt, MetaInt32_Enum1 actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt32(MetaInt32_Enum2 expectedInt, MetaInt32_Enum2 actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt32(MetaInt32_Enum3 expectedInt, MetaInt32_Enum3 actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertInt32(MetaInt32_Hash expectedInt, MetaInt32_Hash actualInt)
        {
            Assert.AreEqual(expectedInt.Value, actualInt.Value);
        }

        public void AssertPointer(MetaGeneric expectedPointer, MetaGeneric actualPointer)
        {
            if (expectedPointer.Value == null)
            {
                Assert.IsNull(actualPointer.Value);
            }            
            else
            {
                Assert.IsNotNull(actualPointer.Value);
                AssertValue(expectedPointer.Value, actualPointer.Value);
            }
        }

        public void AssertStructure(MetaStructure expectedStructure, MetaStructure actualStructure)
        {
            var expectedValues = expectedStructure.Values;
            var actualValues = actualStructure.Values;

            Assert.AreEqual(expectedValues.Count, actualValues.Count);
            foreach (var key in expectedValues.Keys)
            {
                AssertValue(expectedValues[key], actualValues[key]);
            }
        }


    }
}