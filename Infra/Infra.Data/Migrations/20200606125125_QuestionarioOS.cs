using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class QuestionarioOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerguntaOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pergunta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreAberturaOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Assunto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreAberturaOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerguntaOSAlternativa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alternativa = table.Column<string>(nullable: true),
                    PerguntaOSId = table.Column<int>(nullable: false),
                    AlternativaFinal = table.Column<bool>(nullable: false),
                    PreAberturaOSId = table.Column<int>(nullable: true),
                    ProximaPerguntaOSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaOSAlternativa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerguntaOSAlternativa_PerguntaOS_PerguntaOSId",
                        column: x => x.PerguntaOSId,
                        principalTable: "PerguntaOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerguntaOSAlternativa_PreAberturaOS_PreAberturaOSId",
                        column: x => x.PreAberturaOSId,
                        principalTable: "PreAberturaOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerguntaOSAlternativa_PerguntaOS_ProximaPerguntaOSId",
                        column: x => x.ProximaPerguntaOSId,
                        principalTable: "PerguntaOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerguntaOSAlternativa_PerguntaOSId",
                table: "PerguntaOSAlternativa",
                column: "PerguntaOSId");

            migrationBuilder.CreateIndex(
                name: "IX_PerguntaOSAlternativa_PreAberturaOSId",
                table: "PerguntaOSAlternativa",
                column: "PreAberturaOSId");

            migrationBuilder.CreateIndex(
                name: "IX_PerguntaOSAlternativa_ProximaPerguntaOSId",
                table: "PerguntaOSAlternativa",
                column: "ProximaPerguntaOSId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerguntaOSAlternativa");

            migrationBuilder.DropTable(
                name: "PerguntaOS");

            migrationBuilder.DropTable(
                name: "PreAberturaOS");
        }
    }
}
