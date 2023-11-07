using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    public static async Task<long> CalculateAsync(int n, CancellationToken token)
    {
        long sum = 0;

        for (var i = 0; i < n; i++)
        {
            // i + 1 is to allow 2147483647 (Max(Int32))
            sum = sum + (i + 1);

            try
            {
                var wh = token.WaitHandle;

                await Task.Delay(10, token);
            }
            catch(ObjectDisposedException)
            {
                NotifyCalculationProcessCanceled(n);
                throw new OperationCanceledException("The operation cancelled because of CancellationTokenSource disposed.", token);
            }

            if (token.IsCancellationRequested)
            {
                NotifyCalculationProcessCanceled(n);
                token.ThrowIfCancellationRequested();
            }
        }

        return sum;
    }

    private static void NotifyCalculationProcessCanceled(int n)
    {
        Console.WriteLine($"Calculation CANCELLED for n={n}");
    }
}
