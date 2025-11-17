$(document).ready(function() {
    // Portfolio filtering functionality
    $('#portfolio-filter button').click(function() {
        var filter = $(this).data('filter');
        
        // Update active button
        $('#portfolio-filter button').removeClass('active');
        $(this).addClass('active');
        
        if (filter === 'all') {
            $('.portfolio-item').fadeIn(300);
        } else {
            $('.portfolio-item').fadeOut(300);
            $('.portfolio-item[data-category="' + filter + '"]').fadeIn(300);
        }
        
        // Check if any items are visible
        setTimeout(function() {
            var visibleItems = $('.portfolio-item:visible').length;
            if (visibleItems === 0) {
                showNoResults();
            } else {
                $('.no-results').remove();
            }
        }, 300);
    });
    
    function showNoResults() {
        if ($('.no-results').length === 0) {
            $('.row').last().append(`
                <div class="col-12 no-results text-center py-5">
                    <div class="card">
                        <div class="card-body">
                            <i class="fas fa-search fa-3x text-muted mb-3"></i>
                            <h3 class="text-muted">No Projects Found</h3>
                            <p class="text-muted">Try selecting a different category or view all projects.</p>
                            <button class="btn btn-primary" onclick="$('#portfolio-filter button[data-filter=all]').click()">
                                <i class="fas fa-th me-2"></i>View All Projects
                            </button>
                        </div>
                    </div>
                </div>
            `);
        }
    }
    
    // Portfolio item click handlers
    $('.portfolio-card').click(function(e) {
        if (!$(e.target).is('a') && !$(e.target).is('button')) {
            var title = $(this).find('.card-title').text();
            var description = $(this).find('.card-text').text();
            var technologies = $(this).find('.project-technologies').html();
            
            $('#portfolioModalLabelTitle').text(title);
            $('#modalBodyContent').html(`
                ${title}
                <div class="mb-3">
                    <strong>Technologies Used:</strong>
                    <div class="mt-2">${technologies || '<span class="text-muted">Not specified</span>'}</div>
                </div>
            `);
            
            var detailsUrl = $(this).find('[data-details-url]').attr('data-details-url');
            $('#modalViewDetails').off('click').on('click', function() {
                if (detailsUrl) {
                    window.location.href = detailsUrl;
                }
            });
            
            $('#portfolioModal').modal('show');
        }
    });
});
