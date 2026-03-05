

using Application.Dtos;
using Application.States;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[Route("api/state")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateApplication _stateApplication;

    public StateController(IStateApplication stateApplication)
    {
        _stateApplication = stateApplication;
    }

    //[HttpGet("test")]
    //public IActionResult Test()
    //{

    //    return Ok("State created successfully"); // success 200 code
    //    //return BadRequest("State created successfully"); // bad request  400 code
    //}

    //[HttpGet("test-2")]
    //public ActionResult<CountryDto> Test2()
    //{
    //    return new CountryDto();
    //    return Ok("State created successfully"); // success 200 code
    //    //return BadRequest("State created successfully"); // bad request  400 code
    //}


    [HttpPost]
    public async Task<ActionResult> AddState(CreateUpdateStateDto input)
    {
        try
        {
            await _stateApplication.AddState(input);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task UpdateState(int id, CreateUpdateStateDto input)
    {
        await _stateApplication.UpdateState(id, input);
    }

    [HttpGet("{id}")]
    public async Task<StateDto> GetState(int id)
    {
        return await _stateApplication.GetStateById(id);
    }

    [HttpGet]
    public async Task<List<StateDto>> GetAllStates()
    {
        return await _stateApplication.GetAllStates();
    }

    [HttpDelete("{id}")]
    public async Task DeleteState(int id)
    {
        await _stateApplication.DeleteState(id);
    }

}

