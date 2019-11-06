using System;
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
  public class BankItemsController : ControllerBase
  {
    private readonly BankItemsService _vs;
    public BankItemsController(BankItemsService vs)
    {
      _vs = vs;
    }

    [Authorize]
    [HttpGet("{bankId}")]
    public ActionResult<IEnumerable<Item>> Get(int bankId)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Get(bankId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<BankItem> Create([FromBody] BankItem bankItem)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(bankItem, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut]
    public ActionResult<string> Delete([FromBody] BankItem bankItem)
    {
      try
      {
        return Ok(_vs.Remove(bankItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}