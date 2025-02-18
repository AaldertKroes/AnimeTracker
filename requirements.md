# Requirements
- [x] Keep track of a list of anime.
- [x] Keep track of a list of anime that I want to watch myself.
- [ ] Keep track of a list of (anime) movies that I want to watch myself.
- [x] Keep track of a list of anime that I've already watched.
- [x] Keep track of a list of anime that I want to watch together where names can be specified.
- [x] Keep track of a list of anime that I've watched together with people.
- [ ] Keep track of specified anime to watch together in a certain order. (Queue)

The app needs to be usable in the command line. (Cocona)
The app must use an SQLite database. (EntityFrameworkCore.Sqlite)


## DB
Anime {
	Id int NOT NULL PRIMARY KEY AUTO INCREMENT,
	Title text NOT NULL,
	Description text,
}

Movie {
	Id int NOT NULL PRIMARY KEY AUTO INCREMENT,
	Title text NOT NULL,
	Description text,
}

ListSelf {
	Id int NOT NULL PRIMARY KEY AUTO INCREMENT,
	AnimeID int,
	MovieId int,
	Watched bool NOT NULL,
	Rating real,
}

QueueSelf {
	Id int NOT NULL PRIMARY KEY AUTO INCREMENT,
	ListSelfId int NOT NULL,
}

ListTogether {
	Id int NOT NULL PRIMARY KEY AUTO INCREMENT,
	AnimeID int,
	MovieId int,
	WatchingWith text NOT NULL,
	Watched bool NOT NULL,
	Rating real,
}

QueueTogether {
	Id int NOT NULL PRIMARY KEY AUTO INCREMENT,
	ListTogetherId int NOT NULL,
} 