(function ($) {
    $.fn.dropdown = function () {
        var $this = $(this);

        var $div = $('<div />').addClass('dropdown-list-container');
        var $ul = $('<ul />').addClass('dropdown-list-options');

        // loop over options
        $this.children().each(
            function () {
                var $li = $('<li />')
                            .addClass('dropdown-list-option')
                            .html($(this).html())
                            .attr('data-value', $(this).val());

                $li.appendTo($ul);
            });

        $($ul).appendTo($div);
        $($div).appendTo(document.body);

        $('.dropdown-list-option').on('click', function () {
            var $this = $(this);
            var $index = $this.index();

            if ($this.hasClass('selectedItem')) {
                $this.removeClass('selectedItem');
                $('#dropdown option').eq($index).removeAttr('selected');
            }
            else {
                $this.addClass('selectedItem');
                $('#dropdown option').eq($index).attr('selected', 'selected');
            }
        });

        $this.hide();

        return $this;
    }
}(jQuery));