﻿using System.Diagnostics;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using OurInstagram.Models;
using OurInstagram.Models.Login;

namespace OurInstagram.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var followings = Models.Entities.User.currentUser.followings.Select(user => user.userId);
        var imageList = OurDbContext.context.images
            .Where(user => followings.Contains(user.userId)).ToList();
        
        return View(imageList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public ActionResult UploadImage(string imageURL)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(imageURL)
        };
        var uploadResult = new Cloudinary().Upload(uploadParams);
        Console.WriteLine(uploadResult.JsonObj);
        OurDbContext.UploadImage(uploadResult.SecureUrl.ToString(), Models.Entities.User.currentUser.userId);
        return View("Index");
    }
}