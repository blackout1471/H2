using System;
using System.Threading;

public class Program
{

	// class for sharing resources between threads
	private class ThreadHandler
	{
		public bool Alive;
		public char CurrentCharacter;
		public char SubmiteAbleCharacter;
	}

	public static void Main(string[] args)
	{
		// Create Thread Object
		ThreadHandler threadHandler = new ThreadHandler();
		threadHandler.Alive = true;
		threadHandler.CurrentCharacter = '*';

		// Create Threads
		Thread inputThread = new Thread(InputListener);
		Thread outPutThread = new Thread(CharacterPrinter);

		// Start threads
		inputThread.Start(threadHandler);
		outPutThread.Start(threadHandler);

		// Wait for input thread to end
		inputThread.Join();
	}

	// Method which loops until user presses escape
	// Checks for input
	private static void InputListener(object cInfo)
	{
		// Cast object as thread object
		ThreadHandler thandler = cInfo as ThreadHandler;
		if (thandler == null)
			return;

		// create console info object
		ConsoleKeyInfo info = new ConsoleKeyInfo();

		// Loop while all the threads are still alive
		while (thandler.Alive)
		{
			info = Console.ReadKey();

			// Check if enter key was pressed change the character
			if (info.Key == ConsoleKey.Enter)
				thandler.CurrentCharacter = thandler.SubmiteAbleCharacter;
			else
				thandler.SubmiteAbleCharacter = info.KeyChar;

			// Kill loop if user pressed escape key
			if (info.Key == ConsoleKey.Escape)
				thandler.Alive = false;
		}
	}

	// Just a method which loops and prints the current character
	private static void CharacterPrinter(object cInfo)
	{
		// Cast object
		ThreadHandler thandler = cInfo as ThreadHandler;
		if (thandler == null)
			return;

		// Print current character as long as threads are alive
		while (thandler.Alive)
		{
			Console.Write(thandler.CurrentCharacter);
		}
	}
}