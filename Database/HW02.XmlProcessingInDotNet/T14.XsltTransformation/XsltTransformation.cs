using System;
using System.Xml.Xsl;
using T00.Common;

namespace T14.XsltTransformation
{
    /// <summary>
    /// 14. Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
    /// </summary>
    public class XsltTransformation
    {
        private const string SaveFilePath = @"../../Catalogue.html";

        private static void Main()
        {
            var xsl = new XslCompiledTransform();
            xsl.Load(Constants.FilePathForXslt);
            xsl.Transform(Constants.FilePathForCatalogue, SaveFilePath);
            Console.WriteLine("Catalogue.xml created in project folder.");
        }
    }
}
