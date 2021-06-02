namespace framework
{
    public class OperationResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public string Title { get; set; } = null;
        public OperationResultStatus Status { get; set; }

        #region Error
        public static OperationResult<T> Error(T data)
        {
            return new OperationResult<T>()
            {
                Data = data,
                Status = OperationResultStatus.Error,
                Message = "عملیات ناموفق"
            };
        }
        public static OperationResult<T> Error(T data, OperationResultStatus status)
        {
            return new OperationResult<T>()
            {
                Data = data,
                Status = status,
                Message = "عملیات ناموفق"
            };
        }
        public static OperationResult<T> Error(T data, OperationResultStatus status, string message)
        {
            return new OperationResult<T>()
            {
                Data = data,
                Status = status,
                Message = message
            };
        }
        public static OperationResult<T> Error(OperationResultStatus status, string message)
        {
            return new OperationResult<T>()
            {
                Data = default(T),
                Status = status,
                Message = message
            };
        }
        public static OperationResult<T> Error(string message)
        {
            return new OperationResult<T>()
            {
                Data = default(T),
                Status = OperationResultStatus.Error,
                Message = message
            };
        }
        public static OperationResult<T> NotFound(string message = null)
        {
            return new OperationResult<T>()
            {
                Data = default(T),
                Status = OperationResultStatus.NotFound,
                Message = message ?? "اطلاعات درخواستی یافت نشد"
            };
        }
        public static OperationResult<T> Error()
        {
            return new OperationResult<T>()
            {
                Data = default(T),
                Status = OperationResultStatus.Error,
                Message = "عملیات ناموفق"
            };
        }
        #endregion

        #region Succsess
        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>()
            {
                Data = data,
                Status = OperationResultStatus.Success,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
        public static OperationResult<T> Success(T data, string message)
        {
            return new OperationResult<T>()
            {
                Data = data,
                Status = OperationResultStatus.Success,
                Message = message
            };
        }
        public static OperationResult<T> Success(string message)
        {
            return new OperationResult<T>()
            {
                Data = default(T),
                Status = OperationResultStatus.Success,
                Message = message
            };
        }
        #endregion
    }
    public class OperationResult
    {
        public object Data { get; private set; } = null;
        public string Message { get; set; }
        public string Title { get; set; } = null;
        public OperationResultStatus Status { get; set; }

        #region Errors
        public static OperationResult Error()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = "عملیات ناموفق",
                Data = null
            };
        }
        public static OperationResult NotFound(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = message,
                Data = null
            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = "اطلاعات درخواستی یافت نشد",
                Data = null
            };
        }
        public static OperationResult Error(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = message,
                Data = null
            };
        }
        public static OperationResult Error(string message, OperationResultStatus status)
        {
            return new OperationResult()
            {
                Status = status,
                Message = message,
                Data = null
            };
        }
        #endregion

        #region Succsess

        public static OperationResult Success()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = "عملیات با موفقیت انجام شد",
                Data = null
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = message,
                Data = null
            };
        }
        #endregion
    }

    public enum OperationResultStatus
    {
        Error = 10,
        Success = 200,
        NotFound = 404
    }
}