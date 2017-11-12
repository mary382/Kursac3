$('#stars').on('rating:change', function (event, value, caption) {
    let sendObj = {
        instructionId: $('#instructionId').val(),
        stars: value
    }
    $.post("ToAssessInstruction", sendObj, function (data) {
        $('#stars').rating('update', data.avg);
    });
});

