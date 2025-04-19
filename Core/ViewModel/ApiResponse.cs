namespace SimpleSocialBoardServer.Core.ViewModel
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public object? Pagination { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Page(T data, object pagination, int total)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = "Success",
                Data = data,
                Pagination = new
                {
                    Page = ((PaginationRequest)pagination).Page,
                    PageSize = ((PaginationRequest)pagination).PageSize,
                    Total = total
                }
            };
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message
            };
        }
    }
    
}