using System;

// I use this import for Debug.WriteLine(); I use this to output rather than Console.WriteLine() because
// code in the AppLogic project cannot use Console.WriteLine() and I want all (or at least most) of my code to
// use the same method to debug (just in case the IDE treats the output differently between the
// two methods)
using System.Diagnostics;

using Gtk;

using AppLogic;
using System.IO;

namespace AppView
{
	/// <summary>
	/// The view part of the Model-View-Controller architecture implemented in KeyboardCode.
	/// 
	/// When an event occurs on the View, the user interface, it sends that event to the Controller.
	/// The Controller decides what it wants the Model, the application logic, to do; and it invokes
	/// that action.
	/// The Model will do that action and change the View, the user interface, accordingly.
	/// FOR MORE INFORMATION ON MVC, SEE README.MD (ALL CAPS)
	/// </summary>
	public class View : IView
	{
		/// <summary>
		/// The controller that this view will send messages to in response to events on the
		/// user interface
		/// </summary>
		private IController controller;

		/// <summary>
		/// The object in charge of actually managing the user interface
		/// </summary>
		private MainWindow window;

		/// <summary>
		/// Starts the app; in other words, displays the user interfaces and sends an
		/// event to the controller to initialize the application
		/// </summary>
		public void Start()
		{
            // This line of code needs to be commented out on Linux
            CheckWindowsGtk();
			Application.Init ();

			// The MainWindow class contains the actual user interface code
			window = new MainWindow (controller);
			window.Start ();

			Application.Run ();
		}

        /*
         * I got this code (the code that configures the DLL directory) from 
         * https://forums.xamarin.com/discussion/15568/unable-to-load-dll-libgtk-win32-2-0-0-dll
         * For some reason, there was an issue in my GTK# installation that
         * was not letting a particular DLL to be found.
         */

        /// <summary>
        /// An external function that adds a new directory to look for
        /// DLLs in to the ones that the application currently has 
        /// </summary>
        /// <param name="lpPathName">The path of the new directory</param>
        /// <returns>Returns true on success, false on failure</returns>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);

        /// <summary>
        /// If this app is running on a WINDOWS system that had previously had GTK# installations,
        /// there may be a problem not being able to load a DLL; this method
        /// will resolve that issue. It was found here:
        /// https://forums.xamarin.com/discussion/15568/unable-to-load-dll-libgtk-win32-2-0-0-dll
        /// </summary>
        /// <returns>Whether or not the new directory to search for DLLs in was set properly</returns>
        static bool CheckWindowsGtk()
        {
            string location = null;
            Version version = null;
            Version minVersion = new Version(2, 12, 30);
            using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Xamarin\GtkSharp\InstallFolder"))
            {
                if (key != null)
                    location = key.GetValue(null) as string;
            }
            using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Xamarin\GtkSharp\Version"))
            {
                if (key != null)
                    Version.TryParse(key.GetValue(null) as string, out version);
            }
            //TODO: check build version of GTK# dlls in GAC
            if (version == null || version < minVersion || location == null || !File.Exists(Path.Combine(location, "bin", "libgtk-win32-2.0-0.dll")))
            {
                Console.WriteLine("Did not find required GTK# installation");
                //  string url = "http://monodevelop.com/Download";
                //  string caption = "Fatal Error";
                //  string message =
                //      "{0} did not find the required version of GTK#. Please click OK to open the download page, where " +
                //      "you can download and install the latest version.";
                //  if (DisplayWindowsOkCancelMessage (
                //      string.Format (message, BrandingService.ApplicationName, url), caption)
                //  ) {
                //      Process.Start (url);
                //  }
                return false;
            }
            Console.WriteLine(version.ToString());
            Console.WriteLine(location);
            Console.WriteLine("Found GTK# version " + version);
            var path = Path.Combine(location, @"bin");
            Console.WriteLine("SetDllDirectory(\"{0}\") ", path);
            try
            {
                if (SetDllDirectory(path))
                {
                    return true;
                }
            }
            catch (EntryPointNotFoundException)
            {
            }
            // this shouldn't happen unless something is weird in Windows
            Console.WriteLine("Unable to set GTK+ dll directory");
            return true;
        }

        /// <summary>
        /// Configures the view to send events that happen on the user interface to the given
        /// controller. The reason why the controller is not configured
        /// in the view's constructor is because there is a circular dependency with
        /// the view needing a controller, the controller needing a model, and the model needing
        /// a view; we need to create all of the objects first and then supply them with the 
        /// other component that they need.
        /// </summary>
        /// <param name="controller">The controller to manipulate</param>
        public void SetController(IController controller)
		{
			this.controller = controller;
		}

		/// <summary>
		/// A method to use when testing if the IView is working properly or just to
		/// see if the architecture works. As of right now, it just outputs text to the console
		/// </summary>
		public void Test()
		{
			Console.WriteLine ("Testing view");
			controller.Test ();
		}

		/*
		 * The following methods will be invoked by the Controller as part of the Model-View-Controller
		 * architecture.
		 * 
		 * THESE METHODS ARE THE PART OF THE MODEL THAT WILL UPDATE THE VIEW.
 		 */

        /// <summary>
        /// Makes the focus of the window the text box where the user types actions
        /// </summary>
        public void FocusOnActionTextBox()
		{
			Console.WriteLine ("View told to focus on action text area");
			window.Focus = window.ActionTextView;
		}
	}
}


