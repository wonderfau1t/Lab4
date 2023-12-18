using System;
using System.Collections.Generic;
using Lab4.Models;
using Newtonsoft.Json;

namespace Lab4.jsonParse
{
    public class FileConnect
    {
        private static readonly Lazy<FileConnect> _instance = new Lazy<FileConnect>(CreateInstance);

        private FileConnect()
        {
            
        }

        public static FileConnect Instance
        {
            get { return _instance.Value; }
        }
        
        private static FileConnect CreateInstance()
        {
            return new FileConnect();
        }

        public static List<InvoiceType> invoicesTypes = LoadInvoicesTypes();

        public static List<InvoiceType> LoadInvoicesTypes()
        {
            string jsonContent = System.IO.File.ReadAllText("C:\\Users\\itige\\source\\repos\\wonderfau1t\\Lab4\\Lab4\\jsonParse\\invoicesTypes.json");

            List<InvoiceType>invoicesTypes = JsonConvert.DeserializeObject<List<InvoiceType>>(jsonContent);

            return invoicesTypes;
        }

    }
}
