The attached project is an API that is fictionally used in production at Coles to get waves of orders to stores to be picked.

You can get a list of waves, a wave by id, as well as insert/update a wave



Refactor this API to make it readable, maintainable, and testable.

Please highlight your change by committing to a local repository and sending back the whole directory zipped (all relevant solution files + the .git folder)

Please do not spend more than 3 hours on this exercise. The goal is to understand HOW you code.


-----------------------------------------------------

Moving to logic controller for better readability, maintainability, separation of concerns is better for future modifications. It would be easy to apply attributes as well.

Implemented ILogger for logging.

Implemented Global Exception Handling using IExceptionHandler

Implemented JWT Authentication and scope based authorization for write

Choosing EFCore as it is small API and as it uses SQLite.This goes Code-first database approach.
I have used repository pattern to separate business logic and data access.

I havent chose CQRS as it is a small API project and has only one method of upsert




