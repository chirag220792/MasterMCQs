using System;
using System.Collections.Generic;
using MasterMCQs.ViewModel;
using Xamarin.Forms;

namespace MasterMCQs
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage(ReviewPageViewModel rpvm)
        {
            InitializeComponent();

            BindingContext = rpvm;

            listQuestions.ItemTapped += OnListItemTapped;
        }

        void OnListItemTapped(object sender, ItemTappedEventArgs e)
        {
            var qqvm = (QuizQuestionViewModel)e.Item;

            if (qqvm != null)
                this.DisplayAlert("Explanation", qqvm.Explanation, "OK");
        }
    }
}