using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Microsoft.Adal;
using Java.Lang;

namespace hellotest
{
	[Activity (Label = "hellotest", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string TAG = "MainActivity";
		// AAD PARAMETERS
		// https://login.windows.net/tenantInfo
		const string AUTHORITY_URL = "https://login.windows.net/omercantest.onmicrosoft.com";
		// Clientid is given from AAD page when you register your Android app
		const string CLIENT_ID = "650a6609-5463-4bc4-b7c6-19df7990a8bc";
		// RedirectUri
		const string REDIRECT_URL = "http://taskapp";
		// URI for the resource. You need to setup this resource at AAD
		const string RESOURCE_ID = "https://omercantest.onmicrosoft.com/AllHandsTry";
		static string USER_HINT = "";
		// Endpoint we are targeting for the deployed WebAPI service
		const string SERVICE_URL = "https://android.azurewebsites.net/api/values";
		int count = 1;
		AuthenticationContext mAuthContext;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				mAuthContext.AcquireToken (this, RESOURCE_ID, CLIENT_ID,
					REDIRECT_URL, USER_HINT, new TestCallback (this)
				);

			};

			DefaultTokenCacheStore cache = new DefaultTokenCacheStore (this);
			mAuthContext = new AuthenticationContext (this, AUTHORITY_URL,
				false, cache);


		}

		protected override void OnActivityResult (int requestCode, [GeneratedEnum] Result resultCode, Intent data)
		{
			mAuthContext.OnActivityResult (requestCode, (int)resultCode, data);
		}

		class TestCallback :Java.Lang.Object, IAuthenticationCallback
		{
			Context context;

			public TestCallback(Context ctx){
				context = ctx;
			}

			public void OnError (Java.Lang.Exception exc)
			{
				AlertDialog.Builder builder = new AlertDialog.Builder (context);
				builder.SetTitle ("Error");
				builder.SetMessage (exc.Message);
				builder.Create ().Show ();
			}

			public void OnSuccess (Java.Lang.Object result)
			{
				Logger.D (TAG, "Success:");
				AuthenticationResult aresult = result.JavaCast<AuthenticationResult> ();
				if (aresult != null) {
					Logger.V (TAG, "token:" + (aresult.AccessToken));
                    			AlertDialog.Builder builder = new AlertDialog.Builder(context);
                    			builder.SetMessage(aresult.AccessToken);
                    			builder.SetTitle(aresult.ExpiresOn.ToString());
                    			builder.Create().Show();
				}
			}
		}
	}
}


