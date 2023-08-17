using Domain.Shared.Entities;
using Domain.Requester.Models;
using Domain.Shared.ValueObjects;

    namespace Domain.Requested.Models {
        public class Prospect : Entity {
            public string Name { get; private set; }
            public decimal Goal { get; private set; }
            public string Contact { get; private set; }
            public string Biography { get; private set; }
            public Situation Status { get; private set; }
            public DateOnly Birth { get; private set; }
            public string Picture { get; private set; }

                private readonly List<Date> _dates = new List<Date>();
                public IReadOnlyCollection<Date> Dates  =>  _dates;
                public void NewDate(Date date)  =>  _dates.Add(date);

                    private Prospect(
                        string name,
                        decimal goal,
                        string contact,
                        string biography,
                        DateOnly birth,
                        string picture
                    ) {
                        this.Name = name;
                        this.Goal = goal;
                        this.Contact = contact;
                        this.Biography = biography;
                        this.Birth = birth;
                        this.Picture = picture;
                    }
                    public Prospect(
                        string name,
                        decimal goal,
                        string contact,
                        string biography,
                        Situation status,
                        DateOnly birth,
                        string picture
                    ) {
                        this.Name = name;
                        this.Goal = goal;
                        this.Contact = contact;
                        this.Biography = biography;
                        this.Status = status;
                        this.Birth = birth;
                        this.Picture = picture;
                    }
                    public void Update(
                        string name,
                        decimal goal,
                        string contact,
                        string biography,
                        Situation status,
                        DateOnly birth,
                        string picture
                    ) {
                        this.Name = name;
                        this.Goal = goal;
                        this.Contact = contact;
                        this.Biography = biography;
                        this.Status = status;
                        this.Birth = birth;
                        this.Picture = picture;
                    }
        }
    }