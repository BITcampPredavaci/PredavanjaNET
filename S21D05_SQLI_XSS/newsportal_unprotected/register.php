<?php
require 'include.php';
?>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Njuzica.ba | Vaš Izvor Nezamislivih Idiotluka</title>
  </head>

  <body>
    <h1><a href="/">Njuzica</a></h1>
    <p>Vaš izvor nezamislivih idiotluka</p>

    <h2>Registracija</h2>

    <form action="create_account.php" method="post">
      <div>
        <label for="name">Ime:</label>
        <input id="name" name="name" required>
      </div>
      <div>
        <label for="username">Email:</label>
        <input id="username" name="username" type="email" required>
      </div>
      <div>
        <label for="password">Password:</label>
        <input id="password" name="password" type="password" required>
      </div>

      <div>
        <button>Register</button>
      </div>
    </form>
  </body>
</html>

