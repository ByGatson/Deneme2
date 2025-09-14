namespace Application.Result
{
    public class Result<T>
    {
        public T Value { get; }

        private Result(T value, bool isSuccess, string error)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, string.Empty);

        public static new Result<T> Failure(string error) => new Result<T>(default, false, error);
    }
}
