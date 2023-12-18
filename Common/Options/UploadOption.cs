﻿namespace Common.Options;

public class UploadOption
{
    public const string Section = "FileStorage";
    public string StoragePath { get; set; } = string.Empty;
    public decimal MaximumFileSizeInMb { get; set; } = 5;
}