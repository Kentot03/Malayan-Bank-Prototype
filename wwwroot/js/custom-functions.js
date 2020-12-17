

/**
 * Submit function for creation of record
 * @param {any} url POST url from the controller
 * @param {any} form Form of the page
 * @param {any} redirectAction Action name of the view to be redirected after saving
 * @param {any} redirectController Controller name of the view to be redirected after saving
 */
function submitCreateForm(url, form, redirectAction, redirectController) {
    bootbox.confirm({
        title: "<i class='fal fa-check-circle text-success mr-2'></i> Are you sure you want to proceed?",
        message: "<span><strong>Information:</strong> Record will be saved!</span>",
        centerVertical: true,
        swapButtonOrder: true,
        onEscape: true,
        backdrop: true,
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-primary shadow-0'
            },
            cancel: {
                label: 'No',
                className: 'btn-default'
            }
        },
        className: "modal-alert",
        closeButton: false,
        callback: function (result) {
            if (result == true) {
                $('.btn-save').attr('disabled', 'disabled');
                //var data = param;
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: $(form).serialize(),          
                    success: function (data) {
                        if (data.status == "200") {
                            toastr.success(
                                "Redirecting to view page. Please wait.",
                                "Record successfully saved",
                                {
                                    "closeButton": false,
                                    "debug": false,
                                    "newestOnTop": false,
                                    "progressBar": true,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "3000",
                                    "hideDuration": "3000",
                                    "timeOut": "3000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });


                            setTimeout(function () {
                                location.href = '/' + redirectController + '/' + redirectAction;
                            }, 3000);
                        }
                        else if (data.status == "409") {
                            $('.btn-save').removeAttr('disabled');
                            $('#error-string').html(data.content);
                            $('#error-message').css('display', 'block')
                        }
                        else {
                            $('.btn-save').removeAttr('disabled');
                            toastr.error("Record not saved. Please review your inputs",
                                "Error Encountered.",
                                {
                                    "closeButton": false,
                                    "newestOnTop": false,
                                    "progressBar": false,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "300",
                                    "hideDuration": "1000",
                                    "timeOut": "5000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });
                        };
                    },
                    error: function (error) {
                        $('.btn-save').removeAttr('disabled');
                        toastr.error("Record not saved. Please review your inputs",
                            "Error Encountered.",
                            {
                                "closeButton": false,
                                "newestOnTop": false,
                                "progressBar": false,
                                "positionClass": "toast-bottom-right",
                                "preventDuplicates": false,
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            });
                    }
                });
            }
            else {
                $('.btn-save').removeAttr('disabled');
            };
        }
    });
}

/**
 * Submit function for creation of record
 * @param {any} url POST url from the controller
 * @param {any} data Serialized data of the datatables
 * @param {any} redirectAction Action name of the view to be redirected after saving
 * @param {any} redirectController Controller name of the view to be redirected after saving
 */
function submitDatatableForm(url, data, redirectAction, redirectController) {
    bootbox.confirm({
        title: "<i class='fal fa-check-circle text-success mr-2'></i> Are you sure you want to proceed?",
        message: "<span><strong>Information:</strong> Record will be saved!</span>",
        centerVertical: true,
        swapButtonOrder: true,
        onEscape: true,
        backdrop: true,
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-primary shadow-0'
            },
            cancel: {
                label: 'No',
                className: 'btn-default'
            }
        },
        className: "modal-alert",
        closeButton: false,
        callback: function (result) {
            if (result == true) {
                $('.btn-save').attr('disabled', 'disabled');
                //var data = param;
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: data,
                    success: function (data) {
                        if (data == "Success") {
                            toastr.success(
                                "Redirecting to view page. Please wait.",
                                "Record successfully saved",
                                {
                                    "closeButton": false,
                                    "debug": false,
                                    "newestOnTop": false,
                                    "progressBar": true,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "3000",
                                    "hideDuration": "3000",
                                    "timeOut": "3000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });


                            setTimeout(function () {
                                location.href = '/' + redirectController + '/' + redirectAction;
                            }, 3000);
                        }
                        else {
                            $('.btn-save').removeAttr('disabled');
                            toastr.error("Record not saved. Please review your inputs",
                                "Error Encountered.",
                                {
                                    "closeButton": false,
                                    "newestOnTop": false,
                                    "progressBar": false,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "300",
                                    "hideDuration": "1000",
                                    "timeOut": "5000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });
                        }
                    },
                    error: function (error) {
                        $('.btn-save').removeAttr('disabled');
                        toastr.error("Record not saved. Please review your inputs",
                            "Error Encountered.",
                            {
                                "closeButton": false,
                                "newestOnTop": false,
                                "progressBar": false,
                                "positionClass": "toast-bottom-right",
                                "preventDuplicates": false,
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            });
                    }
                });
            }
            else {
                $('.btn-save').removeAttr('disabled');
            };
        }
    });
}

/**
 * Submit function for modification of record
 * @param {any} url POST url from the controller
 * @param {any} form Form of the page
 * @param {any} redirectAction Action name of the view to be redirected after saving
 * @param {any} redirectController Controller name of the view to be redirected after saving
 */
