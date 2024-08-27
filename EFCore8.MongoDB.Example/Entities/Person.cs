using EFCore8.MongoDB.Example.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace EFCore8.MongoDB.Example.Entities
{
    #region MongoDB.Driver
    //public class Person
    //{
    //    [BsonId]
    //    [BsonElement(Order = 0)]
    //    public ObjectId Id { get; set; }

    //    [BsonRepresentation(BsonType.String)]
    //    [BsonElement(Order = 1)]
    //    public string? Name { get; set; }

    //    [BsonRepresentation(BsonType.String)]
    //    [BsonElement(Order = 2)]
    //    public string? Surname { get; set; }

    //    [BsonRepresentation(BsonType.Int64)]
    //    [BsonElement(Order = 3)]
    //    public int? Age { get; set; }

    //    public static implicit operator Person(PersonVM personVM)
    //        => new()
    //        {
    //            Name = personVM.Name,
    //            Surname = personVM.Surname,
    //            Age = personVM.Age,
    //        };
    //}
    #endregion

    #region MongoDB Entity Framework Core Provider
    public class Person
    {
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }

        public static implicit operator Person(PersonVM personVM)
            => new()
            {
                Name = personVM.Name,
                Surname = personVM.Surname,
                Age = personVM.Age,
            };
    }
    #endregion

}
