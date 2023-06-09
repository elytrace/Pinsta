﻿using System.Diagnostics;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Pinsta.Models;
using Pinsta.Models.Entities;

namespace Pinsta.Controllers;

public class ProfileController : Controller
{
    // public IActionResult Index()
    // {
    //     return View(Models.Entities.User.currentUser);
    // }

    public IActionResult Index(string username)
    {
        var user = OurDbContext.context.users.FirstOrDefault(u => u.username == username);
        return View(user);
    }

    public ActionResult FollowerPanel(int userId = 0)
    {
        if (userId == 0)
        {
            return PartialView(Models.Entities.User.currentUser.followers?.ToList());
        }
        var followerList = OurDbContext.context.users
            .FirstOrDefault(u => u.userId == userId)?
            .followers?.ToList();
        return PartialView(followerList);
    }
    
    public ActionResult FollowingPanel(int userId = 0)
    {
        if (userId == 0)
        {
            return PartialView(Models.Entities.User.currentUser.followings?.ToList());
        }
        var followingList = OurDbContext.context.users
            .FirstOrDefault(u => u.userId == userId)?
            .followings?.ToList();
        return PartialView(followingList);
    }

    [HttpPost]
    public ActionResult ConfirmEditImage(int imageId, string imageUrl)
    {
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(imageUrl)
        };
        var uploadResult = new Cloudinary("cloudinary://118591439573672:d6Me8w-RoHBAhA6lDUTmUnEaKcU@dy7yri3d9").Upload(uploadParams);
        Console.WriteLine("ImageID: " + imageId + ". Upload OK. Result: " + uploadResult.JsonObj);
        if (imageId == -1)
        {
            Models.Entities.User.currentUser.avatarPath = uploadResult.SecureUrl.ToString();
        }
        else if (imageId == -2)
        {
            OurDbContext.context.UploadImage(uploadResult.SecureUrl.ToString(), Models.Entities.User.currentUser.userId);
        }
        else
        {
            OurDbContext.context.images
                .FirstOrDefault(i => i.imageId == imageId)!.imagePath = uploadResult.SecureUrl.ToString();
        }

        OurDbContext.context.SaveChangesAsync();
        return Json(uploadResult.SecureUrl.ToString());
    }

    [HttpPost]
    public ActionResult Follow(int userId)
    {
        var userToFollow = OurDbContext.context.users.FirstOrDefault(u => u.userId == userId);
        if (userToFollow.followers.Contains(Models.Entities.User.currentUser))
        {
            userToFollow.followers.Remove(Models.Entities.User.currentUser);
        }
        else
        {
            userToFollow.followers.Add(Models.Entities.User.currentUser);
        }
        OurDbContext.context.SaveChangesAsync();
        return Json(userToFollow.followers.Count);
    }
    
    [HttpPost]
    public ActionResult FollowDirectly(int userId)
    {
        var followState = false;
        var userToFollow = OurDbContext.context.users.FirstOrDefault(u => u.userId == userId);
        if (userToFollow.followers.Contains(Models.Entities.User.currentUser))
        {
            userToFollow.followers.Remove(Models.Entities.User.currentUser);
            followState = false;
        }
        else
        {
            userToFollow.followers.Add(Models.Entities.User.currentUser);
            followState = true;
        }
        OurDbContext.context.SaveChangesAsync();
        return Json(new
        {
            cnt = Models.Entities.User.currentUser.followings?.Count,
            following = followState
        });
    }
}