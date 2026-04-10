using Asana2.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana2.Library.Services
{
    public class ProjectServiceProxy
    {
        private List<Project> _projectList;

        public List<Project> Projects
        {
            get
            {
                return _projectList;
            }
            private set
            {
                if (value != _projectList)
                {
                    _projectList = value ?? new List<Project>();
                }
            }
        }

        private ProjectServiceProxy()
        {
            Projects = new List<Project>{
            new Project { Id = 1, Name = "Project 1", Description = "My Project 1", Priority=5},
            new Project { Id = 2, Name = "Project 2", Description = "My Project 2", Priority=4},
            new Project { Id = 3, Name = "Project 3", Description = "My Project 3", Priority=3},
            new Project { Id = 4, Name = "Project 4", Description = "My Project 4", Priority=2},
            new Project { Id = 5, Name = "Project 5", Description = "My Project 5", Priority=1}
            };
        }

        private static ProjectServiceProxy? instance;

        public static ProjectServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectServiceProxy();
                }
                return instance;
            }
        }
        private int nextKey
        {
            get
            {
                if (Projects.Any())
                {
                    return Projects.Select(p => p.Id).Max() + 1;
                }
                return 1;
            }
        }
        public void AddOrUpdateProject(Project? project)
        {
            if (project != null && project.Id == 0)
            {
                project.Id = nextKey;
                _projectList.Add(project);
            }
        }

        public void DeleteProject(Project? project)
        {
            if (project != null)
            {
                _projectList.Remove(project);
            }
            return;
        }

        public void ListProjects()
        {
            Projects.ForEach(Console.WriteLine);
        }

        public void ListProjectToDos(List<ToDo> toDos)
        {
            Console.WriteLine("Which Project's ToDos to List: ");
            var projectChoice = int.Parse(Console.ReadLine() ?? "0");

            foreach (var toDo in toDos)
            {
                if (toDo.ProjectId == projectChoice)
                {
                    Console.WriteLine(toDo);
                }
            }
        }
        public Project? GetById(int id)
        {
            return Projects.FirstOrDefault(p => p.Id == id);
        }

        public async Task ExportToFileAsync(string filePath)
        {
            var json = JsonConvert.SerializeObject(Projects, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task ImportFromFileAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var loaded = JsonConvert.DeserializeObject<List<Project>>(json);
                Projects = loaded ?? new List<Project>();
            }
        }
    }
}
