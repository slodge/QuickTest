using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Quick.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;
			   
            _label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(_label);
            var sw1 = new UISwitch(new RectangleF(10, 50, 300, 40));
            Add(sw1);
            var sw2 = new UISwitch(new RectangleF(10, 90, 300, 40));
            Add(sw2);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(sw2).To(vm => vm.Show2);
            set.Bind(sw1).To(vm => vm.Show1);
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
        private UILabel _label;

        public bool Change2
        {
            get { return _change2; }
            set { _change2 = value; UpdateText(); }
        }

        private void UpdateText()
        {
            _label.Text = string.Format("Vals: {0} {1}", _change1, _change2);
        }
    }
}
