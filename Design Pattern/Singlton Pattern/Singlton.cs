using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.Singlton_Pattern
{
    public sealed class Singlton
    {
        public Singlton()
        {

        }
        private static readonly object padlock = new object();
        private static Singlton instance = null;

        public static Singlton Instance 
        { 
            
            get {

                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new Singlton();

                    }
                    return instance;
                }
            }
        }
    }
}
