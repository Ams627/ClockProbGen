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
            const int columns = 4;
            const int rows = 5;
            try
            {
                Console.WriteLine("<!doctype html>");
                Console.WriteLine("<html lang=\"en\">");
                Console.WriteLine("<head>");
                Console.WriteLine("<title>Nothing</title>");
                Console.WriteLine("<style type='text/css'>");
                Console.WriteLine("body {");
                Console.WriteLine("font-size:20pt;");
                Console.WriteLine("}");
                Console.WriteLine(".clock {");
                Console.WriteLine("height:170px;");
                Console.WriteLine("width:170px;");
                Console.WriteLine("margin:20px;");
                Console.WriteLine("}");
                Console.WriteLine(".clocktable {");
                Console.WriteLine("text-align:center;");
                Console.WriteLine("padding:20px;");
                Console.WriteLine("margin:0;");
                Console.WriteLine("border-collapse:collapse;");
                Console.WriteLine("}");
                Console.WriteLine(".clocktable,.clocktable td {");
                Console.WriteLine("border:solid 1px #dddddd;");
                Console.WriteLine("}");
                Console.WriteLine("</style>");
                Console.WriteLine("<script>");
                Console.WriteLine("</script>");
                Console.WriteLine("</head>");

                var rnd = new Random();
                Console.WriteLine($"<table class=\"clocktable\">");
                for (int i = 0; i < rows * columns; i++)
                {
                    if (i % columns == 0)
                    {
                        Console.WriteLine($"<tr>");
                    }
                    var time = rnd.Next(1440) / 5 * 5;
                    Console.WriteLine($"<td>{time / 60:D2}:{time % 60:D2}<br><img class=\"clock\" src=\"images/clock-blank.svg\"></td>");
                    if ((i + 1) % columns == 0)
                    {
                        Console.WriteLine($"</tr>");
                    }
                }
                Console.WriteLine($"</table>");
                Console.WriteLine($"</body>");
                Console.WriteLine($"</html>");
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
