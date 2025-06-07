using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared
{
    // Data transfer object for Room
    public record RoomDto(
     // Unique identifier for the room

     int RoomId,

     // Room number (required)
     [Required]
     string RoomNumber,

     // Price of the room (required)
     [Required]
     decimal Price,

     // Type of bed in the room (required)
     [Required]
     string BedType,

     bool Isavailable
);
}
