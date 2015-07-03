/// <reference path="../typings/jquery/jquery.d.ts"/>
$(document).ready(function(){
	var $firstButton = $("#first");
	
	 $('[data-toggle="popover"]').popover();
	
	$("button").click(function(){
		$("button").each(function(){
			$(this).removeClass("btn-success");
		});
		
		$(this).addClass("btn-success");
	});
	
	
	$('.other').html("Not first :(");
	
	$(".alert *").html("Gumb");
	
	
	
	$("#userForm").submit(function(e){
		e.preventDefault();
		
		console.log($(this).serialize());
		
		var mail = $("#inputMail").val();
		var password = $("#inputPassword").val();
		
		console.log(mail, password);
		
	});
	
	
	
	
});

