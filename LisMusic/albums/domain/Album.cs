﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LisMusic.albums.domain
{
    public class Album
    {
        public string idAlbum { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string publication { get; set; }
        public string recordCompany { get; set; }
        public int idMusicGender { get; set; }
        public string genderName { get; set; }
        public int idAlbumType { get; set; }
        public string artistName { get; set; }
        public BitmapImage coverImage { get; set; }

        public Album(string idAlbum, string title, string cover, string publication, string recordCompany, int idMusicGender, int idAlbumType, string artistName, BitmapImage coverImage)
        {
            this.idAlbum = idAlbum;
            this.title = title;
            this.cover = cover;
            this.publication = publication;
            this.recordCompany = recordCompany;
            this.idMusicGender = idMusicGender;
            this.idAlbumType = idAlbumType;
            this.artistName = artistName;
            this.coverImage = coverImage;
        }

        public Album() { }
    }
  
}
