define(['layout'], function (layout) {

    function addOrEdit() {
        $.ajax({
            url: '/GuestBook/AddOrEdit',
            method: 'POST',
            data: {
                Author: $('#Author').val(),
                Id: $('#Id').val(),
                Contact: $('#Contact').val(),
                Date: $('#Date').val(),
                Message: $('#Message').val()
            }
        })
        .complete(function (data) {
            layout.showResult(data);
        });
    }

    return {
        Initialize: function () {
         
            $("#btnAddOrEdit").click(function () {
                addOrEdit();
            });

        }
    }
});
