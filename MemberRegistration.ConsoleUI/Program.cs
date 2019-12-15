using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependecyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMemberService memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member { FirstName = "Iman", LastName = "Huseynlı", DateOfBirth = new DateTime(1995, 01, 28), TcNo = "99741146214", Email = "iman012895@gmail.com" });
            Console.WriteLine("Eklendi...");
            Console.ReadLine();
        }
    }
}
