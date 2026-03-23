using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portifolio.Areas.NinexHype.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genero = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    TelefoneAlternativo = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Foto = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tiporoupa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiporoupa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_usuario_login_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_regra_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_usuario_token_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perfil_regra_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_perfil",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_perfil", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_usuario_perfil_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoRoupaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Foto = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoria_tiporoupa_TipoRoupaId",
                        column: x => x.TipoRoupaId,
                        principalTable: "tiporoupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    QtdeEstoque = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCusto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Destaque = table.Column<bool>(type: "INTEGER", nullable: false),
                    Genero = table.Column<int>(type: "INTEGER", nullable: false),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Cor = table.Column<string>(type: "TEXT", nullable: true),
                    Material = table.Column<string>(type: "TEXT", nullable: true),
                    AtividadeRecomendada = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    CarrinhoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArquivoFoto = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoFoto_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Cpf", "DataNascimento", "Email", "EmailConfirmed", "Foto", "Genero", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TelefoneAlternativo", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", 0, "b2cfe7a1-5391-4143-b66f-e4c8e0df2778", null, new DateTime(1981, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ninexhype@9xhype.com", true, "~/img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png", null, true, null, "9x Hype", "NINEXHYPE@9XHYPE.COM", "9XHYPE", "AQAAAAIAAYagAAAAEAs9zk1NlhBNJ3rtbkTg6VKVSvoXnV/PlOOx3YL7SZ0uIp9W4YpWSQdNw/I61obg0A==", null, false, "2d2ba512-a852-4c4d-ac53-536af5c517e3", null, false, "9xHype" });

            migrationBuilder.InsertData(
                table: "perfil",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", "368730e7-a216-4e38-9c26-edbe9ee1b0b6", "Administrador", "ADMINISTRADOR" },
                    { "bec71b05-8f3d-4849-88bb-0e8d518d2de8", "78af891a-843a-4a00-a8ba-b2e4e5d7ecdc", "Funcionário", "FUNCIONÁRIO" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", "f5b7b7b1-6351-4cc4-bb29-2cf698494593", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "tiporoupa",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Roupa" },
                    { 2, "Tenis" }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Foto", "Nome", "TipoRoupaId" },
                values: new object[,]
                {
                    { 1, null, "Tênis", 2 },
                    { 2, null, "Camisas", 1 },
                    { 3, null, "Blusas", 1 },
                    { 4, null, "Jaquetas", 1 },
                    { 5, null, "Shorts", 1 },
                    { 6, null, "Calças", 1 },
                    { 7, null, "Acessórios", 1 },
                    { 8, null, "Destaques", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario_perfil",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { "bec71b05-8f3d-4849-88bb-0e8d518d2de8", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" }
                });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "Id", "AtividadeRecomendada", "CategoriaId", "Cor", "Descricao", "Destaque", "Genero", "Marca", "Material", "Nome", "QtdeEstoque", "ValorCusto", "ValorVenda" },
                values: new object[,]
                {
                    { 1, "Casual", 1, "Branco", "Confortável, durável e atemporal: não é à toa que ele é o número 1. A construção clássica dos anos 80 combina com detalhes arrojados para um estilo que acompanha você na quadra ou em qualquer lugar.", false, 3, "Nike", "Couro", "Nike Air Force 1", 25, 300.00m, 449.99m },
                    { 2, "Corrida", 1, "Preto", "Seja nas pistas ou nos treinos mais desafiadores, experimente um impulso a cada passo com este tênis de corrida Ultraboost adidas. Feito com nosso amortecimento BOOST mais leve de todos, ele devolve energia a cada passo. Combinado com o Torsion System para estabilidade do calcanhar à ponta do pé, ele oferece uma corrida suave e confortável que você precisa sentir para acreditar.", false, 3, "Adidas", "Tecido Knit", "Adidas Ultraboost", 18, 380.00m, 599.99m },
                    { 3, "Casual", 1, "Colorido", "O RS-X está de volta. A silhueta retrofuturista deste tênis retorna com uma estética progressiva e detalhes angulares, completos com sobreposições em nubuck e em suede. Essa combinação tem tudo a ver com um design inovador para mostrar seu estilo revolucionário.", false, 1, "Puma", "Tecido e Sintético", "Puma RS-X", 20, 320.00m, 489.90m },
                    { 4, "Skate", 1, "Preto", "Em 1977, o tênis Old Skool, originalmente nomeado de Vans #36 foi lançado sendo o primeiro a conter a icônica sidestripe na lateral. O que começou como um rabisco de Paul Van Doren, originalmente chamado de “Jazz Stripe”, se tornou um dos ícones da marca Vans. O Tênis Old Skool Black White é um tênis de cano baixo com cadarço que possui cabedal de lona têxtil e camurça resistente na cor preta, sidestripe em couro branco e viras laterais borracha na cor branca com biqueiras reforçadas para suportar o desgaste por repetição, cano acolchoado para dar suporte e flexibilidade e a clássica sola de borracha waffle vulcanizada exclusiva Vans.", false, 1, "Vans", "Lona e Camurça", "Vans Old Skool", 22, 200.00m, 349.99m },
                    { 5, "Casual", 1, "Cinza", "A partir da silhueta exclusiva dos anos 80, o Tênis Casual Unissex New Balance 574V2 garante estilo clássico ao seu visual. O modelo traz amortecimento na entressola em ENCAP, que combina espuma leve com borda de poliuretano durável para oferecer conforto o dia todo.", false, 3, "New Balance", "Suede e Malha", "New Balance 574", 15, 280.00m, 419.99m },
                    { 6, "Casual", 1, "Preto", "Desde 1917, o Chuck Taylor All Star tem sido o ícone do dia a dia. Você já conhece os detalhes icônicos como o cabedal em lona de algodão, solado com padrão de diamante e a indistinguível biqueira de borracha. Finalizado com palmilha em EVA para ajudar a manter os pés confortáveis.", false, 3, "Converse", "Lona", "Converse Chuck Taylor", 30, 150.00m, 269.99m },
                    { 7, "Corrida", 1, "Azul", "O Tênis Asics Gel Kayano 28 é perfeito para mulheres que buscam desempenho e conforto em suas corridas. Desenvolvido com as melhores tecnologias da Asics, este tênis proporciona uma experiência de corrida superior. A tecnologia FF BLAST™ na entressola oferece uma sensação suave e de suporte em cada passo, garantindo conforto e eficiência. O amortecimento GEL™ proporciona uma passada suave, permitindo uma aterrissagem mais confortável sem perder velocidade.", false, 3, "Asics", "Mesh", "Asics Gel-Kayano 28", 12, 400.00m, 649.99m },
                    { 8, "Casual", 1, "Colorido", "Originalmente criado para as quadras, o Dunk mais tarde foi para as ruas - e como se costuma dizer, o resto é história. Mais de 35 anos após sua estreia, a silhueta ainda oferece um estilo ousado e desafiador. Agora, o tênis OG do basquete universitário retorna com camadas sobrepostas em couro premium e color blocking tradicional. O conforto fica por conta da tecnologia mais atual em calçados, enquanto uma combinação clássica de preto e branco remete ao legado das quadras.", false, 3, "Nike", "Couro e Sintético", "Nike Dunk Low", 10, 360.00m, 549.99m },
                    { 9, "Corrida", 1, "Preto", "A entressola possui a tecnologia Infinity Wave em toda a sua extensão dando a ele um visual moderno e tecnológico. O cabedal feito em mesh laminado proporciona maior respirabilidade e ajuste aos seus pés para um estilo mais casual. Além disso, o solado tem a tecnologia X10, um composto de borracha com carbono que garante maior durabilidade.", false, 1, "Mizuno", "Mesh e Borracha", "Mizuno Wave Prophecy", 8, 500.00m, 799.99m },
                    { 10, "Casual", 1, "Branco", "Modelo atemporal da Fila, febre mundial e vencedor de 2018 do prêmio de Shoe of the Year - Esse é o tênis Fila Disruptor II. Seu design autêntico e robusto une o estilo retrô e moderno em um modelo casual, destaque para a sola tratorada que garante alta durabilidade e maior aderência ao solo.", false, 2, "Fila", "Sintético", "Fila Disruptor II", 14, 220.00m, 369.99m },
                    { 11, "Casual", 1, "Branco", "O Reebok Classic Leather é um ícone dos anos 80 que continua sendo uma referência de estilo e conforto até hoje. Com uma história única, o Reebok Classic Leather foi lançado originalmente em 1983, sendo o primeiro tênis de corrida a utilizar couro no cabedal.", false, 3, "Reebok", "Couro", "Reebok Classic", 16, 180.00m, 299.99m },
                    { 12, "Corrida", 1, "Preto", "Estes calçados de caminhada unissex repletos de tecnologia desenvolvida para corrida e atividades ao ar livre são feitos para ir a qualquer lugar: Amortecimento UA HOVR ™ de nossos tênis de corrida, parte inferior em Michelin inspirada em pneus de bicicleta.", false, 1, "Under Armour", "Tecido Knit", "Under Armour HOVR", 10, 310.00m, 459.99m },
                    { 13, "Casual", 1, "Preto/Vermelho", "Trouxemos os recibos com esta edição especial do AJ1. Feito de couro macio e cremoso, este favorito de todos os tempos vem adornado com detalhes sutis de design para um estilo de dar água na boca.", false, 1, "Nike Jordan", "Couro", "Jordan 1 Mid", 6, 450.00m, 749.99m },
                    { 14, "Trilha", 1, "Marrom", "Pertencente a linha Outdoor, o modelo MODOC LOW II possui um solado de borracha garantindo máxima durabilidade e resistência a abrasão, a entressola em EVA proporciona maior conforto, parte superior em camurça e tecido com logotipo da marca em metal revelam a robustez do produto, garantem durabilidade e design único.", false, 1, "Oakley", "Couro e Borracha", "Oakley Modoc", 18, 280.00m, 399.99m },
                    { 15, "Corrida", 1, "Branco/Verde", "Pegue-os se puder. Dando a você a velocidade do dia da corrida para conquistar qualquer distância, o Nike Vaporfly 3 é feito para aqueles que buscam, os pilotos, os pacers elevados que não conseguem diminuir a emoção da busca. Retrabalhamos o líder do super pacote de calçados e ajustamos o motor embaixo para ajudá-lo a buscar recordes pessoais de 10 km até a maratona. De corredores de elite a novatos em corridas, este cavalo de batalha versátil para corridas de rua é para aqueles que veem a velocidade como uma porta de entrada para mais quilômetros e elevações aparentemente inatingíveis.", false, 1, "Nike", "Mesh", "Nike ZoomX Vaporfly", 5, 600.00m, 999.99m },
                    { 16, "Casual", 2, "Branco", "A Camiseta Oversized Branca da 9xHype entrega conforto máximo com sua modelagem larga e tecido 100% algodão. Ideal para quem busca um visual moderno e despojado no dia a dia. O caimento soltinho garante liberdade de movimento sem perder o estilo. Perfeita para composições casuais e streetwear.", false, 1, "9xHype", "Algodão", "Camiseta Oversized Branca", 50, 40.00m, 79.90m },
                    { 17, "Casual", 6, "Preto", "A Calça Cargo Preta combina estilo urbano e praticidade com seus bolsos laterais funcionais. Confeccionada em algodão e poliéster, oferece resistência e conforto para o dia a dia. O ajuste no tornozelo dá um toque moderno e facilita combinações com tênis. Ideal para looks casuais e cheios de atitude.", false, 1, "9xHype", "Algodão e Poliéster", "Calça Cargo Preta", 30, 90.00m, 149.99m },
                    { 18, "Esportivo", 4, "Cinza", "A Jaqueta Corta-Vento da 9xHype é a escolha perfeita para dias chuvosos e ventosos. Feita em poliéster leve e impermeável, garante proteção sem pesar no corpo. Seu design unissex combina com qualquer estilo. Ideal para práticas esportivas ou uso urbano com conforto e versatilidade.", false, 3, "9xHype", "Poliéster", "Jaqueta Corta-Vento", 12, 120.00m, 219.99m },
                    { 19, "Casual", 3, "Cinza", "O Moletom Liso com Capuz oferece conforto térmico com seu tecido peluciado de algodão. Com design unissex, é uma peça versátil para diversas ocasiões casuais. O toque macio proporciona uma experiência aconchegante nos dias mais frios. Um clássico essencial para o guarda-roupa.", false, 3, "9xHype", "Algodão", "Moletom Liso com Capuz", 25, 80.00m, 129.90m },
                    { 20, "Casual", 5, "Bege", "A Bermuda de Sarja Bege é perfeita para compor looks casuais com estilo. Fabricada em sarja resistente, garante conforto e durabilidade no dia a dia. Seus bolsos laterais adicionam praticidade sem comprometer o visual. Ideal para dias quentes e combinações simples e elegantes.", false, 1, "9xHype", "Sarja", "Bermuda de Sarja Bege", 35, 60.00m, 99.99m },
                    { 21, "Social", 2, "Branca", "A Camisa Social Slim oferece um caimento moderno com seu corte ajustado ao corpo. Confeccionada em algodão macio, proporciona conforto durante todo o dia. Seu visual clean e elegante permite uso tanto em eventos formais quanto em momentos sociais. Uma peça essencial para quem busca estilo e sofisticação.", false, 1, "9xHype", "Algodão", "Camisa Social Slim", 20, 70.00m, 119.99m },
                    { 22, "Casual", 2, "Floral", "O Vestido Midi Floral é leve, fluido e perfeito para o verão. Feito em viscose, possui toque suave e ótimo caimento. O design floral traz um visual fresco e feminino, ideal para passeios e ocasiões casuais. Uma peça confortável que combina estilo e praticidade.", false, 2, "9xHype", "Viscose", "Vestido Midi Floral", 18, 90.00m, 149.90m },
                    { 23, "Casual", 6, "Azul Jeans", "A Calça Jeans Skinny conta com elastano que garante flexibilidade e conforto durante o uso. Seu corte ajustado oferece um visual moderno e versátil, combinando com diferentes tipos de looks. O tom azul jeans clássico é ideal para o dia a dia. Uma peça unissex perfeita para quem busca estilo sem abrir mão da mobilidade.", false, 3, "9xHype", "Jeans com Elastano", "Calça Jeans Skinny", 28, 100.00m, 169.99m },
                    { 24, "Casual", 4, "Azul Jeans", "A Jaqueta Jeans Feminina traz o clássico estilo urbano com um toque moderno. Fabricada em jeans resistente, oferece durabilidade e caimento estruturado. Ideal para combinar com vestidos, croppeds e camisetas. Uma peça curinga para qualquer guarda-roupa feminino.", false, 2, "9xHype", "Jeans", "Jaqueta Jeans Feminina", 10, 130.00m, 199.99m },
                    { 25, "Casual", 5, "Cinza", "O Shorts de Moletom é perfeito para quem prioriza conforto sem perder o estilo. Seu tecido macio proporciona liberdade de movimento para o dia a dia. Ideal para atividades leves, passeios ou uso em casa. Uma peça unissex versátil e prática.", false, 3, "9xHype", "Moletom", "Shorts de Moletom", 40, 50.00m, 89.99m },
                    { 26, "Casual", 2, "Preto", "A Camiseta Polo Preta Feminina é feita em algodão de alta qualidade, garantindo conforto e respirabilidade. Seu design clássico com gola polo oferece um toque elegante ao look casual. Ideal para o dia a dia ou ambientes mais descontraídos. Combina facilmente com jeans, shorts ou saias.", false, 2, "9xHype", "Algodão", "Camiseta Polo Preta Feminina", 60, 35.00m, 69.90m },
                    { 27, "Casual", 2, "Preto", "O Macacão Feminino da 9xHype é a peça ideal para quem busca praticidade sem abrir mão do estilo. Feito em viscose, oferece leveza e ótimo caimento. Seu design moderno valoriza a silhueta de forma confortável. Excelente para eventos casuais ou combinações rápidas e elegantes.", false, 2, "9xHype", "Viscose", "Macacão Feminino", 14, 110.00m, 179.99m },
                    { 28, "Casual", 3, "Rosa", "A Blusa Cropped Texturizada traz um visual jovem e moderno com sua superfície diferenciada. Confeccionada em poliéster, é leve e confortável para o dia a dia. Ideal para compor looks estilosos com calças de cintura alta ou saias. Uma peça versátil para diversas ocasiões casuais.", false, 2, "9xHype", "Poliéster", "Blusa Cropped Texturizada", 22, 45.00m, 79.99m },
                    { 29, "Casual", 2, "Marrom", "A Camisa Polo Texturizada Masculina combina elegância e conforto em uma peça só. Feita em algodão, possui toque macio e ótima respirabilidade. Sua textura diferenciada adiciona sofisticação ao look casual. Ideal para quem busca um visual arrumado sem perder a essência descontraída.", false, 1, "9xHype", "Algodão", "Camisa Polo Texturizada Masculina Marrom", 19, 65.00m, 109.99m },
                    { 30, "Treino", 2, "Cinza", "A Regata Dry Fit é perfeita para treinos, oferencendo leveza e rápida evaporação do suor. Feita em poliéster, garante ventilação e conforto até nos exercícios mais intensos. Seu design unissex se adapta a diferentes estilos e corpos. Ideal para quem busca desempenho e mobilidade.", false, 3, "9xHype", "Poliéster", "Regata Dry Fit", 50, 30.00m, 59.90m },
                    { 31, "Casual", 8, "Branco", "Confortável, durável e atemporal: não é à toa que ele é o número 1. A construção clássica dos anos 80 combina com detalhes arrojados para um estilo que acompanha você na quadra ou em qualquer lugar.", false, 0, "Nike", "Couro", "Nike Air Force 1", 25, 300.00m, 449.99m },
                    { 32, "Corrida", 8, "Preto", "Seja nas pistas ou nos treinos mais desafiadores, experimente um impulso a cada passo com este tênis de corrida Ultraboost adidas. Feito com nosso amortecimento BOOST mais leve de todos, ele devolve energia a cada passo. Combinado com o Torsion System para estabilidade do calcanhar à ponta do pé, ele oferece uma corrida suave e confortável que você precisa sentir para acreditar.", false, 0, "Adidas", "Tecido Knit", "Adidas Ultraboost", 18, 380.00m, 599.99m },
                    { 33, "Casual", 8, "Colorido", "O RS-X está de volta. A silhueta retrofuturista deste tênis retorna com uma estética progressiva e detalhes angulares, completos com sobreposições em nubuck e em suede. Essa combinação tem tudo a ver com um design inovador para mostrar seu estilo revolucionário.", false, 0, "Puma", "Tecido e Sintético", "Puma RS-X", 20, 320.00m, 489.90m },
                    { 34, "Skate", 8, "Preto", "Em 1977, o tênis Old Skool, originalmente nomeado de Vans #36 foi lançado sendo o primeiro a conter a icônica sidestripe na lateral. O que começou como um rabisco de Paul Van Doren, originalmente chamado de “Jazz Stripe”, se tornou um dos ícones da marca Vans. O Tênis Old Skool Black White é um tênis de cano baixo com cadarço que possui cabedal de lona têxtil e camurça resistente na cor preta, sidestripe em couro branco e viras laterais borracha na cor branca com biqueiras reforçadas para suportar o desgaste por repetição, cano acolchoado para dar suporte e flexibilidade e a clássica sola de borracha waffle vulcanizada exclusiva Vans.", false, 0, "Vans", "Lona e Camurça", "Vans Old Skool", 22, 200.00m, 349.99m },
                    { 35, "Casual", 8, "Cinza", "A partir da silhueta exclusiva dos anos 80, o Tênis Casual Unissex New Balance 574V2 garante estilo clássico ao seu visual. O modelo traz amortecimento na entressola em ENCAP, que combina espuma leve com borda de poliuretano durável para oferecer conforto o dia todo.", false, 0, "New Balance", "Suede e Malha", "New Balance 574", 15, 280.00m, 419.99m },
                    { 36, "Casual", 8, "Preto", "Desde 1917, o Chuck Taylor All Star tem sido o ícone do dia a dia. Você já conhece os detalhes icônicos como o cabedal em lona de algodão, solado com padrão de diamante e a indistinguível biqueira de borracha. Finalizado com palmilha em EVA para ajudar a manter os pés confortáveis.", false, 0, "Converse", "Lona", "Converse Chuck Taylor", 30, 150.00m, 269.99m },
                    { 37, "Corrida", 8, "Azul", "O Tênis Asics Gel Kayano 28 é perfeito para mulheres que buscam desempenho e conforto em suas corridas. Desenvolvido com as melhores tecnologias da Asics, este tênis proporciona uma experiência de corrida superior. A tecnologia FF BLAST™ na entressola oferece uma sensação suave e de suporte em cada passo, garantindo conforto e eficiência. O amortecimento GEL™ proporciona uma passada suave, permitindo uma aterrissagem mais confortável sem perder velocidade.", false, 0, "Asics", "Mesh", "Asics Gel-Kayano 28", 12, 400.00m, 649.99m },
                    { 38, "Casual", 8, "Colorido", "Originalmente criado para as quadras, o Dunk mais tarde foi para as ruas - e como se costuma dizer, o resto é história. Mais de 35 anos após sua estreia, a silhueta ainda oferece um estilo ousado e desafiador. Agora, o tênis OG do basquete universitário retorna com camadas sobrepostas em couro premium e color blocking tradicional. O conforto fica por conta da tecnologia mais atual em calçados, enquanto uma combinação clássica de preto e branco remete ao legado das quadras.", false, 0, "Nike", "Couro e Sintético", "Nike Dunk Low", 10, 360.00m, 549.99m },
                    { 39, "Corrida", 8, "Preto", "A entressola possui a tecnologia Infinity Wave em toda a sua extensão dando a ele um visual moderno e tecnológico. O cabedal feito em mesh laminado proporciona maior respirabilidade e ajuste aos seus pés para um estilo mais casual. Além disso, o solado tem a tecnologia X10, um composto de borracha com carbono que garante maior durabilidade.", false, 0, "Mizuno", "Mesh e Borracha", "Mizuno Wave Prophecy", 8, 500.00m, 799.99m },
                    { 40, "Casual", 8, "Branco", "Modelo atemporal da Fila, febre mundial e vencedor de 2018 do prêmio de Shoe of the Year - Esse é o tênis Fila Disruptor II. Seu design autêntico e robusto une o estilo retrô e moderno em um modelo casual, destaque para a sola tratorada que garante alta durabilidade e maior aderência ao solo.", false, 0, "Fila", "Sintético", "Fila Disruptor II", 14, 220.00m, 369.99m },
                    { 41, "Dia a Dia", 1, "Creme", "Inspirado no Nike Air Max 90, o Nike Air Max Excee comemora um clássico com um visual repaginado. O design de linhas alongadas e proporções distorcidas na parte de cima elevam um ícone a um patamar moderno. A unidade Air é visível através de três janelas criando um look atualizado. A entressola de espuma e a sola com cápsulas de espuma e borracha oferecem conforto e durabilidade com muita leveza. As linhas de design alongadas homenageiam o Air Max 90, ao mesmo tempo que o modernizam de forma irreverente.", false, 2, "Nike", "Couro e Material Sintético", "Tênis Nike Air Max Excee Feminino", 127, 379.99m, 799.99m },
                    { 42, "Dia a Dia", 1, "Branco", "Repita a última série e mantenha-se firme nos céus e nas sustentações com o MC Trainer 3. Uma base plana e resistente fornece um nível confiável de estabilidade aos movimentos que você mais gosta. O cabedal adaptável ajuda a mantê-lo contido durante movimentos laterais. A sensação confortável sob os pés é ótima para uso durante todo o dia, dentro e fora da academia. Quanto mais suporte o tênis proporciona, mais estabilidade ele pode dar ao seu passo. Uma combinação de suporte configurado e amortecimento intencionalmente colocado ajuda você a se sentir seguro a cada passo. Uma base reta e estável ajuda a mantê-lo firme e sólido ao fazer movimentos laterais.", false, 2, "Nike", "Malha, Espuma e Borracha", "Tênis Nike MC Trainer 3 Feminino", 52, 379.99m, 499.99m },
                    { 43, "Dia a Dia", 1, "Branco", "Confortável, durável e atemporal — não é à toa que é o número um. O Air Force 1 combina sua silhueta clássica com couro premium para um visual elegante e clean. Esta versão inclui uma corrente prateada e pingentes para elevar seu estilo.", false, 2, "Nike", "Couro Sintético", "Women's Air Force 1 '07 Low", 22, 450.99m, 999.99m },
                    { 44, "Dia a Dia", 1, "Linen Green", "O Courtblock é novo para essas características de filtro em nosso website, na categoria Mulher. Mas você já pode visualizar as imagens acima e ter mais detalhes, para conhecer o produto de diferentes ângulos em primeira mão. Se você já experimentou o Courtblock antes, deixe um comentário a seguir para nos contar o que você achou. Ainda estamos trabalhando para obter mais informações sobre o Courtblock aqui, então não esqueça de retornar ao site em breve. Enquanto isso, aqui está o número do artigo do produto HP7211 para sua referência. Ele é classificado na categoria Tênis.", false, 2, "Adidas", "Couro", "COURTBLOCK", 37, 116.67m, 349.99m },
                    { 45, "Corrida", 1, "Willow Grey", "Seja para uma corrida rápida ao redor do quarteirão ou cumprir as tarefas da cidade, este tênis adidas Ultraboost está pronto para acompanhar. A entressola BOOST leve e de suporte deixa cada passo mais energizado, enquanto o cabedal em malha elástica respirável mantém seus pés refrescados e confortáveis por quilômetros.", false, 2, "Adidas", "Malha Elástica, Forro Sintético e Borracha", "Stella McCartney Ultraboost 5", 12, 269.67m, 1299.99m },
                    { 46, "Fashion", 1, "Cream White", "Nascido da quadra de basquete e criado para o seu estilo diário, adidas Jabbar Hi é um tênis clássico por completo. Embora as origens do basquete dos anos 70 brilhem na silhueta de cano alto, no calcanhar de couro e nas Três Listras, as atualizações moderno vêm na forma de um acabamento premium de pelo de pônei com hachuras cruzadas gravadas a laser. O visual limpo é pouco esforço, versátil e pronto para ser combinado com qualquer roupa ou passeio.", false, 2, "Adidas", "Forro Sintético, Couro e Borracha", "Tênis Jabbar Hi", 15, 315.76m, 1499.99m },
                    { 47, "Treino", 1, "Preto", "The Prospect, um novo treinador com atitude. O tênis possui PROFOAM em todo o comprimento para uma caminhada suave e transferência de energia, e a sola é totalmente em borracha com áreas especiais para aderência superior em todas as condições. Este tênis está repleto de tecnologia que o torna estável, mas fácil de colocar e tirar.", false, 2, "Puma", "Tecido, Formstrip e Borracha", "Tênis de Treino Prospect", 34, 217.67m, 449.99m }
                });

            migrationBuilder.InsertData(
                table: "ProdutoFoto",
                columns: new[] { "Id", "ArquivoFoto", "Descricao", "ProdutoId" },
                values: new object[,]
                {
                    { 1, "/img/500x500/NikeAirForceOne1.png", null, 1 },
                    { 2, "/img/500x500/NikeAirForceOne2.png", null, 1 },
                    { 3, "/img/500x500/NikeAirForceOne3.png", null, 1 },
                    { 4, "/img/500x500/AdidasUltraboost1.png", null, 2 },
                    { 5, "/img/500x500/AdidasUltraboost2.png", null, 2 },
                    { 6, "/img/500x500/AdidasUltraboost3.png", null, 2 },
                    { 7, "/img/500x500/PumaRS-X1.png", null, 3 },
                    { 8, "/img/500x500/PumaRS-X2.png", null, 3 },
                    { 9, "/img/500x500/PumaRS-X3.png", null, 3 },
                    { 10, "/img/500x500/VansOldSkool1.png", null, 4 },
                    { 11, "/img/500x500/VansOldSkool2.png", null, 4 },
                    { 12, "/img/500x500/VansOldSkool3.png", null, 4 },
                    { 13, "/img/500x500/NewBalance574_1.png", null, 5 },
                    { 14, "/img/500x500/NewBalance574_2.png", null, 5 },
                    { 15, "/img/500x500/NewBalance574_3.png", null, 5 },
                    { 16, "/img/500x500/ConverseChuckTaylor1.png", null, 6 },
                    { 17, "/img/500x500/ConverseChuckTaylor2.png", null, 6 },
                    { 18, "/img/500x500/ConverseChuckTaylor3.png", null, 6 },
                    { 19, "/img/500x500/AsicsGel-Kayano28_1.png", null, 7 },
                    { 20, "/img/500x500/AsicsGel-Kayano28_2.png", null, 7 },
                    { 21, "/img/500x500/AsicsGel-Kayano28_3.png", null, 7 },
                    { 22, "/img/500x500/NikeDunkLow1.png", null, 8 },
                    { 23, "/img/500x500/NikeDunkLow2.png", null, 8 },
                    { 24, "/img/500x500/NikeDunkLow3.png", null, 8 },
                    { 25, "/img/500x500/MizunoWaveProphecy1.png", null, 9 },
                    { 26, "/img/500x500/MizunoWaveProphecy2.png", null, 9 },
                    { 27, "/img/500x500/MizunoWaveProphecy3.png", null, 9 },
                    { 28, "/img/500x500/FilaDisruptorII1.png", null, 10 },
                    { 29, "/img/500x500/FilaDisruptorII2.png", null, 10 },
                    { 30, "/img/500x500/FilaDisruptorII3.png", null, 10 },
                    { 31, "/img/500x500/ReebokClassic1.png", null, 11 },
                    { 32, "/img/500x500/ReebokClassic2.png", null, 11 },
                    { 33, "/img/500x500/ReebokClassic3.png", null, 11 },
                    { 34, "/img/500x500/UnderArmourHOVR1.png", null, 12 },
                    { 35, "/img/500x500/UnderArmourHOVR2.png", null, 12 },
                    { 36, "/img/500x500/UnderArmourHOVR3.png", null, 12 },
                    { 37, "/img/500x500/Jordan1Mid1.png", null, 13 },
                    { 38, "/img/500x500/Jordan1Mid2.png", null, 13 },
                    { 39, "/img/500x500/Jordan1Mid3.png", null, 13 },
                    { 40, "/img/500x500/OakleyModoc1.png", null, 14 },
                    { 41, "/img/500x500/OakleyModoc2.png", null, 14 },
                    { 42, "/img/500x500/OakleyModoc3.png", null, 14 },
                    { 43, "/img/500x500/NikeZoomXVaporfly1.png", null, 15 },
                    { 44, "/img/500x500/NikeZoomXVaporfly2.png", null, 15 },
                    { 45, "/img/500x500/NikeZoomXVaporfly3.png", null, 15 },
                    { 46, "/img/500x500/CamisetaOversizedBranca1.png", null, 16 },
                    { 47, "/img/500x500/CamisetaOversizedBranca2.png", null, 16 },
                    { 48, "/img/500x500/CamisetaOversizedBranca3.png", null, 16 },
                    { 49, "/img/500x500/CalcaCargoPreta1.png", null, 17 },
                    { 50, "/img/500x500/CalcaCargoPreta2.png", null, 17 },
                    { 51, "/img/500x500/CalcaCargoPreta3.png", null, 17 },
                    { 52, "/img/500x500/JaquetaCortaVento.png", null, 18 },
                    { 53, "/img/500x500/JaquetaCorta-Vento2.png", null, 18 },
                    { 54, "/img/500x500/JaquetaCorta-Vento3.png", null, 18 },
                    { 55, "/img/500x500/MoletomLisoCapuz1.png", null, 19 },
                    { 56, "/img/500x500/MoletomLisoCapuz2.png", null, 19 },
                    { 57, "/img/500x500/MoletomLisoCapuz3.png", null, 19 },
                    { 58, "/img/500x500/BermudaSarjaBege1.png", null, 20 },
                    { 59, "/img/500x500/BermudaSarjaBege2.png", null, 20 },
                    { 60, "/img/500x500/BermudaSarjaBege3.png", null, 20 },
                    { 61, "/img/500x500/CamisaSocialSlim1.png", null, 21 },
                    { 62, "/img/500x500/CamisaSocialSlim2.png", null, 21 },
                    { 63, "/img/500x500/CamisaSocialSlim3.png", null, 21 },
                    { 64, "/img/500x500/VestidoMidiFloral1.png", null, 22 },
                    { 65, "/img/500x500/VestidoMidiFloral2.png", null, 22 },
                    { 66, "/img/500x500/VestidoMidiFloral3.png", null, 22 },
                    { 67, "/img/500x500/CalçaJeansSkinny1.png", null, 23 },
                    { 68, "/img/500x500/CalçaJeansSkinny2.png", null, 23 },
                    { 69, "/img/500x500/CalçaJeansSkinny3.png", null, 23 },
                    { 70, "/img/500x500/JaquetaJeansFeminina1.png", null, 24 },
                    { 71, "/img/500x500/JaquetaJeansFeminina2.png", null, 24 },
                    { 72, "/img/500x500/JaquetaJeansFeminina3.png", null, 24 },
                    { 73, "/img/500x500/ShortsMoletom1.png", null, 25 },
                    { 74, "/img/500x500/ShortsMoletom2.png", null, 25 },
                    { 75, "/img/500x500/ShortsMoletom3.png", null, 25 },
                    { 76, "/img/500x500/CamisetaPoloPretaFeminina1.png", null, 26 },
                    { 77, "/img/500x500/CamisetaPoloPretaFeminina2.png", null, 26 },
                    { 78, "/img/500x500/CamisetaPoloPretaFeminina3.png", null, 26 },
                    { 79, "/img/500x500/MacacãoFeminino1.png", null, 27 },
                    { 80, "/img/500x500/MacacãoFeminino2.png", null, 27 },
                    { 81, "/img/500x500/MacacãoFeminino3.png", null, 27 },
                    { 82, "/img/500x500/BlusaCroppedTexturizada1.png", null, 28 },
                    { 83, "/img/500x500/BlusaCroppedTexturizada2.png", null, 28 },
                    { 84, "/img/500x500/BlusaCroppedTexturizada3.png", null, 28 },
                    { 85, "/img/500x500/CamisaPoloTexturizadaMasculinaMarrom1.png", null, 29 },
                    { 86, "/img/500x500/CamisaPoloTexturizadaMasculinaMarrom2.png", null, 29 },
                    { 87, "/img/500x500/CamisaPoloTexturizadaMasculinaMarrom3.png", null, 29 },
                    { 88, "/img/500x500/RegataDryFit1.png", null, 30 },
                    { 89, "/img/500x500/RegataDryFit2.png", null, 30 },
                    { 90, "/img/500x500/RegataDryFit3.png", null, 30 },
                    { 91, "/img/500x500/TênisNikeAirMaxExcee1.png", null, 41 },
                    { 92, "/img/500x500/TênisNikeAirMaxExcee2.png", null, 41 },
                    { 93, "/img/500x500/TênisNikeAirMaxExcee3.png", null, 41 },
                    { 94, "/img/500x500/TênisNikeMCTrainerIII1.png", null, 42 },
                    { 95, "/img/500x500/TênisNikeMCTrainerIII2.png", null, 42 },
                    { 96, "/img/500x500/TênisNikeMCTrainerIII3.png", null, 42 },
                    { 97, "/img/500x500/Women'sAirForce1'07Low1.png", null, 43 },
                    { 98, "/img/500x500/Women'sAirForce1'07Low2.png", null, 43 },
                    { 99, "/img/500x500/Women'sAirForce1'07Low3.png", null, 43 },
                    { 100, "/img/500x500/COURTBLOCK1.png", null, 44 },
                    { 101, "/img/500x500/COURTBLOCK2.png", null, 44 },
                    { 102, "/img/500x500/COURTBLOCK3.png", null, 44 },
                    { 103, "/img/500x500/StellaMcCartneyUltraboostV1.png", null, 45 },
                    { 104, "/img/500x500/StellaMcCartneyUltraboostV2.png", null, 45 },
                    { 105, "/img/500x500/StellaMcCartneyUltraboostV3.png", null, 45 },
                    { 106, "/img/500x500/JabbarHi1.png", null, 46 },
                    { 107, "/img/500x500/JabbarHi2.png", null, 46 },
                    { 108, "/img/500x500/JabbarHi3.png", null, 46 },
                    { 109, "/img/500x500/Prospect1.png", null, 47 },
                    { 110, "/img/500x500/Prospect1.png", null, 47 },
                    { 111, "/img/500x500/Prospect1.png", null, 47 },
                    { 112, "/img/FotosCarrossel/fotosGrandes/NikeAirForce1.png", null, 31 },
                    { 113, "/img/FotosCarrossel/fotosGrandes/AdidasUltraboost.png", null, 32 },
                    { 114, "/img/FotosCarrossel/fotosGrandes/PumaRS-X.png", null, 33 },
                    { 115, "/img/FotosCarrossel/fotosGrandes/VansOldSkool.png", null, 34 },
                    { 116, "/img/FotosCarrossel/fotosGrandes/NewBalance574.png", null, 35 },
                    { 117, "/img/FotosCarrossel/fotosGrandes/ConverseChuckTaylor.png", null, 36 },
                    { 118, "/img/FotosCarrossel/fotosGrandes/AsicsGel-Kayano.png", null, 37 },
                    { 119, "/img/FotosCarrossel/fotosGrandes/NikeDunkLow.png", null, 38 },
                    { 120, "/img/FotosCarrossel/fotosGrandes/MizunoWaveProphecy.png", null, 39 },
                    { 121, "/img/FotosCarrossel/fotosGrandes/FilaDisruptorII.png", null, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_ProdutoId",
                table: "CarrinhoItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_UsuarioId",
                table: "Carrinhos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categoria_TipoRoupaId",
                table: "categoria",
                column: "TipoRoupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "perfil",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perfil_regra_RoleId",
                table: "perfil_regra",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_CategoriaId",
                table: "produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFoto_ProdutoId",
                table: "ProdutoFoto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login_UserId",
                table: "usuario_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_RoleId",
                table: "usuario_perfil",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_regra_UserId",
                table: "usuario_regra",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItens");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "perfil_regra");

            migrationBuilder.DropTable(
                name: "ProdutoFoto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "usuario_login");

            migrationBuilder.DropTable(
                name: "usuario_perfil");

            migrationBuilder.DropTable(
                name: "usuario_regra");

            migrationBuilder.DropTable(
                name: "usuario_token");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "tiporoupa");
        }
    }
}
