using ISCommon.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace KSHYWeb.Extensions
{
    public static class IISExtensions
    {
        public static async Task<CreateDomainModel> CreateWebsite(string userName, string password, string token, string apiLink, string domain, string physical_path, string protocol = "http", string ip = "*", int port = 80)
        {
            var hanler = new HttpClientHandler();
            hanler.Credentials = new NetworkCredential(userName, password);
            hanler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var apiClient = new HttpClient(hanler, true);
            apiClient.DefaultRequestHeaders.Add("Access-Token", "Bearer " + token);
            apiClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
            domain = domain.Replace("http://", string.Empty);
            domain = domain.Replace("https://", string.Empty);
            domain = domain.Replace("www.", string.Empty);

            var newSite = new
            {
                name = domain,
                physical_path = physical_path,
                bindings = new object[] {
                    new {
                      port = port,
                      protocol = protocol,
                      ip_address = ip,
                      hostname=domain
                    },
                     new {
                      port = port,
                      protocol = protocol,
                      ip_address = ip,
                      hostname="www."+domain
                    }
                }
            };
            var res = await apiClient.PostAsync(apiLink, new StringContent(JsonConvert.SerializeObject(newSite), Encoding.UTF8, "application/json"));

            if (res.StatusCode == HttpStatusCode.Created)
            {
                var domainData = JsonConvert.DeserializeObject<CreateDomainModel>(res.Content.ReadAsStringAsync().Result);
                return domainData;
            }

            return null;
        }
        public static async Task<CreateDomainModel> UpdateWebsite(string userName, string password, string token, string apiLink, string domain, string physical_path, string siteId, string protocol = "http", string ip = "*", int port = 80)
        {
            var hanler = new HttpClientHandler();
            hanler.Credentials = new NetworkCredential(userName, password);
            hanler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var apiClient = new HttpClient(hanler, true);
            apiClient.DefaultRequestHeaders.Add("Access-Token", "Bearer " + token);
            apiClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
            domain = domain.Replace("http://", string.Empty);
            domain = domain.Replace("https://", string.Empty);
            domain = domain.Replace("www.", string.Empty);

            var updateObject = new
            {
                name = domain,
                physical_path = physical_path,
                bindings = new object[] {
                    new {
                      port = port,
                      protocol = protocol,
                      ip_address = ip,
                      hostname=domain
                    },
                     new {
                      port = port,
                      protocol = protocol,
                      ip_address = ip,
                      hostname="www."+domain
                    }
                }
            };
            var updateRequest = new HttpRequestMessage(new HttpMethod("PATCH"), apiLink + "/" + siteId);
            updateRequest.Content = new StringContent(JsonConvert.SerializeObject(updateObject), Encoding.UTF8, "application/json");

            try
            {
                var res = await apiClient.SendAsync(updateRequest);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var domainData = JsonConvert.DeserializeObject<CreateDomainModel>(res.Content.ReadAsStringAsync().Result);
                    return domainData;
                }
            }
            catch(Exception ex)
            {

            }
            
            return null;
        }
        public static async Task<ListDomainModel> GetListDomain(string userName, string password, string token, string apiLink)
        {
            var hanler = new HttpClientHandler();
            hanler.Credentials = new NetworkCredential(userName, password);
            hanler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var apiClient = new HttpClient(hanler, true);
            apiClient.DefaultRequestHeaders.Add("Access-Token", "Bearer " + token);
            apiClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
            var res = await apiClient.GetAsync(apiLink);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var listDomain = JsonConvert.DeserializeObject<ListDomainModel>(res.Content.ReadAsStringAsync().Result);
                return listDomain;
            }
            return null;
        }
        public static async Task<bool?> CheckExistsDomain(string userName, string password, string token, string apiLink, string siteId, string domainName)
        {
            var hanler = new HttpClientHandler();
            hanler.Credentials = new NetworkCredential(userName, password);
            hanler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var apiClient = new HttpClient(hanler, true);
            apiClient.DefaultRequestHeaders.Add("Access-Token", "Bearer " + token);
            apiClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
            var res = await apiClient.GetAsync(apiLink);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var listDomain = JsonConvert.DeserializeObject<ListDomainModel>(res.Content.ReadAsStringAsync().Result);
                return listDomain?.websites?.Any(a => a.name == domainName && a.id != siteId);
            }
            return null;
        }
        public static async Task<bool> DeleteDomain(string userName, string password, string token, string apiLink, string siteId)
        {
            var hanler = new HttpClientHandler();
            hanler.Credentials = new NetworkCredential(userName, password);
            hanler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var apiClient = new HttpClient(hanler, true);
            apiClient.DefaultRequestHeaders.Add("Access-Token", "Bearer " + token);
            apiClient.DefaultRequestHeaders.Add("Accept", "application/hal+json");
            var res = await apiClient.DeleteAsync(apiLink + "/" + siteId);
            var result = string.IsNullOrEmpty(res.Content.ReadAsStringAsync().Result);
            return result;
        }
    }
}
