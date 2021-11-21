using System;

namespace Vaetech.Data.LazyContext
{
    public abstract class LazyContext<TContext1,TContext2> 
        where TContext1 : class 
        where TContext2 : class
    {
        readonly Lazy<TContext1> __context1;
        readonly Func<TContext1> __contextFactory1;
        readonly Lazy<TContext2> __context2;
        readonly Func<TContext2> __contextFactory2;
        public LazyContext(Func<TContext1> contextFactory1, Func<TContext2> contextFactory2)
        {
            __contextFactory1 = contextFactory1;
            __context1 = new Lazy<TContext1>(contextFactory1);
            __contextFactory2 = contextFactory2;
            __context2 = new Lazy<TContext2>(contextFactory2);
        }
        public TContext GetContext<TContext>() where TContext:TContext1,TContext2
        {
            if(typeof(TContext) == typeof(TContext1))
                return (TContext)(object) __context1.Value;
            else if(typeof(TContext) == typeof(TContext2))
                return (TContext)(object)__context2.Value;

            return default(TContext);
        }
        public TContext NewContext<TContext>()where TContext: TContext1,TContext2
        {
            if (typeof(TContext) == typeof(TContext1))
                return (TContext)(object) new Lazy<TContext1>(__contextFactory1).Value;
            else if (typeof(TContext) == typeof(TContext2))
                return (TContext)(object)new Lazy<TContext2>(__contextFactory2).Value;

            return default(TContext);
        }
    }
}
