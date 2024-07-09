$(document).ready(function() {
    function handleFormSubmit(formId, errorId) {
        $(formId).submit(function(event) {
            event.preventDefault();
            var form = $(this);

            $.ajax({
                url: form.attr('action'),
                type: form.attr('method'),
                data: form.serialize(),
                success: function(response) {
                    if (response.success) {
                        window.location.href = response.redirectUrl;
                    } else {
                        var errorHtml = '<ul>';
                        $.each(response.errors, function(key, value) {
                            errorHtml += '<li>' + value + '</li>';
                        });
                        errorHtml += '</ul>';
                        $(errorId).html(errorHtml).removeClass('d-none');
                    }
                },
                error: function(xhr, status, error) {
                    console.log(xhr + ' / ' + status + ' / ' + error);
                    $(errorId).html('Xəta baş verdi').removeClass('d-none');
                }
            });
        });
    }

    handleFormSubmit('#lesson-form', '#lesson-error');
    handleFormSubmit('#teacher-form', '#teacher-error');
    handleFormSubmit('#pupil-form', '#pupil-error');
    handleFormSubmit('#exam-form', '#exam-error');
    handleFormSubmit('#teacher-lesson-form', '#teacher-lesson-error');
    handleFormSubmit('#exam-mark-form', '#exam-mark-error');
});
