using System.Runtime.CompilerServices;

namespace Choon.Api.Features.Common.Util;

public class AsyncLazy<T> : Lazy<Task<T>>
{
    public AsyncLazy(Func<Task<T>> valueFactory)
        : base(valueFactory)
    { }

    public TaskAwaiter<T> GetAwaiter() => Value.GetAwaiter();
}