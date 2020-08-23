namespace Xian.Lib.Core.Dto
{
    /// <summary>
    /// 回應給前端的格式
    /// </summary>
    public class IsSuccessResult
    {
        public IsSuccessResult()
        {
            IsSuccess = true;
        }

        public IsSuccessResult(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// 回應給前端的格式 (包含物件)
    /// </summary>
    public class IsSuccessResult<T> : IsSuccessResult
    {
        public IsSuccessResult()
        {
            IsSuccess = true;
        }

        public IsSuccessResult(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }

        public T ReturnObject { get; set; }
    }
}