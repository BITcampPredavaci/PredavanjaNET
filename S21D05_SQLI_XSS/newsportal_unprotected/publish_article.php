<?php
require 'include.php';

$title = htmlspecialchars($_POST['title']);
$body = htmlspecialchars($_POST['body']);
$author_id = $account->id;

$pdo->exec(
	"INSERT INTO posts (title, body, author_id) VALUES ('$title', '$body', '$author_id')");

header("Location: /cms.php");
?>
