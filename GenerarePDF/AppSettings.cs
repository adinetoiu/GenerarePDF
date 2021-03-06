﻿using PDFTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarePDF
{
    public class AppSettings
    {
        public List<TableSettings> Tables { get; set; }
        public List<Driver> Drivers { get; set; }
        public Driver LastDriver { get; set; }
        public string LogoBase64 { get; set; }
        public string CompanyDetails { get; set; }
        public string SoftwareProvider { get; set; }

        public List<string> Units { get; set; }

        public AppSettings()
        {
            Tables = new List<TableSettings>();
            Drivers = new List<Driver>();
            Units = new List<string>();
        }
    }

    public class TableSettings
    {
        public string Header { get; set; }
        public bool SeScade { get; set; }
        public List<ColumnSettings> Columns { get; set; }

        public TableSettings()
        {
            Columns = new List<ColumnSettings>();
        }
    }

    public class ColumnSettings
    {
        public string Name { get; set; }
        public float Percentage { get; set; }

        public ColumnSettings(string name, float percentage)
        {
            Name = name;
            Percentage = percentage;
        }
    }

    public class Driver
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Driver(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public Driver()
        {

        }
    }

    public class ExportData
    {
        public List<ExportTable> TableList { get; set; }
        public ExportData()
        {
            TableList = new List<ExportTable>();
        }
        public class ExportTable
        {
            public List<List<string>> Rows { get; set; }
        }

    }
}
