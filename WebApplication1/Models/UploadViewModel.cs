using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UploadViewModel
    {

        [Required]
        public int RoomId { get; set; }
        [Required]
        public IFormFile File { get; set; }

    }
}
