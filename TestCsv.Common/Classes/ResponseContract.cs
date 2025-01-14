namespace TestCsv.Common.Classes
{
    public class ResponseContract<TContract>
    {
        public HeaderContract Header { get; set; }
        public TContract Data { get; set; }

        public ResponseContract()
        {
            Header = new HeaderContract();
            Header.Code = HttpCodes.Ok;
        }
    }

    public class ResponseContract
    {
        public HeaderContract Header { get; set; }
        public ResponseContract()
        {
            Header = new HeaderContract
            {
                Code = HttpCodes.Ok
            };
        }
    }


    public enum HttpCodes
    {
        Ok = 200,
        OkExist = 201,
        BadRequest = 400,
        NotFound = 404,
        ValidationError = 421,
        InternalServerError = 500,
        Unautorized = 401
    }

    public class HeaderContract
    {
        public HttpCodes Code { get; set; }
        public string? Message { get; set; }
    }
    public class ContingencyResponseDTO<T>
    {
        public ContingencyHeaderDTO Header { get; set; }
        public T Data { get; set; }

        public int Count { get; set; }
        public int CountAux { get; set; }

        public ContingencyResponseDTO()
        {
            Header = new ContingencyHeaderDTO
            {
                Code = HttpCodes.Ok
            };
        }

        public ContingencyResponseDTO(HttpCodes code)
        {
            Header = new ContingencyHeaderDTO
            {
                Code = code
            };
        }
    }

    public class ContingencyHeaderDTO : HeaderContract
    {
        public int ContigencyStatus { get; set; }
        public string? ContingencyMessage { get; set; }
    }
}
