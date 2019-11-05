using System.ComponentModel.DataAnnotations;
using RunesKeepr.Interfaces;

namespace RunesKeepr.Models
{
  public class Bank : IBank
  {
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}