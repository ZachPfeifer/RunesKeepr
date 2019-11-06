using System.Collections.Generic;
using System.Data;
using Dapper;
using RunesKeepr.Models;

namespace RunesKeepr.Repositories
{
  public class ItemsRepository
  {
    private readonly IDbConnection _db;
    public ItemsRepository(IDbConnection db)
    {
      _db = db;
    }

    //Calls Start Here

    //GETS Items
    public IEnumerable<Item> GetAll()
    {
      string sql = "SELECT * FROM  items";
      return _db.Query<Item>(sql);
    }
    public Item Get(int id)
    {
      string sql = "SELECT * FROM items WHERE id = @itemId"; //FIXME May need to revisit 
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    public IEnumerable<Item> GetUsersItems(string userId)
    {
      string sql = "SELECT * FROM items WHERE userId = @userId";
      return _db.Query<Item>(sql, new { userId });
    }

    //Create Items
    public int Create(Item newItem)
    {
      string sql = @"
            INSERT INTO keeps
            (name, description, img, isPrivate, userId)
            VALUES
            (@Name, @Description, @Img, @isPrivate, @UserId);
            SELECT LAST_INSERT_ID();
        ";
      return _db.ExecuteScalar<int>(sql, newItem);
    }

    //Edit Item
    public void Edit(Item item)
    {
      string sql = @"
           UPDATE keeps
            SET
                isPrivate = @isPrivate,
                views = @Views,
                shares = @Shares,
                banked = @Banked
            WHERE id = @Id
        ";
      _db.Execute(sql, item);
    }
    //Delete Item
    public void Delete(int id, string userId)
    {
      string sql = "DELETE FROM items WHERE id = @id AND userId = @userId";
      _db.Execute(sql, new { id, userId });
    }


  }
}