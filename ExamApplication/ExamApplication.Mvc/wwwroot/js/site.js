﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$.fn.select2.defaults.set('amdLanguageBase', 'select2/i18n/');
$(document).ready(function() {
    $('.js-example-basic-multiple').select2();
});