using RestSharp;
using System.Threading.Tasks;


namespace KSHYWeb.Extensions
{
    public static class RestSharpExtensions
    {
        //public static RestResponse Execute(this IRestClient client, IRestRequest request)
        //{
        //    var taskCompletion = new TaskCompletionSource<IRestResponse>();
        //    client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
        //    return (RestResponse)(taskCompletion.Task.Result);
        //}
        //public static async Task<RestResponse> ExecuteAsync(this RestClient client, RestRequest request)
        //{
        //    TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
        //    _ = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
        //    return (RestResponse)(await taskCompletion.Task);
        //}
    }
}
