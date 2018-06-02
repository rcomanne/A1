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
                new Movie {
                    Id = 1,
                    Name = "Deadpool 2",
                    YearOfRelease = 2018,
                    LengthInMinutes = 120,
                    SpokenLanguage = "Engels",
                    Genre = "Actie/Avontuur",
                    MinimumAge = 16,
                    ShortDescription = "Na het overleven van een bijna fatale runderaanval, worstelt een misvormde cafetaria-kok (Wade Wilson) om zijn droom te verwezenlijken om een succesvolle barman te worden - terwijl hij daarnaast ook nog moet leren omgaan met smaakverlies. Op zoek naar zijn levenslust én een fluxcondensator, gaat Wade de strijd aan met ninja’s, de yakuza en een groep seksueel agressieve honden. Terwijl hij ondertussen de wereld rondreist om het belang van familie, vriendschap en smaak te ontdekken - op zoek naar avontuur en de felbegeerde koffiemok-titel ‘World’s Best Lover’.",
                    SubtitleLanguage = "Nederlands",
                    Director = "David Leitch",
                    Trailer = "https://www.youtube.com/embed/1gF3lp-qFZo",
                    Imdb = "https://www.imdb.com/title/tt5463162/",
                    WebLink = "http://marvel.com/movies/movie/261/deadpool_2",
                    LastShowDate = new DateTime(2018, 10, 31),
                    ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Deadpool-2_ps_1_jpg_sd-high.jpg&alt=img/movie_placeholder.png"
                },
                new Movie {
                    Id = 2,
                    Name = "Pieter Konijn",
                    YearOfRelease = 2018,
                    LengthInMinutes = 95,
                    SpokenLanguage = "Nederlands",
                    Genre = "Aniematie/Avontuur/Komedie",
                    MinimumAge = 0,
                    ShortDescription = "Pieter Konijn is de verfilming van Beatrix Potters tijdloze verhaal over de eigenwijze en ondeugende Pieter Konijn. De avontuurlijke held Pieter Konijn is geliefd bij meerdere generaties lezers. Nu krijgt hij de hoofdrol in de eigentijdse en stoere live-action animatiefilm voor de hele familie. De strijd tussen Pieter en meneer Verhoef om de moestuin loopt ontzettend uit de hand. Ook proberen ze allebei in de smaak te vallen bij hun lieve buurvrouw Bea. Zij is gek op dieren, terwijl meneer Verhoef juist een hekel heeft aan het ‘ongedierte’ dat zijn tuin probeert te verwoesten. Tommie Christiaan spreekt de stem in van Pieter. Zussen Shelley Vol, Amy Vol en Lisa Vol (OG3NE) nemen de stemmen van de drieling Flopsie, Mopsie en Wipstaart voor hun rekening. Verder met de stemmen van o.a. Do (Bea), Joey Schalker (Thomas Verhoef), Jan Versteegh (Benjamin Wollepluis), Cystine Carreon (afdelingsmanager) en Roué Verveer (Jan Willem de Haan).",
                    Director = "Will Gluck",
                    Trailer = "https://www.youtube.com/embed/Uucnqu8IEmI",
                    Imdb = "https://www.imdb.com/title/tt5117670/",
                    LastShowDate = new DateTime(2018, 8, 31),
                    ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Pieter-Konijn_ps_1_jpg_sd-low_%C2%A9-2018-Sony-Pictures-Entertainment.jpg&alt=img/movie_placeholder.png"
                },
                new Movie {
                    Id = 3,
                    Name = "Avengers: Infinity War",
                    YearOfRelease = 2018,
                    LengthInMinutes = 149,
                    SpokenLanguage = "Engels",
                    Genre = "Actie/Avontuur",
                    MinimumAge = 12,
                    ShortDescription = "Tien jaar nadat de eerste film van het Marvel Cinematic Universe werd uitgebracht, komt de spanning tot een hoogtepunt in de grootste confrontatie aller tijden in Marvel’s Avengers: Infinity War. Voor het eerst komen alle helden en hun bondgenoten uit alle voorgaande films bij elkaar om het op te nemen tegen de machtige Thanos die een bedreiging vormt die te groot is voor een enkele held. De Avengers moeten bereid zijn alles op te geven in een poging om Thanos te verslaan, voordat zijn missie slaagt en zijn verwoesting een einde brengt aan alles.",
                    SubtitleLanguage = "Nederlands",
                    Director = "Joe Russo, Anthony Russo",
                    Trailer = "https://www.youtube.com/embed/L99k7rXPIBY",
                    Imdb = "https://www.imdb.com/title/tt4154756/",
                    WebLink = "http://marvel.com/movies/movie/223/avengers_infinity_war",
                    LastShowDate = new DateTime(2018, 12, 31),
                    ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/avengers_infinity_war_poster.jpg&alt=img/movie_placeholder.png"
                },
                new Movie {
                    Id = 4,
                    Name = "Bankier van het Verzet",
                    YearOfRelease = 2018,
                    LengthInMinutes = 123,
                    SpokenLanguage = "Nederlands",
                    Genre = "Oorlog/Thriller",
                    MinimumAge = 12,
                    ShortDescription = "Als bankier Walraven van Hall (Barry Atsma) in de Tweede Wereldoorlog wordt gevraagd of hij zijn financiële contacten voor het verzet wil inzetten, aarzelt hij niet lang. Samen met zijn broer, Gijs van Hall (Jacob Derwig), bedenkt hij een riskante constructie om grote leningen af te sluiten waarmee het verzet gefinancierd kan worden. Als ook dat niet genoeg is bedenken de broers de grootste bankfraude uit de Nederlandse geschiedenis: tientallen miljoenen guldens worden onder het oog van de bezetters de Nederlandse Bank uit gesluisd. Maar hoe grootschaliger de operatie wordt, hoe meer mensen er vanaf weten. Iedere dag neemt de kans toe dat iemand dat ene foutje maakt dat een einde kan maken aan de daden en het leven van het bankier van het verzet. Bankier van het Verzet is het waargebeurde, onbekende verhaal van Nederlands grootste verzetsheld.",
                    Director = "Joram Lürsen",
                    Trailer = "https://www.youtube.com/embed/eg5El9N03Fs",
                    Imdb = "https://www.imdb.com/title/tt4610378/",
                    LastShowDate = new DateTime(2018, 10, 31),
                    ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/47043546_93278.jpg&alt=img/movie_placeholder.png"
                },
                new Movie {
                    Id = 5,
                    Name = "Tomb Raider",
                    YearOfRelease = 2018,
                    LengthInMinutes = 118,
                    SpokenLanguage = "Engels",
                    Genre = "Actie/Avontuur",
                    MinimumAge = 12,
                    ShortDescription = "Lara Croft is de pittige, onafhankelijke dochter van een excentrieke avonturier die spoorloos verdween toen Lara nog een tiener was. Nu is ze een jonge vrouw van 21 en heeft ze nog geen echt doel in haar leven. Om de huur te kunnen betalen, scheurt ze als fietskoerier door een hippe wijk in Londen en volgt ze cursussen, waar ze maar zelden verschijnt. Ze weigert de leiding te nemen over haar vaders imperium omdat ze haar eigen weg wil uitstippelen. Ook omdat ze niet wil geloven dat hij dood is. Ondanks het feit dat iedereen haar aanraadt de feiten te accepteren en door te gaan met haar leven, besluit Lara het raadsel van zijn mysterieuze dood op te lossen. Lara laat alles en iedereen achter en gaat naar de laatst bekende bestemming van haar vader, een graftombe op een mythisch eiland ergens voor de kust van Japan. Maar het wordt geen makkelijke missie. Alleen de reis naar het eiland toe is al een hachelijke onderneming. Gewapend met slechts haar scherpe verstand, blind vertrouwen en doorzettingsvermogen, moet Lara tot het uiterste gaan tijdens haar reis naar het grote onbekende. Als ze dit avontuur overleeft, zal ze naam maken als de tomb raider.",
                    SubtitleLanguage = "Nederlands",
                    Director = "Roar Uthaug",
                    Trailer = "https://www.youtube.com/embed/RpidFcE-20I",
                    Imdb = "https://www.imdb.com/title/tt1365519/",
                    LastShowDate = new DateTime(2018, 9, 30),
                    ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Tomb-Raider_ps_1_jpg_sd-low_%C2%A9-2017-Warner-Bros-Ent-All-Rights-Reserved.jpg&alt=img/movie_placeholder.png"
                },
                new Movie {
                    Id = 6,
                    Name = "Buurman en Buurman bouwen een huis",
                    YearOfRelease = 2018,
                    LengthInMinutes = 57,
                    SpokenLanguage = "Nederlands",
                    Genre = "Kinderfilm",
                    MinimumAge = 0,
                    ShortDescription = "Buurman & Buurman zijn terug met nieuwe avonturen. In Buurman & Buurman bouwen een huis bedenken de populaire Buurmannen nieuwe briljante oplossingen voor de alledaagse problemen waar zij tegen aanlopen. De twee klunzige vrienden proberen een nieuwe grasmaaier aan de praat te krijgen en een mol te verjagen uit de tuin. En wie anders dan de Buurmannen kunnen een nieuwe keuken aanleggen en daarbij de badkamer volledig in puin leggen? Buurman & Buurman helpen elkaar door dik en dun en krijgen uiteindelijk alles voor elkaar. Aje To!",
                    Director = "Marek Besem",
                    Trailer = "https://www.youtube.com/watch?v=d26ZnTccb6g",
                    Imdb = "https://www.imdb.com/title/tt8007250/",
                    LastShowDate = new DateTime(2018, 10, 31),
                    ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/37091117_94684.jpg&alt=img/movie_placeholder.png"
                }
            );

            context.Rooms.AddOrUpdate(
                r => r.Name,
                room6
            );

            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 1, MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(13), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 2, MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(13), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 3, MovieId = 2, RoomId = 3, Start = DateTime.Today.AddHours(13), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 4, MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(16), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 5, MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(16), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 6, MovieId = 4, RoomId = 3, Start = DateTime.Today.AddHours(16), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 7, MovieId = 6, RoomId = 4, Start = DateTime.Today.AddHours(16), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 8, MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(20), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 9, MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(20), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 10, MovieId = 3, RoomId = 3, Start = DateTime.Today.AddHours(20), Is3D = true });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 11, MovieId = 4, RoomId = 4, Start = DateTime.Today.AddHours(20), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 12, MovieId = 5, RoomId = 5, Start = DateTime.Today.AddHours(20), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 13, MovieId = 6, RoomId = 6, Start = DateTime.Today.AddHours(20), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 14, MovieId = 1, RoomId = 1, Start = DateTime.Today.AddHours(23), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 15, MovieId = 2, RoomId = 2, Start = DateTime.Today.AddHours(23), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 16, MovieId = 3, RoomId = 3, Start = DateTime.Today.AddHours(23), Is3D = true });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 17, MovieId = 4, RoomId = 4, Start = DateTime.Today.AddHours(23), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 18, MovieId = 5, RoomId = 5, Start = DateTime.Today.AddHours(23), Is3D = false });
            context.Showings.AddOrUpdate(s => s.Id, new Showing { Id = 19, MovieId = 6, RoomId = 6, Start = DateTime.Today.AddHours(23), Is3D = false });


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
