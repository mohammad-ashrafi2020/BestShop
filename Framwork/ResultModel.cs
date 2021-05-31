namespace framework
{
    public class ResultModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public string Title { get; set; } = null;
        public ResultModelStatus Status { get; set; }

        #region Error
        public static ResultModel<T> Error(T data)
        {
            return new ResultModel<T>()
            {
                Data = data,
                Status = ResultModelStatus.Error,
                Message = "عملیات ناموفق"
            };
        }
        public static ResultModel<T> Error(T data, ResultModelStatus status)
        {
            return new ResultModel<T>()
            {
                Data = data,
                Status = status,
                Message = "عملیات ناموفق"
            };
        }
        public static ResultModel<T> Error(T data, ResultModelStatus status, string message)
        {
            return new ResultModel<T>()
            {
                Data = data,
                Status = status,
                Message = message
            };
        }
        public static ResultModel<T> Error(ResultModelStatus status, string message)
        {
            return new ResultModel<T>()
            {
                Data = default(T),
                Status = status,
                Message = message
            };
        }
        public static ResultModel<T> Error(string message)
        {
            return new ResultModel<T>()
            {
                Data = default(T),
                Status = ResultModelStatus.Error,
                Message = message
            };
        }
        public static ResultModel<T> NotFound(string message = null)
        {
            return new ResultModel<T>()
            {
                Data = default(T),
                Status = ResultModelStatus.NotFound,
                Message = message ?? "اطلاعات درخواستی یافت نشد"
            };
        }
        public static ResultModel<T> Error()
        {
            return new ResultModel<T>()
            {
                Data = default(T),
                Status = ResultModelStatus.Error,
                Message = "عملیات ناموفق"
            };
        }
        #endregion

        #region Succsess
        public static ResultModel<T> Success(T data)
        {
            return new ResultModel<T>()
            {
                Data = data,
                Status = ResultModelStatus.Success,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
        public static ResultModel<T> Success(T data, string message)
        {
            return new ResultModel<T>()
            {
                Data = data,
                Status = ResultModelStatus.Success,
                Message = message
            };
        }
        public static ResultModel<T> Success(string message)
        {
            return new ResultModel<T>()
            {
                Data = default(T),
                Status = ResultModelStatus.Success,
                Message = message
            };
        }
        #endregion
    }
    public class ResultModel
    {
        public object Data { get; private set; } = null;
        public string Message { get; set; }
        public string Title { get; set; } = null;
        public ResultModelStatus Status { get; set; }

        #region Errors
        public static ResultModel Error()
        {
            return new ResultModel()
            {
                Status = ResultModelStatus.Error,
                Message = "عملیات ناموفق",
                Data = null
            };
        }
        public static ResultModel NotFound(string message)
        {
            return new ResultModel()
            {
                Status = ResultModelStatus.NotFound,
                Message = message,
                Data = null
            };
        }
        public static ResultModel NotFound()
        {
            return new ResultModel()
            {
                Status = ResultModelStatus.NotFound,
                Message = "اطلاعات درخواستی یافت نشد",
                Data = null
            };
        }
        public static ResultModel Error(string message)
        {
            return new ResultModel()
            {
                Status = ResultModelStatus.Error,
                Message = message,
                Data = null
            };
        }
        public static ResultModel Error(string message, ResultModelStatus status)
        {
            return new ResultModel()
            {
                Status = status,
                Message = message,
                Data = null
            };
        }
        #endregion

        #region Succsess

        public static ResultModel Success()
        {
            return new ResultModel()
            {
                Status = ResultModelStatus.Success,
                Message = "عملیات با موفقیت انجام شد",
                Data = null
            };
        }
        public static ResultModel Success(string message)
        {
            return new ResultModel()
            {
                Status = ResultModelStatus.Success,
                Message = message,
                Data = null
            };
        }
        #endregion
    }

    public enum ResultModelStatus
    {
        Error = 10,
        Success = 200,
        NotFound = 404
    }
}