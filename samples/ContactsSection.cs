using Android.Views;
using AndroidX.RecyclerView.Widget;
using IO.Github.Luizgrp.Sectionedrecyclerviewadapter;
using System.Collections.Generic;

namespace FeaturesDemo
{
    public partial class MainActivity
    {
        private class ContactsSection : Section
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
    }
}