using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace FeaturesDemo
{
    public partial class MainActivity
    {
        class HeaderViewHolder : RecyclerView.ViewHolder
        {
            public HeaderViewHolder(View view)
                : base(view)
            {
                TvTitle = view.FindViewById<TextView>(Resource.Id.tvTitle);
            }

            public TextView TvTitle { get; }
        }

    }
}