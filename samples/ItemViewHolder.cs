using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace FeaturesDemo
{
    public partial class MainActivity
    {
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