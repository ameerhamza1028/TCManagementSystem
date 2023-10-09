namespace TCManagementSystem.Helper
{
    public class ApiResponse<T>
    {
        public int Status { get; set; } = 1;
        public string? Message { get; set; } = "Success";
        public T? Data { get; set; }
    }
}
