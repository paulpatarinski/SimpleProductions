  $(document).ready(function () {
    $.getJSON("../api/exceptions", function (data) {

      $('#table_id').DataTable({
        data: data,
        order : [[ 2, "desc" ]],
        columns: [
            { data: 'MethodName'},
            { data: 'Message' , width :'90%'},
            { data: 'ExceptionDate'},
            { data: 'AppVersion'},
        ],
      });
    });
  });