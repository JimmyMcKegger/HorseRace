public class UploadResult
{
    public string FileName { get; set; } = string.Empty;
    public bool Uploaded { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}