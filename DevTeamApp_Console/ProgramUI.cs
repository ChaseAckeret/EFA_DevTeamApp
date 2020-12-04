using DevTeam_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamApp_Console
{
    class ProgramUI
    {
       private DeveloperRepo _developerRepo = new DeveloperRepo();
       private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        
       public void Run()
       {
            Menu(); 
       }
       // Menu Methods
       private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1: Developer Menu\n" +
                    "2: Team Menu\n" +
                    "3: Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        TeamMenu();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
       private void TeamMenu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1: Add new team\n" +
                    "2: View all teams\n" +
                    "3: View team by ID\n" +
                    "4: Add developer to team\n" +
                    "5: Remove developer from team\n" +
                    "6: Delete existing team.\n" +
                    "7: Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewTeam();
                        break;
                    case "2":
                        ViewAllTeams();
                        break;
                    case "3":
                        ViewTeamById();
                        break;
                    case "4":
                        AddDevToTeam();
                        break;
                    case "5":
                        RemoveDevFromTeam();
                        break;
                    case "6":
                        DeleteExistingTeam();
                        break;
                    case "7":
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
       private void DeveloperMenu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1: Add new developer\n" +
                    "2: View all developers\n" +
                    "3: View developer by ID\n" +
                    "4: Update existing developer\n" +
                    "5: Delete existing developer\n" +
                    "6: Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewDev();
                        break;
                    case "2":
                        DisplayAllDev();
                        break;
                    case "3":
                        DisplayDevById();
                        break;
                    case "4":
                        UpdateExistingDev();
                        break;
                    case "5":
                        DeleteExistingDev();
                        break;
                    case "6":
                        Console.Clear();
                        Menu(); 
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
       //Create
       private void AddNewDev()
        {
            Console.Clear();
            //Name
            Console.WriteLine("Enter developer's name:");
            string name = Console.ReadLine();

            //Has Pluralsight Access
            Console.WriteLine("Does developer have access to Pluralsight? (y/n)");
            string pluralsightString = Console.ReadLine().ToLower();
            bool hasPluralsightAccess;
            if (pluralsightString == "y")
            {
                hasPluralsightAccess = true;
            }
            else
            {
                hasPluralsightAccess = false;
            }

            _developerRepo.AddDeveloperToList(name, hasPluralsightAccess);
        }
       private void AddNewTeam()
        {
            Console.Clear();
            //Name
            Console.WriteLine("Enter team name:");
            string name = Console.ReadLine();

            DevTeam newTeam = new DevTeam();
            newTeam.TeamName = name;

            _devTeamRepo.AddTeamToList(newTeam);
        }
       //Read
       private void DisplayAllDev()
        {
            Console.Clear();
            List<Developer> developerList = _developerRepo.GetDeveloperList();

            foreach(Developer dev in developerList)
            {
                Console.WriteLine($"ID: {dev.Id}, Name: {dev.Name}, PluralSight: {dev.HasPluralsightAccess}");
            }
        }
       private void DisplayDevById()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the developer you'd like to see:");
            int id = Int16.Parse(Console.ReadLine());

            Developer developer = _developerRepo.GetDeveloperById(id);

            if(developer != null)
            {
                Console.WriteLine($"ID: {developer.Id}, Name: {developer.Name}, Has Pluralsight Access: {developer.HasPluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No developer by that ID.");
            }
        }
       private void ViewAllTeams()
        {
            Console.Clear();
            List<DevTeam> devTeamList = _devTeamRepo.GetTeamList();

            foreach (DevTeam team in devTeamList)
            {
                Console.WriteLine($"ID: {team.TeamId}, Name: {team.TeamName}");
            }
        }
       private void ViewTeamById()
        {
            Console.Clear();
            ViewAllTeams();
            Console.WriteLine("\nEnter the ID of the team you'd like to see:");
            int id = Int16.Parse(Console.ReadLine());

            DevTeam team = _devTeamRepo.GetTeamById(id);

            if (team != null)
            {
                Console.WriteLine($"ID: {team.TeamId}, Name: {team.TeamName}");
                foreach (var item in team.Developer)
                {
                    Console.WriteLine($"Members:{ item.Name}" );
                }
            }
            else
            {
                Console.WriteLine("No team by that ID.");
            }
        }
       //Update
       private void UpdateExistingDev()
        {
            DisplayAllDev();

            Console.WriteLine("Enter the ID of the developer you'd like to update.");

            int oldId = Int16.Parse(Console.ReadLine());

            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the ID of the developer.");
            newDeveloper.Id = Int16.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the developer.");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Does this developer have Pluralsight Access? (y/n)");
            string hasPluralsightString= Console.ReadLine().ToLower();
            if(hasPluralsightString == "y")
            {
                newDeveloper.HasPluralsightAccess = true;
            }
            else
            {
                newDeveloper.HasPluralsightAccess = false;
            }
            bool wasUpdated = _developerRepo.UpdateExistingDevelopers(oldId, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }
        }
       private void AddDevToTeam()
        {
            DisplayAllDev();

            Console.WriteLine("\nEnter the ID of the developer you would like to add to a team.");
            string input = Console.ReadLine();
            int devId = Int16.Parse(input);
            Console.Clear();

            ViewAllTeams();

            Console.WriteLine("\nEnter the ID of the team you would like to add the developer to.");
            input = Console.ReadLine();
            int teamId = Int16.Parse(input);

            Developer dev =_developerRepo.GetDeveloperById(devId);
            DevTeam team = _devTeamRepo.GetTeamById(teamId);

            team.Developer.Add(dev);
        }
       //Delete
       private void DeleteExistingDev()
        {
            DisplayAllDev();

            Console.WriteLine("\nEnter the ID of the developer you'd like to remove.");
            string inputAsString = Console.ReadLine();
            int input = Int16.Parse(inputAsString);

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
            }
        }
       private void RemoveDevFromTeam()
        {
            DisplayAllDev();

            Console.WriteLine("\nEnter the ID of the Developer you would like to remove.");
            string input = Console.ReadLine();
            int devId = Int16.Parse(input);
            Console.Clear();

            ViewAllTeams();

            Console.WriteLine("\nEnter the ID of the team you would like to remove the developer from.");
            input = Console.ReadLine();
            int teamId = Int16.Parse(input);

            Developer dev = _developerRepo.GetDeveloperById(devId);
            DevTeam team = _devTeamRepo.GetTeamById(teamId);

            team.Developer.Remove(dev);  
        }
       private void DeleteExistingTeam()
        {
            ViewAllTeams();

            Console.WriteLine("\nEnter the ID of the team you'd like to remove.");
            string input = Console.ReadLine();
            int teamId = Int16.Parse(input);

            bool wasDeleted = _devTeamRepo.RemoveTeamFromList(teamId);

            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The team could not be deleted.");
            }
        }
    }
}
