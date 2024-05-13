using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.NasaLogs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PagesResponse;
using Persistence.Contexts;

namespace Application.Domain.LogRecords.Queries.GetLogRecordList;

public class GetLogRecordsHandler(NasaLogDbContext context, IMapper mapper)
    : IRequestHandler<GetLogRecordsQuery, PageResponse<LogRecordDto[]>>
{
    public async Task<PageResponse<LogRecordDto[]>> Handle(GetLogRecordsQuery request, CancellationToken cancellationToken)
    {
        var query = context.LogRecords.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Order.Field))
        {
            query = ApplySorting(query, request.Order);
        }
        
        var logs = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<LogRecordDto>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        return new PageResponse<LogRecordDto[]>(logs.Length, logs);
    }
    
    private IQueryable<LogRecord> ApplySorting(IQueryable<LogRecord> query, SortOptions sortOptions)
    {
        switch (sortOptions.Field.ToLower())
        {
            case "ip":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.Ip)
                    : query.OrderByDescending(l => l.Ip);
                break;
            case "date":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.Date)
                    : query.OrderByDescending(l => l.Date);
                break;
            case "method":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.Method)
                    : query.OrderByDescending(l => l.Method);
                break;
            case "path":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.Path)
                    : query.OrderByDescending(l => l.Path);
                break;
            case "protocol":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.Protocol)
                    : query.OrderByDescending(l => l.Protocol);
                break;
            case "statusCode":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.StatusCode)
                    : query.OrderByDescending(l => l.StatusCode);
                break;
            case "size":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.Size)
                    : query.OrderByDescending(l => l.Size);
                break;
            case "countryCode":
                query = sortOptions.Direction == SortDirections.Ascending
                    ? query.OrderBy(l => l.CountryCode)
                    : query.OrderByDescending(l => l.CountryCode);
                break;
            default:
                throw new ArgumentException("Invalid sorting parameter.");
        }

        return query;
    }
}