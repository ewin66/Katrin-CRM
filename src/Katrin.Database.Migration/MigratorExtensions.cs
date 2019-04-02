using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Builders.Create.Table;

namespace Katrin.Database.Migrations
{
    internal static class MigratorExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax AsMaxString(this ICreateTableColumnAsTypeSyntax createTableColumnAsTypeSyntax)
        {
            //return createTableColumnAsTypeSyntax.AsCustom("nvarchar(max)");
            return createTableColumnAsTypeSyntax.AsString(int.MaxValue);
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax AsMoney(this ICreateTableColumnAsTypeSyntax createTableColumnAsTypeSyntax)
        {
            return createTableColumnAsTypeSyntax.AsCustom("money");
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax AsTINYINT(this ICreateTableColumnAsTypeSyntax createTableColumnAsTypeSyntax)
        {
            return createTableColumnAsTypeSyntax.AsCustom("tinyint");
        }
    }
}
