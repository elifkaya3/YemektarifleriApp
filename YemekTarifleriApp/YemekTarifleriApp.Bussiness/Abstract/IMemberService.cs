using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Bussiness.Abstract
{
    public interface IMemberService
    {
        Member GetById(int id);
        List<Member> GetAll();
        void Create(Member entity);
        void Update(Member entity);
        void Delete(Member entity);
        void Create(Member entity, int[] memberIds);
        void Update(Member entity, int[] memberIds);
    }
}
