namespace RunesKeepr.Interfaces
{
  public interface IBank
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string UserId { get; set; }
  }
}