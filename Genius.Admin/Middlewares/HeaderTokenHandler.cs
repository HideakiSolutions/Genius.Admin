namespace Admin.Middlewares
{
    public class HeaderTokenHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Store.AccessToken);

            return base.SendAsync(request, cancellationToken);
        }

    }
}
