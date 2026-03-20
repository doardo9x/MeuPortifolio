// Seleciona o container
const box = document.getElementById("textBox");

// Seleciona os filhos diretos
const nameDiv = box.querySelector(":scope > div:nth-child(1)");
const subtitleDiv = box.querySelector(":scope > div:nth-child(2)");
const backendDiv = box.querySelector(":scope > div:nth-child(3)");
const link = box.querySelector(":scope > a");

// Texto completo apenas do nome
const fullText = nameDiv.textContent.trim();

// Setup inicial
nameDiv.textContent = "";
nameDiv.style.opacity = "0";

subtitleDiv.style.opacity = "0";
backendDiv.style.opacity = "0";
link.style.opacity = "0";

// Força cálculo de layout
void nameDiv.offsetWidth;

// Delay inicial
setTimeout(() => {
  nameDiv.style.transition = "opacity 300ms ease";
  nameDiv.style.opacity = "1";

  let index = 0;

  // Efeito de digitação do nome
  const interval = setInterval(() => {
    nameDiv.textContent += fullText[index];
    index++;

    if (index === fullText.length) {
      clearInterval(interval);

      // Subtítulo, backend e link surgem juntos
      subtitleDiv.style.transition = "opacity 450ms ease";
      backendDiv.style.transition = "opacity 450ms ease";
      link.style.transition = "opacity 450ms ease";

      subtitleDiv.style.opacity = "1";
      backendDiv.style.opacity = "1";
      link.style.opacity = "1";
    }
  }, 70);
}, 50);

// Mantém o efeito do blur cursor
const blurCursor = document.querySelector('.blur-cursor');

document.addEventListener('mousemove', (e) => {
  blurCursor.style.left = `${e.clientX}px`;
  blurCursor.style.top = `${e.clientY}px`;
});



// efeito bolinha background

const canvas = document.getElementById("particles-bg");
const ctx = canvas.getContext("2d");

let width, height;
const particles = [];
const PARTICLE_COUNT = 80;

function resize() {
    width = canvas.width = window.innerWidth;
    height = canvas.height = window.innerHeight;
}
window.addEventListener("resize", resize);
resize();

class Particle {
    constructor() {
        this.reset();
    }

    reset() {
        this.x = Math.random() * width;
        this.y = Math.random() * height;
        this.radius = Math.random() * 1.5 + 0.5;

        // brilho
        this.alpha = Math.random() * 0.5 + 0.2;
        this.phase = Math.random() * Math.PI * 2;
        this.pulseSpeed = Math.random() * 0.01 + 0.005;

        // movimento lento e suave
        this.vx = (Math.random() - 0.5) * 0.4;
        this.vy = (Math.random() - 0.5) * 0.4;
    }

    update() {
        // movimento
        this.x += this.vx;
        this.y += this.vy;

        // reaparece do outro lado
        if (this.x < 0) this.x = width;
        if (this.x > width) this.x = 0;
        if (this.y < 0) this.y = height;
        if (this.y > height) this.y = 0;

        // pulsar brilho
        this.phase += this.pulseSpeed;
        this.alpha = 0.2 + Math.abs(Math.sin(this.phase)) * 0.6;
    }

    draw() {
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2);
        ctx.fillStyle = `rgba(255, 255, 255, ${this.alpha})`;
        ctx.fill();
    }
}

for (let i = 0; i < PARTICLE_COUNT; i++) {
    particles.push(new Particle());
}

function animate() {
    ctx.clearRect(0, 0, width, height);

    particles.forEach(p => {
        p.update();
        p.draw();
    });

    requestAnimationFrame(animate);
}

animate();
