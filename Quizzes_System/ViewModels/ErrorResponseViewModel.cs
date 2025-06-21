using Quizzes_System.Models.Enum;

namespace Quizzes_System.ViewModels
{
    public class ErrorResponseViewModel<T>:ResponseViewModel<T>
    {
        public ErrorResponseViewModel(string message, ErrorCode errorCode = ErrorCode.UnknownError)
        {
            Data = default;
            IsSuccess = false;
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
