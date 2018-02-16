﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace lion.Pages
{
    public partial class MyPostsPage : ContentPage
    {
        public MyPostsPage()
        {
            InitializeComponent();

            var myPosts = new List<string>
            {
                "Jordan",
                "Rose",
                "Bob"
            };

            MyPostsListView.ItemsSource = myPosts;
        }
    }
}
