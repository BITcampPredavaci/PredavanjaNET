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
    $statement = $pdo->prepare("SELECT COUNT(*) FROM comments WHERE post_id = :post_id");

    foreach ($pdo->query("SELECT posts.*, users.name FROM posts INNER JOIN users ON posts.author_id = users.id ORDER BY created_at DESC") as $post) {
    ?>
    <article>
      <h4><?php echo htmlspecialchars($post['title']) ?></h4>
      <?php echo htmlspecialchars($post['body']) ?>

      <footer>
        <p>Autor:
          <strong>
          <?php echo htmlspecialchars($post['name']) ?>
          </strong>
        </p>

        <?php $statement->execute(array('post_id' => $post['id'])) ?>
        <p>Ukupno komentara: <?php echo htmlspecialchars($statement->fetch()[0]) ?></p>
        <p>
          Likes: <?php echo htmlspecialchars($post['likes']) ?>
          <form action="like.php" method="post">
            <input type="hidden" name="post_id" value="<?php echo htmlspecialchars($post['id']) ?>">
            <button
              style="border: 0; margin: 0; padding: 0; text-decoration: underline; cursor: pointer; background: transparent; color: blue;"
              >Like</button>
          </form>
        </p>
      </footer>
    </article>
    <?php
    }
    ?>
  </body>
</html>
