## GPS Code Test

 

We would like you to refactor the GPS.CodingTest Solution. It contains a Notification API that will receive notifications of different types. Each notification type needs to be received and processed separately. There is also a class library and a unit test project included in the solution.

 

---

 

### What we expect? ###

 

- Refactor the send Notification endpoint and any services it uses, keep in mind what design patterns 
- Complete the implementation of the EmailNotificationMessage
- Review the Status endpoint and think how you would redesign (implementation not essential)
- Add as many units test as you like

 

When refactoring you should take into account SOLID principles, maintainability and testing.

 

You can add any framework(s) / NuGet packages of your choice to improve the code.  We are not expecting the work to be finished, feel free to include an explanation and any further improvements you would make.



### Refactoring

1. I would separate email from SMS functionality completely so that they can evolve separately if they need to. Super-generic handling and sharing of models and classes is not very extendible. I would have separate controller methods, even separate controllers. 
2. Make sure that all service classes are injected into other classes that use it to make it more testable - dependency injection and inversion of control.
3. Separate the status end point into its own controller for good separation of functionality.
4. Add any services to the start-up routine as transient services.
5. For the status class and method: consider making a singleton service and eliminating any static methods and variables. This has a limitation to one single instance of the API and it will have to be redesigned if it is scaled up.
6. Rename `class1.cs` to appropriate name after the class that it hosts.
7. Put more appropriate `required` data annotations on the members of the `NotificationEvent` class. You can also test these in a test.
8. The `INotificationMessage` interface doesn't belong in the Models folder.
9. Make controller methods either properly `async` or just take the `async` away for the time being because it is confusing.
10. The service classes: `SmsNotificationMessage`, `INotificationMessage` and `EmailNotificationMessage` belong in the Services folder. They also have confusing names, rename appropriately.

