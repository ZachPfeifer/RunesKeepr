

using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunesKeepr.Models;
using RunesKeepr.Services;

namespace RunesKeepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly ItemsService _its;
    public ItemsController(ItemsService its)
    {
      _its = its;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAll()
    {
      try
      {
        return Ok(_its.GetAll());
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetAction(int id)
    {
      try
      {
        return Ok(_its.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("user")] //     [HttpGet("{userId}")]
    public ActionResult<IEnumerable<Item>> GetUsersItems()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_its.GetUsersItems(userId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Post Item
    [Authorize]
    [HttpPost]
    public ActionResult<Item> Create([FromBody] Item newItem)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_its.Create(newItem, userId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Edit Item (May Not Need)
    [Authorize]
    [HttpPut]
    public ActionResult<Item> Edit([FromBody] Item editItem)
    {
      try
      {
        return Ok(_its.Edit(editItem));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Delete Item
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_its.Delete(id, userId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}