﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinsta.Models.Entities;

[Table("comments")]
public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int commentId { get; set; }
    
    [StringLength(500)]
    public string? comment { get; set; }
    public int userId { get; set; }
    public virtual User user { get; set; }
    
    public int imageId { get; set; }
    public virtual Image image { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime timeStamp { get; set; }
}