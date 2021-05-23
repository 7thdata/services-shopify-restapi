using SeventhData.Shopify.RestApi.Interfaces;
using SeventhData.Shopify.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeventhData.Shopify.RestApi.Services
{
    // 
    public class Customer : ICustomer
    {

        // Read Shopify doc: https://shopify.dev/docs/admin-api/rest/reference/customers/customer
        //
        // Here are API method that we support in this class.
        // 1. GET /admin/api/2021-04/customers.json
        // 2. GET /admin/api/2021-04/customers/search.json?query=Bob country:United States
        // 3. GET /admin/api/2021-04/customers/{customer_id}.json
        // 4. POST /admin/api/2021-04/customers.json
        // 5. PUT /admin/api/2021-04/customers/{customer_id}.json
        // 6. POST /admin/api/2021-04/customers/{customer_id}/account_activation_url.json
        // 7. POST /admin/api/2021-04/customers/{customer_id}/send_invite.json
        // 8. DELETE /admin/api/2021-04/customers/{customer_id}.json
        // 9. GET /admin/api/2021-04/customers/count.json
        // 10.GET /admin/api/2021-04/customers/{customer_id}/orders.json

        private static readonly HttpClient _client = new HttpClient();
        private string _baseUrl = "";

        public Customer(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Calling: 1. GET /admin/api/2021-04/customers.json
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ids">Restrict results to customers specified by a comma-separated list of IDs.</param>
        /// <param name="since_id">Restrict results to those after the specified ID.</param>
        /// <param name="created_at_min">Show customers created after a specified date.</param>
        /// <param name="created_at_max">Show customers created before a specified date.</param>
        /// <param name="updated_at_min">Show customers last updated after a specified date.</param>
        /// <param name="updated_at_max">Show customers last updated before a specified date.</param>
        /// <param name="limit">Show customers last updated after a specified date.</param>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns></returns>
        public CustomersResponseModel GetCustomers(
            string ids,
            string since_id,
            DateTime created_at_min,
            DateTime created_at_max,
            DateTime updated_at_min,
            DateTime updated_at_max,
            int limit,
            string fields
            )
        {

            var customers = new CustomersResponseModel();

            return customers;
        }

        /// <summary>
        /// Calling: 2. GET /admin/api/2021-04/customers/search.json?query=Bob country:United States
        /// </summary>
        /// <param name="order">Set the field and direction by which to order results.(default: last_order_date DESC)</param>
        /// <param name="query">Text to search for in the shop's customer data. Note: Supported queries: accepts_marketing, activation_date, address1, address2, city, company, country, customer_date, customer_first_name, customer_id, customer_last_name, customer_tag,  email, email_marketing_state, first_name, first_order_date, id, last_abandoned_order_date, last_name, multipass_identifier, orders_count, order_date, phone, province, shop_id, state, tag, total_spent, updated_at, verified_email, product_subscriber_status. All other queries returns all customers.</param>
        /// <param name="limit">The maximum number of results to show.(default: 50, maximum: 250)</param>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns></returns>
        public async Task<CustomersResponseModel> SearchCustomers(
            string query,
            string fields,
            int limit = 50,
            string order = "last_order_date DESC")
        {
            var customers = new CustomersResponseModel();

            // Call API
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var apiRespose = await _client.GetAsync(_baseUrl + "customers/search.json?order=" + order + "&query=" + query + "&limit=" + limit + "&fields=" + fields);

            if (apiRespose.IsSuccessStatusCode)
            {
                customers = await JsonSerializer.DeserializeAsync<CustomersResponseModel>(await apiRespose.Content.ReadAsStreamAsync());
            }

            return customers;
        }

        public CustomerResponseModel UpdateCustomer()
        {

            var customer = new CustomerResponseModel();
            return customer;
        }

        /// <summary>
        /// Append tags to specific user.
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<CustomerResponseModel> AppendTags(string customer_id, string tags)
        {
            var customer = new CustomerResponseModel();

            // Get cutomer

            var originalTags = new List<string>(customer.customer.tags.Split(","));
            var newTags = new List<string>(tags.Split(","));

            // Append tags (if new)
            foreach (var tag in newTags)
            {
                // new?
                var duplicateTag = (from d in originalTags where d == tag select d).FirstOrDefault();

                if (duplicateTag == null)
                {
                    // Then new, so append
                    originalTags.Add(tag);
                }
            }

            // Call API
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var updateRequestModel = new CustomerUpdateModel()
            {
                id = Int64.Parse(customer_id),
                tags = string.Join(",",originalTags)
            };

            var apiRespose = await _client.PutAsync(_baseUrl + "customers/" + customer_id + ".json", new StringContent(JsonSerializer.Serialize(updateRequestModel)));

            if (apiRespose.IsSuccessStatusCode)
            {
                customer = await JsonSerializer.DeserializeAsync<CustomerResponseModel>(await apiRespose.Content.ReadAsStreamAsync());
            }
          
            return customer;
        }

        public CustomerResponseModel RemoveTags(string tags)
        {
            var customer = new CustomerResponseModel();
            return customer;
        }

    }
}
