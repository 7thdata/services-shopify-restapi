using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeventhData.Shopify.RestApi.Models
{
    class CustomerModels
    {
    }

    public class CustomersResponseModel
    {
        public IList<CustomerModel> customers { get; set; }
    }

    public class CustomerResponseModel
    {
        public CustomerModel customer { get; set; }
    }

    public class CustomerModel
    {
        public long id { get; set; }
       
        public string email { get; set; }
        public bool accepts_marketing { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int orders_count { get; set; }
        public string state { get; set; }
        public string total_spent { get; set; }
        public int last_order_id { get; set; }
        public object note { get; set; }
        public bool verified_email { get; set; }
        public object multipass_identifier { get; set; }
        public bool tax_exempt { get; set; }
        public string phone { get; set; }
        public string tags { get; set; }
        public string last_order_name { get; set; }
        public string currency { get; set; }
        public List<CustomerAddressModel> addresses { get; set; }
        public DateTime accepts_marketing_updated_at { get; set; }
        public object marketing_opt_in_level { get; set; }
        public object[] tax_exemptions { get; set; }
        public string admin_graphql_api_id { get; set; }
        public CustomerDefaultAddressModel default_address { get; set; }
    }

    public class CustomerUpdateModel
    {

        public long id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool accepts_marketing { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string first_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string last_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string state { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object note { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool verified_email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object multipass_identifier { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool tax_exempt { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string phone { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string tags { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string currency { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<CustomerAddressModel> addresses { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object marketing_opt_in_level { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object[] tax_exemptions { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CustomerDefaultAddressModel default_address { get; set; }
    }

    public class CustomerDefaultAddressModel
    {
        public long id { get; set; }
        public int customer_id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public object company { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string province_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public bool _default { get; set; }
    }

    public class CustomerAddressModel
    {
        public long id { get; set; }
        public int customer_id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public object company { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string province_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public bool _default { get; set; }
    }

}
