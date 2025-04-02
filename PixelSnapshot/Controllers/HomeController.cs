using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PixelSnapshot.Models;

namespace PixelSnapshot.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Error404()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



    private readonly List<GalleryModel> GalleryList =
    [
        new GalleryModel { Id = 1, Name = "light", Path = "01.jpg" },
        new GalleryModel { Id = 2, Name = "light", Path = "02.jpg" },
        new GalleryModel { Id = 3, Name = "light", Path = "03.jpg" },
        new GalleryModel { Id = 4, Name = "light", Path = "04.jpg" },
        new GalleryModel { Id = 5, Name = "dark",  Path = "05.jpg" },
        new GalleryModel { Id = 6, Name = "dark", Path = "06.jpg" },
        new GalleryModel { Id = 7, Name = "light", Path = "07.jpg" },
        new GalleryModel { Id = 8, Name = "light", Path = "08.jpg" },
        new GalleryModel { Id = 9, Name = "light", Path = "09.jpg" },
        new GalleryModel { Id = 10, Name = "dark", Path = "10.jpg" },
        new GalleryModel { Id = 11, Name = "light", Path = "11.jpg" },
        new GalleryModel { Id = 12, Name = "dark", Path = "12.jpg" },
        new GalleryModel { Id = 13, Name = "dark", Path = "13.jpg" },
        new GalleryModel { Id = 14, Name = "dark", Path = "14.jpg" },
        new GalleryModel { Id = 15, Name = "dark", Path = "15.jpg" },
        new GalleryModel { Id = 16, Name = "dark", Path = "16.jpg" },
        new GalleryModel { Id = 17, Name = "light", Path = "17.jpg" },
        new GalleryModel { Id = 18, Name = "light", Path = "18.jpg" },
        new GalleryModel { Id = 19, Name = "light", Path = "19.jpg" },
        new GalleryModel { Id = 20, Name = "light", Path = "20.jpg" },
        new GalleryModel { Id = 21, Name = "light", Path = "21.jpg" },
        new GalleryModel { Id = 22, Name = "dark", Path = "22.jpg" },
        new GalleryModel { Id = 23, Name = "dark", Path = "23.jpg" },
        new GalleryModel { Id = 24, Name = "dark", Path = "24.jpg" },
        new GalleryModel { Id = 25, Name = "light", Path = "25.jpg" },
        new GalleryModel { Id = 26, Name = "dark", Path = "26.jpg" }
    ];

    [HttpGet]
    public IActionResult Gallery(int page = 1, string search = "")
    {
        search = search ?? "";
        int itemsPerPage = 4;
        var filteredImages = GalleryList
            .Where(img => string.IsNullOrEmpty(search) || img.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
            .ToList();


        int totalPages = (int)Math.Ceiling((double)filteredImages.Count / itemsPerPage);
        var imagesToShow = filteredImages.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

        var model = new GalleryModel
        {
            Images = [.. imagesToShow.Select(g => g.Path)],
            CurrentPage = page,
            TotalPages = totalPages,
            SearchQuery = search
        };

        return View(model);
    }

}
