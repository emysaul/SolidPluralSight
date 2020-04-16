using DataConstract.Models;

namespace DataConstract.Providers
{
    public interface PolicyProvider
    {
        Policy GetPolicy(string identifier);
    }
}
