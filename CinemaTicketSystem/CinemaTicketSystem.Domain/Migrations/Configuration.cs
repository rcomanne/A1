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
            context.Locations.AddOrUpdate(
                l => l.Name,
                new Location { Name = "Tilburg" }
            );

            context.Movies.AddOrUpdate(
                m => m.Name,
                new Movie { Name = "Deadpool 2", ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Deadpool-2_ps_1_jpg_sd-high.jpg&alt=img/movie_placeholder.png" },
                new Movie { Name = "Peter Rabit", ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Pieter-Konijn_ps_1_jpg_sd-low_%C2%A9-2018-Sony-Pictures-Entertainment.jpg&alt=img/movie_placeholder.png" },
                new Movie { Name = "Avengers: Infinity War", ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/avengers_infinity_war_poster.jpg&alt=img/movie_placeholder.png" },
                new Movie { Name = "Bankier van het Verzet", ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/47043546_93278.jpg&alt=img/movie_placeholder.png" },
                new Movie { Name = "Tomb Raider", ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Tomb-Raider_ps_1_jpg_sd-low_%C2%A9-2017-Warner-Bros-Ent-All-Rights-Reserved.jpg&alt=img/movie_placeholder.png" },
                new Movie { Name = "Buurman en Buurman bouwen een huis", ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/37091117_94684.jpg&alt=img/movie_placeholder.png" }
            );
        }
    }
}
