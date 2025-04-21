namespace SmartHealth_Domain.Enums;

[Flags]
public enum LanguagesEnum
{
    French = 1 << 0,
    English = 1 << 1,
    Dutch = 1 << 2,
    German = 1 << 3,
    Arabic = 1 << 4,
    Spanish = 1 << 5,
    Portuguese = 1 << 6,
    Italian = 1 << 7,
    Turkish = 1 << 8,
    Russian = 1 << 9,
    Romanian = 1 << 10,
    Polish = 1 << 11,
    Bulgarian = 1 << 12,
    Chinese = 1 << 13,
    Vietnamese = 1 << 14,
    Farsi = 1 << 15,
    Pashto = 1 << 16,
    Urdu = 1 << 17,
    Somali = 1 << 18,
}