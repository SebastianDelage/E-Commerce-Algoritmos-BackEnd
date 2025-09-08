namespace E_commerce.Responses
{
    public class BaseResponse
    {
        //proprties
        public bool succes {  get; set; }
        public bool error { get; set; }
        public int code { get; set; }
        public string message { get; set; }

        // consturctor baseResponse
        public BaseResponse(bool succes, int code, string message)
        {
            this.succes = succes;
            this.error = !succes;
            this.code = code;
            this.message = message;
        }
    }

    public class DataResponse<T>
    {
        public new T data { get; set; } = default;

        public DataResponse(bool succes, int code, string message,T data = default):base(succes, code, message)
        {
            this.data = data;
        }
    }
}
