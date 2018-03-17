using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using IO.Github.Luizgrp.Sectionedrecyclerviewadapter;
using System.Collections.Generic;

namespace FeaturesDemo
{
    [Activity(Label = "Features Demo", MainLauncher = true, Icon = "@mipmap/icon",
        Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class MainActivity : Activity
    {
        private static SectionedRecyclerViewAdapter _sectionAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

            _sectionAdapter = new SectionedRecyclerViewAdapter();

            for(char alphabet = 'A'; alphabet <= 'Z'; alphabet++)
            {
                List<string> contacts = GetContactsWithLetter(alphabet);

                if(contacts.Count > 0)
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


        private class ContactsSection : StatelessSection
        {
            private string _title;
            List<string> _list;

            public ContactsSection(string title, List<string> list)
                : base(SectionParameters.InvokeBuilder()
                    .ItemResourceId(Resource.Layout.Item_RecyclerView)
                    .HeaderResourceId(Resource.Layout.Header_RecyclerView)
                    .Build())
            {
                _title = title;
                _list = list;
            }

            public override int ContentItemsTotal => _list.Count;

            public override RecyclerView.ViewHolder GetItemViewHolder(View view)
            {
                return new ItemViewHolder(view);
            }

            public override void OnBindItemViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var itemHolder = (ItemViewHolder)holder;

                string name = _list[position];

                itemHolder.TvItem.Text = name;
                itemHolder.ImgItem.SetImageResource(name.GetHashCode() % 2 == 0 ? Resource.Drawable.ic_face_black_48dp : Resource.Drawable.ic_tag_faces_black_48dp);

                itemHolder.RootView.SetOnClickListener(new ViewOnClickListener(itemHolder, _title));
            }

            public override RecyclerView.ViewHolder GetHeaderViewHolder(View view)
            {
                return new HeaderViewHolder(view);
            }

            public override void OnBindHeaderViewHolder(RecyclerView.ViewHolder holder)
            {
                HeaderViewHolder headerHolder = (HeaderViewHolder)holder;

                headerHolder.TvTitle.Text = _title;
            }
        }


        public class ViewOnClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private ItemViewHolder _itemHolder;
            private string _sectionTitle;

            public ViewOnClickListener(ItemViewHolder itemHolder, string sectionTitle)
            {
                this._itemHolder = itemHolder;
                this._sectionTitle = sectionTitle;
            }

            public void OnClick(View v)
            {
                var posInSection = _sectionAdapter.GetPositionInSection(_itemHolder.AdapterPosition);
                Toast.MakeText(
                    Application.Context,
                    string.Format("Clicked on position #{0} of Section {1}", posInSection, _sectionTitle),
                    ToastLength.Short)
                        .Show();
            }
        }


        class HeaderViewHolder : RecyclerView.ViewHolder
        {
            public HeaderViewHolder(View view)
                : base(view)
            {
                TvTitle = view.FindViewById<TextView>(Resource.Id.tvTitle);
            }

            public TextView TvTitle { get; }
        }


        public class ItemViewHolder : RecyclerView.ViewHolder
        {
            public ItemViewHolder(View view)
                : base(view)
            {
                RootView = view;
                ImgItem = view.FindViewById<ImageView>(Resource.Id.imgItem);
                TvItem = view.FindViewById<TextView>(Resource.Id.tvItem);
            }

            public View RootView { get; }

            public ImageView ImgItem { get; }

            public TextView TvItem { get; }
        }

    }
}