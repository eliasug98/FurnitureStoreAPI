namespace FurnitureStoreProject.API.DTOs.MessageDTOs
{
    public class CreateMessageDto
    {
        public string Content { get; set; }
        public int? UserId { get; set; } // (opcional)
    }
}
