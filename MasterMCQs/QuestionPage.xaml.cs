using System;
using System.Collections.Generic;
using MasterMCQs.ViewModel;
using Xamarin.Forms;

namespace MasterMCQs
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }

        public QuestionPage(QuestionPageViewModel qpvm)
        {
            InitializeComponent();

            this.BindingContext = qpvm;
        }
    }
}

