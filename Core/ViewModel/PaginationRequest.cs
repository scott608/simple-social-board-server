using SimpleSocialBoardServer.Core.Enums;

namespace SimpleSocialBoardServer.Core.ViewModel
{
    public class PaginationRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}