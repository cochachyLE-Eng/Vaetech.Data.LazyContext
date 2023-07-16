using System;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!
* Owners: Liiksoft
* Create by Luis Eduardo Cochachi Chamorro
* License: MIT or Apache-2.0
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!*/
namespace Vaetech.Data.LazyContext
{
    public class LazyContext<TContext> : LazyContextResult where TContext : class
    {
        readonly Lazy<TContext> __context;
        readonly Func<TContext> __contextFactory;
        public LazyContext(Func<TContext> contextFactory)
        {
            __contextFactory = contextFactory;
            __context = new Lazy<TContext>(contextFactory);
        }
        public TContext GetContext() => __context.Value;
        public TContext NewContext() => new Lazy<TContext>(__contextFactory).Value;        
    }
}
