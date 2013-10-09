using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;
using Quick.Core.ViewModels;

namespace Quick.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        private TextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            _textView = FindViewById<TextView>(Resource.Id.life);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(this).For("Change1").To("Show1");
            set.Bind(this).For("Change2").To("Show2");
            set.Apply();
        }

        private bool _change1;
        public bool Change1
        {
            get { return _change1; }
            set { _change1 = value; UpdateText(); }
        }

        private bool _change2;
        public bool Change2
        {
            get { return _change2; }
            set { _change2 = value; UpdateText(); }
        }

        private void UpdateText()
        {
            _textView.Text = string.Format("Vals: {0} {1}", _change1, _change2);
        }
    }
}