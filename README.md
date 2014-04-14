#Windows Azure Active Directory Binding Example for Objective-C for Xamarin


This sample shows how to build a Xamarin binding to our native ADAL for iOS library. This sample was created for //BUILD 2014 and is not to be used in production. We plan on adding a true cross platform mapping layer in the future. For those interested in binding to our iOS library in .Net using Xamarin, this code is a good guide and will build a bindling.dll file for your Xamarin for iOS project for use with Xamarin.

##### NOTE 

In the future we will update this sample to include other ADAL libraries, such as Android, as well as create a more robust mapping layer. At the moment, we are using the binding file directly to allow Xamarin developers on iOS to use our library. 

###**CALL FOR PARTICIPATION** 

We would love to get the Xamarin community involvement to help with the following:

* Create a binding for ADAL for Android

* Create a mapping layer between the binding files for iOS and Android to make the library useful to Xamarin developers regardless of platform they are building for.

Thanks - @brandwe

## Quick Start

###Step 0: Learn about binding objective-c libraries with Xamarin

* You'll get up to speed faster if you do some reading of the Xamarin documentation for iOS Binding to native libraries located here: [Binding Objective-C Libraries](http://docs.xamarin.com/guides/ios/advanced_topics/binding_objective-c/binding_objc_libs/)

* Finally, you may want to read through how Xamarin works with Objective-C here: [Xamarin for Objective-C Developers](http://docs.xamarin.com/guides/ios/advanced_topics/xamarin_for_objc/)


### Step 1: Download Xamarin Studio

You can get [Xamarin Studio](http://xamarin.com/studio?_bt=44014804148&_bk=xamarin%20studio&_bm=e&gclid=COqr3sHrs70CFUWVfgodkmEAwg) from the Xamarin website.

### Step 2: Create a "iOS Binding" Project in Xamarin Studio

Select File -> New -> Solution and select "iOS Binding Project"

### Step 3: Clone this code in to your Project directory

Go to the directory where you created your new project and clone the files in this repostiory. You will then need to add these files in to Xamarin Studio by clicking on your project tree and selecting "Add Files.." in the pulldown. 

###### NOTE

The names of the files in this repository should match closely the default files that are included in the iOS Binding project for Xamarin. This will aid you in replacing the files or code with the correct files from our repository.

### Step 3: Add the latest version of ADAL for iOS library to the Project

You will need to bind to **libADALiOS.a** in your Xamarin Studio iOS Binding project as discissed in [Binding Objective-C Libraries](http://docs.xamarin.com/guides/ios/advanced_topics/binding_objective-c/binding_objc_libs/). The easiest way to do this is to grab the latest ADAL for iOS and compile the source.

You can get the latest ADAL for iOS library here: https://github.com/MSOpenTech/azure-activedirectory-library-for-ios


### Step 4: Run and use!

Run the project and then pull the .dll files out of the /bin directory Xamarin Studio will create.

