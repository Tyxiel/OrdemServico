using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace OrdemServico.Migrations
{
    public partial class PopulandoTabelasDefeitosETecnicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserindo dados na tabela Defeitos
            migrationBuilder.Sql(@"INSERT INTO Defeitos (descricao) VALUES 
            ('Não liga'),
            ('Tela azul'),
            ('Superaquecimento'),
            ('Sem conexão com a internet'),
            ('Erro ao inicializar o sistema');");

            // Inserindo dados na tabela Tecnicos
            migrationBuilder.Sql(@"INSERT INTO Tecnicos (nomeTecnico) VALUES 
            ('Arthur Dias'),
            ('Helen Silva'),
            ('Leandro Amaral'),
            ('Vinícius Bonfim'),
            ('Wallace Oliveira');");

            // Inserindo dados na tabela Equipamentos
            migrationBuilder.Sql(@"INSERT INTO Equipamentos (nomeEquipamento) VALUES
            ('Notebook Dell Inspiron 15'),
            ('Desktop HP ProDesk 400'),
            ('MacBook Pro 13'),
            ('Servidor Dell PowerEdge'),
            ('Tablet Samsung Galaxy Tab S6'),
            ('Impressora HP LaserJet Pro'),
            ('Notebook Lenovo ThinkPad X1'),
            ('Smartphone Samsung Galaxy S21'),
            ('All-in-One LG 24V360'),
            ('Servidor HP ProLiant DL380'),
            ('Chromebook Acer Spin 311');");

            // Inserindo dados na tabela Clientes
            migrationBuilder.Sql(@"INSERT INTO Clientes (nomeCliente) VALUES 
            ('João Silva'),
            ('Maria Oliveira'),
            ('Carlos Souza'),
            ('Ana Paula'),
            ('Bruno Henrique'),
            ('Fernanda Costa'),
            ('Rodrigo Lima'),
            ('Juliana Freitas'),
            ('Marcelo Dias'),
            ('Tatiane Melo'),
            ('Lucas Fernandes');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Caso precise remover os dados em um rollback
            migrationBuilder.Sql("DELETE FROM Tecnicos WHERE nomeTecnico IN ('Arthur Dias', 'Helen Silva', 'Leandro Amaral', 'Vinícius Bonfim', 'Wallace Oliveira');");
            migrationBuilder.Sql("DELETE FROM Defeitos WHERE descricao IN ('Não liga', 'Tela azul', 'Superaquecimento', 'Sem conexão com a internet', 'Erro ao inicializar o sistema');");
        }
    }
}
