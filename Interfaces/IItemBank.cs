namespace RunesKeepr.Interfaces
{
  public interface IItemBank
  {
    string Id { get; set; }
    int BankId { get; set; }
    int ItemId { get; set; }
    string UserId { get; set; }
  }
}