<?php
require 'include.php';

$post_id = $_GET['post_id'];

if (!isset($_SESSION['liked_posts'])) {
  $_SESSION['liked_posts'] = array();
}

if (!in_array($post_id, $_SESSION['liked_posts'])) {
  $pdo->exec("UPDATE posts SET likes = likes + 1 WHERE id = $post_id");

  array_push($_SESSION['liked_posts'], $post_id);
}

header("Location: /");
?>
