using MyProjectAPI.Data;
using Microsoft.AspNetCore.Mvc;

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
    
    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }
}