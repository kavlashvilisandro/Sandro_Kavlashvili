namespace PracticalTask.MiddleWares
{
    public class UnHandledExceptionHandlerMiddleWare
    {
public static Dictionary<Exception, DateTime> exceptions = new Dictionary<Exception , DateTime>();
        private readonly RequestDelegate _next;
        public UnHandledExceptionHandlerMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            _next.Invoke(context);
            await CheckErrors();
        }

        public async Task CheckErrors()
        {
            for(int i = 0; i < exceptions.Count; i++)
            {
                await LogExceptions(i);
            }
        }

        public async Task LogExceptions(int index)
        {
            File.AppendAllText("Errors.txt", $"error Message: " +
                $"{exceptions.ElementAt(index).Key.Message}\n" +
                $"Time: {exceptions[exceptions.ElementAt(index).Key].ToString()}\n");
            exceptions.Remove(exceptions.ElementAt(index).Key);
        }

        
    }
}
