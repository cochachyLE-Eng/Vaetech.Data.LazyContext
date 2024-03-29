﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!
* Owners: Liiksoft
* Create by Luis Eduardo Cochachi Chamorro
* License: MIT or Apache-2.0
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!*/
namespace Vaetech.Data.LazyContext
{
    public class LazyContext<TContext1,TContext2> : LazyContextResult
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
        public TContext GetContext<TContext>() where TContext : class
        {
            if(typeof(TContext) == typeof(TContext1))
                return (TContext)(object) __context1.Value;
            else if(typeof(TContext) == typeof(TContext2))
                return (TContext)(object)__context2.Value;

            throw new Exception($"DbContext {typeof(TContext)?.Name} does not exist.");
        }
        public TContext NewContext<TContext>() where TContext : class
        {
            if (typeof(TContext) == typeof(TContext1))
                return (TContext)(object) new Lazy<TContext1>(__contextFactory1).Value;
            else if (typeof(TContext) == typeof(TContext2))
                return (TContext)(object)new Lazy<TContext2>(__contextFactory2).Value;

            throw new Exception($"DbContext {typeof(TContext)?.Name} does not exist.");
        }        
    }
}
