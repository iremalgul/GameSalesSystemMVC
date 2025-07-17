(function ($) {
  ('use strict');

  /*
  |--------------------------------------------------------------------------
  | Template Name: Sattiyas
  | Author: Laralink
  | Version: 1.0.0
  |--------------------------------------------------------------------------
  |--------------------------------------------------------------------------
  | TABLE OF CONTENTS:
  |--------------------------------------------------------------------------
  |
  | 1. Preloader
  | 2. Mobile Menu
  | 3. Sticky Header
  | 4. Dynamic Background
  | 5. Modal Video
  | 6. Isotop Initialize
  | 7. Scroll Up
  | 8. Tabs
  | 9. Review
  | 10. Slick Slider
  | 11. Price Range Slider
  | 12. Single product slider
  | 13. Shop General
  | 
  */

  /*--------------------------------------------------------------
    Scripts initialization
  --------------------------------------------------------------*/
  $.exists = function (selector) {
    return $(selector).length > 0;
  };

  $(window).on('load', function () {
    preloader();
    isotopInit();
  });

  $(function () {
    mainNav();
    stickyHeader();
    dynamicBackground();
    modalVideo();
    isotopInit();
    slickInit();
    scrollUp();
    tabs();
    review();
    priceInit();
    singleProductSlider();
    shopGeneral();
  });

  $(window).on('scroll', function () {
    showScrollUp();
  });

  /*--------------------------------------------------------------
    1. Preloader
  --------------------------------------------------------------*/
  function preloader() {
    $('.cs_perloader').fadeOut();
    $('cs_perloader_in').delay(150).fadeOut('slow');
  }

  /*--------------------------------------------------------------
    2. Mobile Menu
  --------------------------------------------------------------*/
  function mainNav() {
    $('.cs_nav').append('<span class="cs_menu_toggle"><span></span></span>');
    $('.menu-item-has-children').append(
      '<span class="cs_menu_dropdown_toggle"><span></span></span>',
    );
    $('.cs_menu_toggle').on('click', function () {
      $(this)
        .toggleClass('cs_toggle_active')
        .siblings('.cs_nav_list')
        .slideToggle();
    });
    $('.cs_menu_toggle')
      .parents('body')
      .find('.cs_side_header')
      .addClass('cs_has_main_nav');
    $('.cs_menu_toggle')
      .parents('body')
      .find('.cs_toolbox')
      .addClass('cs_has_main_nav');
    $('.cs_menu_dropdown_toggle').on('click', function () {
      $(this).toggleClass('active').siblings('ul').slideToggle();
      $(this).parent().toggleClass('active');
    });
    $('.cs_header_search_btn').on('click', function () {
      $('.cs_header_search_wrap').addClass('active');
    });
    $('.cs_header_search_close').on('click', function () {
      $('.cs_header_search_wrap').removeClass('active');
    });
  }
  /*--------------------------------------------------------------
    3. Sticky Header
  --------------------------------------------------------------*/
  function stickyHeader() {
    var $window = $(window);
    var lastScrollTop = 0;
    var $header = $('.cs_sticky_header');
    var headerHeight = $header.outerHeight() + 30;

    $window.scroll(function () {
      var windowTop = $window.scrollTop();
      if (windowTop >= headerHeight) {
        $header.addClass('cs_gescout_sticky');
      } else {
        $header.removeClass('cs_gescout_sticky');
        $header.removeClass('cs_gescout_show');
      }
      if ($header.hasClass('cs_gescout_sticky')) {
        if (windowTop < lastScrollTop) {
          $header.addClass('cs_gescout_show');
        } else {
          $header.removeClass('cs_gescout_show');
        }
      }

      lastScrollTop = windowTop;
    });
  }
  /*--------------------------------------------------------------
    4. Dynamic Background
  --------------------------------------------------------------*/
  function dynamicBackground() {
    $('[data-src]').each(function () {
      var src = $(this).attr('data-src');
      $(this).css({
        'background-image': 'url(' + src + ')',
      });
    });
  }
  /*--------------------------------------------------------------
    5. Modal Video
  --------------------------------------------------------------*/
  function modalVideo() {
    if ($.exists('.cs_video_open')) {
      $('body').append(`
        <div class="cs_video_popup">
          <div class="cs_video_popup_overlay"></div>
          <div class="cs_video_popup_content">
            <div class="cs_video_popup_layer"></div>
            <div class="cs_video_popup_container">
              <div class="cs_video_popup_align">
                <div class="embed_responsive embed_responsive_16by9">
                  <iframe class="embed_responsive_item" src="about:blank"></iframe>
                </div>
              </div>
              <div class="cs_video_popup_close"></div>
            </div>
          </div>
        </div>
      `);
      $(document).on('click', '.cs_video_open', function (e) {
        e.preventDefault();
        var video = $(this).attr('href');
        $('.cs_video_popup_container iframe').attr('src', `${video}`);
        $('.cs_video_popup').addClass('active');
      });
      $('.cs_video_popup_close, .cs_video_popup_layer').on(
        'click',
        function (e) {
          $('.cs_video_popup').removeClass('active');
          $('html').removeClass('overflow-hidden');
          $('.cs_video_popup_container iframe').attr('src', 'about:blank');
          e.preventDefault();
        },
      );
    }
  }
  /*--------------------------------------------------------------
    6. Isotop Initialize
  --------------------------------------------------------------*/
  function isotopInit() {
    if ($.exists('.cs_isotope')) {
      $('.cs_isotope').isotope({
        itemSelector: '.cs_isotope_item',
        transitionDuration: '0.60s',
        percentPosition: true,
        masonry: {
          columnWidth: '.cs_grid_sizer',
        },
      });
      /* Active Class of Portfolio*/
      $('.cs_isotope_filter ul li').on('click', function (event) {
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        event.preventDefault();
      });
      /*=== Portfolio filtering ===*/
      $('.cs_isotope_filter ul').on('click', 'a', function () {
        var filterElement = $(this).attr('data-filter');
        $('.cs_isotope').isotope({
          filter: filterElement,
        });
      });
    }
  }

  /*-----------------------------------------------------------
    7. Scroll Up
  ------------------------------------------------------------*/
  function scrollUp() {
    $('#cs_scroll_btn').on('click', function (e) {
      e.preventDefault();
      $('html,body').animate(
        {
          scrollTop: 0,
        },
        0,
      );
    });
  }
  // For Show Scroll Up
  function showScrollUp() {
    let scroll = $(window).scrollTop();
    if (scroll >= 350) {
      $('#cs_scroll_btn').addClass('cs_scrollup_show');
    } else {
      $('#cs_scroll_btn').removeClass('cs_scrollup_show');
    }
  }

  /*---------------------------------------------------------
  8. Tabs
  ------------------------------------------------------------*/
  function tabs() {
    $('.cs_tab_links a').on('click', function (e) {
      var currentAttrValue = $(this).attr('href');
      $('.cs_tabs_fade ' + currentAttrValue)
        .fadeIn(400)
        .siblings()
        .hide();
      //Tab and slider both activation code
      $('.cs_tabs ' + currentAttrValue)
        .addClass('active')
        .siblings()
        .removeClass('active');
      $(this).parents('li').addClass('active').siblings().removeClass('active');
      e.preventDefault();
    });
  }

  /*-----------------------------------------------------------
    9. Review
  --------------------------------------------------------------*/
  function review() {
    $('.cs_rating').each(function () {
      var review = $(this).data('rating');
      var reviewVal = review * 20 + '%';
      $(this).find('.cs_rating_percentage').css('width', reviewVal);
    });
  }

  /*-----------------------------------------------------------
    10. Slick Slider
  --------------------------------------------------------------*/
  var helpers = {
    addZeros: function (n) {
      return n < 10 ? '0' + n : '' + n;
    },
  };
  function slickInit() {
    if ($.exists('.cs_slider')) {
      $('.cs_slider').each(function () {
        // Slick Variable
        var $ts = $(this).find('.cs_slider_container');
        var $slickActive = $(this).find('.cs_slider_wrapper');
        // Auto Play
        var autoPlayVar = parseInt($ts.attr('data-autoplay'), 10);
        // Auto Play Time Out
        var autoplaySpdVar = 3000;
        if (autoPlayVar > 1) {
          autoplaySpdVar = autoPlayVar;
          autoPlayVar = 1;
        }
        // Slide Change Speed
        var speedVar = parseInt($ts.attr('data-speed'), 10);
        // Slider Loop
        var loopVar = Boolean(parseInt($ts.attr('data-loop'), 10));
        // Slider Center
        var centerVar = Boolean(parseInt($ts.attr('data-center'), 10));
        // Variable Width
        var variableWidthVar = Boolean(
          parseInt($ts.attr('data-variable-width'), 10),
        );
        // Pagination
        var paginaiton = $(this)
          .find('.cs_pagination')
          .hasClass('cs_pagination');
        // Slide Per View
        var slidesPerView = $ts.attr('data-slides-per-view');
        if (slidesPerView == 1) {
          slidesPerView = 1;
        }
        if (slidesPerView == 'responsive') {
          var slidesPerView = parseInt($ts.attr('data-add-slides'), 10);
          var lgPoint = parseInt($ts.attr('data-lg-slides'), 10);
          var mdPoint = parseInt($ts.attr('data-md-slides'), 10);
          var smPoint = parseInt($ts.attr('data-sm-slides'), 10);
          var xsPoint = parseInt($ts.attr('data-xs-slides'), 10);
          var xxsPoint = parseInt($ts.attr('data-xxs-slides'), 10);
        }
        // Fade Slider
        var fadeVar = parseInt($($ts).attr('data-fade-slide'));
        fadeVar === 1 ? (fadeVar = true) : (fadeVar = false);
        // Slick Active Code
        $slickActive.slick({
          centerMode: centerVar,
          autoplay: autoPlayVar,
          dots: paginaiton,
          speed: speedVar,
          infinite: loopVar,
          autoplaySpeed: autoplaySpdVar,
          fade: fadeVar,
          prevArrow: $(this).find('.cs_left_arrow'),
          nextArrow: $(this).find('.cs_right_arrow'),
          appendDots: $(this).find('.cs_pagination'),
          slidesToShow: slidesPerView,
          variableWidth: variableWidthVar,
          responsive: [
            {
              breakpoint: 1600,
              settings: {
                slidesToShow: lgPoint,
              },
            },
            {
              breakpoint: 1200,
              settings: {
                slidesToShow: mdPoint,
              },
            },
            {
              breakpoint: 992,
              settings: {
                slidesToShow: smPoint,
              },
            },
            {
              breakpoint: 768,
              settings: {
                slidesToShow: xsPoint,
              },
            },
            {
              breakpoint: 180,
              settings: {
                slidesToShow: xxsPoint,
              },
            },
          ],
        });

        // Slider Number
        if ($(this).find('.slick_slide_in').length > 1) {
          $(this).siblings('.cs_slides_numbers').show();
        }
        $(this).on('afterChange', function (event, slick, currentSlide) {
          $(this)
            .find('.cs_slides_numbers .active')
            .html(helpers.addZeros(currentSlide + 1));
        });
        var sliderItemsNum = $(this)
          .find('.slick-slide')
          .not('.slick-cloned').length;
        $(this)
          .find('.cs_slides_numbers .cs_total_slide')
          .html(helpers.addZeros(sliderItemsNum));
      });
    }
  }

  /*-----------------------------------------------------------
    11. Price Range Slider
   ------------------------------------------------------------*/
  function priceInit() {
    if ($.exists('#slider_range')) {
      $('#slider_range').slider({
        range: true,
        min: 0,
        max: 1000,
        values: [100, 600],
        slide: function (event, ui) {
          $('#amount').val(
            'Price: $' + ui.values[0] + '.00 - $' + ui.values[1] + '.00',
          );
        },
      });
    }
    if ($.exists('#amount')) {
      $('#amount').val(
        'Price: $' +
          $('#slider_range').slider('values', 0) +
          '.00 - $' +
          $('#slider_range').slider('values', 1) +
          '.00',
      );
    }
  }
  /*----------------------------------------------------------
    12. Single product slider
   ------------------------------------------------------------*/
  function singleProductSlider() {
    // Product Single Slider
    $('.cs_single_product_thumb').slick({
      slidesToShow: 1,
      slidesToScroll: 1,
      arrows: false,
      asNavFor: '.cs_single_product_nav',
      vertical: true,
    });

    $('.cs_single_product_nav').slick({
      slidesToShow: 4,
      slidesToScroll: 1,
      asNavFor: '.cs_single_product_thumb',
      focusOnSelect: true,
      arrows: false,
      vertical: true,
    });
  }
  /*----------------------------------------------------------
    13. Shop General
   ------------------------------------------------------------*/
  function shopGeneral() {
    // List and Grid View Toggle
    $('.cs_grid_btn').on('click', function () {
      $(this).addClass('active').siblings().removeClass('active');
      $('.cs_product_grid')
        .addClass('cs_grid_view')
        .removeClass('cs_list_view');
    });
    $('.cs_list_btn').on('click', function () {
      $(this).addClass('active').siblings().removeClass('active');
      $('.cs_product_grid')
        .addClass('cs_list_view')
        .removeClass('cs_grid_view');
    });

    // Filter Widget Toggle
    $('.cs_filter_widget_title').on('click', function () {
      $(this).toggleClass('active').siblings().slideToggle();
    });

    // Filter Sidebar Show And Hide
    $('.cs_filter_btn').on('click', function () {
      $('.cs_shop_filter').addClass('active');
    });
    $('.cs_filter_close, .cs_filter_overlay').on('click', function () {
      $('.cs_shop_filter').removeClass('active');
    });

    // Star Rating Input
    $('.cs_input_rating i').on('click', function () {
      $(this).siblings().removeClass('fa-solid');
      $(this).addClass('fa-solid').prevAll().addClass('fa-solid');
    });

    // Quantity Increment and Decrement
    $('.cs_increment').click(function () {
      var countElement = $(this).siblings('.cs_quantity_input');
      var count = parseInt(countElement.text());
      count++;
      countElement.text(count);
    });
    $('.cs_decrement').click(function () {
      var countElement = $(this).siblings('.cs_quantity_input');
      var count = parseInt(countElement.text());
      if (count > 0) {
        count--;
        countElement.text(count);
      }
    });
  }
})(jQuery); // End of use strict
