﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteUWP_Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DBInstanceContext())
            {
                lv1.ItemsSource = db.Blogs.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DBInstanceContext())
            {
                var blog = new Blog() { Url = blogUriTbx.Text };
                db.Blogs.Add(blog);
                db.SaveChanges();
                lv1.ItemsSource = db.Blogs.ToList();
            }
        }
    }
}
