using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuseumWeb.Model
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public int FrameNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}