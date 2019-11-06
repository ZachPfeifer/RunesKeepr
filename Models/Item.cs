using System.ComponentModel.DataAnnotations;
using RunesKeepr.Interfaces;

namespace RunesKeepr.Models
{
  public class Item : IItem
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Img { get; set; }
    public bool isPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Banked { get; set; }
  }
}