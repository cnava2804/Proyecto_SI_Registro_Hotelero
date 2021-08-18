$(".social, .newsocial").on("keydown keyup", function (e) {
    $(this).prop("value", function (i, o) {
        if (o.length < 7) {
            return o.replace(/\d/g, "*")
        }
    })
})