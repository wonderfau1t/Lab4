using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Models;
using Newtonsoft.Json;

namespace Lab4.jsonParse
{
    public static class FileConnect
    {

        public static InvoicesTypes invoicesTypes = LoadInvoicesTypes("C:\\Users\\dmitrij\\source\\repos\\Lab4\\Lab4\\jsonParse\\invoicesTypes.json");

        public static InvoicesTypes LoadInvoicesTypes(string filePath)
        {
            string jsonContent = System.IO.File.ReadAllText(filePath);

            InvoicesTypes invoicesTypes = JsonConvert.DeserializeObject<InvoicesTypes>(jsonContent);

            return invoicesTypes;
        }

    }
}
