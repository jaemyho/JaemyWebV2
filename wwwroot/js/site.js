// Site-specific JavaScript
$(document).ready(function() {
    // Smooth scrolling for anchor links
    $('a[href*="#"]').click(function(e) {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && 
            location.hostname == this.hostname) {
            
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            
            if (target.length) {
                e.preventDefault();
                $('html, body').animate({
                    scrollTop: target.offset().top - 80
                }, 1000);
            }
        }
    });

    // Add animation classes on scroll
    function checkScroll() {
        $('.portfolio-card, .feature-card').each(function() {
            const elementTop = $(this).offset().top;
            const elementBottom = elementTop + $(this).outerHeight();
            const viewportTop = $(window).scrollTop();
            const viewportBottom = viewportTop + $(window).height();

            if (elementBottom > viewportTop && elementTop < viewportBottom) {
                $(this).addClass('fade-in');
            }
        });
    }

    $(window).on('scroll', checkScroll);
    checkScroll(); // Check on page load

    // Header scroll animation
    let lastScrollTop = 0;
    let ticking = false;
    
    function updateHeader() {
        const scrollTop = $(window).scrollTop();
        const navbar = $('.navbar');
        
        if (scrollTop > lastScrollTop && scrollTop > 100) {
            // Scrolling down - hide header
            navbar.removeClass('navbar-visible').addClass('navbar-hidden');
        } else {
            // Scrolling up - show header
            navbar.removeClass('navbar-hidden').addClass('navbar-visible');
        }
        
        lastScrollTop = scrollTop;
        ticking = false;
    }
    
    function requestTick() {
        if (!ticking) {
            requestAnimationFrame(updateHeader);
            ticking = true;
        }
    }
    
    $(window).on('scroll', requestTick);

    // Portfolio filter functionality
    $('#portfolio-filter button').click(function() {
        const filter = $(this).data('filter ');
        
        $('#portfolio-filter button').removeClass('active');
        $(this).addClass('active');
        
        $('.portfolio-item').fadeOut(300, function() {
            if (filter === 'all' || $(this).data('category') === filter) {
                $(this).fadeIn(300);
            }
        });
    });

    // Contact form enhancement
    $('#contactForm').submit(function(e) {
        const submitBtn = $('#submit-btn');
        const originalText = submitBtn.text();
        
        submitBtn.prop('disabled', true)
                .html('<i class="fas fa-spinner fa-spin"></i> Sending...');
        
        // Re-enable button after 5 seconds regardless of success/failure
        setTimeout(function() {
            submitBtn.prop('disabled', false).text(originalText);
        }, 5000);
    });

    // Loading animation for images
    $('img').on('load', function() {
        $(this).addClass('fade-in');
    }).each(function() {
        if (this.complete) {
            $(this).load();
        }
    });
});

// Utility functions
function showAlert(message, type = 'info') {
    const alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    `;
    
    if ($('#alert-container').length) {
        $('#alert-container').html(alertHtml);
    } else {
        $('main').prepend(alertHtml);
    }
    
    // Auto-dismiss after 5 seconds
    setTimeout(function() {
        $('.alert').fadeOut();
    }, 5000);
}
