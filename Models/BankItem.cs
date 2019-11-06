using System.ComponentModel.DataAnnotations;
using RunesKeepr.Interfaces;

namespace RunesKeepr.Models
{
  public class BankItem : IBankItem
  {
    [Required]
    public int Id { get; set; }
    public int BankId { get; set; }
    public int ItemId { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}