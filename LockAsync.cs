using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lock_test;

public class LockAsync
{
    private readonly SemaphoreSlim _lock = new(1, 1);

    public async Task Lock(Func<Task> f)
    {
        await _lock.WaitAsync();
        try
        {
            await f();
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<T> Lock<T>(Func<Task<T>> f)
    {
        await _lock.WaitAsync();
        try
        {
            return await f();
        }
        finally
        {
            _lock.Release();
        }
    }

}
