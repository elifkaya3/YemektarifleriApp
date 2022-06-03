



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Data.Abstract
{
    public interface IMemberRepository:IRepository<Member>
    {
        void Create(Member entity, int[] memberIds);
        void Update(Member entity, int[] memberIds);
    }
}
