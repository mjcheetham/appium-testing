using System;

namespace Mjcheetham.AppiumTesting.AppModel
{
    public abstract class Page<TApp> where TApp : IApp
    {
        protected TApp App { get; }

        protected Page(TApp app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            this.App = app;
        }
    }
}
