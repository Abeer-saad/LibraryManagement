using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers;

[ApiController, Route("api/[controller]")]
public class CategoriesController(ICategoryService service) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());
    [HttpGet("{uuid}")] public async Task<IActionResult> Get(string uuid) { var x = await service.GetDetailsAsync(uuid); return x is null ? NotFound() : Ok(x); }
    [HttpPost] public async Task<IActionResult> Post(CategoryCreateDto dto) { await service.AddAsync(dto); return Ok(); }
    [HttpPut] public async Task<IActionResult> Put(CategoryUpdateDto dto) { await service.UpdateAsync(dto); return NoContent(); }
    [HttpDelete("{uuid}")] public async Task<IActionResult> Delete(string uuid) { try { await service.DeleteAsync(uuid); return NoContent(); } catch (KeyNotFoundException) { return NotFound(); } catch (InvalidOperationException e) { return Conflict(e.Message); } }
}

[ApiController, Route("api/[controller]")]
public class CustomersController(ICustomerService service) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());
    [HttpGet("{uuid}")] public async Task<IActionResult> Get(string uuid) { var x = await service.GetDetailsAsync(uuid); return x is null ? NotFound() : Ok(x); }
    [HttpPost] public async Task<IActionResult> Post(CustomerCreateDto dto) { await service.AddAsync(dto); return Ok(); }
    [HttpPut] public async Task<IActionResult> Put(CustomerUpdateDto dto) { await service.UpdateAsync(dto); return NoContent(); }
    [HttpDelete("{uuid}")] public async Task<IActionResult> Delete(string uuid) { try { await service.DeleteAsync(uuid); return NoContent(); } catch (KeyNotFoundException) { return NotFound(); } catch (InvalidOperationException e) { return Conflict(e.Message); } }
}

[ApiController, Route("api/[controller]")]
public class BorrowingsController(IBorrowingService service) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());
    [HttpGet("{uuid}")] public async Task<IActionResult> Get(string uuid) { var x = await service.GetDetailsAsync(uuid); return x is null ? NotFound() : Ok(x); }
    [HttpPost] public async Task<IActionResult> Post(BorrowingCreateDto dto) { try { await service.AddAsync(dto); return Ok(); } catch (InvalidOperationException e) { return BadRequest(e.Message); } }
    [HttpPut] public async Task<IActionResult> Put(BorrowingUpdateDto dto) { try { await service.UpdateAsync(dto); return NoContent(); } catch (KeyNotFoundException) { return NotFound(); } catch (InvalidOperationException e) { return BadRequest(e.Message); } }
    [HttpDelete("{uuid}")] public async Task<IActionResult> Delete(string uuid) { try { await service.DeleteAsync(uuid); return NoContent(); } catch (KeyNotFoundException) { return NotFound(); } }
}
