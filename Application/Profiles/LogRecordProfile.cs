using Application.Domain.LogRecords.Queries.GetLogRecordList;
using AutoMapper;
using Core.Domain.NasaLogs.Models;

namespace Application.Profiles;

public class LogRecordProfile : Profile
{
    public LogRecordProfile()
    {
        CreateProjection<LogRecord, LogRecordDto>();
    }
}