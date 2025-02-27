﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AdiçãodoNomenaAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Agendas");
        }
    }
}
