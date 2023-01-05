namespace Vineeth.services
{
    public class Userservice
    {
        private readonly IHttpContextAccessor _httpContext;

        public Userservice(IHttpContextAccessor httpContext)
        {
            this._httpContext = httpContext;
        }
        public string userID()
        {
            return null;
        }
    }
}
