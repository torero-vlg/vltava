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
                    $('nav').addClass('navbar-fixed-top');
                    $('#bs-example-navbar-collapse-1').addClass('navbar-fixed-top');

                }
                else {
                    $('#banner').show();
                    $('nav').removeClass('navbar-fixed-top');
                    $('#bs-example-navbar-collapse-1').removeClass('navbar-fixed-top');
                }

                if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
                    $('#btnUp').show();
                } else {
                    $('#btnUp').hide();
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




