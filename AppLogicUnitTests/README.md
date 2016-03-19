KeyboardCode
=========================================

AppLogicUnitTests
------------------------------

This project contains unit tests for the AppLogic project, the Model of the Model-View-Controller pattern
implemented in KeyboardCode.

Most tests are done through the command line.

The TestView class is used as a "dummy" view to do tests with instead of having the actual view.

The Start class is the entry point into this project (it contains the Main method).


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
the model and a folder for the controller. Both the model and the controller are each defined in an
interface that other code can implement, so that we can switch out a model or controller (or view, for
that matter) if we need to with minimal code change.