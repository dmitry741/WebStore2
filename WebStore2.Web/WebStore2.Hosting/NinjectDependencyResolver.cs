using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;

namespace WebStore2.Hosting
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel m_kernel;

        void AddBinding()
        {
            m_kernel.Bind<Services.Services.Base.IDataBaseEngine>().To<Services.Services.DataBaseEngine>();
            m_kernel.Bind<IDiscountHelper>().To<FirstDiscountHelper>();
        }

        public IKernel GetKernel()
        {
            return m_kernel;
        }

        public NinjectDependencyResolver(IKernel kernel)
        {
            m_kernel = kernel;
            AddBinding();
        }

        public object GetService(Type st)
        {
            return m_kernel.TryGet(st);
        }

        public IEnumerable<object> GetServices(Type st)
        {
            return m_kernel.GetAll(st);
        }
    }
}