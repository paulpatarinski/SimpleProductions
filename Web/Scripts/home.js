  $(document).ready(function () {
    $.getJSON("../api/exceptions", function (data) {

      $('#table_id').DataTable({
        data: data,
        columns: [
            { data: 'MethodName', width:'10%'},
            { data: 'Message' , width :'80%'},
            { data: 'ExceptionDate', width: '80%' },
        ]
      });
    });
  });