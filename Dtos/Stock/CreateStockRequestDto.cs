using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Stock;

public class CreateStockRequestDto
{
    [Required]
    [MaxLength(10, ErrorMessage = "Stock name cannot be longer than 10 characters.")]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    [MaxLength(10, ErrorMessage = "Stock name cannot be longer than 10 characters.")]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
    public decimal Purchace { get; set; }

    [Required]
    [Range(0.001, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
    public decimal Lastdiv { get; set; }

    [Required]
    [MaxLength(10, ErrorMessage = "Stock name cannot be longer than 10 characters.")]
    public string Industry { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
    public long Marketcap { get; set; }
}