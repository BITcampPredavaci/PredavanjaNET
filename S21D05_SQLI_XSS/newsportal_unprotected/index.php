<?php
require 'include.php';
?>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Njuzica.ba | Vaš Izvor Nezamislivih Idiotluka</title>
  </head>

  <body>
    <h1><a href="/">Njuzica</a></h1>
    <p>Vaš izvor nezamislivih idiotluka</p>

    <?php include "components/user_bar.php" ?>

    <h2>Izbor najboljih vijesti za zaglupljivanje</h2>

    <?php
    foreach ($pdo->query("SELECT posts.*, users.name FROM posts INNER JOIN users ON posts.author_id = users.id") as $post) {
    ?>
    <article>
      <h4><?php echo $post['title'] ?></h4>
      <?php echo $post['body'] ?>

      <footer>
        <p>Autor:
          <strong>
          <?php echo $post['name'] ?>
          </strong>
        </p>

        <p>Ukupno komentara: <?php echo $pdo->query("SELECT COUNT(*) FROM comments WHERE post_id = {$post['id']}")->fetch()[0] ?></p>
        <p>
          Likes: <?php echo $post['likes'] ?>
          <a href="/like.php?post_id=<?php echo $post['id'] ?>">Like</a>
        </p>
      </footer>
    </article>
    <?php
    }
    ?>
  </body>
</html>
