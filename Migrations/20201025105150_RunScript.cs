using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;

namespace Mtd.OrderMaker.Dbs.Migrations
{
    public partial class RunScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = typeof(RunScript).Namespace + "._InitDatabase.sql";
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            string sqlResult = reader.ReadToEnd();
            migrationBuilder.Sql(sqlResult);

        }

    }
}
