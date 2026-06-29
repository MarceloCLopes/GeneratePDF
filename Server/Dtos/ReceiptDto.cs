namespace Server.Dtos;

public record ReceiptDto(
    string ReceiptId,
    string Name,
    decimal Price1,
    decimal Price2
);

