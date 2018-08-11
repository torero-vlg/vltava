define([], function () {

    return {
        Initialize: function () {

            $('#successContainer').hide();
            $('#errorContainer').hide();

            $('.alert').click(function () {
                $(this).hide();
            });

            //отображение меню при прокрутке
            $(document).on("scroll", function (eventArgs) {
                console.log($(document).scrollTop());
             //   $('.navbar-fixed-top').css('top', 200 - $(document).scrollTop());

                if ($(document).scrollTop() > 199) {
                    $('#banner').hide();
                  //  $("#menu").addClass("smallmenu");
                    $('.navbar-fixed-top').css('top', 0);
                }
                else {
                    $('#banner').show();
                    $('.navbar-fixed-top').css('top', 200 - $(document).scrollTop());
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




