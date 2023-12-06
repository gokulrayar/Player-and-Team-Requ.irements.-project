using System;
using System.Collections.Generic;
using static Player_and_Team_Requirements.onedayteam;
using static Player_and_Team_Requirements.player;

namespace Player_and_Team_Requirements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam oneDayTeam = new OneDayTeam();
            string again;

            do
            {
                Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3: Get Player By Id 4: Get Player by Name 5: Get All Players");
                int choice;

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Player details:");
                        Console.Write("Player Id: ");
                        int playerId = GetValidIntegerInput();

                        Console.Write("Player Name: ");
                        string playerName = Console.ReadLine();

                        Console.Write("Player Age: ");
                        int playerAge = GetValidIntegerInput();

                        Player newPlayer = new Player { PlayerId = playerId, PlayerName = playerName, PlayerAge = playerAge };
                        oneDayTeam.Add(newPlayer);
                        break;

                    case 2:
                        Console.Write("Enter Player Id to remove: ");
                        int removePlayerId = GetValidIntegerInput();
                        oneDayTeam.Remove(removePlayerId);
                        break;

                    case 3:
                        Console.Write("Enter Player Id to get details: ");
                        int getPlayerById = GetValidIntegerInput();
                        Player playerById = oneDayTeam.GetPlayerById(getPlayerById);
                        DisplayPlayerDetails(playerById);
                        break;
                         
                    case 4:
                        Console.Write("Enter Player Name to get details: ");
                        string getPlayerByName = Console.ReadLine();
                        Player playerByName = oneDayTeam.GetPlayerByName(getPlayerByName);
                        DisplayPlayerDetails(playerByName);
                        break;

                    case 5:
                        List<Player> allPlayers = oneDayTeam.GetAllPlayers();
                        Console.WriteLine("All Players:");
                        foreach (var player in allPlayers)
                        {
                            DisplayPlayerDetails(player);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.Write("Do you want to Continue? (Yes/No): ");
                again = Console.ReadLine();
            }
            while (again.Equals("Yes", StringComparison.OrdinalIgnoreCase));

            Console.ReadKey();
        }

        private static int GetValidIntegerInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return input;
        }

        private static void DisplayPlayerDetails(Player player)
        {
            if (player != null)
            {
                Console.WriteLine($"Player Id: {player.PlayerId}, Player Name: {player.PlayerName}, Player Age: {player.PlayerAge}");
            }
            else
            {
                Console.WriteLine("Player not found.");
            }
        }
    }
}
