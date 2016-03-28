KeyboardCode
====================================================

AppLogic
--------------------------------

The AppLogic project contains the main logic behind the application. In other words, AppLogic is the brain
and the other projects are the skin and outer appearance.

AppLogic is a portable class library (PCL) that projects like AppUI and AppLogicUnitTests reference and invoke.

This project is the Model and Controller of the Model-View-Controller pattern that KeyboardCode implements.

Code that references this library will only interact with the Controller object, except for when they initialize
a Model object with a class in that project that implements IView and will pass that Model as an argument
to the Controller.

Any utilities that the other code uses (or miscellaneous classes/interfaces/enumerations) are contained in the
"Utilities" folder.


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