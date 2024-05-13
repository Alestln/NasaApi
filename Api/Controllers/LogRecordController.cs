using Application.Domain.LogRecords.Queries.GetLogRecordList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagesResponse;

namespace NasaApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class LogRecordController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List(
        [FromQuery] int page,
        [FromQuery] int pageSize,
        [FromQuery] string sortField = "",
        [FromQuery] string sortDirection = SortDirections.Ascending,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var logs = 
                await mediator.Send(new GetLogRecordsQuery(page, pageSize, 
                        new SortOptions(sortField, sortDirection)), 
                    cancellationToken);

            return Ok(logs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}