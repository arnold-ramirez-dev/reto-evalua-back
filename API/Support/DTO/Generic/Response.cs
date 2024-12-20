namespace API.Support.DTO.Generic
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Response()
        {
            IsSuccess = false;
            Message = Constants.Message.Error;
        }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
