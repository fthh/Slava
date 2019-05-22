$(function () {

    $('.pm').bind("change keyup input click",
        function () {
            if (this.value.length >= 0) {
                $.ajax({
                    type: 'post',
                    url: "/Home/GetUsers",
                    data: { 'str': this.value },
                    response: 'text',
                    success: function (data) {
                        $(".search_resultPM").html(data).fadeIn();
                    }
                });
            }
        });
    $(".search_resultPM").hover(function () {
        $(".pm").blur();
    });
    $("#pickAnotherPM").on("click",
        function () {
            $("#ProjectManager").val("");
            $(".pm").val("").removeAttr('disabled', 'enabled');
            $("#pickAnotherPM").fadeOut();
            $("#addAnotherPM").fadeOut();
        });

    $(".search_resultPM").on("click",
        "li",
        function () {
            selectedPM = $(this).text();
            $(".pm").val(selectedPM).attr('disabled', 'disabled');
            $("#pickAnotherPM").fadeIn();
            $("#addAnotherPM").fadeIn();
            $("#ProjectManager").val(selectedPM.split('*')[1]);
            $(".search_resultPM").fadeOut();
        });
})