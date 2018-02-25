﻿using System;
using System.Collections.Generic;
using lion.Controls;
using Xamarin.Forms;

namespace lion.Pages
{
    public partial class FeedAddPostModalPage : ContentPage
    {

        async void OnCanceled_Clicked(object sender, System.EventArgs e)
        {
            var homeView = new ContentPage();

            await Navigation.PushModalAsync(new NavigationPage(new Pages.LionTabbedPage()));
        }

		public FeedAddPostModalPage()
		{
			InitializeComponent();

            BindingContext = Application.Current;
		}
    }
}