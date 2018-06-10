define([], function () {

    return {
        Initialize: function () {

            $('#successContainer').hide();
            $('#errorContainer').hide();

            $('.alert').click(function () {
                $(this).hide();
            });

            //отображение меню при прокрутке
            $(document).on("scroll", function () {
                if ($(document).scrollTop() > 199) {
                    $('#banner').hide();
                    $("#menu").addClass("smallmenu");
                }
                else {
                    $('#banner').show();
                    $("#menu").removeClass("smallmenu");
                }
            });

        },

        showResult: function (data) {

            var response = JSON.parse(data.responseText);

            if (response.Status != 0) {
                $('#errorContainer').show();
                $('#successContainer').hide();
                $('#errorContainer').html(response.Message);
            }
            else {
                $('#errorContainer').hide();
                $('#successContainer').show();
                $('#successContainer').html(response.Message);
            }

            setTimeout(function () {
                $('.alert').hide(1000);
            }, 5000);
        }
    }
});




