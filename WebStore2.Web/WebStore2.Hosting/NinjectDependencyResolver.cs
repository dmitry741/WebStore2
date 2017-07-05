using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;

namespace WebStore2.Hosting
{
    public class NinjectDepKernel
    {
        IKernel m_kernel;

        void AddBinding()
        {
            m_kernel.Bind<Services.Services.Base.IDataBaseEngine>().To<Services.Services.DataBaseEngine>();
            m_kernel.Bind<IDiscountHelper>().To<FirstDiscountHelper>().WithConstructorArgument("discount", 3);
        }

        public IKernel GetKernel()
        {
            return m_kernel;
        }

        public NinjectDepKernel(IKernel kernel)
        {
            m_kernel = kernel;
            AddBinding();
        }
    }
}