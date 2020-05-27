$('#myModal').on('shown.bs.modal', function () {
  $('#myInput').trigger('focus')
})

$('[data-toggle="popover"]').popover();