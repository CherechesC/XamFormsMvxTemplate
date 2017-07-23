using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platform;
using Xamarin.Forms;

namespace $safeprojectname$
{
    [Activity(Label = "FormsApplicationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FormsApplicationActivity : MvxFormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            UserDialogs.Init(this);

            var app = new MvxFormsApplication();
            var presenter = Mvx.Resolve<IMvxAndroidViewPresenter>() as IMvxFormsPagePresenter;
            presenter.FormsApplication = app;

            LoadApplication(app);

            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}