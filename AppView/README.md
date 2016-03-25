KeyboardCode
=========================================

AppView
------------------------------
This project contains the view, the user interface that the user interacts with, of Keyboard Code.

EntryPoint.cs is the entry point into the application; it is where code execution is started.
Most of the code executed in the KeyboardCode source code (not necessarily in the GTK# source
code, though) can be traced back to having been caused by a method call in the entry point,
EntryPoint.cs
// TODO: add descriptions about class structure


Model-View-Controller Implementation in the Source Code
---------------------------------

The Model-View-Controller design pattern is a way to structure your code so that it is easy to
change the app's behavior and to increase code reuse. It consists of three parts: the model, view,
and controller.

The view is the user interface of the app. It is the part that the user will interact with. When an
event occurs on the view (radio button click, text typed, etc.), the view will send that event to
the controller. The controller's job is to decide what that event means and how the app should respond.
Once it decides what to do with the event, it invokes the appropriate action on the model. The model is
the application's logic; it is the "brains" of the program. The controller will tell the model what it needs
to be done, and the model will do it. The model will change what the view shows according to what the controller
has told it do to.

****How is it implemented in the source code?****

In this app, the model and controller are contained in the AppLogic project. There is a folder for
the model and a folder for the controller. The model, view, and controller are all defined in 
interface that other code can implement, so that we can switch out a model, view, or controller if we need to with minimal code change.

The AppLogic project contains the model and controller; and as of right now, the AppView project contains the view. However, in the future,
the view may be split between several projects (one view for Mac OS X, one view for Windows, etc.).