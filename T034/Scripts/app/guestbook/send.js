define(['layout'], function (layout) {

    function addOrEdit() {
        $.ajax({
            url: '/GuestBook/Send',
            method: 'POST',
            data: {
                Author: $('#Author').val(),
                Contact: $('#Contact').val(),
                Message: $('#Message').val()
    }
        })
        .complete(function (data) {
            layout.showResult(data);
        });
    }

    return {
        Initialize: function () {
         
            $("#btnSubmit").click(function () {
                addOrEdit();
            });

        }
    }
});
