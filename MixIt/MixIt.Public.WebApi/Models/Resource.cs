using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  MixIt.Public.WebApi.Models
{
    public class Resource
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public static List<Resource> GetDummyList()
        {
            List<Resource> result = new List<Resource>();

            for (int i = 0; i < 15; i++)
            {
                result.Add(new Resource() { Id = i, Name = "Resource_" + i, Description = "Description Of " + i });
            }

            return result;
        }
    }
}