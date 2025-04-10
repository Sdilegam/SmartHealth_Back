using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Telecom
{
    public int TelecomId { get; init; }
    public required string TelecomValue { get; init; }
    public TelecomsTypeEnum Type { get; init; }
    public ScopeEnum Scope { get; init; }
};