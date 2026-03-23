document.addEventListener("DOMContentLoaded", function () {
    const botaoAdd = document.getElementById("botaoAddComentario");
    const formComentario = document.getElementById("comentarioNovo");
    const btnDeletar = formComentario.querySelector(".btnDeletarComentario");
    const inputFoto = document.getElementById("fotoComentario");
    const preview = document.getElementById("previewImagem");
    const imagemPadrao = "../assets/PagProduto/Cometarios/ImagemVazia.png";
    const textarea = document.getElementById("comentarioAutoAltura");
    const notaInput = document.getElementById("notaSelecionada");
    const stars = document.querySelectorAll('#avaliacaoNova .fa-star');

    let comentarioAtivo = false;
    let comentarioGerado = null;

    // === Mostrar o formulário ===
    botaoAdd.addEventListener("click", function () {
        if (comentarioAtivo) {
            // se já há um comentário, deleta ele
            if (comentarioGerado) comentarioGerado.remove();
            comentarioAtivo = false;
            botaoAdd.textContent = "Adicionar";
            return;
        }

        formComentario.classList.remove("oculto");
        formComentario.style.display = "flex";
        botaoAdd.style.display = "none";
    });

    // === Preview da imagem ===
    inputFoto.addEventListener("change", function () {
        const arquivo = this.files[0];
        if (arquivo) {
            const leitor = new FileReader();
            leitor.onload = function (e) {
                preview.src = e.target.result;
                preview.style.objectFit = "cover";
                preview.style.width = "100%";
                preview.style.height = "100%";
                preview.style.borderRadius = "12px";
            };
            leitor.readAsDataURL(arquivo);
        } else {
            preview.src = imagemPadrao;
        }
    });

    // === Deletar comentário ===
    btnDeletar.addEventListener("click", function (e) {
        e.preventDefault();

        textarea.value = "";
        notaInput.value = "0";
        preview.src = imagemPadrao;
        inputFoto.value = "";
        stars.forEach(s => s.classList.remove("checked"));

        if (comentarioGerado) {
            comentarioGerado.remove();
            comentarioGerado = null;
        }

        comentarioAtivo = false;
        botaoAdd.textContent = "Adicionar";
        botaoAdd.style.display = "inline-block";
        formComentario.classList.add("oculto");
        formComentario.style.display = "none";
    });

    // === Envio do formulário ===
    formComentario.addEventListener("submit", function (e) {
        e.preventDefault();
        if (comentarioAtivo) return;

        const nomeUsuario = formComentario.querySelector(".nomePerfil").textContent.trim() || "Usuário Anônimo";
        const textoComentario = textarea.value.trim();
        const nota = parseInt(notaInput.value);
        const fotoURL = preview.src !== imagemPadrao ? preview.src : null;

        if (!textoComentario) return;

        // cria o novo comentário
        const novoComentario = document.createElement("div");
        novoComentario.classList.add("comentario");

        let estrelasHTML = "";
        for (let i = 1; i <= 5; i++) {
            estrelasHTML += `<span class="fa fa-star ${i <= nota ? "checked" : ""}"></span>`;
        }

        novoComentario.innerHTML = `
            <div class="infoEscritas">
                <div class="perfil">
                    <img src="~NinexHype.-img/PerfilUsuario/perfilVazio.png" class="imgPerfil">
                    <p class="nomePerfil">${nomeUsuario}</p>
                </div>
                <div class="avaliacao">${estrelasHTML}</div>
                <div class="txtComentario">
                    <p class="paragrafoComentario">${textoComentario}</p>
                </div>
            </div>
            ${fotoURL ? `
            <div class="imgComentario">
                <img src="${fotoURL}" alt="" class="imgReviewComentario">
            </div>` : ""}
        `;

        // adiciona o comentário
        const containerComentarios = formComentario.parentElement;
        containerComentarios.insertBefore(novoComentario, formComentario);

        comentarioGerado = novoComentario;
        comentarioAtivo = true;

        // troca o botão principal pra "Deletar Comentário"
        botaoAdd.textContent = "Deletar Comentário";
        botaoAdd.style.display = "inline-block";

        // limpa e esconde o formulário
        textarea.value = "";
        notaInput.value = "0";
        preview.src = imagemPadrao;
        inputFoto.value = "";
        stars.forEach(s => s.classList.remove("checked"));
        formComentario.classList.add("oculto");
        formComentario.style.display = "none";
    });

    // === Sistema de estrelas ===
    stars.forEach((star, index) => {
        star.addEventListener("click", () => {
            stars.forEach(s => s.classList.remove("checked"));
            for (let i = 0; i <= index; i++) {
                stars[i].classList.add("checked");
            }
            notaInput.value = index + 1;
        });
    });
});





const cepInput = document.getElementById("cepInput");
const prazoDiv = document.getElementById("prazoResultado");
const infoCep = document.getElementById("infoCep");

// Permitir apenas números e hífen
cepInput.addEventListener("input", () => {
    cepInput.value = cepInput.value
        .replace(/[^\d-]/g, "")           // permite só números e hífen
        .replace(/(\d{5})(\d)/, "$1-$2") // aplica o hífen automaticamente
        .slice(0, 9);                    // limita ao formato XXXXX-XXX
});

// Ao apertar ENTER
cepInput.addEventListener("keydown", (e) => {
    if (e.key === "Enter") {
        e.preventDefault();

        const cepVal = cepInput.value;
        const cepValido = /^[0-9]{5}-[0-9]{3}$/.test(cepVal);

        if (cepValido) {
            prazoDiv.textContent = "Prazo estimado de entrega: 5 a 10 dias úteis";

            // OCULTAR o texto "Informe o seu CEP..."
            infoCep.style.display = "none";
        } else {
            prazoDiv.textContent = "CEP inválido! Digite no formato 17350-000.";

            // Mostrar novamente caso esteja oculto
            infoCep.style.display = "block";
        }
    }
});



let quantidade = 1; // Valor inicial
const spanQuantidade = document.getElementById("quantidadeSelecionada");

document.querySelector(".btnAdd").addEventListener("click", () => {
    quantidade++;
    spanQuantidade.textContent = quantidade;
});

document.querySelector(".btnRem").addEventListener("click", () => {
    if (quantidade > 1) { 
        quantidade--;
        spanQuantidade.textContent = quantidade;
    }
});
