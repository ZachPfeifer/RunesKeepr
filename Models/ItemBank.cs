using System.ComponentModel.DataAnnotations;
using RunesKeepr.Interfaces;

namespace RunesKeepr.Models
{
  public class ItemBank : IItemBank
  {
    [Required]
    public string Id { get; set; }
    public int BankId { get; set; }
    public int ItemId { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}