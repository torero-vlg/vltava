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

            $('.main-menu').on("click", function (e) {
                var targetName = e.currentTarget.hash.replace('#', '');
                var targerElement = $('a[name=' + targetName + ']');
                var top = targerElement[0].offsetTop;

                //прокрутка с учётом фиксированного меню и баннера
                var menuHeight = 0;
                var bannerHeight = 0;
                if ($('.navbar').length > 0) {
                    menuHeight = $('.navbar')[0].clientHeight;
                }
                if ($('.banner').length > 0) {
                    bannerHeight = $('.banner')[0].clientHeight;
                }
                var scroll = menuHeight + bannerHeight;
                if (bannerHeight > 0)
                    scroll += menuHeight;
                $('html, body').animate({ scrollTop: top - scroll }, 700);
 
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




