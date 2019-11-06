using System;
using System.Collections.Generic;
using RunesKeepr.Models;
using RunesKeepr.Repositories;

namespace RunesKeepr.Services
{
  public class ItemsService
  {
    private readonly ItemsRepository _repo;
    public ItemsService(ItemsRepository repo)
    {
      _repo = repo;
    }

    //Get Items
    public IEnumerable<Item> GetAll()
    {
      return _repo.GetAll();
    }

    public Item Get(int id)
    {
      Item exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Items ID"); }
      return exists;
    }

    public IEnumerable<Item> GetUsersItems(string userId)
    {
      return _repo.GetUsersItems(userId);
    }

    //Create Item
    public Item Create(Item newItem, string userId)
    {
      newItem.UserId = userId;
      int id = _repo.Create(newItem);
      newItem.Id = id;
      return newItem;
    }

    //Edit Items (Mainly for Banked / Views / Shares)
    public Item Edit(Item editItem)
    {
      Item item = _repo.Get(editItem.Id);
      if (item == null) { throw new Exception("Invalid Id Homie"); }
      item.isPrivate = editItem.isPrivate;
      item.Views = editItem.Views;
      item.Shares = editItem.Shares;
      item.Banked = editItem.Banked;

      _repo.Edit(item);
      return item;
    }

    public string Delete(int id, string userId)
    {
      Item exists = _repo.Get(id);
      if (exists == null || exists.UserId != userId) { new Exception("Invalid Item ID"); }
      _repo.Delete(id, userId);
      return "Successfully Deleted Item";
    }




  }
}