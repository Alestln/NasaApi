using System.ComponentModel.DataAnnotations;

namespace PagesResponse;

// Names in ascending and descending order at the level of the contract with the front-end developer
public record SortOptions([property: Required] string Field, [property: Required] string Direction);