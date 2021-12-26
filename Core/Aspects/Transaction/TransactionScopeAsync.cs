using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Transaction
{
  public  class TransactionScopeAsync:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope=new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    if (invocation.ReturnValue is Task returnValueTask)
                    {
                        returnValueTask.GetAwaiter().GetResult();
                    }

                    if (invocation.ReturnValue is Task task &&  task.Exception!=null)
                    {
                        throw task.Exception;
                    }
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw ;
                }
            }
            base.Intercept(invocation);
        }
    }
}
