using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using RunesKeepr.Models;

namespace RunesKeepr.Repositories
{
  public class BanksRepository
  {
    private readonly IDbConnection _db;
    public BanksRepository(IDbConnection db)
    {
      _db = db;
    }

    //Get Bank
    public IEnumerable<Bank> Get(string userId)
    {
      string sql = "SELECT * FROM banks WHERE userId = @userId";
      return _db.Query<Bank>(sql, new { userId });
    }

    public Bank Get(int bankId)
    {
      string sql = "SELECT * FROM banks WHERE id = @bankId";
      return _db.QueryFirstOrDefault<Bank>(sql, new { bankId });
    }

    //Create Bank
    public int Create(Bank newBank)
    {
      string sql = @"
        INSERT INTO banks
        (name, description, userId)
        VALUES
        (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBank);
    }

    //Edit Bank
    public void Edit(Bank bank)
    {
      string sql = @"
         UPDATE banks
         SET
          name = @Name,
          descritpion = @Description
         WHERE id = @Id";
      _db.Execute(sql, bank);
    }

    //Delete Bank
    public void Delete(int bankId)
    {
      string sql = "DELETE FROM banks WHERE id = @bankId";
      _db.Execute(sql, new { bankId });
    }
  }
}