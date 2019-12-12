function progress() {
        var valeur = 0;
        var numberOfChecked = $('input:checkbox:checked').length;
        var totalCheckboxes = $('input:checkbox').length;
        var percent = (numberOfChecked / totalCheckboxes).toFixed(2) * 100;
        $('.progress-bar').css('width', percent + '%').attr('aria-valuenow', percent);
}