function submitModifyForm(url, form, redirectAction, redirectController) {
    bootbox.confirm({
        title: "<i class='fal fa-check-circle text-success mr-2'></i> Are you sure you want to proceed?",
        message: "<span><strong>Information:</strong> Record will be modified!</span>",
        centerVertical: true,
        swapButtonOrder: true,
        onEscape: true,
        backdrop: true,
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-primary shadow-0'
            },
            cancel: {
                label: 'No',
                className: 'btn-default'
            }
        },
        className: "modal-alert",
        closeButton: false,
        callback: function (result) {
            if (result == true) {
                $('.btn-save').attr('disabled', 'disabled');
                //var data = param;
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: $(form).serialize(),
                    success: function (data) {
                        if (data.status == "200") {
                            toastr.success(
                                "Redirecting to view page. Please wait.",
                                "Record successfully modified",
                                {
                                    "closeButton": false,
                                    "debug": false,
                                    "newestOnTop": false,
                                    "progressBar": true,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "3000",
                                    "hideDuration": "3000",
                                    "timeOut": "3000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });


                            setTimeout(function () {
                                location.href = '/' + redirectController + '/' + redirectAction;
                            }, 3000);
                        }
                        else if (data.status == "409") {
                            $('.btn-save').removeAttr('disabled');
                            $('#error-string').html(data.content);
                            $('#error-message').css('display', 'block')
                        }
                        else {
                            $('.btn-save').removeAttr('disabled');
                            toastr.error("Record not modified. Please review your inputs",
                                "Error Encountered.",
                                {
                                    "closeButton": false,
                                    "newestOnTop": false,
                                    "progressBar": false,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "300",
                                    "hideDuration": "1000",
                                    "timeOut": "5000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });
                        }
                    },
                    error: function (error) {
                        $('.btn-save').removeAttr('disabled');
                        toastr.error("Record not modified. Please review your inputs",
                            "Error Encountered.",
                            {
                                "closeButton": false,
                                "newestOnTop": false,
                                "progressBar": false,
                                "positionClass": "toast-bottom-right",
                                "preventDuplicates": false,
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            });
                    }
                });
            }
            else {
                $('.btn-save').removeAttr('disabled');
            };
        }
    });
}

/**
 * Submit function for modification of record
 * @param {any} url POST url from the controller
 * @param {any} id Parameter(ID) to be passed in the controller
 * @param {any} redirectAction Action name of the view to be redirected after saving
 * @param {any} redirectController Controller name of the view to be redirected after saving
 */
function deleteRecord(url, id, redirectAction, redirectController) {
    bootbox.confirm({
        title: "<i class='fal fa-times-circle text-danger mr-2'></i> Are you sure you want to proceed?",
        message: "<span><strong>Warning!:</strong> Record will be deleted! This action cannot be undone.</span>",
        centerVertical: true,
        swapButtonOrder: true,
        onEscape: true,
        backdrop: true,
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-primary shadow-0'
            },
            cancel: {
                label: 'No',
                className: 'btn-default'
            }
        },
        className: "modal-alert",
        closeButton: false,
        callback: function (result) {
            if (result == true) {
                //var data = param;
                $.ajax({
                    type: 'GET',
                    url: url + '?id=' + id,
                    success: function (data) {
                        if (data == "Success") {
                            toastr.success(
                                "Page is reloading. Please wait.",
                                "Record successfully deleted",
                                {
                                    "closeButton": false,
                                    "debug": false,
                                    "newestOnTop": false,
                                    "progressBar": true,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "2000",
                                    "hideDuration": "2000",
                                    "timeOut": "2000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });

                            setTimeout(function () {
                                location.href = '/' + redirectController + '/' + redirectAction;
                            }, 2000);
                        }
                        else {
                            toastr.error("Record not deleted.",
                                "Error Encountered.",
                                {
                                    "closeButton": false,
                                    "newestOnTop": false,
                                    "progressBar": false,
                                    "positionClass": "toast-bottom-right",
                                    "preventDuplicates": false,
                                    "onclick": null,
                                    "showDuration": "300",
                                    "hideDuration": "1000",
                                    "timeOut": "5000",
                                    "extendedTimeOut": "1000",
                                    "showEasing": "swing",
                                    "hideEasing": "linear",
                                    "showMethod": "fadeIn",
                                    "hideMethod": "fadeOut"
                                });
                        }
                    },
                    error: function (error) {
                        toastr.error("Record not deleted",
                            "Error Encountered.",
                            {
                                "closeButton": false,
                                "newestOnTop": false,
                                "progressBar": false,
                                "positionClass": "toast-bottom-right",
                                "preventDuplicates": false,
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            });
                    }
                });
            }
            else {

            };
        }
    });
}

/**
 * Submit function for modification of record
 * @param {any} element element
 * @param {any} date set default date
 */
function initDatePicker(element, date) {
    var controls = {
        leftArrow: '<i class="fal fa-angle-left" style="font-size: 1.25rem"></i>',
        rightArrow: '<i class="fal fa-angle-right" style="font-size: 1.25rem"></i>'
    }
    $(element).datepicker({
        orientation: "bottom left",
        templates: controls
    });

    if (date != null) {
        $(element).datepicker('setDate', date);
    };
};