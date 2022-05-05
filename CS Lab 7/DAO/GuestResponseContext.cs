using CS_Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CS_Lab_7.DAO
{
    public class GuestResponseContext: DbContext
    {
        public DbSet<GuestResponse> GuestResponses { get; set; }
       
    }
}