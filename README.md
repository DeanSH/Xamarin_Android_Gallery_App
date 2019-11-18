# Xamarin_Android_Gallery_App
Xamarin Android basic Art Gallery app solution which also includes a C# Self Host API Server to act as the middle man between the Android app and a MS SQL Server Local DB File ".mdf" containing test data, All API interactions are Async &amp; demonstrates full CRUD interaction &amp; builds page views using C# instead of XMAL. 

Screenshot of both the Self Host API Server running, and Gallery Android App side by side locally has been provided where you can also see the Database connection where its linked to the MDF file, and solution Files and projects. 

## NOTES:
This has been originally created in Visual studio 2017 for trying out Xamarin Cross-platform app development as part of a course I studied towards my BIT, while other students developed the Art Gallery mobile app using UWP (Universal Windows Platform) with its inbuilt visual designer I decided to challenge myself and out of curiousity try development using the newer Xamarin added in VS 2015 originally.

I have now updated it to work in Visual Studio 2019, and included the SelfHostAPI Server project and MDF example local database file with test data to completely get the Android app functional.

This has been built using code design patterns in an object orientated manner with a MVC style architecture, and instead of using XMAL to build the visual elements I experimented with using the C# code base to design pages which actually worked out pretty good and only required a simple method to help with the grid layout for pages to add elements to.

## HOW TO USE:
Before you open the solution you should already have the VS Android Emulator installed & setup working, and any Android versions you require for testing, this solution targets Level 28 with a minimum Level 16, if you have never Emulated android in VS before i recommend watching this you tube video - https://www.youtube.com/watch?v=lVpflX_6h4A

After you first open this project you will need to connect to the database file, open server explorer and connect create a new data connection, select the SQL Server Local DB type, then browse to the "Gallery_Data.mdf" file inside the first SelfHostApiServer folder, for authentication just leave it as Windows Authentication, test connection and it should be successful, then finish and done, in server explorer you should now see it and be able to view the tables, or data on tables, etc.

Next, Click the Gallery_Data data connection and view the properties to get the full file path to where it is located on you computer, copy the full path and then inside Solution Explorer goto the "Gallery3SelfHost" project and open the App.config file, there you will see the Gallery Database connection string, replace the filepath section of the connection string to point to the file on your computer by pasting the full path you copied previously but keep the "\Gallery_Data.mdf" part of the path on the end still!

Now save the changes to the Solution.

Before the Self Host API Server can successfully run error free, you need to enable the port access for your computer and user logged in with using CMD or PowerShell to execute these commands:

-> whoami
This will give your computer-name\user-name for the system your using the Self Host API server on! Next run...

-> netsh http add urlacl url=http://+:PPPPP/ user=computer-name\user-name
This will allow the Self Host API server to listen and accept connections for the specified PORT (PPPPP) and Computer/Username! So be sure to replace the PPPPP with the desired port (currently port 60064 for this example) and the computer-name\user-name you got from running whoiam.

Eg -> netsh http add urlacl url=http://+:60064/ user=deans-pc\r4
It should work fine and say it was successful!!

Lastly, before you can run and test the Self Host API server, you should goto the Gallery_Data data connection inside the Server Explorer window of VS, and right click it and close connection if active, this will prevent any connection error inside the Self Host API Server when it trys to access the MDF file in response to API calls from the Android App.

Now you are ready to try it out!! Right click the "Gallery3SelfHost" project and select Debug->Run New Instance. This will start a copy of the Self Host API Server in a command line looking window on screen saying it is now listening!

Next to launch the Android App, show the solution explorer in Visual Studio, and right click the "App5_2018.Android" project and again select Debug->Run New Instance. It will launch the Android emulator, compile the Android art gallery app and run it inside the emulator to try out, and if successful to connect with the API server display a list of Artists for the gallery.

If you got this far, well done!!

## TO MODIFY
If going to use this for anything other than an example to learn from, you might change the Port and run the CMD command again, serviceclient class in the Android app file contains the API calls where you can add more, modify them, change the API server addressing to an external IP if want, or the port etc. Could easily set this up to connect to other Database types, and start building a Xamarin Android application! Enjoy.
