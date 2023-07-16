﻿using System;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!
* Owners: Liiksoft
* Create by Luis Eduardo Cochachi Chamorro
* License: MIT or Apache-2.0
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!*/
namespace Vaetech.Data.LazyContext
{
    public class LazyContext<TContext1,TContext2, TContext3, TContext4> : LazyContextResult
        where TContext1 : class 
        where TContext2 : class
        where TContext3 : class
        where TContext4 : class
    {
        readonly Lazy<TContext1> __context1;
        readonly Func<TContext1> __contextFactory1;
        readonly Lazy<TContext2> __context2;
        readonly Func<TContext2> __contextFactory2;
        readonly Lazy<TContext3> __context3;
        readonly Func<TContext3> __contextFactory3;
        readonly Lazy<TContext4> __context4;
        readonly Func<TContext4> __contextFactory4;
        public LazyContext(Func<TContext1> contextFactory1, Func<TContext2> contextFactory2, Func<TContext3> contextFactory3, Func<TContext4> contextFactory4)
        {
            __contextFactory1 = contextFactory1;
            __context1 = new Lazy<TContext1>(contextFactory1);
            __contextFactory2 = contextFactory2;
            __context2 = new Lazy<TContext2>(contextFactory2);
            __contextFactory3 = contextFactory3;
            __context3 = new Lazy<TContext3>(contextFactory3);
            __contextFactory4 = contextFactory4;
            __context4 = new Lazy<TContext4>(contextFactory4);
        }
        public TContext GetContext<TContext>() where TContext : class
        {
            if(typeof(TContext) == typeof(TContext1))
                return (TContext)(object) __context1.Value;
            else if(typeof(TContext) == typeof(TContext2))
                return (TContext)(object)__context2.Value;
            else if (typeof(TContext) == typeof(TContext3))
                return (TContext)(object)__context3.Value;
            else if (typeof(TContext) == typeof(TContext4))
                return (TContext)(object)__context4.Value;

            throw new Exception($"DbContext {typeof(TContext)?.Name} does not exist.");
        }
        public TContext NewContext<TContext>() where TContext : class
        {
            if (typeof(TContext) == typeof(TContext1))
                return (TContext)(object) new Lazy<TContext1>(__contextFactory1).Value;
            else if (typeof(TContext) == typeof(TContext2))
                return (TContext)(object)new Lazy<TContext2>(__contextFactory2).Value;
            else if (typeof(TContext) == typeof(TContext3))
                return (TContext)(object)new Lazy<TContext3>(__contextFactory3).Value;
            else if (typeof(TContext) == typeof(TContext4))
                return (TContext)(object)new Lazy<TContext4>(__contextFactory4).Value;

            throw new Exception($"DbContext {typeof(TContext)?.Name} does not exist.");
        }
    }
}
