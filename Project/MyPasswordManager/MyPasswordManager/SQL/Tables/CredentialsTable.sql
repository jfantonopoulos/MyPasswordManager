﻿CREATE TABLE IF NOT EXISTS Credentials(
	ID INTEGER PRIMARY KEY AUTOINCREMENT,
	Source TEXT NOT NULL,
	Username TEXT NOT NULL,
	PasswordHash TEXT NOT NULL
);