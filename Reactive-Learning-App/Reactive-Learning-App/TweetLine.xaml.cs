﻿using System;
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
using ReactiveUI;

namespace Reactive_Learning_App
{
    /// <summary>
    /// Interaction logic for TweetLine.xaml
    /// </summary>
    public partial class TweetLine : IViewFor<TweetViewModel>
    {
        public TweetLine()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                //d(this.OneWayBind(ViewModel, vm => vm.TweetText, v => v.TweetText.Text));
                d(this.OneWayBind(ViewModel, vm => vm.User, v => v.User.Content));
                d(this.OneWayBind(ViewModel, vm => vm.UserProfileImageUrl, v => v.UserImage.Source));
            });
        }

        public static readonly DependencyProperty ViewModelProperty;

        static TweetLine()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(TweetViewModel), typeof(TweetLine));
        }

        public TweetViewModel ViewModel
        {
            get { return (TweetViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (TweetViewModel)value; }
        }
    }
}
