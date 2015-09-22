$.ajaxPrefilter(function(options, originalOptions, jqXHR) {
  var authorizationOptions = {
    headers: {
      'Authorization':
        'Basic ' +
        btoa('<username>:<access-token>')
    }
  };

  $.extend(options, authorizationOptions, originalOptions);
});

$('#fetch-repos').click(function(e) {
  e.preventDefault();
  var username = $('#github-username').val();
  var url =
    "https://api.github.com/users/" + username + "/repos";

  $.ajax({
    url: url
  }).then(function(result) {
    $('#github-repositories')
      .fadeOut(function() {
        $('#github-repositories').empty();    

        for (var i = 0; i < result.length; i++) {
          $('<li>',
            {
              text: result[i].name,
              data: { repository: result[i] }
            })
            .appendTo('#github-repositories');
        }

        $('#github-repositories').fadeIn();
      })
  });
});

$('#github-repositories').on('click', 'li', function() {
  var repository = $(this).data('repository');

   $.ajax({
    url: repository.issues_url.replace('{/number}', '')
  }).then(function(result) {
    var output = "Full repository name: " +
      repository.full_name +
      "\n\n" +
      "Open issues count: " +
      repository.open_issues_count;

    if (result.length > 0) {
      output +=
        "\n\n" +
        "Last opened issue's title: " +
        result[0].title;
    }

    alert(output);
  });
});


$('#github-username').val('aspnet');
$('#fetch-repos').click();
