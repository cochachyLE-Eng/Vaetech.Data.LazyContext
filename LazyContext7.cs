using System;

namespace Vaetech.Data.LazyContext
{
    public abstract class LazyContext<TContext1,TContext2, TContext3, TContext4, TContext5, TContext6, TContext7> 
        where TContext1 : class 
        where TContext2 : class
        where TContext3 : class
        where TContext4 : class
        where TContext5 : class
        where TContext6 : class
        where TContext7 : class
    {
        readonly Lazy<TContext1> __context1;
        readonly Func<TContext1> __contextFactory1;
        readonly Lazy<TContext2> __context2;
        readonly Func<TContext2> __contextFactory2;
        readonly Lazy<TContext3> __context3;
        readonly Func<TContext3> __contextFactory3;
        readonly Lazy<TContext4> __context4;
        readonly Func<TContext4> __contextFactory4;
        readonly Lazy<TContext5> __context5;
        readonly Func<TContext5> __contextFactory5;
        readonly Lazy<TContext6> __context6;
        readonly Func<TContext6> __contextFactory6;
        readonly Lazy<TContext7> __context7;
        readonly Func<TContext7> __contextFactory7;
        public LazyContext(
            Func<TContext1> contextFactory1, 
            Func<TContext2> contextFactory2, 
            Func<TContext3> contextFactory3, 
            Func<TContext4> contextFactory4,
            Func<TContext5> contextFactory5,
            Func<TContext6> contextFactory6,
            Func<TContext7> contextFactory7)
        {
            __contextFactory1 = contextFactory1;
            __context1 = new Lazy<TContext1>(contextFactory1);
            __contextFactory2 = contextFactory2;
            __context2 = new Lazy<TContext2>(contextFactory2);
            __contextFactory3 = contextFactory3;
            __context3 = new Lazy<TContext3>(contextFactory3);
            __contextFactory4 = contextFactory4;
            __context4 = new Lazy<TContext4>(contextFactory4);
            __contextFactory5 = contextFactory5;
            __context5 = new Lazy<TContext5>(contextFactory5);
            __contextFactory6 = contextFactory6;
            __context6 = new Lazy<TContext6>(contextFactory6);
            __contextFactory7 = contextFactory7;
            __context7 = new Lazy<TContext7>(contextFactory7);
        }
        public TContext GetContext<TContext>() where TContext:TContext1,TContext2,TContext3,TContext4,TContext5,TContext6,TContext7
        {
            if(typeof(TContext) == typeof(TContext1))
                return (TContext)(object) __context1.Value;
            else if(typeof(TContext) == typeof(TContext2))
                return (TContext)(object)__context2.Value;
            else if (typeof(TContext) == typeof(TContext3))
                return (TContext)(object)__context3.Value;
            else if (typeof(TContext) == typeof(TContext4))
                return (TContext)(object)__context4.Value;
            else if (typeof(TContext) == typeof(TContext5))
                return (TContext)(object)__context5.Value;
            else if (typeof(TContext) == typeof(TContext6))
                return (TContext)(object)__context6.Value;
            else if (typeof(TContext) == typeof(TContext7))
                return (TContext)(object)__context7.Value;

            throw new Exception($"DbContext {typeof(TContext)?.Name} does not exist.");
        }
        public TContext NewContext<TContext>()where TContext: TContext1,TContext2,TContext3,TContext4,TContext5,TContext6,TContext7
        {
            if (typeof(TContext) == typeof(TContext1))
                return (TContext)(object) new Lazy<TContext1>(__contextFactory1).Value;
            else if (typeof(TContext) == typeof(TContext2))
                return (TContext)(object)new Lazy<TContext2>(__contextFactory2).Value;
            else if (typeof(TContext) == typeof(TContext3))
                return (TContext)(object)new Lazy<TContext3>(__contextFactory3).Value;
            else if (typeof(TContext) == typeof(TContext4))
                return (TContext)(object)new Lazy<TContext4>(__contextFactory4).Value;
            else if (typeof(TContext) == typeof(TContext5))
                return (TContext)(object)new Lazy<TContext5>(__contextFactory5).Value;
            else if (typeof(TContext) == typeof(TContext6))
                return (TContext)(object)new Lazy<TContext6>(__contextFactory6).Value;
            else if (typeof(TContext) == typeof(TContext7))
                return (TContext)(object)new Lazy<TContext7>(__contextFactory7).Value;

            throw new Exception($"DbContext {typeof(TContext)?.Name} does not exist.");
        }
    }
}
