using Domain.Shared.Entities;
using Domain.Requested.Models;
using Domain.Shared.Enumerators;

    namespace Domain.Requester.Models {
        public class Date : Entity {
            public string Name { get; private set; }
            public string Title { get; private set; }
            public EStatus Status { get; private set; }
            public string Contact { get; private set; }
            public DateTime Schedule { get; private set; }
            public string Latitude { get; private set; }
            public string Longitude { get; private set; }
            public string Description { get; private set; }
            public EDisplacement Displacement { get; private set; }
            public decimal Contribution { get; private set; }

                public Guid ProspectId { get; private set; }
                public Prospect? Prospect { get; private set; }

                    public Date(
                        string name,
                        string title,
                        EStatus status,
                        string contact,
                        DateTime schedule,
                        string latitude,
                        string longitude,
                        string description,
                        EDisplacement displacement,
                        decimal contribution,
                        Guid prospectId
                    ) {
                        this.Name = name;
                        this.Title = title;
                        this.Status = status;
                        this.Contact = contact;
                        this.Schedule = schedule;
                        this.Latitude = latitude;
                        this.Longitude = longitude;
                        this.Description = description;
                        this.Displacement = displacement;
                        this.Contribution = contribution;
                        this.ProspectId = prospectId;
                    }
                    public void Update(
                        string name,
                        string title,
                        EStatus status,
                        string contact,
                        DateTime schedule,
                        string latitude,
                        string longitude,
                        string description,
                        EDisplacement displacement,
                        decimal contribution,
                        Guid prospectId
                    ) {
                        this.Name = name;
                        this.Title = title;
                        this.Status = status;
                        this.Contact = contact;
                        this.Schedule = schedule;
                        this.Latitude = latitude;
                        this.Longitude = longitude;
                        this.Description = description;
                        this.Displacement = displacement;
                        this.Contribution = contribution;
                        this.ProspectId = prospectId;
                    }
        }
    }