using System;
using System.Threading;

public class Program {
	
	// class for sharing resources between threads
	private class ThreadHandler {
		public bool Alive;
		public char CurrentCharacter;
		public char SubmiteAbleCharacter;
	}
	
	private ThreadHandler threadHandler;
	
	public static void main(string[] args)
	{
		// Create Thread Object
		threadHandler = new ThreadHandler();
		threadHandler.Alive = true;
		threadHandler.CurrentCharacter = '*';
		
		// Create Threads
		Thread inputThread = new Thread();
		Thread outPutThread = new Thread();
		
		// Start threads
		inputThread.Start(currentChar);
		outPutThread.Start(currentChar);
		
		// Wait for input thread to end
		inputThread.Join();
	}
	
	// Method which loops until user presses escape
	// Checks for input
	private static void InputListener(object cInfo)
	{
		// Cast object as thread object
		ThreadHandler thandler = cinfo as ThreadHandler;
		if (thandler == null)
			return;
		
		// create console info object
		ConsoleKeyInfo info = new ConsoleKeyInfo();
		
		// Loop while all the threads are still alive
		while (cInfo.Alive)
		{
			info = Console.ReadKey();
			
			thandler.SubmiteAbleCharacter = info.KeyChar;
			
			// Check if enter key was pressed change the character
			if (info.Key == ConsoleKey.Enter)
				thandler.CurrentCharacter = thandler.SubmiteAbleCharacter;
			
			// Kill loop if user pressed escape key
			if (info.Key == ConsoleKey.Escape)
				cInfo.Alive = false;
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
		while (cInfo.Alive)
		{
			Console.Write(thandler.CurrentCharacter);
		}
	}
}