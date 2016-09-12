using System;
using System.Diagnostics;
using System.Collections;
using System.Windows.Input;
using System.Collections.Generic;
namespace getGit
{
	class MainClass
	{
		public static string command;
		public static String repo;
		public static String dir;

		public static void Main (string[] args)
		{
			Setup ();
			while (true) {
				if (getChoice () == "2") {
					Console.Clear ();
					setup4Linux ();
					setupCore ();
					get4Linux ();

				} else if (getChoice () == "1") {
					Console.WriteLine ("gG for windows isn't available yet!");
					Console.Clear ();
					Setup ();
				} 
				  else if (getChoice ()== "3") {
					Console.Clear ();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("gG is an Open-Source app made by Ahmed I. Elsayed ");
					Console.WriteLine ("If you want a feature, or wanna submit a bug");
					Console.WriteLine ("drop me here ahmeddark369@gmail.com");
				} else {
					Console.Clear ();
					Setup ();
				}
			}
		}
		public static string getChoice()
		{
			string choice;
			choice = Console.ReadLine ();
			return choice;
		}
		public static void Setup()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("getGit v0.1");	
			Console.WriteLine ();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Choose your operating system!");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("   - Windows (1) -SOON-");
			Console.WriteLine ("   - Linux (2)");
			Console.WriteLine ();
			Console.WriteLine ("Credits (3)");
		}
		public static void setupCore ()
		{
			setupDir ();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine ("Enter the repo");
			setupRepo ();
			
		}
		public static void setupRepo(){
			repo = Console.ReadLine ();
			if (repo.Contains ("git") == false){
				
				Console.WriteLine ("Enter a valid repo");
				setupRepo ();
			}
			if (repo.Contains (".com") == false) {
				Console.WriteLine ("Enter a valid repo");
				setupRepo ();
			}
		}
		public static void setupDir(){
			Console.WriteLine ();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("   Where to save your files?");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine ("============================================================================");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Your directory needs to be a NON-EXISTING folder, Otherwise it won't work");
			Console.WriteLine ("or just LEAVE IT EMPTY & We will sort it out!");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine ("============================================================================");
			dir = Console.ReadLine ();
		}
		public static void setup4Win()
		{
		 //	Console.ForegroundColor = ConsoleColor.Red;
		 //	Console.WriteLine ("getGit for Windows");
		}
		public static void setup4Linux()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("getGit for Linux");
		}
		public static bool get4Linux ()
		{
			
			if (dir == "" | dir == "home" | dir == "Home") {
				dir = "/output";
			}
			if (repo.Contains ("tree/master")) {
				repo = repo.Replace ("tree/master", "trunk");
				//  Console.WriteLine ("DEBUG --> " + repo);
			}
			command = "svn export " + repo + " " + dir;
			Process terminal = new System.Diagnostics.Process ();
			terminal.StartInfo.FileName = "/bin/bash";
			terminal.StartInfo.Arguments = "-c \" " + command + " \"";
			terminal.StartInfo.UseShellExecute = false;
			terminal.StartInfo.RedirectStandardOutput = true;
			terminal.Start ();
			while (!terminal.StandardOutput.EndOfStream) {
				Console.WriteLine (terminal.StandardOutput.ReadLine ());
			}
			if (!terminal.StandardOutput.BaseStream.ToString ().Contains ("Permission denied")) {
				Console.WriteLine ("Run as sudo or put gitGet in home folder");
				return false;
			} else {
				Console.WriteLine ("You will find your files in the new directory " + dir);
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Congratulations!");
				return true;
			}
		}
	}
}
