<?php
class Account {
  public $id;
  public $name;
  public $email;

  function __construct($row) {
    $this->id = $row['id'];
    $this->name = $row['name'];
    $this->email = $row['email'];
  }

  public function set_password($password) {
    $this->password_hash = md5($password);
  }

  private $password_hash;
}
?>
