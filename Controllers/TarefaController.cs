using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class TarefaController : Controller
{
	private readonly TarefaContext _context;

	public TarefaController(TarefaContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		var tarefas = _context.Tarefa.ToList().Where(x => x.DeletionDate ==  null).ToList();
		return View(tarefas);
	}

	public IActionResult Adicionar()
	{
		return View();
	}
	
	[HttpPost]
	public IActionResult Adicionar(Tarefa tarefa)
	{
		_context.Add(tarefa);
		_context.SaveChanges();
		return RedirectToAction(nameof(Index));
	}
	
	public IActionResult Excluir(int Id)
	{
		Tarefa tarefa = _context.Tarefa.Find(Id);
		tarefa.DeletionDate = DateTime.Now;
		
		_context.Tarefa.Update(tarefa);
		_context.SaveChanges();
		
		return RedirectToAction(nameof(Index));
	}
	
	public IActionResult Editar(int Id)
	{
		Tarefa tarefa = _context.Tarefa.Find(Id);
		return View(tarefa);
	}
	
	[HttpPost]
	public IActionResult Editar(Tarefa tarefa)
	{
		var tarefaBanco = _context.Tarefa.Find(tarefa.Id);
		
		tarefaBanco.Descricao = tarefa.Descricao;
		tarefaBanco.Completo = tarefa.Completo;
		
		_context.Tarefa.Update(tarefaBanco);
		_context.SaveChanges();
		return RedirectToAction(nameof(Index));
	}
	
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
