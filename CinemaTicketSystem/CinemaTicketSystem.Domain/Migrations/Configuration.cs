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
            Room room7 = new Room { Id = 7, Name = "7", NumberOfSeats = 120, WheelchairAccesible = true, Location = Tilburg };

            context.Locations.AddOrUpdate(
                l => l.Name,
                Tilburg
            );
            
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
                new Room { Id = 1, Name = "1", LocationId = context.Locations.Find(1).Id },
                new Room { Id = 2, Name = "2", LocationId = context.Locations.Find(1).Id },
                new Room { Id = 3, Name = "3", LocationId = context.Locations.Find(1).Id },
                new Room { Id = 4, Name = "4", LocationId = context.Locations.Find(1).Id },
                new Room { Id = 5, Name = "5", LocationId = context.Locations.Find(1).Id },
                new Room { Id = 6, Name = "6", LocationId = context.Locations.Find(1).Id },
                room7
            );

            context.Showings.Add(new Showing { MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(13) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(13) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 3, Start = DateTime.Today.AddHours(13) });
            context.Showings.Add(new Showing { MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 4, RoomId = 3, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 6, RoomId = 4, Start = DateTime.Today.AddHours(16) });
            context.Showings.Add(new Showing { MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(20) });
            context.Showings.Add(new Showing { MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(20) });
            context.Showings.Add(new Showing { MovieId = 3, RoomId = 3, Start = DateTime.Today.AddHours(20) });
            context.Showings.Add(new Showing { MovieId = 4, RoomId = 4, Start = DateTime.Today.AddHours(20) });
            context.Showings.Add(new Showing { MovieId = 5, RoomId = 5, Start = DateTime.Today.AddHours(20) });
            context.Showings.Add(new Showing { MovieId = 6, RoomId = 6, Start = DateTime.Today.AddHours(20) });

            foreach (int row in Enumerable.Range(1, 8))
            {

                foreach (int num in Enumerable.Range(1, 15))
                {
                    context.Seats.AddOrUpdate(m => m.Row,
                       new Seat { Available = true, Room = room7, Number = num, Row = row });
                }
            }
        }
    }
}
