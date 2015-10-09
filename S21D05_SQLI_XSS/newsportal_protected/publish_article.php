<?php
require 'include.php';

$title = $_POST['title'];
$body = $_POST['body'];
$author_id = $account->id;

$statement = $pdo->prepare("INSERT INTO posts (title, body, author_id) VALUES (:title, :body, :author_id)");
$statement->execute(array(':title' => $title, ':body' => $body, ':author_id' => $author_id));

header("Location: /cms.php");
?>
