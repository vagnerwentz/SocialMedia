# SocialMedia

## .NET Microservices: CQRS & Event Sourcing with Kafka

### What is a Command?
A Command, is a combination of expressed intent. In other words it describes an action that you want to be performed. 
It also contains the information that is required to undertake the desired action.

Commands are always named with a **verb** in the imperative mood.
For example: *NewPostCommand, LikePostCommand, AddCommentCommand*

### What is an Event?
Events are objects that describe something that has occured in the application. A typical source of events is the aggregate.
When somenthing important happens in the aggregate, it will raise an event

Events are named with a **past-participle** verb.
For example: *PosCreatedEvent, PostLikedEvent, CommentAddedEvent*
