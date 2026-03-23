var owl = $('.screenshot_slider').owlCarousel({ 
    loop: true,
    responsiveClass: true,
    nav: true,
    margin: 10,
    dots: false,
    rewind: false,
    autoplay: true,
    autoplayTimeout: 4000,
    smartSpeed: 600,
    center: true,
    navText: ['&#8592;', '&#8594;'],
    responsive: {
      0: { items: 1 },
      600: { items: 2 },
      1200: { items: 3 }
    }
  });
  
  // navegação com teclado
  $(document).keydown(function (event) {
    if (event.keyCode == 37) { 
      owl.trigger('prev.owl.carousel');
    } else if (event.keyCode == 39) { 
      owl.trigger('next.owl.carousel');
    }
  });
  
  // navegação clicando nas imagens laterais
  $('.screenshot_slider').on('click', '.owl-item', function () {
    const $clicked = $(this);
    if ($clicked.hasClass('center')) return; // se clicar na imagem central, não faz nada
  
    const $center = $('.screenshot_slider .owl-item.center');
    const clickedIndex = $clicked.index();
    const centerIndex = $center.index();
  
    if (clickedIndex > centerIndex) {
      owl.trigger('next.owl.carousel');
    } else {
      owl.trigger('prev.owl.carousel');
    }
  });
  