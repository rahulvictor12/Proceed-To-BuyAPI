using ProceedToBuyMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuyMicroservice.Services
{
    public interface IProvider
    {
        public Vendor GetVendors(int productId);
    }
}
