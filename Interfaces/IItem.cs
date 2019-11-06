namespace RunesKeepr.Interfaces
{
  public interface IItem
  {
    int Id { get; set; }
    string UserId { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Img { get; set; }
    bool isPrivate { get; set; }
    int Views { get; set; }
    int Shares { get; set; }
    int Banked { get; set; }
  }
}