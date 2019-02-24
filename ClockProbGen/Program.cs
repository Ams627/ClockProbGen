using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockProbGen
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (!args.Any())
            {
                var message = "you must speficiy the number of worksheets to generate.";
                message += "\r\n" + "For example";
                message += "\r\n\r\n    " + "clockprobgen 5\r\n\r\ngenerates 5 worksheets.";
                throw new Exception(message);
            }
            int numberOfWorksheets = Convert.ToInt32(args[0]);
            try
            {
                const int columns = 4;
                const int rows = 5;
                for (int sheet = 0; sheet < numberOfWorksheets; sheet++)
                {
                    var filename = $"clock-worksheet-{sheet + 1:D3}.html";
                    using (var stream = new StreamWriter(filename))
                    {
                        stream.WriteLine("<!doctype html>");
                        stream.WriteLine("<html lang=\"en\">");
                        stream.WriteLine("<head>");
                        stream.WriteLine("<title>Nothing</title>");
                        stream.WriteLine("<style type='text/css'>");
                        stream.WriteLine("body {");
                        stream.WriteLine("font-size:20pt;");
                        stream.WriteLine("}");
                        stream.WriteLine(".clock {");
                        stream.WriteLine("height:170px;");
                        stream.WriteLine("width:170px;");
                        stream.WriteLine("margin:20px;");
                        stream.WriteLine("}");
                        stream.WriteLine(".clocktable {");
                        stream.WriteLine("text-align:center;");
                        stream.WriteLine("padding:20px;");
                        stream.WriteLine("margin:0;");
                        stream.WriteLine("border-collapse:collapse;");
                        stream.WriteLine("}");
                        stream.WriteLine(".clocktable,.clocktable td {");
                        stream.WriteLine("border:solid 1px #dddddd;");
                        stream.WriteLine("}");
                        stream.WriteLine("</style>");
                        stream.WriteLine("<script>");
                        stream.WriteLine("</script>");
                        stream.WriteLine("</head>");

                        var rnd = new Random();
                        stream.WriteLine($"<table class=\"clocktable\">");
                        for (int i = 0; i < rows * columns; i++)
                        {
                            if (i % columns == 0)
                            {
                                stream.WriteLine($"<tr>");
                            }
                            var time = rnd.Next(1440) / 5 * 5;
                            stream.WriteLine($"<td>{time / 60:D2}:{time % 60:D2}<br><img class=\"clock\" src=\"images/clock-blank.svg\"></td>");
                            if ((i + 1) % columns == 0)
                            {
                                stream.WriteLine($"</tr>");
                            }
                        }
                        stream.WriteLine($"</table>");
                        stream.WriteLine($"</body>");
                        stream.WriteLine($"</html>");
                    }
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
