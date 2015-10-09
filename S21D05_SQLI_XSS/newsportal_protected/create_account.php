<?php
require 'include.php';

$name = $_POST['name'];
$username = $_POST['username'];
$password = $_POST['password'];
$password_digest = md5($password);

$statement = $pdo->prepare("INSERT INTO users (name, email, password) VALUES (:name, :username, :password_digest)");
$statement->execute(array(':name' => $name, ':username' => $username, ':password_digest' => $password_digest));

$account = find_user_by_credentials($pdo, $username, $password);
if ($account) {
  $_SESSION['current_account_id'] = $account->id;
  header("Location: /cms.php");
} else {
  header("Location: /");
}
?>
