using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSPA;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
        var models = await _context.Students.ToListAsync();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound("Student not found for the provided ID.");
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Post(Student model)
    {
        _context.Students.Add(model);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", new { id = model.Id }, model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Student model)
    {
        if (id != model.Id)
        {
            return BadRequest("The provided Id in the request body does not match the Id in the URL.");
        }

        var existingEntity = await _context.Students.FindAsync(id);

        if (existingEntity == null)
        {
            return NotFound("Not found for the provided Id.");
        }

        // Update the properties of the existingEntity with the values from the model
        existingEntity.Id = model.Id;
        existingEntity.FirstName = model.FirstName;
        existingEntity.LastName = model.LastName;
        existingEntity.Mobile = model.Mobile;
        existingEntity.Email = model.Email;
        existingEntity.NIC = model.NIC;
        existingEntity.DateOfBirth = model.DateOfBirth;
        existingEntity.Address = model.Address;
        existingEntity.ProfileImage = model.ProfileImage;


        // If you have more properties, update them accordingly

        // Save changes to the database
        await _context.SaveChangesAsync();

        return NoContent(); // Indicates a successful update without returning data
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var model = await _context.Students.FindAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        _context.Students.Remove(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool YourModelExists(int id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
