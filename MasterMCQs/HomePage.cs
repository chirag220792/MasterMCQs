﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using MasterMCQs.Services;
using Xamarin.Forms;

namespace MasterMCQs
{
    public class HomePage : ContentPage
    {
        public bool IsStartButtonEnabled
        {
            get { return button.IsEnabled; }
            set { button.IsEnabled = value; }
        }
        Button button;

        public HomePage()
        {
            var layout = new AbsoluteLayout();

            Content = layout;

            button = new Button()
            {
                Text = "Start eXam!",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#0892d0"),
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                IsEnabled = false,
            };

            var bg = new Image();
            bg.Source = ImageSource.FromResource("eXam.Images.background.jpg");
            bg.Aspect = Aspect.AspectFill;

            layout.Children.Add(bg, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);

            layout.Children.Add(button, new Rectangle(0.5, 0.5, 200, 60), AbsoluteLayoutFlags.PositionProportional);

            NavigationPage.SetHasNavigationBar(this, false);

            button.Clicked += OnStartClicked;
        }

        async void OnStartClicked(object sender, EventArgs e)
        {
            var nav = DependencyService.Get<NavigationService>();
            if (nav != null)
                await nav.GotoPageAsync(AppPage.QuestionPage);
        }
    }

}