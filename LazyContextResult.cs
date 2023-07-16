using System;
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
    public class LazyContextResult
    {
        public async Task<ActionResult<T>> Execute<T>(Func<Task<T>> action)
            => await Execute<T, Exception>(action);
        public async Task<ActionResult<T>> Execute<T, TException>(Func<Task<T>> action) where TException : Exception
        {
            try
            {
                T value = await action();
                return new ActionResult<T>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        public ActionResult<T> Execute<T>(Func<T> action)
            => Execute<T, Exception>(action, out Exception exception);
        public ActionResult<T> Execute<T, TException>(Func<T> action, out TException exception) where TException : Exception
        {
            try
            {
                T value = action();
                return new ActionResult<T>(value, false, (exception = default(TException))?.Message);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, (exception = ex).Message);
            }
        }
        public async Task<ActionResult<T>> Execute<T>(Func<Task<List<T>>> action)
            => await Execute<T, Exception>(action);
        public async Task<ActionResult<T>> Execute<T, TException>(Func<Task<List<T>>> action) where TException : Exception
        {
            try
            {
                IEnumerable<T> list = await action();
                return new ActionResult<T>(list);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        public async Task<ActionResult<T>> Execute<T>(Func<Task<IEnumerable<T>>> action)
            => await Execute<T, Exception>(action);
        public async Task<ActionResult<T>> Execute<T, TException>(Func<Task<IEnumerable<T>>> action) where TException : Exception
        {
            try
            {
                IEnumerable<T> list = await action();
                return new ActionResult<T>(list);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        public ActionResult<T> Execute<T>(Func<IEnumerable<T>> action)
            => Execute<T, Exception>(action, out Exception exception);
        public ActionResult<T> Execute<T, TException>(Func<IEnumerable<T>> action, out TException exception) where TException : Exception
        {
            try
            {
                IEnumerable<T> list = action();
                return new ActionResult<T>(list, false, (exception = default(TException))?.Message);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, (exception = ex).Message);
            }
        }
    }
}
