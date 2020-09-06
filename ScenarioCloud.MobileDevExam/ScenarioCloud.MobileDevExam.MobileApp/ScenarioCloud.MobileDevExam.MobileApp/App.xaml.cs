using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScenarioCloud.MobileDevExam.MobileApp.Services;
using ScenarioCloud.MobileDevExam.MobileApp.Views;

namespace ScenarioCloud.MobileDevExam.MobileApp
{
  public partial class App : Application
  {

    public App()
    {
      InitializeComponent();

      DependencyService.Register<MockDataStore>();
      MainPage = new MainPage();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
