using System.ComponentModel.DataAnnotations;

namespace PagesResponse;

public record PageResponse<T>([property: Required] int Total, [property: Required] T Results) where T : class;