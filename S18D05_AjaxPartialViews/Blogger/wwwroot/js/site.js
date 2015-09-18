$('#comment-form').submit(function(e) {
	e.preventDefault();
	$.ajax({
		url: $(this).attr('action'),
		method: $(this).attr('method'),
		data: $(this).serialize()
	}).then(function(result) {
		var tempDiv = $('<div>', { html: result });
		
		var comment = tempDiv.find('.comment');
		comment.hide()
		comment.appendTo('.comments')
		comment.fadeIn('slow');
	}).fail(function() {
		alert("Došlo je do greške. Pokušajte malo sutra.");
	})
});
