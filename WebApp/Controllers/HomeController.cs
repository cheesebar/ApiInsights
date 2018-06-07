using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cheers.ApiInsights;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [NoInsight]
        public async Task<bool> Index()
        {


            return true;
        }
    }
}
