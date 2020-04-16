using DataConstract.Models;

namespace DataConstract.Services
{
    public interface RunPolicy
    {
        decimal Start(Policy policy);
    }
}
