$(document).ready(function () {

	$("#peopleForm").submit(function (e) {
		e.preventDefault();
		//$("#personName").val("Moje ime");
		var name = $('#personName').val();
		var surname = $("#personSurname").val();
		var toAdd = "<tr> "
			+ "<td> " + name + " </td> "
			+ "<td> " + surname + "</td>"
			+ '<td> <button class="btn btn-danger delete" > Remove </button> </td>'
			+ "</tr>";

		$("#peopleTable tbody").append(toAdd);
		$('#personName').val("");
		$('#personSurname').val("");

		$('.delete').click(function () {
			$(this).parent().parent().remove();
		});
	});




});