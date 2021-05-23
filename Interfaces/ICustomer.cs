using SeventhData.Shopify.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeventhData.Shopify.RestApi.Interfaces
{
    public interface ICustomer
    {
        /// <summary>
        /// Append tags to specific user.
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task<CustomerResponseModel> AppendTags(string customer_id, string tags);
    }
}
