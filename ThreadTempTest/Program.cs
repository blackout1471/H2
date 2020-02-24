using System;
using System.Threading;
					
public class Program
{
	// class for sharing resources between threads
	private class AlarmThread
	{
		public Random Rnd;
		public int Count;
	};
	
	
	public static void Main()
	{
		// Create new thread resource
		AlarmThread threadStruct = new AlarmThread();
		threadStruct.Rnd = new Random();
		threadStruct.Count = 0;
		
		// Create thread
		Thread alarm = new Thread(Alarming);
		alarm.Start(threadStruct);
		
		// Loop and check if thread is still alive
		while (alarm.IsAlive)
		{
			Console.WriteLine("Alarm thread is alive");
			
			Thread.Sleep(10000);	
		}
	}
	
	// Alarm thread method used to generate new temps
	private static void Alarming(object threadStruct)
	{
		// Cast object to thread object
		AlarmThread s = threadStruct as AlarmThread;
		if (s == null)
			return;
		
		// Loop for 3 tries
		while (s.Count != 3) {
			
			int temp = (int)s.Rnd.Next(-20, 120);

			Console.WriteLine("Temp is " + temp);

			if (temp < 0 || temp > 100)
			{
				Console.WriteLine("Alarm temp");
				s.Count++;
			}

			Thread.Sleep(2000);
		}
	}
}