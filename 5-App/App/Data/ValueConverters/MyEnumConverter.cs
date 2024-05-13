using App.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.ValueConverter
{
    public class MyEnumConverter :ValueConverter<BookType,string>
    {
       public MyEnumConverter():base(v => v.ToString(), v => (BookType)Enum.Parse(typeof(BookType), v))
        {

        }
    }
}
