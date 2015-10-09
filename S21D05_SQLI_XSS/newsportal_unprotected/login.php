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

    <h2>Log In</h2>

    <form action="verify_login.php" method="post">
      <div>
        <label for="username">Email:</label>
        <input id="username" name="username" type="email">
      </div>
      <div>
        <label for="password">Password:</label>
        <input id="password" name="password" type="password">
      </div>

      <div>
        <button>Log In</button>
      </div>
    </form>
  </body>
</html>
