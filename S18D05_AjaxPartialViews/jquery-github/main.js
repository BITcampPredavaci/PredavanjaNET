$('#fetch-repos').click(function(e) {
  e.preventDefault();
  var username = $('#github-username').val();
  var url =
    "https://api.github.com/users/" + username + "/repos";

  $.ajax({
    url: url,
    headers: {
      'Authorization':
        'Basic ' +
        btoa('<username>:<access-token>')
    }
  }).then(function(result) {
    $('#github-repositories')
      .fadeOut(function() {
        $('#github-repositories').empty();    

        for (var i = 0; i < result.length; i++) {
          $('<li>',
            {
              text: result[i].name,
              data: { fullName: result[i].full_name }
            })
            .appendTo('#github-repositories');
        }

        $('#github-repositories').fadeIn();
      })
  });
});

$('#github-repositories').on('click', 'li', function() {
  var fullName = $(this).data('fullName');
  alert(fullName);
});


$('#github-username').val('aspnet');
$('#fetch-repos').click();



