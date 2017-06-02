                                                                              $(document).ready(function () {


	
	var timeMax = new TweenMax();


	$("#slider a").first().show();

	var index = 0;
	var count = 5;

	function bannerRotator() {
		$('#slider a').delay(4300).eq(index).fadeOut(function () {
			if (index === count) {
				index = -1;
			}

			$('#slider a').eq(index + 1).fadeIn(function () {
				index++;
				bannerRotator();
			});
		});
	}
	bannerRotator();



});


function LoadItems(Model) {	

	for (var i = 0; i < 4; i++) {
		alert();
	}
}


$('#btn').click(function () {
	alert();
});


function previewChange(id) {

	var newSrc = ($('#' + id + ' img').attr('src'));

	$('li img ').css('border-style', 'double');
	$("#previewImage").attr('src', newSrc);

	$('#' + id + ' img').css('border-style', 'solid');

}

function onloadfunction() {
	alert();
}


























                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            