CREATE TABLE users (
  id serial PRIMARY KEY,
  name varchar(255),
  email varchar(255),
  password varchar(255),
  created_at timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE posts (
  id serial PRIMARY KEY,
  title varchar(255),
  body text,
  author_id integer NOT NULL REFERENCES users (id),
  likes INTEGER NOT NULL DEFAULT 0,
  created_at timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE comments (
  id serial PRIMARY KEY,
  author varchar(255),
  body text,
  post_id integer NOT NULL REFERENCES posts (id),
  created_at timestamp NOT NULL DEFAULT (now())
);

CREATE TABLE cookies (
  id serial PRIMARY KEY,
  value text,
  created_at timestamp NOT NULL DEFAULT (now())
);
