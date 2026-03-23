// ===== CHAT DE IA =====
async function sendMessage() {
    const input   = document.getElementById('userInput');
    const message = input.value.trim();
    if (!message) return;

    addMessage('Você', message, 'user');
    input.value = '';

    addMessage('IA', 'Pensando...', 'bot');

    try {
        const response = await fetch('/Ia/Chat', {
            method:  'POST',
            headers: { 'Content-Type': 'application/json' },
            body:    JSON.stringify({ message })
        });

        const data = await response.json();
        removeLastBotMessage();

        if (data.reply) {
            addMessage('IA', data.reply, 'bot');
        } else {
            addMessage('IA', data.error ?? 'Erro desconhecido.', 'bot');
        }
    } catch {
        removeLastBotMessage();
        addMessage('IA', 'Erro ao se comunicar com o servidor.', 'bot');
    }
}

function addMessage(author, text, cls) {
    const box = document.getElementById('chat-box');
    const div = document.createElement('div');
    div.classList.add('message', cls);
    div.innerHTML = `<strong>${author}:</strong> ${text}`;
    box.appendChild(div);
    box.scrollTop = box.scrollHeight;
}

function removeLastBotMessage() {
    const box      = document.getElementById('chat-box');
    const messages = box.querySelectorAll('.message.bot');
    if (messages.length > 0) messages[messages.length - 1].remove();
}

// Enviar com Enter
document.addEventListener('DOMContentLoaded', () => {
    const input = document.getElementById('userInput');
    if (input) {
        input.addEventListener('keypress', (e) => {
            if (e.key === 'Enter') sendMessage();
        });
    }
});