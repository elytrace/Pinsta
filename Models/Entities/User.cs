﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinsta.Models.Entities;

[Table("users")]
public class User
{
    public User()
    {
        images = new HashSet<Image>();
        followers = new HashSet<User>();
        followings = new HashSet<User>();
        likes = new HashSet<Like>();
        comments = new HashSet<Comment>();
        searchs = new HashSet<SearchRecent>();
    }

    [NotMapped]
    public static User currentUser = new User();

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int userId { get; set; }
    
    [StringLength(50)]
    public string? username { get; set; }
    
    [StringLength(50)]
    public string? password { get; set; }
    
    [StringLength(50)]
    public string? email { get; set; }
    
    [StringLength(50)]
    public string? phone { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime dateOfBirth { get; set; }
    
    public byte gender { get; set; }
    
    [StringLength(255)]
    public string? avatarPath { get; set; }
    
    [StringLength(255)]
    public string? biography { get; set; }
    
    [StringLength(255)]
    public string? displayedName { get; set; }
    
    public virtual ICollection<Image>? images { get; set; }
    public virtual ICollection<User>? followers { get; set; }
    public virtual ICollection<User>? followings { get; set; }
    
    public virtual ICollection<Like>? likes { get; set; }
    public virtual ICollection<Comment>? comments { get; set; }
    public virtual ICollection<SearchRecent>? searchs { get; set; }
}