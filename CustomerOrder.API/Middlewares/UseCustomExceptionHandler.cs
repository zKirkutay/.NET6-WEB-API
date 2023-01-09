namespace CustomerOrder.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<GeneralExceptionHandlingMiddleware>();
        }
    }
}
