using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace economia.models
{
    class Dados
    {
        private static string csv = null;
        public static string Csv
        {
            get{
                if(csv == null)
                {
                    var s = Path.DirectorySeparatorChar;
                    return File.ReadAllText("res" + s + "planilhaMercado.csv");
                }
                return csv;
            }
        }

        
        
    }
}
