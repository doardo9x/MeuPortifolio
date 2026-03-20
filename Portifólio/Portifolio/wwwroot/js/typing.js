// ===== EFEITO DE DIGITAÇÃO (página inicial) =====
document.addEventListener('DOMContentLoaded', () => {
    const box       = document.getElementById('textBox');
    if (!box) return;

    const nomeDiv   = box.querySelector('.hero-nome');
    const subDiv    = box.querySelector('.hero-sub');
    const stackDiv  = box.querySelector('.hero-stack');
    const link      = box.querySelector('.hero-link');

    const fullText  = nomeDiv?.textContent.trim() ?? '';
    if (!nomeDiv) return;

    // Estado inicial invisível
    nomeDiv.textContent    = '';
    nomeDiv.style.opacity  = '0';
    if (subDiv)   subDiv.style.opacity  = '0';
    if (stackDiv) stackDiv.style.opacity = '0';
    if (link)     link.style.opacity     = '0';

    // Pequeño delay para garantir que o layout foi calculado
    setTimeout(() => {
        nomeDiv.style.transition = 'opacity 300ms ease';
        nomeDiv.style.opacity    = '1';

        let index = 0;
        const interval = setInterval(() => {
            nomeDiv.textContent += fullText[index];
            index++;

            if (index === fullText.length) {
                clearInterval(interval);

                const fadeIn = 'opacity 500ms ease';
                if (subDiv)   { subDiv.style.transition   = fadeIn; subDiv.style.opacity   = '1'; }
                if (stackDiv) { stackDiv.style.transition = fadeIn; stackDiv.style.opacity = '1'; }
                if (link)     { link.style.transition     = fadeIn; link.style.opacity     = '1'; }
            }
        }, 70);
    }, 150);
});