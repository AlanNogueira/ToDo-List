using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AdiconandoColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.RenameTable(
                name: "Tarefas",
                newName: "Tarefa");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Tarefa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefa",
                table: "Tarefa",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefa",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Tarefa");

            migrationBuilder.RenameTable(
                name: "Tarefa",
                newName: "Tarefas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "Id");
        }
    }
}
