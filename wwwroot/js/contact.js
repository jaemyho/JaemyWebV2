$(document).ready(function() {
    // Form validation and enhancement
    $('#contactForm').on('submit', function(e) {
        var isValid = true;
        
        // Clear previous validation states
        $('.form-control').removeClass('is-valid is-invalid');
        
        // Validate required fields
        $('#Name, #Email, #Message').each(function() {
            if ($(this).val().trim() === '') {
                $(this).addClass('is-invalid');
                isValid = false;
            } else {
                $(this).addClass('is-valid');
            }
        });
        
        // Validate email format
        var email = $('#Email').val();
        var emailRegex = new RegExp('^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$');
        if (email && !emailRegex.test(email)) {
            $('#Email').addClass('is-invalid');
            isValid = false;
        }
        
        if (!isValid) {
            e.preventDefault();
            showAlert('Please fill in all required fields correctly.', 'danger');
            return false;
        }
    });
    
    // Real-time validation
    $('#Name, #Email, #Message').on('blur focusout', function() {
        if ($(this).val().trim() !== '') {
            $(this).removeClass('is-invalid').addClass('is-valid');
        } else {
            $(this).removeClass('is-valid is-invalid');
        }
    });
    
    $('#Email').on('blur focusout', function() {
        var email = $(this).val();
        var emailRegex = new RegExp('^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$');
        
        if (email && !emailRegex.test(email)) {
            $(this).addClass('is-invalid');
        } else if (email) {
            $(this).removeClass('is-invalid').addClass('is-valid');
        } else {
            $(this).removeClass('is-valid is-invalid');
        }
    });
    
    // Character count for message
    $('#Message').on('input', function() {
        var length = $(this).val().length;
        var maxLength = 1000; // Optional: set a max length
        
        if (length > maxLength) {
            $(this).val($(this).val().substring(0, maxLength));
            showAlert('Message length exceeds maximum allowed characters.', 'warning');
        }
    });
    
    // Auto-dismiss alerts
    setTimeout(function() {
        $('.alert').fadeOut();
    }, 5000);
});
