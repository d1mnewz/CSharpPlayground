using System;

namespace _03_FunctionalErrorHandling
{
	public class Result
	{
		public bool Success { get; private set; }
		public string Error { get; set; }
		public bool Failure => !Success;

		protected Result(bool success, string error)
		{
			Success = success;
			Error = error;
		}

		public static Result Fail(string message) => new Result(false, message);
		public static Result Ok() => new Result(true, String.Empty);

		public static Result<T> Fail<T>(string message) => new Result<T>(default(T), false, message);

		public static Result<T> Ok<T>(T value) => new Result<T>(value, true, String.Empty);
	}

	public class Result<T> : Result
	{
		public T Value { get; }

		protected internal Result(T value, bool success, string error) : base(success, error)
		{
			Value = value;
		}

	}

	public static class ResultExtensions
	{

		public static Result<T> OnSuccess<T>(this Result result, Func<T> func)
			=> result.Failure ? Result.Fail<T>(result.Error) : Result.Ok(func());

		public static Result<TK> OnSuccess<T, TK>(this Result<T> result, Func<T, Result<TK>> func)
			=> result.Failure ? Result.Fail<TK>(result.Error) : func(result.Value);

		public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func)
			=> result.Failure ? Result.Fail<T>(result.Error) : func();

		public static Result<TK> OnSuccess<T, TK>(this Result<T> result, Func<Result<TK>> func)
			=> result.Failure ? Result.Fail<TK>(result.Error) : func();

		public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func)
			=> result.Failure ? Result.Fail(result.Error) : func(result.Value);

		public static Result OnSuccess(this Result result, Func<Result> func)
			=> result.Failure ? result : func();

		public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
			=> result.Failure
			? Result.Fail<T>(result.Error)
			: (!predicate(result.Value) ? Result.Fail<T>(errorMessage) : Result.Ok(result.Value));

		public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
			=> result.Failure
			? Result.Fail(result.Error) : (!predicate()
			? Result.Fail(errorMessage) : Result.Ok());

		public static Result<TK> Map<T, TK>(this Result<T> result, Func<T, TK> func)
			=> result.Failure ? Result.Fail<TK>(result.Error) : Result.Ok(func(result.Value));

		public static Result<T> Map<T>(this Result result, Func<T> func)
			=> result.Failure ? Result.Fail<T>(result.Error) : Result.Ok(func());

		public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
		{
			if (result.Success)
			{
				action(result.Value);
			}

			return result;
		}

		public static Result OnSuccess(this Result result, Action action)
		{
			if (result.Success)
			{
				action();
			}

			return result;
		}

		public static T OnBoth<T>(this Result result, Func<Result, T> func)
		{
			return func(result);
		}

		public static TK OnBoth<T, TK>(this Result<T> result, Func<Result<T>, TK> func)
			=> func(result);

		public static Result<T> OnFailure<T>(this Result<T> result, Action action)
		{
			if (result.Failure)
			{
				action();
			}

			return result;
		}

		public static Result OnFailure(this Result result, Action action)
		{
			if (result.Failure)
			{
				action();
			}

			return result;
		}

		public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
		{
			if (result.Failure)
			{
				action(result.Error);
			}

			return result;
		}

		public static Result OnFailure(this Result result, Action<string> action)
		{
			if (result.Failure)
			{
				action(result.Error);
			}

			return result;
		}
	}
}