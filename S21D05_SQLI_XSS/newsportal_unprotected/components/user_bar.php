<?php
if (isset($account)) {
?>
<p>
  Hi,
  <strong>
    <?php echo $account->name ?>
  </strong>
  |
  <?php echo $account->email ?>
  |
  <a href="/logout.php">Log out</a>
</p>
<?php
} else {
?>
<p>
  <a href="/login.php">Log In</a>
  |
  <a href="/register.php">Register</a>
</p>
<?php
}
?>
