using BenchmarkDotNet.Attributes;

public class CacheLocalityBenchmark
{
    private int[] array = new int[64 * 64 * 64 * 64 * 4];
    const int ThreadCount = 8;

    public void RunThreads(Action<int> f)
    {
        var threads = new Thread[ThreadCount];

        for (int i = 0; i < ThreadCount; i++)
        {
            var l = i;
            threads[i] = new Thread(new ThreadStart(() => f(l)));
            threads[i].Start();
        }

        for (int i = 0; i < ThreadCount; i++)
            threads[i].Join();
    }

    [Benchmark(Description = "Threads read one by one confusing the cacheline")]
    public int BenchReadClose()
    {
        var sum = 0;

        Action<int> f = x =>
        {
            var len = array.Length;
            var localSum = 0;
            for (int i = 0; i < len / ThreadCount; i++)
            {
                var l = i * ThreadCount + x;
                localSum += (array[l] + 2) * 3;
            }

            sum += localSum;
        };

        RunThreads(f);

        return sum;
    }

    [Benchmark(Description = "Threads read far from each other")]
    public int BenchReadFar()
    {
        var sum = 0;

        Action<int> f = x =>
        {
            var len = array.Length;
            var localSum = 0;
            for (int i = len / ThreadCount * x; i < len / ThreadCount * (x + 1); i++)
            {
                localSum += (array[i] + 2) * 3;
            }
            sum += localSum;
        };

        RunThreads(f);

        return sum;
    }

    [Benchmark(Description = "Threads write one by one confusing the cacheline")]
    public int BenchWriteClose()
    {
        Action<int> f = x =>
        {
            var len = array.Length;
            var localSum = 0;
            for (int i = 0; i < len / ThreadCount; i++)
            {
                var l = i * ThreadCount + x;
                localSum += l;
                array[l] = localSum;
            }

        };

        RunThreads(f);

        return array[^1];
    }

    [Benchmark(Description = "Threads write far from each other")]
    public int BenchWriteFar()
    {
        Action<int> f = x =>
        {
            var len = array.Length;
            var localSum = 0;
            for (int i = len / ThreadCount * x; i < len / ThreadCount * (x + 1); i++)
            {
                localSum += i;
                array[i] = localSum;
            }
            
        };

        RunThreads(f);

        return array[^1];
    }
}