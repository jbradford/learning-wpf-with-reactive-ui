// ReSharper disable once CheckNamespace
namespace ReactiveUI
{
    public static class ReactiveCommandExtensions
    {
        /// <summary>
        /// Executes a <see cref="IReactiveCommand" /> with a null parameter.
        /// </summary>
        /// <param name="command">The <see cref="IReactiveCommand"/> to execute.</param>
        public static void Execute(this IReactiveCommand command)
        {
            command.Execute(null);
        }
    }
}
