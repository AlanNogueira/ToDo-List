using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
	public class Tarefa
	{
		public int Id { get; set; }
		
		public string Descricao { get; set; }
		
		public bool Completo { get; set; }
		
		public DateTime? DeletionDate { get; set; }
	}
}