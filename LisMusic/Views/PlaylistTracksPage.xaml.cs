﻿using LisMusic.player;
using LisMusic.playlists;
using LisMusic.playlists.domain;
using LisMusic.tracks;
using LisMusic.tracks.domain;
using LisMusic.Utils;
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
            var template = ListView_tracks_album.ItemsPanel;
            



        }

        public async void LoadTracks()
        {
            try
            {
                tracks = await TrackRepository.GetTracksPlaylist(playlist.idPlaylist);
                foreach (var track in tracks)
                {
                    track.indexRow = tracks.IndexOf(track) + 1;
                }
                ListView_tracks_album.ItemsSource = tracks;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void ListView_tracks_album_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Track track = (Track)ListView_tracks_album.SelectedValue;
            if(track != null)
            {
                var result = await Player.UploadTrackAsync(track);
                if (result)
                {
                    SingletonMainWindows.GetSingletonWindow().UpdateInfoPlayer(track);
                }
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Button_add_queue_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Track track = button.DataContext as Track;
            Player.AddTrackToQueue(track);
        }

        private void Button_generate_radio_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Track track = button.DataContext as Track;
            GenerateRadio(track);
        }

        private async void GenerateRadio(Track track)
        {
            try
            {
                var tracks = await TrackRepository.GetRadioTrack(track);
                Player.AddListTracksToQueue(tracks);
                MessageBox.Show("Radio station generated: " +track.album.musicGender.genderName);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void Button_remove_playlist_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Track track = button.DataContext as Track;
            try
            {
                if (await PlaylistRepository.RemoveTrack(track.idTrack, this.playlist.idPlaylist))
                {
                    MessageBox.Show("Removed to playlist");
                    LoadTracks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_play_tracks_Click(object sender, RoutedEventArgs e)
        {
            Track.PlayListTracks(this.tracks);
        }
    }
}
