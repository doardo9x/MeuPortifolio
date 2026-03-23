using Portifolio.Areas.NinexHype.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Portifolio.Areas.NinexHype.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<TipoRoupa> tiposRoupa = new()
        {
            new TipoRoupa { Id = 1, Nome= "Roupa"},
            new TipoRoupa { Id = 2, Nome= "Tenis"},
        };
        builder.Entity<TipoRoupa>().HasData(tiposRoupa);

        List<Categoria> categorias = new()
        {
            new Categoria { Id = 1, Nome = "Tênis", TipoRoupaId = 2 },
            new Categoria { Id = 2, Nome = "Camisas", TipoRoupaId = 1  },
            new Categoria { Id = 3, Nome = "Blusas", TipoRoupaId = 1  },
            new Categoria { Id = 4, Nome = "Jaquetas", TipoRoupaId = 1  },
            new Categoria { Id = 5, Nome = "Shorts", TipoRoupaId = 1  },
            new Categoria { Id = 6, Nome = "Calças", TipoRoupaId = 1  },
            new Categoria { Id = 7, Nome = "Acessórios", TipoRoupaId = 1  },
            new Categoria { Id = 8, Nome = "Destaques", TipoRoupaId = 1  }
        };
        builder.Entity<Categoria>().HasData(categorias);

        List<Produto> produtos = new List<Produto>{

            // ===== TÊNIS =====
            new Produto { Id = 1, CategoriaId = 1, Nome = "Nike Air Force 1",  ValorCusto = 300.00m, ValorVenda = 449.99m, QtdeEstoque = 25, Genero = Genero.Unissex, Marca="Nike", Cor="Branco", Material="Couro", AtividadeRecomendada="Casual", Descricao = "Confortável, durável e atemporal: não é à toa que ele é o número 1. A construção clássica dos anos 80 combina com detalhes arrojados para um estilo que acompanha você na quadra ou em qualquer lugar."},
            new Produto { Id = 2, CategoriaId = 1, Nome = "Adidas Ultraboost",  ValorCusto = 380.00m, ValorVenda = 599.99m, QtdeEstoque = 18, Genero = Genero.Unissex, Marca="Adidas", Cor="Preto", Material="Tecido Knit", AtividadeRecomendada="Corrida", Descricao = "Seja nas pistas ou nos treinos mais desafiadores, experimente um impulso a cada passo com este tênis de corrida Ultraboost adidas. Feito com nosso amortecimento BOOST mais leve de todos, ele devolve energia a cada passo. Combinado com o Torsion System para estabilidade do calcanhar à ponta do pé, ele oferece uma corrida suave e confortável que você precisa sentir para acreditar."},
            new Produto { Id = 3, CategoriaId = 1, Nome = "Puma RS-X", ValorCusto = 320.00m, ValorVenda = 489.90m, QtdeEstoque = 20, Genero = Genero.Masculino, Marca="Puma", Cor="Colorido", Material="Tecido e Sintético", AtividadeRecomendada="Casual",  Descricao = "O RS-X está de volta. A silhueta retrofuturista deste tênis retorna com uma estética progressiva e detalhes angulares, completos com sobreposições em nubuck e em suede. Essa combinação tem tudo a ver com um design inovador para mostrar seu estilo revolucionário."},
            new Produto { Id = 4, CategoriaId = 1, Nome = "Vans Old Skool",  ValorCusto = 200.00m, ValorVenda = 349.99m, QtdeEstoque = 22, Genero = Genero.Masculino, Marca="Vans", Cor="Preto", Material="Lona e Camurça", AtividadeRecomendada="Skate", Descricao = "Em 1977, o tênis Old Skool, originalmente nomeado de Vans #36 foi lançado sendo o primeiro a conter a icônica sidestripe na lateral. O que começou como um rabisco de Paul Van Doren, originalmente chamado de “Jazz Stripe”, se tornou um dos ícones da marca Vans. O Tênis Old Skool Black White é um tênis de cano baixo com cadarço que possui cabedal de lona têxtil e camurça resistente na cor preta, sidestripe em couro branco e viras laterais borracha na cor branca com biqueiras reforçadas para suportar o desgaste por repetição, cano acolchoado para dar suporte e flexibilidade e a clássica sola de borracha waffle vulcanizada exclusiva Vans."},
            new Produto { Id = 5, CategoriaId = 1, Nome = "New Balance 574", Descricao = "A partir da silhueta exclusiva dos anos 80, o Tênis Casual Unissex New Balance 574V2 garante estilo clássico ao seu visual. O modelo traz amortecimento na entressola em ENCAP, que combina espuma leve com borda de poliuretano durável para oferecer conforto o dia todo.", ValorCusto = 280.00m, ValorVenda = 419.99m, QtdeEstoque = 15, Genero = Genero.Unissex, Marca="New Balance", Cor="Cinza", Material="Suede e Malha", AtividadeRecomendada="Casual" },
            new Produto { Id = 6, CategoriaId = 1, Nome = "Converse Chuck Taylor", ValorCusto = 150.00m, ValorVenda = 269.99m, QtdeEstoque = 30, Genero = Genero.Unissex, Marca="Converse", Cor="Preto", Material="Lona", AtividadeRecomendada="Casual", Descricao = "Desde 1917, o Chuck Taylor All Star tem sido o ícone do dia a dia. Você já conhece os detalhes icônicos como o cabedal em lona de algodão, solado com padrão de diamante e a indistinguível biqueira de borracha. Finalizado com palmilha em EVA para ajudar a manter os pés confortáveis."},
            new Produto { Id = 7, CategoriaId = 1, Nome = "Asics Gel-Kayano 28",  ValorCusto = 400.00m, ValorVenda = 649.99m, QtdeEstoque = 12, Genero = Genero.Unissex, Marca="Asics", Cor="Azul", Material="Mesh", AtividadeRecomendada="Corrida", Descricao = "O Tênis Asics Gel Kayano 28 é perfeito para mulheres que buscam desempenho e conforto em suas corridas. Desenvolvido com as melhores tecnologias da Asics, este tênis proporciona uma experiência de corrida superior. A tecnologia FF BLAST™ na entressola oferece uma sensação suave e de suporte em cada passo, garantindo conforto e eficiência. O amortecimento GEL™ proporciona uma passada suave, permitindo uma aterrissagem mais confortável sem perder velocidade."},
            new Produto { Id = 8, CategoriaId = 1, Nome = "Nike Dunk Low", ValorCusto = 360.00m, ValorVenda = 549.99m, QtdeEstoque = 10, Genero = Genero.Unissex, Marca="Nike", Cor="Colorido", Material="Couro e Sintético", AtividadeRecomendada="Casual",  Descricao = "Originalmente criado para as quadras, o Dunk mais tarde foi para as ruas - e como se costuma dizer, o resto é história. Mais de 35 anos após sua estreia, a silhueta ainda oferece um estilo ousado e desafiador. Agora, o tênis OG do basquete universitário retorna com camadas sobrepostas em couro premium e color blocking tradicional. O conforto fica por conta da tecnologia mais atual em calçados, enquanto uma combinação clássica de preto e branco remete ao legado das quadras."},
            new Produto { Id = 9, CategoriaId = 1, Nome = "Mizuno Wave Prophecy",  ValorCusto = 500.00m, ValorVenda = 799.99m, QtdeEstoque = 8, Genero = Genero.Masculino, Marca="Mizuno", Cor="Preto", Material="Mesh e Borracha", AtividadeRecomendada="Corrida", Descricao = "A entressola possui a tecnologia Infinity Wave em toda a sua extensão dando a ele um visual moderno e tecnológico. O cabedal feito em mesh laminado proporciona maior respirabilidade e ajuste aos seus pés para um estilo mais casual. Além disso, o solado tem a tecnologia X10, um composto de borracha com carbono que garante maior durabilidade."},
            new Produto { Id = 10, CategoriaId = 1, Nome = "Fila Disruptor II",  ValorCusto = 220.00m, ValorVenda = 369.99m, QtdeEstoque = 14, Genero = Genero.Feminino, Marca="Fila", Cor="Branco", Material="Sintético", AtividadeRecomendada="Casual", Descricao = "Modelo atemporal da Fila, febre mundial e vencedor de 2018 do prêmio de Shoe of the Year - Esse é o tênis Fila Disruptor II. Seu design autêntico e robusto une o estilo retrô e moderno em um modelo casual, destaque para a sola tratorada que garante alta durabilidade e maior aderência ao solo."},
            new Produto { Id = 11, CategoriaId = 1, Nome = "Reebok Classic", ValorCusto = 180.00m, ValorVenda = 299.99m, QtdeEstoque = 16, Genero = Genero.Unissex, Marca="Reebok", Cor="Branco", Material="Couro", AtividadeRecomendada="Casual", Descricao = "O Reebok Classic Leather é um ícone dos anos 80 que continua sendo uma referência de estilo e conforto até hoje. Com uma história única, o Reebok Classic Leather foi lançado originalmente em 1983, sendo o primeiro tênis de corrida a utilizar couro no cabedal."},
            new Produto { Id = 12, CategoriaId = 1, Nome = "Under Armour HOVR",  ValorCusto = 310.00m, ValorVenda = 459.99m, QtdeEstoque = 10, Genero = Genero.Masculino, Marca="Under Armour", Cor="Preto", Material="Tecido Knit", AtividadeRecomendada="Corrida", Descricao = "Estes calçados de caminhada unissex repletos de tecnologia desenvolvida para corrida e atividades ao ar livre são feitos para ir a qualquer lugar: Amortecimento UA HOVR ™ de nossos tênis de corrida, parte inferior em Michelin inspirada em pneus de bicicleta."},
            new Produto { Id = 13, CategoriaId = 1, Nome = "Jordan 1 Mid",  ValorCusto = 450.00m, ValorVenda = 749.99m, QtdeEstoque = 6, Genero = Genero.Masculino, Marca="Nike Jordan", Cor="Preto/Vermelho", Material="Couro", AtividadeRecomendada="Casual", Descricao = "Trouxemos os recibos com esta edição especial do AJ1. Feito de couro macio e cremoso, este favorito de todos os tempos vem adornado com detalhes sutis de design para um estilo de dar água na boca."},
            new Produto { Id = 14, CategoriaId = 1, Nome = "Oakley Modoc", ValorCusto = 280.00m, ValorVenda = 399.99m, QtdeEstoque = 18, Genero = Genero.Masculino, Marca="Oakley", Cor="Marrom", Material="Couro e Borracha", AtividadeRecomendada="Trilha",  Descricao = "Pertencente a linha Outdoor, o modelo MODOC LOW II possui um solado de borracha garantindo máxima durabilidade e resistência a abrasão, a entressola em EVA proporciona maior conforto, parte superior em camurça e tecido com logotipo da marca em metal revelam a robustez do produto, garantem durabilidade e design único."},
            new Produto { Id = 15, CategoriaId = 1, Nome = "Nike ZoomX Vaporfly",  ValorCusto = 600.00m, ValorVenda = 999.99m, QtdeEstoque = 5, Genero = Genero.Masculino, Marca="Nike", Cor="Branco/Verde", Material="Mesh", AtividadeRecomendada="Corrida", Descricao = "Pegue-os se puder. Dando a você a velocidade do dia da corrida para conquistar qualquer distância, o Nike Vaporfly 3 é feito para aqueles que buscam, os pilotos, os pacers elevados que não conseguem diminuir a emoção da busca. Retrabalhamos o líder do super pacote de calçados e ajustamos o motor embaixo para ajudá-lo a buscar recordes pessoais de 10 km até a maratona. De corredores de elite a novatos em corridas, este cavalo de batalha versátil para corridas de rua é para aqueles que veem a velocidade como uma porta de entrada para mais quilômetros e elevações aparentemente inatingíveis."},

            new Produto { Id = 41, CategoriaId = 1, Nome = "Tênis Nike Air Max Excee Feminino",  ValorCusto = 379.99m, ValorVenda = 799.99m, QtdeEstoque = 127, Genero = Genero.Feminino, Marca="Nike", Cor="Creme", Material="Couro e Material Sintético", AtividadeRecomendada="Dia a Dia", Descricao = "Inspirado no Nike Air Max 90, o Nike Air Max Excee comemora um clássico com um visual repaginado. O design de linhas alongadas e proporções distorcidas na parte de cima elevam um ícone a um patamar moderno. A unidade Air é visível através de três janelas criando um look atualizado. A entressola de espuma e a sola com cápsulas de espuma e borracha oferecem conforto e durabilidade com muita leveza. As linhas de design alongadas homenageiam o Air Max 90, ao mesmo tempo que o modernizam de forma irreverente."},
            new Produto { Id = 42, CategoriaId = 1, Nome = "Tênis Nike MC Trainer 3 Feminino",  ValorCusto = 379.99m, ValorVenda = 499.99m, QtdeEstoque = 52, Genero = Genero.Feminino, Marca="Nike", Cor="Branco", Material="Malha, Espuma e Borracha", AtividadeRecomendada="Dia a Dia", Descricao = "Repita a última série e mantenha-se firme nos céus e nas sustentações com o MC Trainer 3. Uma base plana e resistente fornece um nível confiável de estabilidade aos movimentos que você mais gosta. O cabedal adaptável ajuda a mantê-lo contido durante movimentos laterais. A sensação confortável sob os pés é ótima para uso durante todo o dia, dentro e fora da academia. Quanto mais suporte o tênis proporciona, mais estabilidade ele pode dar ao seu passo. Uma combinação de suporte configurado e amortecimento intencionalmente colocado ajuda você a se sentir seguro a cada passo. Uma base reta e estável ajuda a mantê-lo firme e sólido ao fazer movimentos laterais."},
            new Produto { Id = 43, CategoriaId = 1, Nome = "Women's Air Force 1 '07 Low",  ValorCusto = 450.99m, ValorVenda = 999.99m, QtdeEstoque = 22, Genero = Genero.Feminino, Marca="Nike", Cor="Branco", Material="Couro Sintético", AtividadeRecomendada="Dia a Dia", Descricao = "Confortável, durável e atemporal — não é à toa que é o número um. O Air Force 1 combina sua silhueta clássica com couro premium para um visual elegante e clean. Esta versão inclui uma corrente prateada e pingentes para elevar seu estilo."},
            new Produto { Id = 44, CategoriaId = 1, Nome = "COURTBLOCK",  ValorCusto = 116.67m, ValorVenda = 349.99m, QtdeEstoque = 37, Genero = Genero.Feminino, Marca="Adidas", Cor="Linen Green", Material="Couro", AtividadeRecomendada="Dia a Dia", Descricao = "O Courtblock é novo para essas características de filtro em nosso website, na categoria Mulher. Mas você já pode visualizar as imagens acima e ter mais detalhes, para conhecer o produto de diferentes ângulos em primeira mão. Se você já experimentou o Courtblock antes, deixe um comentário a seguir para nos contar o que você achou. Ainda estamos trabalhando para obter mais informações sobre o Courtblock aqui, então não esqueça de retornar ao site em breve. Enquanto isso, aqui está o número do artigo do produto HP7211 para sua referência. Ele é classificado na categoria Tênis."},
            new Produto { Id = 45, CategoriaId = 1, Nome = "Stella McCartney Ultraboost 5",  ValorCusto = 269.67m, ValorVenda = 1299.99m, QtdeEstoque = 12, Genero = Genero.Feminino, Marca="Adidas", Cor="Willow Grey", Material="Malha Elástica, Forro Sintético e Borracha", AtividadeRecomendada="Corrida", Descricao = "Seja para uma corrida rápida ao redor do quarteirão ou cumprir as tarefas da cidade, este tênis adidas Ultraboost está pronto para acompanhar. A entressola BOOST leve e de suporte deixa cada passo mais energizado, enquanto o cabedal em malha elástica respirável mantém seus pés refrescados e confortáveis por quilômetros."},
            new Produto { Id = 46, CategoriaId = 1, Nome = "Tênis Jabbar Hi",  ValorCusto = 315.76m, ValorVenda = 1499.99m, QtdeEstoque = 15, Genero = Genero.Feminino, Marca="Adidas", Cor="Cream White", Material="Forro Sintético, Couro e Borracha", AtividadeRecomendada="Fashion", Descricao = "Nascido da quadra de basquete e criado para o seu estilo diário, adidas Jabbar Hi é um tênis clássico por completo. Embora as origens do basquete dos anos 70 brilhem na silhueta de cano alto, no calcanhar de couro e nas Três Listras, as atualizações moderno vêm na forma de um acabamento premium de pelo de pônei com hachuras cruzadas gravadas a laser. O visual limpo é pouco esforço, versátil e pronto para ser combinado com qualquer roupa ou passeio."},
            new Produto { Id = 47, CategoriaId = 1, Nome = "Tênis de Treino Prospect",  ValorCusto = 217.67m, ValorVenda = 449.99m, QtdeEstoque = 34, Genero = Genero.Feminino, Marca="Puma", Cor="Preto", Material="Tecido, Formstrip e Borracha", AtividadeRecomendada="Treino", Descricao = "The Prospect, um novo treinador com atitude. O tênis possui PROFOAM em todo o comprimento para uma caminhada suave e transferência de energia, e a sola é totalmente em borracha com áreas especiais para aderência superior em todas as condições. Este tênis está repleto de tecnologia que o torna estável, mas fácil de colocar e tirar."},

            // ===== ROUPAS =====
            new Produto { Id = 16, CategoriaId = 2, Nome = "Camiseta Oversized Branca",  ValorCusto = 40.00m, ValorVenda = 79.90m, QtdeEstoque = 50, Genero = Genero.Masculino, Marca="9xHype", Cor="Branco", Material="Algodão", AtividadeRecomendada="Casual", Descricao = "A Camiseta Oversized Branca da 9xHype entrega conforto máximo com sua modelagem larga e tecido 100% algodão. Ideal para quem busca um visual moderno e despojado no dia a dia. O caimento soltinho garante liberdade de movimento sem perder o estilo. Perfeita para composições casuais e streetwear."},
            new Produto { Id = 17, CategoriaId = 6, Nome = "Calça Cargo Preta", ValorCusto = 90.00m, ValorVenda = 149.99m, QtdeEstoque = 30, Genero = Genero.Masculino, Marca="9xHype", Cor="Preto", Material="Algodão e Poliéster", AtividadeRecomendada="Casual",  Descricao = "A Calça Cargo Preta combina estilo urbano e praticidade com seus bolsos laterais funcionais. Confeccionada em algodão e poliéster, oferece resistência e conforto para o dia a dia. O ajuste no tornozelo dá um toque moderno e facilita combinações com tênis. Ideal para looks casuais e cheios de atitude."},
            new Produto { Id = 18, CategoriaId = 4, Nome = "Jaqueta Corta-Vento", ValorCusto = 120.00m, ValorVenda = 219.99m, QtdeEstoque = 12, Genero = Genero.Unissex, Marca="9xHype", Cor="Cinza", Material="Poliéster", AtividadeRecomendada="Esportivo", Descricao = "A Jaqueta Corta-Vento da 9xHype é a escolha perfeita para dias chuvosos e ventosos. Feita em poliéster leve e impermeável, garante proteção sem pesar no corpo. Seu design unissex combina com qualquer estilo. Ideal para práticas esportivas ou uso urbano com conforto e versatilidade."},
            new Produto { Id = 19, CategoriaId = 3, Nome = "Moletom Liso com Capuz", ValorCusto = 80.00m, ValorVenda = 129.90m, QtdeEstoque = 25, Genero = Genero.Unissex, Marca="9xHype", Cor="Cinza", Material="Algodão", AtividadeRecomendada="Casual", Descricao = "O Moletom Liso com Capuz oferece conforto térmico com seu tecido peluciado de algodão. Com design unissex, é uma peça versátil para diversas ocasiões casuais. O toque macio proporciona uma experiência aconchegante nos dias mais frios. Um clássico essencial para o guarda-roupa." },
            new Produto { Id = 20, CategoriaId = 5, Nome = "Bermuda de Sarja Bege", ValorCusto = 60.00m, ValorVenda = 99.99m, QtdeEstoque = 35, Genero = Genero.Masculino, Marca="9xHype", Cor="Bege", Material="Sarja", AtividadeRecomendada="Casual", Descricao = "A Bermuda de Sarja Bege é perfeita para compor looks casuais com estilo. Fabricada em sarja resistente, garante conforto e durabilidade no dia a dia. Seus bolsos laterais adicionam praticidade sem comprometer o visual. Ideal para dias quentes e combinações simples e elegantes." },
            new Produto { Id = 21, CategoriaId = 2, Nome = "Camisa Social Slim", ValorCusto = 70.00m, ValorVenda = 119.99m, QtdeEstoque = 20, Genero = Genero.Masculino, Marca="9xHype", Cor="Branca", Material="Algodão", AtividadeRecomendada="Social", Descricao = "A Camisa Social Slim oferece um caimento moderno com seu corte ajustado ao corpo. Confeccionada em algodão macio, proporciona conforto durante todo o dia. Seu visual clean e elegante permite uso tanto em eventos formais quanto em momentos sociais. Uma peça essencial para quem busca estilo e sofisticação." },
            new Produto { Id = 22, CategoriaId = 2, Nome = "Vestido Midi Floral", ValorCusto = 90.00m, ValorVenda = 149.90m, QtdeEstoque = 18, Genero = Genero.Feminino, Marca="9xHype", Cor="Floral", Material="Viscose", AtividadeRecomendada="Casual", Descricao = "O Vestido Midi Floral é leve, fluido e perfeito para o verão. Feito em viscose, possui toque suave e ótimo caimento. O design floral traz um visual fresco e feminino, ideal para passeios e ocasiões casuais. Uma peça confortável que combina estilo e praticidade."},

            new Produto { Id = 23, CategoriaId = 6, Nome = "Calça Jeans Skinny", ValorCusto = 100.00m, ValorVenda = 169.99m, QtdeEstoque = 28, Genero = Genero.Unissex, Marca="9xHype", Cor="Azul Jeans", Material="Jeans com Elastano", AtividadeRecomendada="Casual", Descricao = "A Calça Jeans Skinny conta com elastano que garante flexibilidade e conforto durante o uso. Seu corte ajustado oferece um visual moderno e versátil, combinando com diferentes tipos de looks. O tom azul jeans clássico é ideal para o dia a dia. Uma peça unissex perfeita para quem busca estilo sem abrir mão da mobilidade." },
            new Produto { Id = 24, CategoriaId = 4, Nome = "Jaqueta Jeans Feminina", ValorCusto = 130.00m, ValorVenda = 199.99m, QtdeEstoque = 10, Genero = Genero.Feminino, Marca="9xHype", Cor="Azul Jeans", Material="Jeans", AtividadeRecomendada="Casual", Descricao = "A Jaqueta Jeans Feminina traz o clássico estilo urbano com um toque moderno. Fabricada em jeans resistente, oferece durabilidade e caimento estruturado. Ideal para combinar com vestidos, croppeds e camisetas. Uma peça curinga para qualquer guarda-roupa feminino." },
            new Produto { Id = 25, CategoriaId = 5, Nome = "Shorts de Moletom", ValorCusto = 50.00m, ValorVenda = 89.99m, QtdeEstoque = 40, Genero = Genero.Unissex, Marca="9xHype", Cor="Cinza", Material="Moletom", AtividadeRecomendada="Casual", Descricao = "O Shorts de Moletom é perfeito para quem prioriza conforto sem perder o estilo. Seu tecido macio proporciona liberdade de movimento para o dia a dia. Ideal para atividades leves, passeios ou uso em casa. Uma peça unissex versátil e prática." },
            new Produto { Id = 26, CategoriaId = 2, Nome = "Camiseta Polo Preta Feminina", ValorCusto = 35.00m, ValorVenda = 69.90m, QtdeEstoque = 60, Genero = Genero.Feminino, Marca="9xHype", Cor="Preto", Material="Algodão", AtividadeRecomendada="Casual", Descricao = "A Camiseta Polo Preta Feminina é feita em algodão de alta qualidade, garantindo conforto e respirabilidade. Seu design clássico com gola polo oferece um toque elegante ao look casual. Ideal para o dia a dia ou ambientes mais descontraídos. Combina facilmente com jeans, shorts ou saias." },
            new Produto { Id = 27, CategoriaId = 2, Nome = "Macacão Feminino", ValorCusto = 110.00m, ValorVenda = 179.99m, QtdeEstoque = 14, Genero = Genero.Feminino, Marca="9xHype", Cor="Preto", Material="Viscose", AtividadeRecomendada="Casual", Descricao = "O Macacão Feminino da 9xHype é a peça ideal para quem busca praticidade sem abrir mão do estilo. Feito em viscose, oferece leveza e ótimo caimento. Seu design moderno valoriza a silhueta de forma confortável. Excelente para eventos casuais ou combinações rápidas e elegantes." },
            new Produto { Id = 28, CategoriaId = 3, Nome = "Blusa Cropped Texturizada", ValorCusto = 45.00m, ValorVenda = 79.99m, QtdeEstoque = 22, Genero = Genero.Feminino, Marca="9xHype", Cor="Rosa", Material="Poliéster", AtividadeRecomendada="Casual", Descricao = "A Blusa Cropped Texturizada traz um visual jovem e moderno com sua superfície diferenciada. Confeccionada em poliéster, é leve e confortável para o dia a dia. Ideal para compor looks estilosos com calças de cintura alta ou saias. Uma peça versátil para diversas ocasiões casuais." },
            new Produto { Id = 29, CategoriaId = 2, Nome = "Camisa Polo Texturizada Masculina Marrom", ValorCusto = 65.00m, ValorVenda = 109.99m, QtdeEstoque = 19, Genero = Genero.Masculino, Marca="9xHype", Cor="Marrom", Material="Algodão", AtividadeRecomendada="Casual", Descricao = "A Camisa Polo Texturizada Masculina combina elegância e conforto em uma peça só. Feita em algodão, possui toque macio e ótima respirabilidade. Sua textura diferenciada adiciona sofisticação ao look casual. Ideal para quem busca um visual arrumado sem perder a essência descontraída." },
            new Produto { Id = 30, CategoriaId = 2, Nome = "Regata Dry Fit", ValorCusto = 30.00m, ValorVenda = 59.90m, QtdeEstoque = 50, Genero = Genero.Unissex, Marca="9xHype", Cor="Cinza", Material="Poliéster", AtividadeRecomendada="Treino", Descricao = "A Regata Dry Fit é perfeita para treinos, oferencendo leveza e rápida evaporação do suor. Feita em poliéster, garante ventilação e conforto até nos exercícios mais intensos. Seu design unissex se adapta a diferentes estilos e corpos. Ideal para quem busca desempenho e mobilidade." },


            // ===== DESTAQUES =====
            new Produto { Id = 31, CategoriaId = 8, Nome = "Nike Air Force 1", ValorCusto = 300.00m, ValorVenda = 449.99m, QtdeEstoque = 25, Marca="Nike", Cor="Branco", Material="Couro", AtividadeRecomendada="Casual", Descricao = "Confortável, durável e atemporal: não é à toa que ele é o número 1. A construção clássica dos anos 80 combina com detalhes arrojados para um estilo que acompanha você na quadra ou em qualquer lugar." },
            new Produto { Id = 32, CategoriaId = 8, Nome = "Adidas Ultraboost", ValorCusto = 380.00m, ValorVenda = 599.99m, QtdeEstoque = 18, Marca="Adidas", Cor="Preto", Material="Tecido Knit", AtividadeRecomendada="Corrida", Descricao = "Seja nas pistas ou nos treinos mais desafiadores, experimente um impulso a cada passo com este tênis de corrida Ultraboost adidas. Feito com nosso amortecimento BOOST mais leve de todos, ele devolve energia a cada passo. Combinado com o Torsion System para estabilidade do calcanhar à ponta do pé, ele oferece uma corrida suave e confortável que você precisa sentir para acreditar." },
            new Produto { Id = 33, CategoriaId = 8, Nome = "Puma RS-X", ValorCusto = 320.00m, ValorVenda = 489.90m, QtdeEstoque = 20, Marca="Puma", Cor="Colorido", Material="Tecido e Sintético", AtividadeRecomendada="Casual", Descricao = "O RS-X está de volta. A silhueta retrofuturista deste tênis retorna com uma estética progressiva e detalhes angulares, completos com sobreposições em nubuck e em suede. Essa combinação tem tudo a ver com um design inovador para mostrar seu estilo revolucionário." },
            new Produto { Id = 34, CategoriaId = 8, Nome = "Vans Old Skool", ValorCusto = 200.00m, ValorVenda = 349.99m, QtdeEstoque = 22, Marca="Vans", Cor="Preto", Material="Lona e Camurça", AtividadeRecomendada="Skate", Descricao = "Em 1977, o tênis Old Skool, originalmente nomeado de Vans #36 foi lançado sendo o primeiro a conter a icônica sidestripe na lateral. O que começou como um rabisco de Paul Van Doren, originalmente chamado de “Jazz Stripe”, se tornou um dos ícones da marca Vans. O Tênis Old Skool Black White é um tênis de cano baixo com cadarço que possui cabedal de lona têxtil e camurça resistente na cor preta, sidestripe em couro branco e viras laterais borracha na cor branca com biqueiras reforçadas para suportar o desgaste por repetição, cano acolchoado para dar suporte e flexibilidade e a clássica sola de borracha waffle vulcanizada exclusiva Vans." },
            new Produto { Id = 35, CategoriaId = 8, Nome = "New Balance 574", ValorCusto = 280.00m, ValorVenda = 419.99m, QtdeEstoque = 15, Marca="New Balance", Cor="Cinza", Material="Suede e Malha", AtividadeRecomendada="Casual", Descricao = "A partir da silhueta exclusiva dos anos 80, o Tênis Casual Unissex New Balance 574V2 garante estilo clássico ao seu visual. O modelo traz amortecimento na entressola em ENCAP, que combina espuma leve com borda de poliuretano durável para oferecer conforto o dia todo." },
            new Produto { Id = 36, CategoriaId = 8, Nome = "Converse Chuck Taylor", ValorCusto = 150.00m, ValorVenda = 269.99m, QtdeEstoque = 30, Marca="Converse", Cor="Preto", Material="Lona", AtividadeRecomendada="Casual", Descricao = "Desde 1917, o Chuck Taylor All Star tem sido o ícone do dia a dia. Você já conhece os detalhes icônicos como o cabedal em lona de algodão, solado com padrão de diamante e a indistinguível biqueira de borracha. Finalizado com palmilha em EVA para ajudar a manter os pés confortáveis." },
            new Produto { Id = 37, CategoriaId = 8, Nome = "Asics Gel-Kayano 28", ValorCusto = 400.00m, ValorVenda = 649.99m, QtdeEstoque = 12, Marca="Asics", Cor="Azul", Material="Mesh", AtividadeRecomendada="Corrida", Descricao = "O Tênis Asics Gel Kayano 28 é perfeito para mulheres que buscam desempenho e conforto em suas corridas. Desenvolvido com as melhores tecnologias da Asics, este tênis proporciona uma experiência de corrida superior. A tecnologia FF BLAST™ na entressola oferece uma sensação suave e de suporte em cada passo, garantindo conforto e eficiência. O amortecimento GEL™ proporciona uma passada suave, permitindo uma aterrissagem mais confortável sem perder velocidade." },
            new Produto { Id = 38, CategoriaId = 8, Nome = "Nike Dunk Low", ValorCusto = 360.00m, ValorVenda = 549.99m, QtdeEstoque = 10, Marca="Nike", Cor="Colorido", Material="Couro e Sintético", AtividadeRecomendada="Casual", Descricao = "Originalmente criado para as quadras, o Dunk mais tarde foi para as ruas - e como se costuma dizer, o resto é história. Mais de 35 anos após sua estreia, a silhueta ainda oferece um estilo ousado e desafiador. Agora, o tênis OG do basquete universitário retorna com camadas sobrepostas em couro premium e color blocking tradicional. O conforto fica por conta da tecnologia mais atual em calçados, enquanto uma combinação clássica de preto e branco remete ao legado das quadras." },
            new Produto { Id = 39, CategoriaId = 8, Nome = "Mizuno Wave Prophecy", ValorCusto = 500.00m, ValorVenda = 799.99m, QtdeEstoque = 8, Marca="Mizuno", Cor="Preto", Material="Mesh e Borracha", AtividadeRecomendada="Corrida", Descricao = "A entressola possui a tecnologia Infinity Wave em toda a sua extensão dando a ele um visual moderno e tecnológico. O cabedal feito em mesh laminado proporciona maior respirabilidade e ajuste aos seus pés para um estilo mais casual. Além disso, o solado tem a tecnologia X10, um composto de borracha com carbono que garante maior durabilidade." },
            new Produto { Id = 40, CategoriaId = 8, Nome = "Fila Disruptor II", ValorCusto = 220.00m, ValorVenda = 369.99m, QtdeEstoque = 14, Marca="Fila", Cor="Branco", Material="Sintético", AtividadeRecomendada="Casual", Descricao = "Modelo atemporal da Fila, febre mundial e vencedor de 2018 do prêmio de Shoe of the Year - Esse é o tênis Fila Disruptor II. Seu design autêntico e robusto une o estilo retrô e moderno em um modelo casual, destaque para a sola tratorada que garante alta durabilidade e maior aderência ao solo." },


        };

        builder.Entity<Produto>().HasData(produtos);

        List<ProdutoFoto> produtoFotos = new List<ProdutoFoto>
        {
            // Produto 1 - Nike Air Force 1
            new ProdutoFoto { Id = 1, ProdutoId = 1, ArquivoFoto = "/ninexhype-img/500x500/NikeAirForceOne1.png"},
            new ProdutoFoto { Id = 2, ProdutoId = 1, ArquivoFoto = "/ninexhype-img/500x500/NikeAirForceOne2.png"},
            new ProdutoFoto { Id = 3, ProdutoId = 1, ArquivoFoto = "/ninexhype-img/500x500/NikeAirForceOne3.png"},

            // Produto 2 - Adidas Ultraboost
            new ProdutoFoto { Id = 4, ProdutoId = 2, ArquivoFoto = "/ninexhype-img/500x500/AdidasUltraboost1.png"},
            new ProdutoFoto { Id = 5, ProdutoId = 2, ArquivoFoto = "/ninexhype-img/500x500/AdidasUltraboost2.png"},
            new ProdutoFoto { Id = 6, ProdutoId = 2, ArquivoFoto = "/ninexhype-img/500x500/AdidasUltraboost3.png"},

            // Produto 3 - Puma RS-X
            new ProdutoFoto { Id = 7, ProdutoId = 3, ArquivoFoto = "/ninexhype-img/500x500/PumaRS-X1.png"},
            new ProdutoFoto { Id = 8, ProdutoId = 3, ArquivoFoto = "/ninexhype-img/500x500/PumaRS-X2.png"},
            new ProdutoFoto { Id = 9, ProdutoId = 3, ArquivoFoto = "/ninexhype-img/500x500/PumaRS-X3.png"},

            // Produto 4 - Vans Old Skool
            new ProdutoFoto { Id = 10, ProdutoId = 4, ArquivoFoto = "/ninexhype-img/500x500/VansOldSkool1.png"},
            new ProdutoFoto { Id = 11, ProdutoId = 4, ArquivoFoto = "/ninexhype-img/500x500/VansOldSkool2.png"},
            new ProdutoFoto { Id = 12, ProdutoId = 4, ArquivoFoto = "/ninexhype-img/500x500/VansOldSkool3.png"},

            // Produto 5 - New Balance 574
            new ProdutoFoto { Id = 13, ProdutoId = 5, ArquivoFoto = "/ninexhype-img/500x500/NewBalance574_1.png" },
            new ProdutoFoto { Id = 14, ProdutoId = 5, ArquivoFoto = "/ninexhype-img/500x500/NewBalance574_2.png" },
            new ProdutoFoto { Id = 15, ProdutoId = 5, ArquivoFoto = "/ninexhype-img/500x500/NewBalance574_3.png" },

            // Produto 6 - Converse Chuck Taylor
            new ProdutoFoto { Id = 16, ProdutoId = 6, ArquivoFoto = "/ninexhype-img/500x500/ConverseChuckTaylor1.png" },
            new ProdutoFoto { Id = 17, ProdutoId = 6, ArquivoFoto = "/ninexhype-img/500x500/ConverseChuckTaylor2.png" },
            new ProdutoFoto { Id = 18, ProdutoId = 6, ArquivoFoto = "/ninexhype-img/500x500/ConverseChuckTaylor3.png" },

            // Produto 7 - Asics Gel-Kayano 28
            new ProdutoFoto { Id = 19, ProdutoId = 7, ArquivoFoto = "/ninexhype-img/500x500/AsicsGel-Kayano28_1.png" },
            new ProdutoFoto { Id = 20, ProdutoId = 7, ArquivoFoto = "/ninexhype-img/500x500/AsicsGel-Kayano28_2.png" },
            new ProdutoFoto { Id = 21, ProdutoId = 7, ArquivoFoto = "/ninexhype-img/500x500/AsicsGel-Kayano28_3.png" },

            // Produto 8 - Nike Dunk Low

            // AINDA NAO PEGAMOS AS FOTOS
            new ProdutoFoto { Id = 22, ProdutoId = 8, ArquivoFoto = "/ninexhype-img/500x500/NikeDunkLow1.png" },
            new ProdutoFoto { Id = 23, ProdutoId = 8, ArquivoFoto = "/ninexhype-img/500x500/NikeDunkLow2.png" },
            new ProdutoFoto { Id = 24, ProdutoId = 8, ArquivoFoto = "/ninexhype-img/500x500/NikeDunkLow3.png" },

            // Produto 9 - Mizuno Wave Prophecy
            new ProdutoFoto { Id = 25, ProdutoId = 9, ArquivoFoto = "/ninexhype-img/500x500/MizunoWaveProphecy1.png" },
            new ProdutoFoto { Id = 26, ProdutoId = 9, ArquivoFoto = "/ninexhype-img/500x500/MizunoWaveProphecy2.png" },
            new ProdutoFoto { Id = 27, ProdutoId = 9, ArquivoFoto = "/ninexhype-img/500x500/MizunoWaveProphecy3.png" },

            // Produto 10 - Fila Disruptor II
            new ProdutoFoto { Id = 28, ProdutoId = 10, ArquivoFoto = "/ninexhype-img/500x500/FilaDisruptorII1.png"},
            new ProdutoFoto { Id = 29, ProdutoId = 10, ArquivoFoto = "/ninexhype-img/500x500/FilaDisruptorII2.png"},
            new ProdutoFoto { Id = 30, ProdutoId = 10, ArquivoFoto = "/ninexhype-img/500x500/FilaDisruptorII3.png"},

            // Produto 11 - Reebok Classic
            new ProdutoFoto { Id = 31, ProdutoId = 11, ArquivoFoto = "/ninexhype-img/500x500/ReebokClassic1.png"},
            new ProdutoFoto { Id = 32, ProdutoId = 11, ArquivoFoto = "/ninexhype-img/500x500/ReebokClassic2.png"},
            new ProdutoFoto { Id = 33, ProdutoId = 11, ArquivoFoto = "/ninexhype-img/500x500/ReebokClassic3.png"},

            // Produto 12 - Under Armour HOVR
            new ProdutoFoto { Id = 34, ProdutoId = 12, ArquivoFoto = "/ninexhype-img/500x500/UnderArmourHOVR1.png"},
            new ProdutoFoto { Id = 35, ProdutoId = 12, ArquivoFoto = "/ninexhype-img/500x500/UnderArmourHOVR2.png"},
            new ProdutoFoto { Id = 36, ProdutoId = 12, ArquivoFoto = "/ninexhype-img/500x500/UnderArmourHOVR3.png"},

            // Produto 13 - Jordan 1 Mid
            new ProdutoFoto { Id = 37, ProdutoId = 13, ArquivoFoto = "/ninexhype-img/500x500/Jordan1Mid1.png"},
            new ProdutoFoto { Id = 38, ProdutoId = 13, ArquivoFoto = "/ninexhype-img/500x500/Jordan1Mid2.png"},
            new ProdutoFoto { Id = 39, ProdutoId = 13, ArquivoFoto = "/ninexhype-img/500x500/Jordan1Mid3.png"},

            // Produto 14 - Oakley Modoc
            new ProdutoFoto { Id = 40, ProdutoId = 14, ArquivoFoto = "/ninexhype-img/500x500/OakleyModoc1.png"},
            new ProdutoFoto { Id = 41, ProdutoId = 14, ArquivoFoto = "/ninexhype-img/500x500/OakleyModoc2.png"},
            new ProdutoFoto { Id = 42, ProdutoId = 14, ArquivoFoto = "/ninexhype-img/500x500/OakleyModoc3.png"},

            // Produto 15 - Nike ZoomX Vaporfly
            new ProdutoFoto { Id = 43, ProdutoId = 15, ArquivoFoto = "/ninexhype-img/500x500/NikeZoomXVaporfly1.png"},
            new ProdutoFoto { Id = 44, ProdutoId = 15, ArquivoFoto = "/ninexhype-img/500x500/NikeZoomXVaporfly2.png"},
            new ProdutoFoto { Id = 45, ProdutoId = 15, ArquivoFoto = "/ninexhype-img/500x500/NikeZoomXVaporfly3.png"},

            // Produto 16 - Camiseta Oversized Branca
            new ProdutoFoto { Id = 46, ProdutoId = 16, ArquivoFoto = "/ninexhype-img/500x500/CamisetaOversizedBranca1.png"},
            new ProdutoFoto { Id = 47, ProdutoId = 16, ArquivoFoto = "/ninexhype-img/500x500/CamisetaOversizedBranca2.png"},
            new ProdutoFoto { Id = 48, ProdutoId = 16, ArquivoFoto = "/ninexhype-img/500x500/CamisetaOversizedBranca3.png"},

            // Produto 17 - Calça Cargo Preta
            new ProdutoFoto { Id = 49, ProdutoId = 17, ArquivoFoto = "/ninexhype-img/500x500/CalcaCargoPreta1.png"},
            new ProdutoFoto { Id = 50, ProdutoId = 17, ArquivoFoto = "/ninexhype-img/500x500/CalcaCargoPreta2.png"},
            new ProdutoFoto { Id = 51, ProdutoId = 17, ArquivoFoto = "/ninexhype-img/500x500/CalcaCargoPreta3.png"},

            // Produto 18 - Jaqueta Corta-Vento
            new ProdutoFoto { Id = 52, ProdutoId = 18, ArquivoFoto = "/ninexhype-img/500x500/JaquetaCortaVento.png"},
            new ProdutoFoto { Id = 53, ProdutoId = 18, ArquivoFoto = "/ninexhype-img/500x500/JaquetaCorta-Vento2.png"},
            new ProdutoFoto { Id = 54, ProdutoId = 18, ArquivoFoto = "/ninexhype-img/500x500/JaquetaCorta-Vento3.png"},

            // Produto 19 - Moletom Liso com Capuz
            new ProdutoFoto { Id = 55, ProdutoId = 19, ArquivoFoto = "/ninexhype-img/500x500/MoletomLisoCapuz1.png"},
            new ProdutoFoto { Id = 56, ProdutoId = 19, ArquivoFoto = "/ninexhype-img/500x500/MoletomLisoCapuz2.png"},
            new ProdutoFoto { Id = 57, ProdutoId = 19, ArquivoFoto = "/ninexhype-img/500x500/MoletomLisoCapuz3.png"},

            // Produto 20 - Bermuda de Sarja Bege
            new ProdutoFoto { Id = 58, ProdutoId = 20, ArquivoFoto = "/ninexhype-img/500x500/BermudaSarjaBege1.png"},
            new ProdutoFoto { Id = 59, ProdutoId = 20, ArquivoFoto = "/ninexhype-img/500x500/BermudaSarjaBege2.png"},
            new ProdutoFoto { Id = 60, ProdutoId = 20, ArquivoFoto = "/ninexhype-img/500x500/BermudaSarjaBege3.png"},

            // Produto 21 - Camisa Social Slim
            new ProdutoFoto { Id = 61, ProdutoId = 21, ArquivoFoto = "/ninexhype-img/500x500/CamisaSocialSlim1.png"},
            new ProdutoFoto { Id = 62, ProdutoId = 21, ArquivoFoto = "/ninexhype-img/500x500/CamisaSocialSlim2.png"},
            new ProdutoFoto { Id = 63, ProdutoId = 21, ArquivoFoto = "/ninexhype-img/500x500/CamisaSocialSlim3.png"},

            // Produto 22 - Vestido Midi Floral
            new ProdutoFoto { Id = 64, ProdutoId = 22, ArquivoFoto = "/ninexhype-img/500x500/VestidoMidiFloral1.png"},
            new ProdutoFoto { Id = 65, ProdutoId = 22, ArquivoFoto = "/ninexhype-img/500x500/VestidoMidiFloral2.png"},
            new ProdutoFoto { Id = 66, ProdutoId = 22, ArquivoFoto = "/ninexhype-img/500x500/VestidoMidiFloral3.png"},

            // Produto 23 - Calça Jeans Skinny
            new ProdutoFoto { Id = 67, ProdutoId = 23, ArquivoFoto = "/ninexhype-img/500x500/CalçaJeansSkinny1.png"},
            new ProdutoFoto { Id = 68, ProdutoId = 23, ArquivoFoto = "/ninexhype-img/500x500/CalçaJeansSkinny2.png"},
            new ProdutoFoto { Id = 69, ProdutoId = 23, ArquivoFoto = "/ninexhype-img/500x500/CalçaJeansSkinny3.png"},

            // Produto 24 - Jaqueta Jeans Feminina
            new ProdutoFoto { Id = 70, ProdutoId = 24, ArquivoFoto = "/ninexhype-img/500x500/JaquetaJeansFeminina1.png"},
            new ProdutoFoto { Id = 71, ProdutoId = 24, ArquivoFoto = "/ninexhype-img/500x500/JaquetaJeansFeminina2.png"},
            new ProdutoFoto { Id = 72, ProdutoId = 24, ArquivoFoto = "/ninexhype-img/500x500/JaquetaJeansFeminina3.png"},

            // Produto 25 - Shorts de Moletom
            new ProdutoFoto { Id = 73, ProdutoId = 25, ArquivoFoto = "/ninexhype-img/500x500/ShortsMoletom1.png"},
            new ProdutoFoto { Id = 74, ProdutoId = 25, ArquivoFoto = "/ninexhype-img/500x500/ShortsMoletom2.png"},
            new ProdutoFoto { Id = 75, ProdutoId = 25, ArquivoFoto = "/ninexhype-img/500x500/ShortsMoletom3.png"},

            // Produto 26 - Camiseta Polo Preta Feminina
            new ProdutoFoto { Id = 76, ProdutoId = 26, ArquivoFoto = "/ninexhype-img/500x500/CamisetaPoloPretaFeminina1.png"},
            new ProdutoFoto { Id = 77, ProdutoId = 26, ArquivoFoto = "/ninexhype-img/500x500/CamisetaPoloPretaFeminina2.png"},
            new ProdutoFoto { Id = 78, ProdutoId = 26, ArquivoFoto = "/ninexhype-img/500x500/CamisetaPoloPretaFeminina3.png"},

            // Produto 27 - Macacão Feminino
            new ProdutoFoto { Id = 79, ProdutoId = 27, ArquivoFoto = "/ninexhype-img/500x500/MacacãoFeminino1.png"},
            new ProdutoFoto { Id = 80, ProdutoId = 27, ArquivoFoto = "/ninexhype-img/500x500/MacacãoFeminino2.png"},
            new ProdutoFoto { Id = 81, ProdutoId = 27, ArquivoFoto = "/ninexhype-img/500x500/MacacãoFeminino3.png"},

            // Produto 28 - Blusa Cropped Texturizada
            new ProdutoFoto { Id = 82, ProdutoId = 28, ArquivoFoto = "/ninexhype-img/500x500/BlusaCroppedTexturizada1.png"},
            new ProdutoFoto { Id = 83, ProdutoId = 28, ArquivoFoto = "/ninexhype-img/500x500/BlusaCroppedTexturizada2.png"},
            new ProdutoFoto { Id = 84, ProdutoId = 28, ArquivoFoto = "/ninexhype-img/500x500/BlusaCroppedTexturizada3.png"},

            // Produto 29 - Camisa Polo Texturizada Masculina Marrom
            new ProdutoFoto { Id = 85, ProdutoId = 29, ArquivoFoto = "/ninexhype-img/500x500/CamisaPoloTexturizadaMasculinaMarrom1.png"},
            new ProdutoFoto { Id = 86, ProdutoId = 29, ArquivoFoto = "/ninexhype-img/500x500/CamisaPoloTexturizadaMasculinaMarrom2.png"},
            new ProdutoFoto { Id = 87, ProdutoId = 29, ArquivoFoto = "/ninexhype-img/500x500/CamisaPoloTexturizadaMasculinaMarrom3.png"},

            // Produto 30 - Regata Dry Fit
            new ProdutoFoto { Id = 88, ProdutoId = 30, ArquivoFoto = "/ninexhype-img/500x500/RegataDryFit1.png"},
            new ProdutoFoto { Id = 89, ProdutoId = 30, ArquivoFoto = "/ninexhype-img/500x500/RegataDryFit2.png"},
            new ProdutoFoto { Id = 90, ProdutoId = 30, ArquivoFoto = "/ninexhype-img/500x500/RegataDryFit3.png"},

            // Produto 41 -
            new ProdutoFoto { Id = 91, ProdutoId = 41, ArquivoFoto = "/ninexhype-img/500x500/TênisNikeAirMaxExcee1.png"},
            new ProdutoFoto { Id = 92, ProdutoId = 41, ArquivoFoto = "/ninexhype-img/500x500/TênisNikeAirMaxExcee2.png"},
            new ProdutoFoto { Id = 93, ProdutoId = 41, ArquivoFoto = "/ninexhype-img/500x500/TênisNikeAirMaxExcee3.png"},

            // Produto 42 - 
            new ProdutoFoto { Id = 94, ProdutoId = 42, ArquivoFoto = "/ninexhype-img/500x500/TênisNikeMCTrainerIII1.png"},
            new ProdutoFoto { Id = 95, ProdutoId = 42, ArquivoFoto = "/ninexhype-img/500x500/TênisNikeMCTrainerIII2.png"},
            new ProdutoFoto { Id = 96, ProdutoId = 42, ArquivoFoto = "/ninexhype-img/500x500/TênisNikeMCTrainerIII3.png"},

            // Produto 43 -
            new ProdutoFoto { Id = 97, ProdutoId = 43, ArquivoFoto = "/ninexhype-img/500x500/Women'sAirForce1'07Low1.png"},
            new ProdutoFoto { Id = 98, ProdutoId = 43, ArquivoFoto = "/ninexhype-img/500x500/Women'sAirForce1'07Low2.png"},
            new ProdutoFoto { Id = 99, ProdutoId = 43, ArquivoFoto = "/ninexhype-img/500x500/Women'sAirForce1'07Low3.png"},

            // Produto 44 -
            new ProdutoFoto { Id = 100, ProdutoId = 44, ArquivoFoto = "/ninexhype-img/500x500/COURTBLOCK1.png"},
            new ProdutoFoto { Id = 101, ProdutoId = 44, ArquivoFoto = "/ninexhype-img/500x500/COURTBLOCK2.png"},
            new ProdutoFoto { Id = 102, ProdutoId = 44, ArquivoFoto = "/ninexhype-img/500x500/COURTBLOCK3.png"},

            // Produto 45 -
            new ProdutoFoto { Id = 103, ProdutoId = 45, ArquivoFoto = "/ninexhype-img/500x500/StellaMcCartneyUltraboostV1.png"},
            new ProdutoFoto { Id = 104, ProdutoId = 45, ArquivoFoto = "/ninexhype-img/500x500/StellaMcCartneyUltraboostV2.png"},
            new ProdutoFoto { Id = 105, ProdutoId = 45, ArquivoFoto = "/ninexhype-img/500x500/StellaMcCartneyUltraboostV3.png"},

            // Produto 46 -
            new ProdutoFoto { Id = 106, ProdutoId = 46, ArquivoFoto = "/ninexhype-img/500x500/JabbarHi1.png"},
            new ProdutoFoto { Id = 107, ProdutoId = 46, ArquivoFoto = "/ninexhype-img/500x500/JabbarHi2.png"},
            new ProdutoFoto { Id = 108, ProdutoId = 46, ArquivoFoto = "/ninexhype-img/500x500/JabbarHi3.png"},

            // Produto 47 -
            new ProdutoFoto { Id = 109, ProdutoId = 47, ArquivoFoto = "/ninexhype-img/500x500/Prospect1.png"},
            new ProdutoFoto { Id = 110, ProdutoId = 47, ArquivoFoto = "/ninexhype-img/500x500/Prospect1.png"},
            new ProdutoFoto { Id = 111, ProdutoId = 47, ArquivoFoto = "/ninexhype-img/500x500/Prospect1.png"},

            // Imagens produtos Destaques
            new ProdutoFoto { Id = 112, ProdutoId = 31, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/NikeAirForce1.png" },
            new ProdutoFoto { Id = 113, ProdutoId = 32, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/AdidasUltraboost.png" },
            new ProdutoFoto { Id = 114, ProdutoId = 33, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/PumaRS-X.png" },
            new ProdutoFoto { Id = 115, ProdutoId = 34, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/VansOldSkool.png" },
            new ProdutoFoto { Id = 116, ProdutoId = 35, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/NewBalance574.png" },
            new ProdutoFoto { Id = 117, ProdutoId = 36, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/ConverseChuckTaylor.png" },
            new ProdutoFoto { Id = 118, ProdutoId = 37, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/AsicsGel-Kayano.png" },
            new ProdutoFoto { Id = 119, ProdutoId = 38, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/NikeDunkLow.png" },
            new ProdutoFoto { Id = 120, ProdutoId = 39, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/MizunoWaveProphecy.png" },
            new ProdutoFoto { Id = 121, ProdutoId = 40, ArquivoFoto = "/ninexhype-img/FotosCarrossel/fotosGrandes/FilaDisruptorII.png" },

        };
        builder.Entity<ProdutoFoto>().HasData(produtoFotos);


        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "bec71b05-8f3d-4849-88bb-0e8d518d2de8",
               Name = "Funcionário",
               NormalizedName = "FUNCIONÁRIO"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new()
        {
            new Usuario()
            {
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "ninexhype@9xhype.com",
                NormalizedEmail = "NINEXHYPE@9XHYPE.COM",
                UserName = "9xHype",
                NormalizedUserName = "9XHYPE",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "9x Hype",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "~/ninexhype-img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}