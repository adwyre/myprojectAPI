using MyProjectAPI.Data;
using Microsoft.AspNetCore.Mvc;
using MyProjectAPI.Models;
using MyProjectAPI.Dtos;

namespace MyProjectAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    DataContextDapper _dapper;
    public ProjectController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }
    
    [HttpGet("GetAllProjects")]
    public IEnumerable<Project> GetAllProjects()
    {
        string sql = "SELECT * FROM ProjectManagerSchema.Projects";
        IEnumerable<Project> projects = _dapper.LoadData<Project>(sql);
        return projects;

    }

    [HttpGet("GetProject/{Id}")]
    public Project GetProject(int Id)
    {
        string sql = "SELECT * FROM ProjectManagerSchema.Projects WHERE Id = " + Id.ToString(); 
        Project project = _dapper.LoadDataSingle<Project>(sql);
        return project;
    }
    
    [HttpPut("EditProject/{Id}")]
    public IActionResult EditProject(Project project)
    {
        string sql = @"
        UPDATE ProjectManagerSchema.Projects
            SET [Title] = '" + project.Title + 
                "', [Tag] = '" + project.Tag +
                "', [Description] = '" + project.Description + 
                "', [Status] = '" + project.Status + 
                "', [Priority] = '" + project.Priority + 
                "', [StartDate] = '" + project.StartDate + 
                "', [DueDate] = '" + project.DueDate + 
                "', [Completed] = '" + project.Completed + 
            "' WHERE Id = " + project.Id;
        
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } 

        throw new Exception("Failed to Update Project");
    }


    [HttpPost("AddProject")]
    public IActionResult AddProject(ProjectToAdd project)
    {
        string sql = @"INSERT INTO ProjectManagerSchema.Projects(
                [Title],
                [Tag],
                [Description],
                [Status],
                [Priority],
                [StartDate],
                [DueDate],
                [Completed]
            ) VALUES (" +
                "'" + project.Title + 
                "', '" + project.Tag +
                "', '" + project.Description + 
                "', '" + project.Status + 
                "', '" + project.Priority + 
                "', '" + project.StartDate + 
                "', '" + project.DueDate + 
                "', '" + project.Completed + 
            "')";
        
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } 

        throw new Exception("Failed to Add Project");
    }

    [HttpDelete("DeleteProject/{Id}")]
    public IActionResult DeleteProject(int Id)
    {
        string sql = "DELETE FROM ProjectManagerSchema.Projects WHERE Id = " + Id.ToString();
        
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } 

        throw new Exception("Failed to Delete Project");
    }
    
}