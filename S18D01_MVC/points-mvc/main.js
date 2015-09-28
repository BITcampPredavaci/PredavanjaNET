$(document).ready(function() {
  var canvas = document.getElementById("points-canvas");
  var ctx = canvas.getContext("2d");
  $('#points-canvas').on('contextmenu', function(e) {
    e.preventDefault();
  });

  // Model
  //
  // Brine se za poslovnu logiku, update-uje View kada dolazi do promjena.
  var points = {
    coordinates: [],

    push: function(x, y) {
      var point = { x: x, y: y };
      this.coordinates.push(point);
      drawing.refresh();
    },

    pop: function() {
      this.coordinates.pop();
      drawing.refresh();
    }
  };

  // View
  //
  // Brine se za prikaz podataka iz Modela. Nema interakcije s Controller-om.
  var drawing = {
    refresh: function() {
      ctx.clearRect(0, 0, canvas.width, canvas.height);
      ctx.fillStyle = "green";

      for (var i = 0; i < points.coordinates.length; i++) {
        var point = points.coordinates[i];
        ctx.fillRect(point.x, point.y, 10, 10);
      }
    }
  };

  // Controller
  //
  // Obrađuje korisnički input. Nema direktne interakcije s View-om.
  $('#points-canvas').mousedown(function(e) {
    if (e.which === 1) {
      points.push(e.offsetX, e.offsetY);
    } else if (e.which === 3) {
      points.pop();
    }
  });
});
