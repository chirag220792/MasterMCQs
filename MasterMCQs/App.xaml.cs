using MasterMCQs.Models;
using MasterMCQs.Services;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterMCQs
{
    public partial class App : Application
    {
        public static Game CurrentGame { get; private set; }

        HomePage homePage;

        static Uri JsonQuestionsUri
        {
            get
            {
                return new Uri("https://www.dropbox.com/s/racrgjrsq2xcwdu/questions.json?raw=1");
            }
        }

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(homePage = new HomePage());

            DependencyService.Register<NavigationService>();
        }

        protected override async void OnStart()
        {
            var fileHelper = DependencyService.Get<IFileHelper>();

            string questionsText;

                var assembly = typeof(App).GetTypeInfo().Assembly;
                using (var stream = assembly.GetManifestResourceStream("MasterMCQs.Data.questions.json"))
                {
                    questionsText = new StreamReader(stream).ReadToEnd();
                }

            var questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(questionsText);

            CurrentGame = new Game(questions);

            homePage.IsStartButtonEnabled = true;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
