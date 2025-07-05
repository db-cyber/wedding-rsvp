using MongoDB.Bson.Serialization.Attributes;

namespace WeddingRSVP.Models
{
    public class GuestRsvp
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("first_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? FirstName {  get; set; }

        [BsonElement("last_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? LastName { get; set; }

        [BsonElement("phone_number"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? PhoneNumber { get; set; }

        [BsonElement("dietary_requirements"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? DietaryRequirements {  get; set; }

        [BsonElement("notes"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Notes { get; set; }

        [BsonElement("is_attending"), BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool IsAttending {  get; set; }
    }
}
