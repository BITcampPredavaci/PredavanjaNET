<?php
require "classes/account.php";

session_start();

function pdo_connection_string() {
  if (getenv('DATABASE_URL')) {
    $opts = parse_url(getenv('DATABASE_URL'));

    $host = $opts['host'];
    $port = $opts['port'];
    $username = $opts['user'];
    $password = $opts['pass'];
    $database = substr($opts['path'], 1);

    return "pgsql:dbname={$database} host={$host} port={$port} user={$username} password={$password} sslmode=require";
  } else {
    return 'pgsql:dbname=njuzica';
  }
}

function find_user_by_credentials($pdo, $username, $password) {
  $password_digest = md5($password);

  # $username = \' OR 1=1 --
  # SELECT * FROM users WHERE email='\' OR 1=1 --' AND password = '$password_digest'"
  // $statement = $pdo->query(
  //   "SELECT * FROM users WHERE email='$username' AND password = '$password_digest'"
  // );

  $statement = $pdo->prepare(
    "SELECT * FROM users WHERE email=:email AND password = :password");
  $statement->execute(array(':email' => $username, ':password' => $password_digest));

  if ($statement->rowCount() > 0) {
    return new Account($statement->fetch());
  } else {
    return null;
  }
}

$pdo = new PDO(pdo_connection_string());
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

if (isset($_SESSION['current_account_id'])) {
  $account_id = $_SESSION['current_account_id'];

  $statement = $pdo->query("SELECT * FROM users WHERE id = $account_id");
  if ($statement->rowCount() > 0) {
    $account = new Account($statement->fetch());
  }
}
?>
