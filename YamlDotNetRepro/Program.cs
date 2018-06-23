using System;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace YamlDotNetRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            var yaml = new YamlStream();
            var rootNode = new YamlMappingNode();
            for (int i = 0; i < 5; i++)
            {
                var random = new Random(i).Next(100, 2000).ToString();

                // repro with this line
                rootNode.Add(random, random);

                // NO repro with this line instead of the one above           
                //rootNode.Add("key" + i, "value" + i);
            }
            yaml.Documents.Add(new YamlDocument(rootNode));
            var writer = new StringWriter();
            yaml.Save(writer);
            Console.WriteLine(writer.ToString().Replace("\r\n...\r\n", ""));

            //Output look like this
            // &1944107265 1479: 1479
            // &1075620271 572: 572
            // &1182217550 1565: 1565
            // &2008746139 657: 657
            // &1222564548 1650: 1650
        }
    }
}
