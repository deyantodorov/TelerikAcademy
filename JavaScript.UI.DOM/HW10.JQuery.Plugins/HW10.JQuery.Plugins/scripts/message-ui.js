(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);

        if ($this.css('display') === 'none') {
            $this.fadeIn(3000);
        }
        else {
            $this.fadeOut(3000);
        }

        return {
            success: 'Success message',
            error: 'Error message',
            this: $this
        };
    }
}(jQuery));