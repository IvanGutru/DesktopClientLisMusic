﻿using LisMusic.playlists.domain;
using LisMusic.tracks;
using LisMusic.tracks.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LisMusic.Views
{
    /// <summary>
    /// Interaction logic for PlaylistTracksPage.xaml
    /// </summary>
    public partial class PlaylistTracksPage : Page
    {
        List<Track> tracks;
        Playlist playlist;
        public PlaylistTracksPage(Playlist playlist)
        {
            InitializeComponent();
            this.playlist = playlist;
            TextBlock_playlist_name.Text = playlist.title;
            TextBlock_owner.Text = playlist.owner;
            Image_cover_playlist.Source = playlist.coverImage;
          
            LoadTracks();

         
        }

        public async void LoadTracks()
        {
            tracks = await TrackRepository.GetTracksPlaylist(playlist.idPlaylist);
            foreach (var track in tracks)
            {
                track.indexRow = tracks.IndexOf(track) + 1;
            }
            ListView_tracks_album.ItemsSource = tracks;
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
