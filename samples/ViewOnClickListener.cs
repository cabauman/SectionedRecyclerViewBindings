using Android.App;
using Android.Views;
using Android.Widget;

namespace FeaturesDemo
{
    public partial class MainActivity
    {
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

    }
}