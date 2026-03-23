function filter(type) {
    let cards, i, buttons;
    let count = 0;
    
    // Busca os containers das colunas para esconder a coluna inteira
    cards = document.querySelectorAll(".col-pokedex");
    buttons = document.querySelectorAll(".btn-filter");

    // 1. Lógica de Filtro dos Cards
    for (i = 0; i < cards.length; i++) {
        let cardElement = cards[i].querySelector('.card');
        
        cards[i].style.display = 'none'; // Esconde o container da coluna

        // Verifica se o card dentro da coluna contém a classe do tipo
        if (type === "all" || cardElement.classList.contains(type)) {
            cards[i].style.display = 'block'; // Mostra o container
            count += 1;
        }
    }

    // 2. Lógica de Estilo dos Botões (Active)
    for (i = 0; i < buttons.length; i++) {
        buttons[i].classList.remove("active", "bg-dark", "text-white");
        
        // Se for o botão "Ver Todos", mantém o estilo dark padrão quando ativo
        if (buttons[i].id === "btn-all" && type === "all") {
             buttons[i].classList.add("active", "bg-dark", "text-white");
        } 
        // Se for um botão de tipo, adiciona a classe active (o CSS trata o resto)
        else if (buttons[i].id === `btn-${type}`) {
            buttons[i].classList.add("active");
        }
    }

    // 3. Lógica da mensagem de "Zero Pokemon"
    const zeroPkmMessage = document.getElementById("zeroPokemon");
    if (count === 0) {
        zeroPkmMessage.classList.remove("d-none");
    } else {
        zeroPkmMessage.classList.add("d-none");
    }
}