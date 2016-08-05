CREATE TABLE Users
(
UserLogin varchar(25) NOT NULL,
UserPassword varchar(100) NOT NULL,
UserSalt varchar(177) NOT NULL,
UserIsAdmin int default 0,
CONSTRAINT pkUsersID PRIMARY KEY (UserLogin)
);


CREATE TABLE Subscriptions
(
SubscriptionsFullName varchar(135) NOT NULL,
SubscriptionsAge int NOT NULL,
SubscriptionsEmail varchar(255),
CONSTRAINT pkSubscriptionsEmail PRIMARY KEY (SubscriptionsEmail)
);