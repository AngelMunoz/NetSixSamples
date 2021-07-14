using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

namespace Newish
{
    public record Todo(int id, string title, bool isDone);
    public static class Todos
    {
        /// obviously this is not how you should do this, but it's a demo
        private static List<Todo> _todos = new List<Todo>();
        private static Func<IEnumerable<Todo>> GetTodos =
            () => _todos;
        private static Func<Todo, bool> AddTodo =
            todo => { _todos.Add(todo); return true; };

        public static WebApplication RegisterTodoRoutes(this WebApplication app)
        {
            app.MapGet("/todos", GetTodos);
            app.MapPost("/todos", AddTodo);
            return app;
        }

    }
}
