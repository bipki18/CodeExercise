using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingPractise
{
    public interface IProduct
    {
        string PrintText(string name);

    }

    public class Product : IProduct, IDisposable
    {
        public string PrintText(string name )
        {
            return $"Hello {name}";
        }

        public void Dispose()
        {
            GC.Collect();

        }

      


    }



   



}
