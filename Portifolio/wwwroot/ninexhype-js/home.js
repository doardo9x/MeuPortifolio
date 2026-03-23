document.getElementById("menuToggle").addEventListener("click", function () {
    document.getElementById("sidebar").classList.add("show");
  });
  
  document.getElementById("closeSidebar").addEventListener("click", function () {
    document.getElementById("sidebar").classList.remove("show");
  });
  
  let carouselInterval;
  function setupCarousel() {
    const carousel = document.getElementById('bgCarousel');
  
    // Se a tela for menor que 700px, remove o carrossel se existir
    if (window.innerWidth < 700) {
      if (carouselInterval) {
        clearInterval(carouselInterval);
        carouselInterval = null;
      }
      return;
    }
  
    // Se já estiver configurado, não faz nada
    if (carouselInterval) return;
  
    // Configura o carrossel apenas para telas maiores
    const images = [
      "/ninexhype-img/Home/CarrosselDestaques/Nike Blue Baby.png",
      "/ninexhype-img/Home/CarrosselDestaques/Skateboard.png",
      "/ninexhype-img/Home/CarrosselDestaques/Vinicius.png"
    ];
  
    let currentIndex = 0;
    const intervalTime = 3000;
  
    function changeBackground() {
      currentIndex = (currentIndex + 1) % images.length;
      carousel.style.backgroundImage = `url('${images[currentIndex]}')`;
      preloadNextImage();
    }
  
    function preloadNextImage() {
      const nextIndex = (currentIndex + 1) % images.length;
      const img = new Image();
      img.src = images[nextIndex];
    }
  
    // Inicia o carrossel
    carousel.style.backgroundImage = `url('${images[0]}')`;
    preloadNextImage();
    carouselInterval = setInterval(changeBackground, intervalTime);
  
    carousel.addEventListener('mouseenter', () => {
      if (carouselInterval) {
        clearInterval(carouselInterval);
      }
    });
  
    carousel.addEventListener('mouseleave', () => {
      carouselInterval = setInterval(changeBackground, intervalTime);
    });
  }
  
  document.addEventListener('DOMContentLoaded', setupCarousel);
  
  window.addEventListener('resize', function () {
    setupCarousel();
  });
  
  // carousel mobile
  const slider = document.querySelector(".items");
  const slides = document.querySelectorAll(".item");
  const button = document.querySelectorAll(".button");
  
  let current = 0;
  let prev = 4;
  let next = 1;
  
  for (let i = 0; i < button.length; i++) {
    button[i].addEventListener("click", () => i == 0 ? gotoPrev() : gotoNext());
  }
  
  const gotoPrev = () => current > 0 ? gotoNum(current - 1) : gotoNum(slides.length - 1);
  
  const gotoNext = () => current < 4 ? gotoNum(current + 1) : gotoNum(0);
  
  const gotoNum = number => {
    current = number;
    prev = current - 1;
    next = current + 1;
  
    for (let i = 0; i < slides.length; i++) {
      slides[i].classList.remove("active");
      slides[i].classList.remove("prev");
      slides[i].classList.remove("next");
    }
  
    if (next == 5) {
      next = 0;
    }
  
    if (prev == -1) {
      prev = 4;
    }
  
    slides[current].classList.add("active");
    slides[prev].classList.add("prev");
    slides[next].classList.add("next");
  }
  
  
  // carousel destaque produto
  
  let carrosselSlides = document.querySelectorAll('.slideshow');
  let dots = document.querySelectorAll('.dot');
  let slideIndex = 0;
  let timeoutID;
  
  const showSlides = (nextIndex, direction = 1) => {
    if (nextIndex >= carrosselSlides.length) nextIndex = 0;
    if (nextIndex < 0) nextIndex = carrosselSlides.length - 1;
  
    const currentSlide = carrosselSlides[slideIndex];
    const nextSlide = carrosselSlides[nextIndex];
  
    // Remove classes anteriores
    carrosselSlides.forEach(slide => {
        slide.classList.remove('ativo', 'saindo-esquerda', 'saindo-direita');
    });
  
    // Anima o slide atual saindo
    if (direction === 1) {
      currentSlide.classList.add('saindo-esquerda');
    } else {
      currentSlide.classList.add('saindo-direita');
    }
  
    // Anima o próximo slide entrando
    nextSlide.classList.add('ativo');
  
    // Atualiza os dots
    dots.forEach(dot => dot.classList.remove('ativo'));
    dots[nextIndex].classList.add('ativo');
  
    slideIndex = nextIndex;
  
    clearTimeout(timeoutID);
    timeoutID = setTimeout(() => showSlides(slideIndex + 1, 1), 4000);
  };
  
  const plusSlides = (n) => {
    showSlides(slideIndex + n, n > 0 ? 1 : -1);
  };
  
  const currentSlide = (n) => {
    const direction = n > slideIndex ? 1 : -1;
    showSlides(n, direction);
  };
  
  showSlides(1); // Inicia
  wSlides(slideIndex); // Inicia com o primeiro slide
  