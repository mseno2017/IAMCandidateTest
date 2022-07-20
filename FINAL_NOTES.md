# Final Notes
* There are lots of improvements available to make the architecture scalable and robust but below are just simple examples that would satisfy the requirements.
* In my development environment I am using .Net 5 but this should be compatible with .Net 6 as well
* UI uses HttpClient to call APIs. 
* UI layout and functionality remains the same as it mentioned in the instructions no need to recreate.
* I would use the MVC design pattern to 
* Implemented Web API to replace the direct database calls and so data is available in any platforms
* For logging I would use NLog
* I will keep swagger to test API end points and use for getting any other pertinent information about the API
* For security I would use Identity Security
* In the example I am using Entity Framework code first but I would also recommend to use Dapper in some scenarios. Dapper performs better than entity framework as experienced.

