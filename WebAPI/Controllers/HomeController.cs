using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Data;
using WebAPI.Data.Model;
using WebAPI.Data.ViewModel;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet("Get-AllEmployee")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var employees = _appDbContext.Employees.ToList();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Timeout occurred.");
                //throw;
                return BadRequest(ModelState);
            }
        }

        [HttpGet("Get-EmployeeById/{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Employee emp = _appDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost("Add-NewUser")]
        [Authorize]
        public IActionResult Create(EmployeeVM emp)
        {
            var _employee = new Employee()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                EmailId = emp.EmailId,
                UserName = emp.UserName,
                Password    = emp.Password
            };

            _appDbContext.Employees.Add(_employee);
            _appDbContext.SaveChanges();
            return Ok();
        }


        [HttpPut("Update-EmployeeByID/{Empid}")]
        [Authorize]
        public IActionResult Update(int Empid , EmployeeVM emp)
        {
            if(Empid == 0)
            {
                return BadRequest();
            }
            else
            {
                var _emp = _appDbContext.Employees.FirstOrDefault(x => x.Id == Empid);
                if (_emp !=null)
                {
                    _emp.FirstName = emp.FirstName;
                    _emp.LastName = emp.LastName;
                    _emp.EmailId = emp.EmailId;
                    _emp.UserName = emp.UserName;
                    _emp.Password = emp.Password;

                    _appDbContext.SaveChanges();
                    return Ok(_emp);
                }
                else
                {
                    return NotFound();
                }
                
            }
        }

        [HttpDelete("Delete-EmployeeById/{Empid}")]
        [Authorize]
        public IActionResult Delete(int Empid)
        {
            if(Empid < 0 || Empid.ToString() == null)
            {
                return BadRequest();
            }
            else
            {
                Employee _emp = _appDbContext.Employees.FirstOrDefault(emp => emp.Id == Empid);
                if(_emp != null)
                {
                    _appDbContext.Employees.Remove(_emp);
                    _appDbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
                
            }
        }
    }
}
