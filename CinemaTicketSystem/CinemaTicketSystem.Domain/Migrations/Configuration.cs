namespace CinemaTicketSystem.Domain.Migrations
{
    using CinemaTicketSystem.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaTicketSystem.Domain.Concrete.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaTicketSystem.Domain.Concrete.ApplicationDbContext context)
        {

            Location Tilburg = new Location { Id = 1, Name = "Tilburg" };

            context.Locations.AddOrUpdate(
                l => l.Name,
                Tilburg
            );

            Room room1 = new Room { Id = 1, Name = "1", NumberOfSeats = 120, WheelchairAccesible = true, LocationId = context.Locations.Find(1).Id };
            Room room2 = new Room { Id = 2, Name = "2", NumberOfSeats = 120, WheelchairAccesible = true, LocationId = context.Locations.Find(1).Id };
            Room room3 = new Room { Id = 3, Name = "3", NumberOfSeats = 120, WheelchairAccesible = true, LocationId = context.Locations.Find(1).Id };
            Room room4 = new Room { Id = 4, Name = "4", NumberOfSeats = 60, WheelchairAccesible = true, LocationId = context.Locations.Find(1).Id };
            Room room5 = new Room { Id = 5, Name = "5", NumberOfSeats = 50, WheelchairAccesible = false, LocationId = context.Locations.Find(1).Id };
            Room room6 = new Room { Id = 6, Name = "6", NumberOfSeats = 50, WheelchairAccesible = false, LocationId = context.Locations.Find(1).Id };

            
            context.Movies.AddOrUpdate(
                m => m.Id,
                new Movie { Id = 1, Name = "Deadpool 2", YearOfRelease = 2018, LengthInMinutes = 120, SpokenLanguage = "English", Genre = "Actie/Avontuur", MinimumAge = 16, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Deadpool-2_ps_1_jpg_sd-high.jpg&alt=img/movie_placeholder.png" },
                new Movie { Id = 2, Name = "Peter Rabbit", YearOfRelease = 2018, LengthInMinutes = 95, SpokenLanguage = "English", Genre = "Aniematie/Avontuur/Komedie", MinimumAge = 0, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Pieter-Konijn_ps_1_jpg_sd-low_%C2%A9-2018-Sony-Pictures-Entertainment.jpg&alt=img/movie_placeholder.png" },
                new Movie { Id = 3, Name = "Avengers: Infinity War", YearOfRelease = 2018, LengthInMinutes = 149, SpokenLanguage = "English", Genre = "Actie/Avontuur", MinimumAge = 12, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/avengers_infinity_war_poster.jpg&alt=img/movie_placeholder.png" },
                new Movie { Id = 4, Name = "Bankier van het Verzet", YearOfRelease = 2018, LengthInMinutes = 123, SpokenLanguage = "Dutch", Genre = "Oorlog/Thriller", MinimumAge = 12, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/47043546_93278.jpg&alt=img/movie_placeholder.png" },
                new Movie { Id = 5, Name = "Tomb Raider", YearOfRelease = 2018, LengthInMinutes = 118, SpokenLanguage = "English", Genre = "Actie/Avontuur", MinimumAge = 12, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Tomb-Raider_ps_1_jpg_sd-low_%C2%A9-2017-Warner-Bros-Ent-All-Rights-Reserved.jpg&alt=img/movie_placeholder.png" },
                new Movie { Id = 6, Name = "Buurman en Buurman bouwen een huis", YearOfRelease = 2018, LengthInMinutes = 57, SpokenLanguage = "Dutch", Genre = "Kinderfilm", MinimumAge = 0, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/37091117_94684.jpg&alt=img/movie_placeholder.png" }
            );

            context.Rooms.AddOrUpdate(
                r => r.Name,
                room6
            );

            context.Showings.Add(new Showing { MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(13) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(13) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 3, Start = DateTime.Today.AddHours(13) });
            context.Showings.Add(new Showing { MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 4, RoomId = 3, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 6, RoomId = 4, Start = DateTime.Today.AddHours(16) });

            context.Showings.Add(new Showing { MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(23) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(23) });
            context.Showings.Add(new Showing { MovieId = 3, RoomId = 3, Start = DateTime.Today.AddHours(23) });
            context.Showings.Add(new Showing { MovieId = 4, RoomId = 4, Start = DateTime.Today.AddHours(23) });
            context.Showings.Add(new Showing { MovieId = 5, RoomId = 5, Start = DateTime.Today.AddHours(23) });
            context.Showings.Add(new Showing { MovieId = 6, RoomId = 6, Start = DateTime.Today.AddHours(23) });


            // Add seats to room 1, 2, 3
            foreach (int row in Enumerable.Range(1, 8))
            {
                foreach (int num in Enumerable.Range(1, 15))
                {
                    context.Seats.Add(new Seat { Room = room1, Number = num, Row = row });
                    context.Seats.Add(new Seat { Room = room2, Number = num, Row = row });
                    context.Seats.Add(new Seat { Room = room3, Number = num, Row = row });
                }
            }

            // Add seats to room 4
            foreach (int row in Enumerable.Range(1, 6))
            {
                foreach (int num in Enumerable.Range(1, 10))
                {
                    context.Seats.Add(new Seat { Room = room4, Number = num, Row = row });
                }
            }

            // Add seats to room 5 and 6
            foreach (int row in Enumerable.Range(1, 4))
            {
                int numSeats = row >= 2 ? 15 : 10;
                foreach (int num in Enumerable.Range(1, numSeats))
                {
                    context.Seats.Add(new Seat { Room = room5, Number = num, Row = row });
                    context.Seats.Add(new Seat { Room = room6, Number = num, Row = row });
                }
            }
        }
    }
}
