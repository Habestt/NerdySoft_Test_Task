using Microsoft.AspNetCore.Mvc;
using NerdySoft_Test_Task.EF;
using NerdySoft_Test_Task.Entities;
using NerdySoft_Test_Task.Interfaces;
using NerdySoft_Test_Task.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace NerdySoft_Test_Task.Controllers
{
    [ApiController]
    public class AnnouncementControllerTest : ControllerBase
    {
        //UnitOfWork Database { get; set; }
        UnitOfWork _context { get; set; }

        public AnnouncementControllerTest(UnitOfWork context)
        {
            _context = context;
        }


        [HttpGet("api/GetAll")]
        public IActionResult GetAllAnnouncements()
        {
            IEnumerable<Announcement> announcements;
            try
            {
                //announcements = Database.Announcements.GetAll();
                announcements = _context.Announcements.GetAll();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(announcements);
        }

        [HttpPut("api/Create")]
        public IActionResult CreateAnnouncement(Announcement announcements)
        {
            try
            {
                _context.Announcements.Create(announcements);
                //Database.Announcements.Create(announcements);
                _context.Save();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(new { Message = "Test was successfully created!" });
        }
    }
}