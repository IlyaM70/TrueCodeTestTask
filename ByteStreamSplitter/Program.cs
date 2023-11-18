using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace ByteStreamSplitter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get appsettings
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            string? byteMarkerString = config["ByteMarker"];
            string? bytesString = config["BytesString"]; 

            if(string.IsNullOrEmpty(byteMarkerString))
            {
                throw new Exception("Byte marker not set in the appsetting.json file");
            }
            if (string.IsNullOrEmpty(bytesString))
            {
                throw new Exception("Bytes string not set in the appsetting.json file");
            }


            Console.WriteLine("Byte Stream Splitter");
            Console.WriteLine();
            Console.WriteLine("Bytes stream:");
            Console.WriteLine(bytesString);
            Console.WriteLine("Split marker:");
            Console.WriteLine(byteMarkerString);
            Console.WriteLine();

            //Get bytes for byte stream
            string source = bytesString;
            byte[] bytes = new byte[bytesString.Replace(" ","").Length];
            try
            {
                bytes = source
                  .Split(' ')
                  .Select(x => Convert.ToByte(x, 16))
                  .ToArray();
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                    throw new Exception("Bytes string in the appsetting.json file is not right format. Right format - \"HEX HEX HEX ...\"");
            }


            //Simulate byte stream
            MemoryStream byteStream = new MemoryStream(bytes);

            //split
            byte[] data = ByteStreamConverter.ToArray(byteStream);
            byte splitMarker = 0;

            try
            {
                splitMarker = Convert.ToByte(byteMarkerString, 16);
            }
            catch(Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                    throw new Exception("Byte marker in the appsetting.json must be hex value");
            }

            
            byte[][] result = ByteArraySplitter.Split(data, splitMarker);

            //Show in console
            string report = string.Join(Environment.NewLine,
                    result.Select(line => string.Join(" ", line.Select(x => x.ToString("X2")))));
            Console.WriteLine(report);

        }

    }

}