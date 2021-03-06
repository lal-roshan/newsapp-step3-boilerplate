﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    /// <summary>
    /// This class will be acting as the data model for the News Table in the database.
    /// </summary>
    public class News
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedAt { get; set; }

        [ForeignKey("User")]
        public string CreatedBy { get; set; }

        public UserProfile User { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }
    }
}
