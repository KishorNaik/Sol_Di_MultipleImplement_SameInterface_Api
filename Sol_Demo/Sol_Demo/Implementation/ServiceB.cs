using Sol_Demo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Implementation
{
    public class ServiceB : IService
    {
        string IService.DoWork()
        {
            return "Service B";
        }
    }
}
