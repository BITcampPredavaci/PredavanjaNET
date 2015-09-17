$(document).ready(function() {
  var points = [];
  var canvas = document.getElementById("points-canvas");
  var ctx = canvas.getContext("2d");
  $('#points-canvas').on('contextmenu', function(e) {
    e.preventDefault();
  });

  // Sav bitan kôd se nalazi u jednom bloku, bez razdvajanja uloga. U istoj
  // funkciji se bavimo modeliranjem padataka (pravimo nove objekte),
  // obrađujemo korisniči input i te podatke crtamo na ekran. Sve je previše
  // uvezano i daljnje promjene su komplikovane.
  $('#points-canvas').mousedown(function(e) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.fillStyle = "green";

    if (e.which === 1) {
      points.push({ x: e.offsetX, y: e.offsetY });
    } else if (e.which === 3) {
      points.pop();
    }

    for (var i = 0; i < points.length; i++) {
      var point = points[i];
      ctx.fillRect(point.x, point.y, 10, 10);
    }
  });
});
