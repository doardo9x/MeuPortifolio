// ===== BLUR CURSOR =====
const blurCursor = document.querySelector('.blur-cursor');
if (blurCursor) {
    document.addEventListener('mousemove', (e) => {
        blurCursor.style.left = `${e.clientX}px`;
        blurCursor.style.top  = `${e.clientY}px`;
    });
}

// ===== PARTÍCULAS =====
const canvas = document.getElementById('particles-bg');
if (canvas) {
    const ctx = canvas.getContext('2d');
    let width, height;
    const PARTICLE_COUNT = 80;
    const particles = [];

    function resize() {
        width = canvas.width  = window.innerWidth;
        height = canvas.height = window.innerHeight;
    }
    window.addEventListener('resize', resize);
    resize();

    class Particle {
        constructor() { this.reset(); }

        reset() {
            this.x          = Math.random() * width;
            this.y          = Math.random() * height;
            this.radius     = Math.random() * 1.5 + 0.5;
            this.alpha      = Math.random() * 0.5 + 0.2;
            this.phase      = Math.random() * Math.PI * 2;
            this.pulseSpeed = Math.random() * 0.01 + 0.005;
            this.vx         = (Math.random() - 0.5) * 0.4;
            this.vy         = (Math.random() - 0.5) * 0.4;
        }

        update() {
            this.x += this.vx;
            this.y += this.vy;
            if (this.x < 0)      this.x = width;
            if (this.x > width)  this.x = 0;
            if (this.y < 0)      this.y = height;
            if (this.y > height) this.y = 0;
            this.phase += this.pulseSpeed;
            this.alpha = 0.2 + Math.abs(Math.sin(this.phase)) * 0.6;
        }

        draw() {
            ctx.beginPath();
            ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2);
            ctx.fillStyle = `rgba(255,255,255,${this.alpha})`;
            ctx.fill();
        }
    }

    for (let i = 0; i < PARTICLE_COUNT; i++) particles.push(new Particle());

    function animate() {
        ctx.clearRect(0, 0, width, height);
        particles.forEach(p => { p.update(); p.draw(); });
        requestAnimationFrame(animate);
    }
    animate();
}