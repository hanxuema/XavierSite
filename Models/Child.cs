using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XavierSite.Models
{
    public class Child : Parent
    {
        public override string virtualTest()
        {
            return base.virtualTest();
        }

        public override string abstractTest()
        {
            return "ASDF";
        }

       
    }
}