using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Context
{
	public class TarefaContext : DbContext
	{
		public TarefaContext (DbContextOptions<TarefaContext> options) : base(options)
		{
			
		}
		
		public DbSet<Tarefa> Tarefa { get; set; }
	}
}