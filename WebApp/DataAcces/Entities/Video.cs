﻿namespace WebApp.DataAcces.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UploadLink { get; set; }
        public int UserId { get; set; }
    }
}
