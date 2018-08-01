using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Memories.Models
{
  public class MemoryImage
  {
    [Key]
    public int ImageId { get; set; }

    [Required]
    public string Title { get; set; }
    [DisplayName("Upload File")]
    public string ImagePath { get; set; }
    [NotMapped]
    public HttpPostedFileBase ImageFile { get; set; }

  }
}
