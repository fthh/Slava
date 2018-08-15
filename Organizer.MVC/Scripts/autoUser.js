$(function () {

    $('.who').bind("change keyup input click",
        function () {
            if (this.value.length >= 0) {
                $.ajax({
                    type: 'post',
                    url: "/Home/GetUsers",
                    data: { 'str': this.value },
                    response: 'text',
                    success: function (data) {
                        $(".search_result").html(data).fadeIn();
                    }
                });
            }
        });
    $(".search_result").hover(function () {
        $(".who").blur();
    });
    $("#pickAnother").on("click",
        function () {
            $("#UserId").val("");
            $(".who").val("").removeAttr('disabled', 'enabled');
            $("#pickAnother").fadeOut();
            $("#addAnother").fadeOut();
        });

    $(".search_result").on("click",
        "li",
        function () {
            selectedPM = $(this).text();
            $(".who").val(selectedPM).attr('disabled', 'disabled');
            $("#pickAnother").fadeIn();
            $("#addAnother").fadeIn();
            $("#userId").val(selectedPM.split('*')[1]);
            $(".search_result").fadeOut();
        });
})