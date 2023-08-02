using Domain.Shared.Entities;
using Domain.Requester.Models;

    namespace Domain.Requested.Models {
        public class Prospect : Entity {
            public string Name { get; private set; }
            public decimal Goal { get; private set; }
            public bool Active { get; private set; }
            public string Contact { get; private set; }
            public string Biography { get; private set; }
            public bool Available { get; private set; }
            public DateOnly Birth { get; private set; }
            public string Picture { get; private set; }

                private readonly List<Date> _dates = new List<Date>();
                public IReadOnlyCollection<Date> Dates  =>  _dates;
                public void NewDate(Date date)  =>  _dates.Add(date);

                    public Prospect(
                        string name,
                        decimal goal,
                        bool active,
                        string contact,
                        string biography,
                        bool available,
                        DateOnly birth,
                        string picture
                    ) {
                        this.Name = name;
                        this.Goal = goal;
                        this.Active = active;
                        this.Contact = contact;
                        this.Biography = biography;
                        this.Available = available;
                        this.Birth = birth;
                        this.Picture = picture;
                    }
                    public void Update(
                        string name,
                        decimal goal,
                        bool active,
                        string contact,
                        string biography,
                        bool available,
                        DateOnly birth,
                        string picture
                    ) {
                        this.Name = name;
                        this.Goal = goal;
                        this.Active = active;
                        this.Contact = contact;
                        this.Biography = biography;
                        this.Available = available;
                        this.Birth = birth;
                        this.Picture = picture;
                    }
        }
    }