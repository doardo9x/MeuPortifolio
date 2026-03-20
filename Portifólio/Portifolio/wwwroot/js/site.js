// ===== MENU LATERAL =====
function openMenu()  { document.body.classList.add('menu-open'); }
function closeMenu() { document.body.classList.remove('menu-open'); }

// Fecha o menu ao clicar fora dele
document.addEventListener('click', (e) => {
    const sidebar  = document.getElementById('sidebar');
    const openBtn  = document.querySelector('.open-btn');
    if (
        document.body.classList.contains('menu-open') &&
        !sidebar.contains(e.target) &&
        !openBtn.contains(e.target)
    ) {
        closeMenu();
    }
});

// ===== ANIMAÇÃO DE ENTRADA DA PÁGINA =====
document.addEventListener('DOMContentLoaded', () => {
    const content = document.getElementById('content');
    if (content) {
        // Dispara a animação após o primeiro frame
        requestAnimationFrame(() => {
            content.querySelector('.page-content')?.classList.add('surgindo');
        });
    }
});