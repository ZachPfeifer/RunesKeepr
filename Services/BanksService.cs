using System;
using System.Collections.Generic;
using RunesKeepr.Models;
using RunesKeepr.Repositories;

namespace RunesKeepr.Services
{
  public class BanksService
  {
    private readonly BanksRepository _repo;
    public BanksService(BanksRepository repo)
    {
      _repo = repo;
    }

    //Get Bank
    public IEnumerable<Bank> Get(string userId)
    {
      return _repo.Get(userId);
    }
    public Bank Get(int bankId)
    {
      Bank exists = _repo.Get(bankId);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    public Bank Create(Bank newBank, string userId)
    {
      newBank.UserId = userId;
      int id = _repo.Create(newBank);
      newBank.Id = id;
      return newBank;
    }

    //Edit Banks
    public Bank Edit(Bank editBank)
    {
      Bank bank = _repo.Get(editBank.Id);
      if (bank == null) { throw new Exception("Invalid ID"); }
      bank.Name = editBank.Name;
      bank.Description = editBank.Description;
      _repo.Edit(bank);
      return bank;
    }

    //Delete Bank
    public string Delete(int bankId, string userId)
    {
      Bank exists = _repo.Get(bankId);
      if (exists == null || exists.UserId != userId) { throw new Exception("Invalid ID"); }
      _repo.Delete(bankId);
      return "Successfully Deleted.";
    }
  }
}