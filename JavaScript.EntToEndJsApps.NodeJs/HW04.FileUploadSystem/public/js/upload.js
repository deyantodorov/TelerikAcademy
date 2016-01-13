$(document).ready(function () {
    $('#add-input-file').on('click', function () {
        var form = $('#form-upload');
        var count = form.children('input[type="file"]').length;

        var labelTypeFile = $('<label>');
        labelTypeFile.attr('for', 'file_' + count);
        labelTypeFile.text('Upload file ' + (count + 1));

        var inputTypeFile = $('<input />');
        inputTypeFile.attr('type', 'file');
        inputTypeFile.attr('name', 'file_' + count);
        inputTypeFile.attr('id', 'file_' + count);
        inputTypeFile.attr('class', 'form-control');

        var inputTypeCheckbox = $('<input />');
        inputTypeCheckbox.attr('type', 'checkbox');
        inputTypeCheckbox.attr('name', 'private_' + count);
        inputTypeCheckbox.attr('id', 'private_' + count);

        var labelCheckbox = $('<label>');
        labelCheckbox.attr('for', 'private_' + count);
        labelCheckbox.attr('class', 'pl-10');
        labelCheckbox.text('Is private file ' + (count + 1));

        var br = $('<br/>');

        form.prepend(br)
            .prepend(labelCheckbox)
            .prepend(inputTypeCheckbox)
            .prepend(inputTypeFile)
            .prepend(labelTypeFile)
            .prepend(br);
    });
});