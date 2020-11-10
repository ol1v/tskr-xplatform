﻿using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Environment = System.Environment;

namespace Taskerino.Android
{
    [Activity(Label = "Taskerino", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            string fileName = "tasks_db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(fileLocation, fileName);
            
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(fullPath));
        }
    }
}