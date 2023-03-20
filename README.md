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

### What is an Aggregate?
The aggregate can be viewed as the domain entity on the write or command side of a
CQRS and Event Sourcing based application or service, similar to the domain entity that you find on the read or query side.
When you create the Aggregate class, you will see that it is difficult at first glance to view the aggregate as a domain entity,
because unlike the domain entity on the read sidem it is not simple plain old C# object that contains only state and no behaviour.

IMPORTANT - The fundamentals differences in its structure is due to the fundamental
differences in how the data is stored in the write database ir event store vs how it is stored in the read database.

The read side is simple one instance of the domain entity represents one record in the read database.

The write side is more complex, because there we store the data as a sequence of immutable events over time. In other words, we store all the state changes
and we save these state changes in the form of events that are versioned.

The design of the aggregate should therefore allow you to be able to use these events to recreate or replay the latest state of the Aggregate,
so that you do not have to query the read database for the latest state, else the hard separation of commands and queries would be in vain.
