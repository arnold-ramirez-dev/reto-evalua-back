using System.Collections.Generic;

namespace API.Support.DTO.Generic
{
    public class PaginateResponse<T>
    {
        public int TotalRow { get; set; } = 0;
        public List<T> List { get; set; } = [];
    }
}
