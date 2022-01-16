
$('#desembarque').on('change', function () {
  $('#preco').val($(this).val());
});

// init
$('#desembarque').change();

$(document).ready(function () {
  alert("Ola");
});