using Android.App;
using Android.OS;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using IO.Github.Luizgrp.Sectionedrecyclerviewadapter;

namespace FeaturesDemo
{
    [Activity(Label = "Features Demo", MainLauncher = true, Icon = "@mipmap/icon",
        Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public partial class MainActivity : Activity
    {
        private static SectionedRecyclerViewAdapter _sectionAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

            _sectionAdapter = new SectionedRecyclerViewAdapter();

            for (char alphabet = 'A'; alphabet <= 'Z'; alphabet++)
            {
                List<string> contacts = GetContactsWithLetter(alphabet);

                if (contacts.Count > 0)
                {
                    _sectionAdapter.AddSection(new ContactsSection(alphabet.ToString(), contacts));
                }
            }

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerview);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.SetAdapter(_sectionAdapter);
        }

        private List<string> GetContactsWithLetter(char letter)
        {
            List<string> contacts = new List<string>();

            foreach(var contact in Resources.GetStringArray(Resource.Array.names))
            {
                if(contact[0] == letter)
                {
                    contacts.Add(contact);
                }
            }

            return contacts;
        }
    }
}