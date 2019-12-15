using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }

        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {
            CheckIfMemberExists(member);

            CheckIfUserValidFromKps(member);

            _memberDal.Add(member);
        }

        private void CheckIfMemberExists(Member member)
        {
            if (_memberDal.Get(c => c.TcNo == member.TcNo) != null)
            {
                throw new Exception("Bu kulanici daha once kayit olmustur !");
            }
        }

        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("Kulanici dogrulamasi gecerli degil !");
            }
        }
    }
}
