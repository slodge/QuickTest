using Cirrious.MvvmCross.ViewModels;

namespace Quick.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private bool _show1;
        public bool Show1 
        {   
            get { return _show1; }
            set { _show1 = value; RaisePropertyChanged(() => Show1); }
        }

        private bool _show2;
        public bool Show2 
        {   
            get { return _show2; }
            set { _show2 = value; RaisePropertyChanged(() => Show2); }
        }
    }
}
