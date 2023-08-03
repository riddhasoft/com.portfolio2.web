using com.portfolio2.web.Models;

namespace com.portfolio2.web.Controllers.ViewModel
{
    public class HomeViewModel
    {
        public UserProfile Profile { get; set; }
        public List<Service> Services { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
