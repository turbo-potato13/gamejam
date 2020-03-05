using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using System.IO;
using System.Text.RegularExpressions;

public class PuzzleManager : MonoBehaviour
{

	[SerializeField] TMP_Text	consoleOutput;

	[SerializeField] GameObject console;

	[SerializeField] GameObject gameMenu;

	[SerializeField] int puzzleNum = 0;

	public static bool isWriteToFile = false;
	static string fileToWrite = string.Empty;
	static string textToWrite = string.Empty;

	bool goToNextLevel = false;
	// Start is called before the first frame update
	void Start()
	{
		string[] files = Directory.GetFiles("./", @"*.gf");
		foreach (string file in files)
		{
			Debug.Log(file);
			File.Delete(file);
		}
		consoleOutput.text += "Error. Can't load StartMenu. File not found. Type help.\n";
	}

	// Update is called once per frame
	void Update()
	{
		if (goToNextLevel)
		{
			goToNextLevel = false;
			puzzleNum++;
			if (puzzleNum == 1)
			{
				console.SetActive(false);
				gameMenu.SetActive(true);
			}
		}
		if (puzzleNum == 0)
		{
			//console.text += "Error. Can't load file level1. \n";
			// if (File.Exists("./level1.gf"))
			// {
			// 	string pattern =  @"^\s+loadData\s+level1$";
			// 	string text = File.ReadAllText("./level1.gf");
			// 	Match m = Regex.Match(text, pattern);
			// 	if (m.Success)
			// 	{
			// 		console.text += "load menu here\n";

			// 	}
			// 	else
			// 	{
			// 		console.text += "Error. Can't load file level1. \n";
			// 	}
			// }
		}
		if (puzzleNum == 1)
		{

		}
	}

