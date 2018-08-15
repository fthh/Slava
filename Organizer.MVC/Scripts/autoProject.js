$(function () {

    $('.who').bind("change keyup input click",
        function () {
            if (this.value.length >= 0) {
                $.ajax({
                    type: 'post',
                    url: "/Home/GetProjects",
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
            $("#ProjectId").val("");
            $(".who").val("").removeAttr('disabled', 'enabled');
            $("#pickAnother").fadeOut();
        });

    $(".search_result").on("click",
        "li",
        function () {
            selectedPM = $(this).text();
            $(".who").val(selectedPM).attr('disabled', 'disabled');
            $("#pickAnother").fadeIn();
            $("#projectId").val(parseInt(selectedPM.split(' ')[1]));
            $(".search_result").fadeOut();
        });
})