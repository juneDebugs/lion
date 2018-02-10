﻿using System;
using System.Collections.Generic;
using System.Linq;
using lion.Models;
using lion.Pages;
using Xamarin.Forms;

namespace lion.Views
{
    public partial class HomeView : TabbedPage
    {
        void Handle_Activated(object sender, System.EventArgs e)
        {
            DisplayAlert("Post new message", "Post new message", "OK");
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var feedDetails = e.SelectedItem as FeedDetails;
            await Navigation.PushAsync(new PostsDetailsPage(feedDetails));
            listViewFeed.SelectedItem = null;
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            listViewFeed.ItemsSource = GetPosts(e.NewTextValue);
        }


        IEnumerable<FeedDetails> GetPosts(string searchText = null)
        {
            //Call to a remote service, placeholder for now
            var posts = new List<FeedDetails>{
                new FeedDetails {
                    Post = "And the only way to do great work is to love what you do. ",
                    UserUrl = "https://lion.blob.core.windows.net/pic1/pic1.jpeg",
                    Status= "replies"},
                new FeedDetails {
                    Post = "And the only way to do great work is to love what you do. ",
                    UserUrl = "https://lion.blob.core.windows.net/pic2/pic2.jpeg",
                    Status= "replies" }
            };

            if (String.IsNullOrWhiteSpace(searchText))
                return posts;


            return posts.Where(x => x.Post.StartsWith(searchText));
        }

        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            listViewFeed.ItemsSource = GetPosts();

            listViewFeed.EndRefresh();
        }

        public HomeView()
        {
            InitializeComponent();

            listViewFeed.ItemsSource = GetPosts();
        }

    }
}
