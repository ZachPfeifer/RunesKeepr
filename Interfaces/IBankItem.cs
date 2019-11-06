namespace RunesKeepr.Interfaces
{
  public interface IBankItem
  {
    int Id { get; set; }
    int BankId { get; set; }
    int ItemId { get; set; }
    string UserId { get; set; }
  }
}