using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blogapicontroller.Data;
using blogapicontroller.Models;

namespace blogapicontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private readonly BlogApiContext _context;

        public ActivityLogController(BlogApiContext context)
        {
            _context = context;
        }

        // GET: api/ActivityLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLog>>> GetActivityLogs()
        {
            return await _context.ActivityLogs.ToListAsync();
        }

        // GET: api/ActivityLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityLog>> GetActivityLog(int id)
        {
            var activityLog = await _context.ActivityLogs.FindAsync(id);

            if (activityLog == null)
            {
                return NotFound();
            }

            return activityLog;
        }

        // PUT: api/ActivityLog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityLog(int id, ActivityLog activityLog)
        {
            if (id != activityLog.LogId)
            {
                return BadRequest();
            }

            _context.Entry(activityLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivityLog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityLog>> PostActivityLog(ActivityLog activityLog)
        {
            _context.ActivityLogs.Add(activityLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityLog", new { id = activityLog.LogId }, activityLog);
        }

        // DELETE: api/ActivityLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityLog(int id)
        {
            var activityLog = await _context.ActivityLogs.FindAsync(id);
            if (activityLog == null)
            {
                return NotFound();
            }

            _context.ActivityLogs.Remove(activityLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityLogExists(int id)
        {
            return _context.ActivityLogs.Any(e => e.LogId == id);
        }
    }
}
