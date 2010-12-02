using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F5_MoneyPacificSite.Models;
using F5_MoneyPacificSite.Models.BUS;
using F5_MoneyPacificSite.ViewModels;

namespace F5_MoneyPacificSite.Controllers
{
    public class AgentController : Controller
    {
        //
        // GET: /Agent/
        public ActionResult Index()
        {
            return RedirectToAction("Browse");
        }
        //
        // GET: /Agent/Browse
        public ActionResult Browse()
        {
            var model = new AgentListViewModel
            {
                agents = AgentBUS.GetList(),
                agentStates = AgentStateBUS.GetList(),
                DeleteId = 0
            };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            bool bSuccess = AgentBUS.Remove(id);
            var model = new AgentListViewModel
            {
                agents = AgentBUS.GetList(),
                agentStates = AgentStateBUS.GetList(),
                DeleteId = id
            };

            return Json(model);
        }

        //
        // GET: /Agent/Edit
        
        
        public ActionResult Edit(int id)
        {
            var model = new AgentEditViewModel
            {
                existAgent = AgentBUS.GetItem(id),
                agentStates = AgentStateBUS.GetList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AgentEditViewModel obj)
        {
            bool bSuccess = AgentBUS.Update(obj.existAgent);

            if (bSuccess == true)
            {
                return RedirectToAction("Browse");
            }
            else
            {

                ViewData["message"] = "There is an error!...";
                obj.agentStates = AgentStateBUS.GetList();
                return View(obj);
            }
        }

        //
        // GET: /Agent/Detail
        public ActionResult Details(int id)
        {
            Agent model = AgentBUS.GetItem(id);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new AgentCreateViewModel
            {
                newAgent = new Agent(),
                agentStates = AgentStateBUS.GetList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(AgentCreateViewModel model)
        {
            Agent newAgent = new Agent();
            newAgent.Username = model.newAgent.Username;
            newAgent.Password = model.newAgent.Password;
            newAgent.StatusId = model.newAgent.StatusId;
            newAgent.FistName = model.newAgent.FistName;
            newAgent.LastName = model.newAgent.LastName;
            newAgent.Address = model.newAgent.Address;
            newAgent.Phone = model.newAgent.Phone;
            newAgent.Email = model.newAgent.Email;
            newAgent.Comment = model.newAgent.Comment;

            bool bSuccess = AgentBUS.AdđItem(newAgent);

            if (bSuccess == true)
                return RedirectToAction("Browse");

            return View(model);
        }
    }
}
