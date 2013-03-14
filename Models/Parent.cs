using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XavierSite.Models
{
    public abstract  class Parent
    {
        public virtual string virtualTest()
        {
            return "A";
        }

        public abstract string abstractTest();

    }
}