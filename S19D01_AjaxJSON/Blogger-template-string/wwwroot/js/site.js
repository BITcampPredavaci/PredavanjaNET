var commentTemplate = '<div class="comment">{{Body}}' +
	'<form action="/Comments/Delete/{{Id}}" method="post">' +
	'<button>Delete comment</button></form></div>';

$('#comment-form').submit(function(e) {
	e.preventDefault();
	$.ajax({
		url: $(this).attr('action'),
		method: $(this).attr('method'),
		data: $(this).serialize()
	}).then(function(result) {
		var output = Mustache.render(commentTemplate, result);

		var tempDiv = $('<div>', { html: output });

		var comment = tempDiv.find('.comment');
		comment.hide();
		comment.appendTo('.comments');
		comment.fadeIn('slow');
	}).fail(function() {
		alert("Došlo je do greške. Pokušajte malo sutra.");
	})
});

$('.comments').on('submit', '.comment form', function(e) {
	e.preventDefault();
	var comment = $(this).closest('.comment');

	$.ajax({
		url: $(this).attr('action'),
		method: $(this).attr('method')
	}).then(function() {
		comment.remove();
	});
});
