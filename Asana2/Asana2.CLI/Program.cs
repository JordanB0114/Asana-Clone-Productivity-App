using Asana2.Library.Models;
using Asana2.Library.Services;
using System;

namespace Asana2
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var toDoSvc = ToDoServiceProxy.Current;
            var projectSvc = ProjectServiceProxy.Current;
            var choiceInt = 0;
            do
            {
                Console.WriteLine("Choose a menu option: ");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. List all ToDos");
                Console.WriteLine("3. List all outstanding ToDos");
                Console.WriteLine("4. Delete a ToDo");
                Console.WriteLine("5. Update a ToDo");
                Console.WriteLine("6. Create a Project");
                Console.WriteLine("7. Delete Project");
                Console.WriteLine("8. Update a Project");
                Console.WriteLine("9. List all Projects");
                Console.WriteLine("10. List all ToDos of a projecta");
                Console.WriteLine("11. Exit");








                var choice = Console.ReadLine() ?? "11";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1:
                            Console.WriteLine("Name: ");
                            var name = Console.ReadLine();
                            Console.WriteLine("Description: ");
                            var description = Console.ReadLine();
                            Console.WriteLine("Project Id: ");
                            var projectid = int.Parse(Console.ReadLine() ?? "0");

                            toDoSvc.AddOrUpdate(new ToDo
                            {
                                Name = name,
                                Description = description,
                                IsCompleted = false,
                                Id = 0,
                                ProjectId = projectid
                            }, projectSvc.Projects);
                            break;

                        case 2:
                            toDoSvc.DisplayToDos(true);
                            break;

                        case 3:
                            toDoSvc.DisplayToDos();
                            break;

                        case 4:
                            toDoSvc.DisplayToDos(true);
                            Console.WriteLine("Which ToDo to Delete: ");
                            var toDoChoice = int.Parse(Console.ReadLine() ?? "0");

                            var reference = toDoSvc.GetById(toDoChoice);                            
                            toDoSvc.DeleteToDo(reference);
                            break;

                        case 5:
                            toDoSvc.DisplayToDos(true);
                            Console.WriteLine("Which ToDo to update: ");
                            var toDoChoice5 = int.Parse(Console.ReadLine() ?? "0");
                            var updateReference = toDoSvc.GetById(toDoChoice5);

                            if (updateReference != null)
                            {
                                Console.WriteLine("Name: ");
                                updateReference.Name = Console.ReadLine();
                                Console.WriteLine("Description: ");
                                updateReference.Description = Console.ReadLine();
                            }
                            toDoSvc.AddOrUpdate(updateReference, projectSvc.Projects);
                            break;

                        case 6:
                            Console.WriteLine("Name of Project: ");
                            var projectName = Console.ReadLine();
                            Console.WriteLine("Description: ");
                            var projectDescription = Console.ReadLine();



                            projectSvc.AddOrUpdateProject(new Project
                            {
                                Name = projectName,
                                Description = projectDescription,
                                CompletePercent = 0,
                                Id = 0
                            });
                            break;

                        case 7:
                            projectSvc.ListProjects();
                            Console.WriteLine("Which Project to Delete: ");
                            var projectChoice1 = int.Parse(Console.ReadLine() ?? "0");

                            var projectReference = projectSvc.GetById(projectChoice1);
                            projectSvc.DeleteProject(projectReference);
                            break;

                        case 8:
                            projectSvc.ListProjects();
                            Console.WriteLine("Which Project to update: ");
                            var projectChoice2 = int.Parse(Console.ReadLine() ?? "0");
                            var projectUpdateReference = projectSvc.GetById(projectChoice2);

                            if (projectUpdateReference != null)
                            {
                                Console.WriteLine("Name: ");
                                projectUpdateReference.Name = Console.ReadLine();
                                Console.WriteLine("Description: ");
                                projectUpdateReference.Description = Console.ReadLine();
                            }
                            projectSvc.AddOrUpdateProject(projectUpdateReference);
                            break;

                        case 9:
                            projectSvc.ListProjects();
                            break;

                        case 10:
                            projectSvc.ListProjectToDos(toDoSvc.ToDos);
                            break;

                        case 11:
                            break;

                        default:
                            Console.WriteLine("Error: unknown menu selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {choice} is not valid");
                }
            } while (choiceInt != 11);
        }
    }
}

