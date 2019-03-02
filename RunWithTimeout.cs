using System;
using System.Threading;

public static class Program
{
	public static int LongRunningMethod(int parameter)
	{
		Thread.Sleep(TimeSpan.FromSeconds(2));
		Console.WriteLine("[LONG RUNNING METHOD EXECUTED]");
		return parameter * 10;
	}

	public static void Main(string[] args)
	{
		var result = 0;

		if (RunWithTimeout(() => result = LongRunningMethod(10), TimeSpan.FromSeconds(1)))
		{
			Console.WriteLine($"[SUCCESS]: {result}");
		}
		else
		{
			Console.WriteLine($"[ABORT]: {result}");
		}

		Console.ReadKey();
	}

	public static bool RunWithTimeout(Action action, TimeSpan timeout)
	{
		var thread = new Thread(action.Invoke);

		thread.Start();

		var terminated = thread.Join(timeout);

		if (!terminated) { thread.Abort(); }

		return terminated;
	}
}
