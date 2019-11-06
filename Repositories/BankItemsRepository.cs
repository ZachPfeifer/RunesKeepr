using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using RunesKeepr.Models;

namespace RunesKeepr.Repositories
{
  public class BankItemsRepository
  {
    private readonly IDbConnection _db;
    public BankItemsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Item> Get(int bankId, string userId)
    {
      string sql = @"
      SELECT * FROM bankitems vk
      INNER JOIN items k ON k.id = vk.itemId 
      WHERE (bankId = @bankId AND vk.userId = @userId)";
      return _db.Query<Item>(sql, new { bankId, userId });
    }
    public BankItem Check(int bankId, int itemId)
    {
      string sql = "SELECT * FROM bankitems WHERE bankId = @bankId AND itemId = @itemId";
      return _db.QueryFirstOrDefault<BankItem>(sql, new { bankId, itemId });
    }
    public void Remove(int id)
    {
      string sql = "DELETE FROM bankitems WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public int Create(BankItem bankItem)
    {
      string sql = @"
      INSERT INTO bankitems
      (bankId, itemId, userId)
      VALUES
      (@BankId, @ItemId, @UserId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, bankItem);
    }

  }
}