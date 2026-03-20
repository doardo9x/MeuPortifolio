function previewImagem(inputId, imgId, labelId) {
    const input = document.getElementById(inputId);
    const img = document.getElementById(imgId);
    const label = document.querySelector(`label[for="${inputId}"]`);

    input.addEventListener("change", function () {
        const file = this.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                img.src = e.target.result;
                img.style.display = "block";
                label.style.display = "none"; // esconde o texto "Foto Exemplo"
            }
            reader.readAsDataURL(file);
        }
    });
}

// ligar para cada campo
previewImagem("uploadGrande1", "previewGrande1");
previewImagem("uploadGrande2", "previewGrande2");
previewImagem("uploadPequena1", "previewPequena1");
previewImagem("uploadPequena2", "previewPequena2");