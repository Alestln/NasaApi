using MediatR;
using PagesResponse;

namespace Application.Domain.LogRecords.Queries.GetLogRecordList;

public record GetLogRecordsQuery(
    int Page,
    int PageSize,
    SortOptions Order) : IRequest<PageResponse<LogRecordDto[]>>;