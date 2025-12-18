// ===== MENU LATERAL =====
function openMenu() {
    document.body.classList.add('menu-open');
}

function closeMenu() {
    document.body.classList.remove('menu-open');
}

function showPage(pageId) {
    document.querySelectorAll('.page').forEach(page => {
        page.classList.remove('active', 'surgindo');
    });

    const page = document.getElementById(pageId);
    page.classList.add('active');

    // Adiciona efeito de surgimento
    setTimeout(() => {
        page.classList.add('surgindo');
    }, 50);

    closeMenu();
}

// ===== EFEITO DE SURGIMENTO AO CARREGAR A PÁGINA =====
window.addEventListener('load', () => {
    const home = document.getElementById('home');
    home.classList.add('active');
    setTimeout(() => {
        home.classList.add('surgindo');
    }, 50);
});

// ===== IA REAL (GROQ / ou sua API) =====
async function sendMessage() {
    const input = document.getElementById("userInput");
    const message = input.value.trim();
    if (!message) return;

    addMessage("Você", message, "user");
    input.value = "";

    addMessage("IA", "Pensando...", "bot");

    try {
        const response = await fetch("http://localhost:3000/api/ia", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ message })
        });

        const data = await response.json();

        removeLastBotMessage();
        addMessage("IA", data.reply, "bot");

    } catch (error) {
        removeLastBotMessage();
        addMessage("IA", "Erro ao se comunicar com o servidor.", "bot");
    }
}

function addMessage(author, text, cls) {
    const box = document.getElementById("chat-box");
    const messageDiv = document.createElement("div");
    messageDiv.classList.add("message", cls);
    messageDiv.innerHTML = `<strong>${author}:</strong> ${text}`;
    box.appendChild(messageDiv);
    box.scrollTop = box.scrollHeight;
}

function removeLastBotMessage() {
    const box = document.getElementById("chat-box");
    const messages = box.querySelectorAll(".message.bot");
    if (messages.length > 0) messages[messages.length - 1].remove();
}

// ===== ENVIAR MENSAGEM COM ENTER =====
const inputField = document.getElementById("userInput");
if(inputField){
    inputField.addEventListener("keypress", function(e){
        if(e.key === "Enter") sendMessage();
    });
}
