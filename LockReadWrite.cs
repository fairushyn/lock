namespace lock_test;

public class LockReadWrite
{
    public enum ReadWrite { Read, Write };
    private readonly ReaderWriterLockSlim _lock = new();
    public void Lock(Action f, ReadWrite rw)
    {
        switch (rw)
        {
            case ReadWrite.Read:
                try
                {
                    _lock.EnterReadLock();
                    f();
                }
                finally
                {
                    _lock.ExitReadLock();
                }
                break;
            case ReadWrite.Write:
                try
                {
                    _lock.EnterWriteLock();
                    f();
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
                break;
        }
    }

    public T? Lock<T>(Func<T> f, ReadWrite rw)
    {
        switch (rw)
        {
            case ReadWrite.Read:
                try
                {
                    _lock.EnterReadLock();
                    return f();
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            case ReadWrite.Write:
                try
                {
                    _lock.EnterWriteLock();
                    return f();
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
        }
        return default;
    }


}