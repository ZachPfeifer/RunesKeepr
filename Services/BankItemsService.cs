using System;
using System.Collections.Generic;
using RunesKeepr.Models;
using RunesKeepr.Repositories;

namespace RunesKeepr.Services
{
  public class BankItemsService
  {
    private readonly BankItemsRepository _repo;
    public BankItemsService(BankItemsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Item> Get(int bankId, string userId)
    {
      return _repo.Get(bankId, userId);
    }

    public BankItem Create(BankItem bankItem, string userId)
    {
      bankItem.UserId = userId;
      int id = _repo.Create(bankItem);
      bankItem.Id = id;
      return bankItem;
    }

    public string Remove(BankItem bankItem)
    {
      BankItem exists = _repo.Check(bankItem.BankId, bankItem.ItemId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      _repo.Remove(exists.Id);
      return "Successfully deleted.";
    }
  }
}