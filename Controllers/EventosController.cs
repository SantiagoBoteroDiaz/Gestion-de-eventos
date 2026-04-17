using GentionDeDeportes.Data;
using GentionDeDeportes.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GentionDeDeportes.Controllers;

public class EventosController : Controller
{
    private readonly MysqlDbContext _context;
    
    public EventosController(MysqlDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {        
        return View(); 
    }
    [HttpGet]
    public IActionResult ViewEvents()
    {
        var eventos = _context.Eventos.ToList(); 
        return View(eventos);
    }
    
    [HttpGet]
    public IActionResult Dashboard()
    {
        var eventos = _context.Eventos.ToList(); 
        return View(eventos);
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var evento = _context.Eventos.Find(id);
        if (evento == null)
        {
            return NotFound();
        }
        _context.Eventos.Remove(evento);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    public IActionResult EditEvent()
    {
        return View();
    }

    public IActionResult CreateEvent()
    {
        return View();
    }
    public IActionResult Create(string name, string description, DateTime date)
    {
        var newEvent = new Eventos
        {
            Name = name,
            Description = description,
            Date = date
        }; 
        _context.Eventos.Add(newEvent);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    public IActionResult EditEvent(int id)
    {
        var evento = _context.Eventos.Find(id);
        return View(evento);  
    }

    public IActionResult Edit(int id, string name, string description, DateTime date)
    {
        var  evento = _context.Eventos.Find(id);
        if (evento == null)
        {
            return NotFound();
        }
        evento.Name = name;
        evento.Description = description;
        evento.Date = date;
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }
}