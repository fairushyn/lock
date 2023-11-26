using lock_test;

void Rename(string dir)
{
    foreach (var d in Directory.GetDirectories(dir))
        Rename(d);
    var fs = Directory.GetFiles(dir);
    foreach (var f in fs)
        if (Path.GetFileName(f).IndexOf("X2Download.com-") > -1)
            File.Move(f, f.Replace("X2Download.com-", ""));
}

Rename(@"v:\Ролики\");


//Task.Run(() =>
//{
//    for (var i = 0; i < 10; i++)
//    {
//        Thread.Sleep(100);
//        Console.WriteLine($"1_{i}");
//    }
//});

//Task.Run(() =>
//{
//    for (var i = 0; i < 10; i++)
//    {
//        Thread.Sleep(100);
//        Console.WriteLine($"2_{i}");
//    }
//});


#region lock

var _lock = new object();

//Task.Run(() =>
//{
//    lock (_lock)
//        for (var i = 0; i < 10; i++)
//        {
//            Thread.Sleep(100);
//            Console.WriteLine($"lock1_{i}");
//        }

//});

//Task.Run(() =>
//{
//    lock (_lock)
//        for (var i = 0; i < 10; i++)
//        {
//            Thread.Sleep(100);
//            Console.WriteLine($"lock2_{i}");
//        }
//});
#endregion

#region Monitor
var _lockWasTaken = false;
try
{
    Monitor.Enter(_lock, ref _lockWasTaken);
}
finally
{
    if (_lockWasTaken) Monitor.Exit(_lock);
}
#endregion

#region lock one thread
//void LockWriteLine(int i)
//{
//    lock (_lock)    
//        Console.WriteLine($"lock {i}");

//}


//Task.Run(() =>
//{
//    lock (_lock)
//    {
//        LockWriteLine(1);
//        LockWriteLine(2);
//        LockWriteLine(3);
//    }
//});
#endregion

#region lock async

//Task.Run(async () =>
//{
//    lock (_lock)
//    {
//        await Task.Delay(2000);
//    }
//});



//var _lockAsync = new LockAsync();

//Task.Run(async () =>
//{
//    var result = await _lockAsync.Lock(async () =>
//    {
//        await Task.Delay(2000);
//        for (var i = 0; i < 10; i++)
//            Console.WriteLine($"lockAsync1 {i}");
//        return 34;
//    });
//    Console.WriteLine(result);
//});

//Task.Run(async () =>
//{
//    var result = await _lockAsync.Lock(async () =>
//    {
//        await Task.Delay(100);
//        for (var i = 0; i < 10; i++)
//            Console.WriteLine($"lockAsync2 {i}");
//        return 8;
//    });
//    Console.WriteLine(result);
//});
#endregion

#region lock read/write
//var _lockrw = new LockReadWrite();

//Task.Run(() =>
//{
//    _lockrw.Lock(() =>
//    {

//        for (var i = 0; i < 10; i++)
//        {
//            Thread.Sleep(100);
//            Console.WriteLine($"read1 {i}");
//        }

//    }, LockReadWrite.ReadWrite.Read);
//});

//Task.Run(() =>
//{
//    _lockrw.Lock(() =>
//    {

//        for (var i = 0; i < 10; i++)
//        {
//            Thread.Sleep(100);
//            Console.WriteLine($"read2 {i}");
//        }

//    }, LockReadWrite.ReadWrite.Read);
//});

//Task.Run(() =>
//{
//    _lockrw.Lock(() =>
//    {
//        for (var i = 0; i < 10; i++)
//        {
//            Thread.Sleep(100);
//            Console.WriteLine($"write {i}");
//        }

//    }, LockReadWrite.ReadWrite.Write);
//});
#endregion

Console.ReadLine();
