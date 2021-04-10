using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : Controller
    {
        private readonly LinkDbContext _linkDbContext;
        public static string last = String.Empty;

        public LinksController(LinkDbContext context)
        {
            _linkDbContext = context;
        }

        [HttpGet, Route("/")]
        public IActionResult Index()
        {
            ViewData["longUrl"] = String.Empty;
            ViewData["shortUrl"] = String.Empty;
            ViewData["local"] = String.Empty;
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet, Route("/{url}")]
        public async Task<IActionResult> Index_param([FromRoute] string url)
        {
            Link temp = await _linkDbContext.Links.Where(i=>i.LinkShort==url).FirstOrDefaultAsync();
            UriBuilder uri = new UriBuilder(temp.LinkLong);
            return (temp != null) ? Redirect(uri.ToString()) : BadRequest("Error");
        }

        [HttpPost, Route("/")]
        public async Task<IActionResult> Index([FromForm]string url)
        {
            string short_url = String.Empty;
            if (_linkDbContext.Links.Any(u => u.LinkLong == url))
            {
                var founded = await _linkDbContext.Links.Where(s => s.LinkLong == url).SingleOrDefaultAsync();
                short_url = founded.LinkShort;
            }
            else
            {
                Link new_link = new Link(url, GetRandomString());
                await _linkDbContext.Links.AddAsync(new_link);
                await _linkDbContext.SaveChangesAsync();
                short_url = new_link.LinkShort;
            }
            ViewData["local"] = HttpContext.Request.Host+"/";
            ViewData["longUrl"] = url;
            ViewData["shortUrl"] = short_url;
            return View("~/Views/Home/Index.cshtml");
        }

        public string GetRandomString()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz", result = "";
            var rnd = new Random();
            while (true)
            {
                for (int i = 0; i < 6; i++)
                {
                    result += chars[rnd.Next(0, 36)];
                }
                if(!_linkDbContext.Links.Any(s => s.LinkShort == result))
                {
                    break;
                }
            }
            return result;
        }
    }
}