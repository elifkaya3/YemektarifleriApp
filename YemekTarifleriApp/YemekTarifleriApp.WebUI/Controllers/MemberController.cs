using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Bussiness.Abstract;

namespace YemekTarifleriApp.WebUI.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            return View(_memberService.GetAll());
        }
       
    }
}
