using App.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.ValuesConverters
{
    public class MyEnumConvrter : ValueConverter<BookType, string>
    {
        //public MyEnumConvrter(Expression<Func<BookType, string>> convertToProviderExpression, Expression<Func<string, BookType>> convertFromProviderExpression, ConverterMappingHints? mappingHints = null) : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        //{


        //}

        public MyEnumConvrter():base(v => v.ToString(), v => (BookType)Enum.Parse(typeof(BookType), v))
        {
            
        }




    }
}
