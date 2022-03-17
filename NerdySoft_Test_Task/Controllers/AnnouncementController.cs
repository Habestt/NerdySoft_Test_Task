using Microsoft.AspNetCore.Mvc;
using NerdySoft_Test_Task.EF;
using NerdySoft_Test_Task.Entities;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace NerdySoft_Test_Task.Controllers
{    
    [ApiController]
    public class AnnouncementController : ControllerBase
    {        
        private ApplicationContext _context { get; set; }

        public AnnouncementController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("api/Create")]
        public IActionResult CreateAnnouncement(Announcement announcement)
        {
            try
            {
                _context.Announcements.Add(announcement);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(new { Message = "Announcement was successfully created!" });
        }

        [HttpPut("api/Edit")]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            try
            {
                var dbAnnouncement = _context.Announcements.Find(announcement.Id);
                if (dbAnnouncement == null)
                {
                    return BadRequest("Not fount.");
                }
                dbAnnouncement.Title = announcement.Title;
                dbAnnouncement.Description = announcement.Description;                
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(new { Message = "Announcement was successfully changed!" });
        }

        [HttpDelete("api/Delete{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {            
            try
            {
                var dbAnnouncement = _context.Announcements.Find(id);
                if (dbAnnouncement == null)
                {
                    return BadRequest("Not fount.");
                }
                _context.Announcements.Remove(dbAnnouncement);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(new { Message = "Announcement was successfully deleted!" });
        }

        [HttpGet("api/GetAll")]
        public IActionResult GetAllAnnouncements()
        {
            IEnumerable<Announcement> announcements;
            try
            {                
                announcements = _context.Announcements.ToList();
            } 
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(announcements); 
        }

        [HttpGet("api/GetTop3")]
        public IActionResult GetTopSimilarAnnouncements()
        {
            IEnumerable<Announcement> announcements;            
            try
            {                
                announcements = _context.Announcements.ToList();

                return Ok(announcements.Select(x => announcements.Where(y => y.Description.ToLower().Split(" ").Any(z => x.Title.ToLower().Split(" ").Any(o => o == z))).Take(1).Take(3)));                                

            }
            catch (Exception)
            {
                return StatusCode(500);
            }            
        }
    } 
}