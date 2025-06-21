namespace Quizzes_System.ViewModels
{
    public class SuccessResponseViewModel<T> : ResponseViewModel<T>
    {
        public SuccessResponseViewModel(T Data, string message)
        {
            this.Data = Data;
            Message = message;
            IsSuccess = true;
            ErrorCode = Models.Enum.ErrorCode.NoError;
        }
    }
}
