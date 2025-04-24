using Microsoft.EntityFrameworkCore.Migrations;

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Caso precise remover os dados em um rollback
            migrationBuilder.Sql("DELETE FROM Tecnicos WHERE nomeTecnico IN ('Arthur Dias', 'Helen Silva', 'Leandro Amaral', 'Vinícius Bonfim', 'Wallace Oliveira');");
            migrationBuilder.Sql("DELETE FROM Defeitos WHERE descricao IN ('Não liga', 'Tela azul', 'Superaquecimento', 'Sem conexão com a internet', 'Erro ao inicializar o sistema');");
        }
    }
}
