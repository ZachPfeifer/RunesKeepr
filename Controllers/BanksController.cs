using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunesKeepr.Models;
using RunesKeepr.Services;

namespace RunesKeepr.Controllers
{
  [ApiController]
  [Route("api/[controller")]
  public class BanksController : ControllerBase
  {
    public readonly BanksService _bs;
    public BanksController(BanksService bs)
    {
      _bs = bs;
    }

    //Get Bank
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Bank>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_bs.Get(userId));

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("{bankId}")]
    public ActionResult<Bank> Get(int bankId)
    {
      try
      {
        return Ok(_bs.Get(bankId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Create Bank
    [Authorize]
    [HttpPost]
    public ActionResult<Bank> Create([FromBody] Bank newBank)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_bs.Create(newBank, userId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Edit Bank
    [Authorize]
    [HttpPut("{bankId}")]
    public ActionResult<Bank> Edit(int bankId, [FromBody] Bank editBank)
    {
      try
      {
        editBank.Id = bankId;
        return Ok(_bs.Edit(editBank));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete Bank
    [Authorize]
    [HttpDelete("{bankId}")]
    public ActionResult<string> Delete(int bankId)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_bs.Delete(bankId, userId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}