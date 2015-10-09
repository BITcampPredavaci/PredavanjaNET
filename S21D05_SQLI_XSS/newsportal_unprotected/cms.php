<?php
require 'include.php';

if (!$account) {
  header('Location: /');
  return;
}
?>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Njuzica.ba | Vaš Izvor Nezamislivih Idiotluka</title>
  </head>

  <body>
    <h1><a href="/">Njuzica</a></h1>

    <?php include "components/user_bar.php" ?>

    <h2>CMS</h2>

    <h3>Pisanje novog članka</h3>

    <form action="publish_article.php" method="POST">
      <div>
        <label for="title">Naslov:</label><br>
        <input id="title" name="title" required>
      </div>
      <div>
        <label for="body">Tekst članka:</label><br>
        <textarea id="body" name="body"></textarea>
      </div>

      <div>
        <button>Objavi Idiotluk</button>
      </div>
    </form>

    <h3>Članci</h3>

    <?php
    foreach ($pdo->query("SELECT * FROM posts") as $post) {
    ?>
    <article>
      <h4><?php echo $post['title'] ?></h4>
      <?php echo $post['body'] ?>

      <footer>
        <p>Autor ID: <?php echo $post['author_id'] ?></p>
        <p>Ukupno komentara: <?php echo $pdo->query("SELECT COUNT(*) FROM comments WHERE post_id = {$post['id']}")->fetch()[0] ?></p>
      </footer>
    </article>
    <?php
    }
    ?>
  </body>
</html>
