$('#comment-form').submit(function(e) {
	e.preventDefault();
	$.ajax({
		url: $(this).attr('action'),
		method: $(this).attr('method'),
		data: $(this).serialize()
	}).then(function(result) {
		var comment = $('<div>', {
			'class': 'comment',
			text: result.Body
		});

		var form = $('<form>', {
			action: '/Comments/Delete/' + comment.id,
			method: 'post'
		});

		var button = $('<button>', {
			text: 'Delete comment'
		});

		comment.append(form);
		form.append(button);

		comment.hide()
		comment.appendTo('.comments')
		comment.fadeIn('slow');
	}).fail(function() {
		alert("Došlo je do greške. Pokušajte malo sutra.");
	});
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
