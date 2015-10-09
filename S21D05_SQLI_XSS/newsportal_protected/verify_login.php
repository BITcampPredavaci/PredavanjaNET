<?php
require 'include.php';

$account = find_user_by_credentials($pdo, $_POST['username'], $_POST['password']);
var_dump($account);

if ($account) {
  $_SESSION['current_account_id'] = $account->id;
  header("Location: /cms.php");
} else {
  header("Location: /");
}
?>
