using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        /// <summary>
        /// Metod çalışmadan önce
        /// </summary>
        /// <param name="ınvocation"></param>
        protected virtual void OnBefore(IInvocation invocation)
        { }

        /// <summary>
        /// Metod çalıştıktan sonra
        /// </summary>
        /// <param name="ınvocation"></param>
        protected virtual void OnAfter(IInvocation invocation)
        { }

        /// <summary>
        ///  Hata (Exception) alındığında
        /// </summary>
        /// <param name="ınvocation"></param>
        protected virtual void OnException(IInvocation invocation, Exception e)
        { }

        /// <summary>
        /// İşlem başarılı olduğunda
        /// </summary>
        /// <param name="ınvocation"></param>
        protected virtual void OnSuccess(IInvocation invocation)
        { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); //metodu çalıştır.
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}