	public void commandParser(string command)
	{
		//Debug.Log(c)
		//delete spaces from string
		command = command.Trim();

		//find first space to split on command and args
		int firstSpace = command.IndexOf(" ");

		Debug.Log(firstSpace);

		string commandName;
		string commandArgs;

		//if no spaces then there is command with no arggs
		if (firstSpace == -1)
		{
			commandName = command;
			commandArgs = string.Empty;
		}
		//else take two substrings
		else
		{
			commandName = command.Substring(0, firstSpace);
			commandArgs = command.Substring(firstSpace + 1).Trim();
		}

		Debug.Log("command: " + commandName);
		Debug.Log("args: " + commandArgs);

		if (isWriteToFile)
		{
			if (command == ":wq")
			{
				Debug.Log("Save to file" + fileToWrite);
				isWriteToFile = false;
				File.WriteAllText("./" + fileToWrite + ".gf", textToWrite);
			}
			else
				textToWrite += command + "\n";
		}
		else if (commandName == "help")
		{
			if (string.IsNullOrEmpty(commandArgs))
			{ consoleOutput.text += "use help for more info";
				consoleOutput.text += "If you don't know what to do use help\n";
				consoleOutput.text += "commands:\n";
				consoleOutput.text += " help\n";
				consoleOutput.text += " getAllFiles\n";
				consoleOutput.text += " getFileContent\n";
				consoleOutput.text += " createFile\n";
				consoleOutput.text += " writeToFile\n";
				consoleOutput.text += " loadScene\n";
				consoleOutput.text += " loadData\n";
			}
			else
			{
				if (commandArgs == "help")
				{
					consoleOutput.text += "help - list all commands\n";
					consoleOutput.text += "help %command% - get %command%  description\n";
				}
				else if (commandArgs == "getAllFiles")
				{
					consoleOutput.text += "getAllFiles - list all game files\n";
				}
				else if (commandArgs == "getFileContent")
				{
					consoleOutput.text += "getFileContent %file name%- output content from %file name%\n";
				}
				else if (commandArgs == "createFile")
				{
					consoleOutput.text += "createFile %file name% - create file named %file name%\n";
				}
				else if (commandArgs == "writeToFile")
				{
					consoleOutput.text += "writeToFile %file name% - write to %file name% file\n";
				}
				else if (commandArgs == "loadScene")
				{
					consoleOutput.text += "loadScene %scene name% - load %scene name% scene\n";
				}
				else if (commandArgs == "loadData")
				{
					consoleOutput.text += "loadData %scene name% - load data for %scene name%\n";
				}
			}
		}
		//Solving first puzzle with this command
		else if (commandName == "loadScene")
		{
			if (string.IsNullOrEmpty(commandArgs))
			{ consoleOutput.text += "use help for more info";
				consoleOutput.text += "error\n";
			}
			else
			{
				if (commandArgs == "StartMenu")
				{	
					if (File.Exists("./StartMenu.gf"))
					{
						string pattern =  @"^(\/\/.*\n)*\s*loadData\s*StartMenu(\/\/.*)*$";
						string text = File.ReadAllText("./StartMenu.gf");
						Match m = Regex.Match(text, pattern);
						if (m.Success)
						{
							goToNextLevel = true;
							//consoleOutput.text += "we solve the puzzle\n";
						}
						else
						{
							consoleOutput.text += "Error. Can't load StartMenu. Data not loaded.\n";
						}
					}
					else
					{
						consoleOutput.text += "Error. Can't load StartMenu. File not found. \n";
					}
				}
			}
		}
		else if (commandName == "getAllFiles")
		{
			string pattern = @"^\.\/(.*)\.gf$";
			string[] allFiles = Directory.GetFiles("./", "*.gf");
			Debug.Log("Command: getAllFiles");
			consoleOutput.text += "StartGame\n";
			foreach (var file in allFiles)
			{
				Match m = Regex.Match(file, pattern);
				if (m.Success)
				{
					GroupCollection groups = m.Groups;
					Debug.Log(groups[0].Value);
					Debug.Log(groups[1].Value);
					consoleOutput.text += groups[1].Value + "\n";
				}
				else
				{
					Debug.Log("Error\n");
				}
			}
		}
		else if (commandName == "getFileContent")
		{
			if (string.IsNullOrEmpty(commandArgs))
			{ consoleOutput.text += "use help for more info";
				Debug.Log("Incorrect command 1");
			}
			else
			{
				if (commandArgs == "StartGame")
				{
					consoleOutput.text += "if (sceneLoaded StartMenu)\n" +
										"//load data before loading scene\n" +
										"\tloadData StartGame\n" +
									"else\n" +
										"\tprintError\n";
				}
				else if (File.Exists("./" + commandArgs + ".gf"))
				{
					string[] text = File.ReadAllLines("./" + commandArgs + ".gf");
					foreach (string line in text)
					{
						consoleOutput.text += line;
					}
				}
				else
				{
					//Color32 oldColor = console.color;
					//console.color = new Color32(255, 0, 0, 255);
					consoleOutput.text += "λ> Error\n";
					//console.color = oldColor;
				}
			}
		}
		else if (commandName == "createFile")
		{
			Debug.Log("Command: createFile");
			if (string.IsNullOrEmpty(commandArgs))
			{ consoleOutput.text += "use help for more info";
				Debug.Log("Incorrect command 1");
			}
			else if (commandArgs == "StartGame")
			{
				consoleOutput.text += "Error. File already exists\n";
			}
			else
			{
				if (File.Exists("./" + commandArgs + ".gf"))
				{
					consoleOutput.text += "Error. File already exists\n";
					Debug.Log("Incorrect command 2");
				}
				else
				{
					Debug.Log("File to create: " + "./" + commandArgs + ".gf");
					File.Create("./" + commandArgs + ".gf");
				}	
			}
		}
		else if (commandName == "writeToFile")
		{
			Debug.Log("Command: writeToFile");
			if (string.IsNullOrEmpty(commandArgs))
			{ consoleOutput.text += "use help for more info";
				Debug.Log("Error no args");
			}
			else if (commandArgs == "StartGame")
			{
				consoleOutput.text += "λ> Error. File already using.\n";
			}
			else
			{
				if (!File.Exists("./" + commandArgs + ".gf"))
				{
					consoleOutput.text += "λ> Error. File not found.\n";
				}
				else
				{
					isWriteToFile = true;
					fileToWrite = commandArgs;
					textToWrite = string.Empty;
					consoleOutput.text += "Write to file: " + commandArgs + ". :wq - save&exit\n\n";
					Debug.Log("Write to File" + commandArgs);
				}
			}
		}
		else
		{
			Debug.Log("Incorrect command");
		}
	}
}
