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