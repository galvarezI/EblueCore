using EblueWorkPlan.Models;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Microsoft.CodeAnalysis;
using Microsoft.Build.Execution;
using Rotativa.AspNetCore;
using Microsoft.Build.Evaluation;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net;
using AspNetCore.Reporting;
using System.Security.Policy;
using EblueWorkPlan.Services;

namespace EblueWorkPlan.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly WorkplandbContext _context;
        private readonly PermissionService permissionService;
        private readonly PermissionAccessService _accessService;
        private List<SelectListItem> _rosterItems;
        private List<SelectListItem> _departmentsItems;
        private List<SelectListItem> _porganizationsItems;

        private List<SelectListItem> _fundtypeItems;
        private List<SelectListItem> _commodityItems;
        private List<SelectListItem> _fiscalYearItems;
        private List<SelectListItem> _substationItems;
        private List<SelectListItem> _programAreaItems;
        private List<SelectListItem> _locationsItems;
        private List<SelectListItem> _thesisItems;
        private List<SelectListItem> _gradItems;
        private List<SelectListItem> _scirolesItems;

        public ProjectsController(WorkplandbContext context, PermissionService permissionService, PermissionAccessService accessService)
        {
            _context = context;
            this.permissionService = permissionService;
            this._accessService = accessService;
        }

        // GET: Projects

        public async Task<IActionResult> Index()
        {
            //check, esto va para el servidor...

          var  roleId = permissionService.GetCurrentUserRoleId(User);
            var permissions = permissionService.GetPermissionsForRole(roleId);
            
            ViewBag.Permissions = permissions;

            //Not Filtered Version

            //var projects = await _context.Projects.Include(p => p.Comm)
            //    .Include(p => p.Department)
            //    .Include(p => p.FiscalYear)
            //    .Include(p => p.ProjectStatus)
            //    .Include(p => p.ProgramArea).Include(p => p.Roster).ToListAsync();

            //filtered version


            // Filtra SOLO los proyectos que el usuario puede ver
            var proyectosFiltrados = _accessService
       .FilterProjectsForUser(User)
       .Include(p => p.Department)
       .Include(p => p.Comm)
       .Include(p => p.FiscalYear)
       .Include(p => p.ProjectStatus)
       .Include(p => p.ProgramArea)
       .Include(p => p.Roster);

            var lista = await proyectosFiltrados.ToListAsync();

            return View(lista);

            /*.Include(ps => ps.ProjectStatus)*/
            ;
            //await workplandbContext.ToListAsync())

            //return View(projects);
        }



        public async Task<IActionResult> ProjectDetails(int? id)
        {



            var query = (from p in _context.Projects
                         where p.ProjectId == id
                         select p).FirstOrDefault();


            ProjectFormView projectTemplate = new ProjectFormView()
            {
                ProjectId = query.ProjectId,
                Projects = query,
                ProjectNumber = query.ProjectNumber
                ,
                ProjectTitle = query.ProjectTitle
            };



            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;

            var substation = _context.Substacions.ToList();
            _substationItems = new List<SelectListItem>();
            foreach (var item in substation)
            {
                _substationItems.Add(new SelectListItem
                {
                    Text = item.SubStationName,
                    Value = item.SubstationId.ToString()
                });
                ViewBag.substationItems = _substationItems;
            }


            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            ViewBag.rosterPI = _rosterItems;






            return View(projectTemplate);
        }


        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Comm)
                .Include(p => p.Department)
                .Include(p => p.FiscalYear)
                .Include(p => p.ProgramArea)
                .Include(p => p.ProjectStatus)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public async Task<IActionResult> Create( )
        {

            ProjectViewModel projects = new ProjectViewModel();

            // ViewBag Area:


            #region dropdownlists

            // CARGAMOS EL DropDownList 
            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;

            var departments = _context.Departments.ToList();
            _departmentsItems = new List<SelectListItem>();
            foreach (var item in departments)
            {
                _departmentsItems.Add(new SelectListItem
                {
                    Text = item.DepartmentName,
                    Value = item.DepartmentId.ToString()
                });
            }
            ViewBag.departmentItems = _departmentsItems;

            var porganizations = _context.Porganizations.ToList();
            _porganizationsItems = new List<SelectListItem>();
            foreach (var item in porganizations)
            {
                _porganizationsItems.Add(new SelectListItem
                {
                    Text = item.PorganizationName,
                    Value = item.PorganizationId.ToString()
                });
                ViewBag.porganizationItem = _porganizationsItems;
            }

            var commodity = _context.Commodities.ToList();
            _commodityItems = new List<SelectListItem>();
            foreach (var item in commodity)
            {
                _commodityItems.Add(new SelectListItem
                {
                    Text = item.CommName,
                    Value = item.CommId.ToString()
                });
                ViewBag.commodityItems = _commodityItems;
            }




            var fundtype = _context.FundTypes.ToList();
            _fundtypeItems = new List<SelectListItem>();
            foreach (var item in fundtype)
            {
                _fundtypeItems.Add(new SelectListItem
                {
                    Text = item.FundTypeName,
                    Value = item.FundTypeId.ToString()
                });
                ViewBag.fundtypeItems = _fundtypeItems;
            }

            var fiscalYear = _context.FiscalYears.ToList();
            _fiscalYearItems = new List<SelectListItem>();
            foreach (var item in fiscalYear)
            {
                _fiscalYearItems.Add(new SelectListItem
                {
                    Text = item.FiscalYearName,
                    Value = item.FiscalYearId.ToString()
                });
                ViewBag.fiscalyearItems = _fiscalYearItems;
            }

            var substation = _context.Substacions.ToList();
            _substationItems = new List<SelectListItem>();
            foreach (var item in substation)
            {
                _substationItems.Add(new SelectListItem
                {
                    Text = item.SubStationName,
                    Value = item.SubstationId.ToString()
                });
                ViewBag.substationItems = _substationItems;
            }
            var programAreas = _context.ProgramAreas.ToList();
            _programAreaItems = new List<SelectListItem>();
            foreach (var item in programAreas)
            {
                _programAreaItems.Add(new SelectListItem
                {
                    Text = item.ProgramAreaName,
                    Value = item.ProgramAreaId.ToString()
                });
                ViewBag.programAreaItems = _programAreaItems;
            }

            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();
            foreach (var item in location) {

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;


            }
            #endregion

            return View();






       

            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommName");
            ViewData["Department"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["FiscalYear"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName ");

            ViewData["Roster"] = new SelectList(_context.Rosters, "RosterID", "RosterName");
            ViewData["Location"] = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewData["FundType"] = new SelectList(_context.FundTypes, "FundTyoeId", "FundTypeName");
            ViewData["POrganizarion"] = new SelectList(_context.Porganizations, "PorganizationId", "PorganizationName");
            ViewData["SubStation"] = new SelectList(_context.Substacions, "SubstationId", "SubStationName");
            return View();
        }

        
        [HttpPost]

        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(ProjectViewModel template)
        {

            
            ProjectViewModel projects = new ProjectViewModel();



            if (ModelState.IsValid)
            {
                string[] substacion = new string[template.SubStationSelectedArray.Length];
                int index = 0;
                foreach (var item in template.SubStationSelectedArray) {

                    var consult = (from s in _context.Substacions
                                   where s.SubstationId == item
                                   select s).FirstOrDefault();


                    //var query = (from p in _context.Projects
                    //             where p.ProjectId == project.ProjectId
                    //             select
                    //             p).FirstOrDefault();

                    substacion[index] = consult.SubStationName;
                    index++;
                }
                string substationString = string.Join(",", substacion);


                var Project = new Models.Project()
                {
                    ProjectNumber = template.ProjectNumber,
                    ProjectTitle = template.ProjectTitle,
                    DepartmentId = template.DepartmentId,
                    CommId = template.CommId,
                    ProgramAreaId = template.ProgramAreaId,
                    SubStationId = template.SubStationId,
                    FundTypeId = template.FundTypeId,
                    ContractNumber = template.ContractNumber,
                    Orcid = template.Orcid,
                    PorganizationsId = template.PorganizationsId,
                    Substation = substationString,
                    RosterId = template.RosterId,
                    FiscalYearId = template.FiscalYearId,
                    ProjectStatusId = 1

                };
                var Fundtype = new FundType()
                {
                    FundTypeName = template.OtherFundtype

                };

                TempData["AlertCreate"] = "Project Created Succesfully!";

                _context.Add(Project);
                _context.Add(Fundtype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));




            }
            ViewData["selectedProjectPI"] = _rosterItems;
            ViewBag.rosterPI = _rosterItems;

            ViewBag.CommoditiesItem = new SelectList(_context.Commodities, "CommId", "CommName");
            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.FiscalYearItem = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName");
            ViewBag.ProgramAreaItem = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName");
            ViewBag.POrganizationItem = new SelectList(_context.Porganizations, "PorganizationId", "PorganizationName");
            ViewBag.FundTypeItem = new SelectList(_context.FundTypes, "FundTypeId", "FundTypeName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");



            return View(template);
        }




        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommId", project.CommId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", project.DepartmentId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearId", project.FiscalYearId);
            ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaId", project.ProgramAreaId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectNumber,ProjectTitle,ProjectPi,DepartmentId,CommId,ProgramAreaId,SubStationId,DateRegister,LastUpdate,ProjectStatusId,FiscalYearId,Objectives,ObjWorkPlan,PresentOutlook,Wp1fieldWork,Wp2id,Workplan2Desc,ResultsAvailable,Facilities,Impact,Salaries,Materials,Equipment,Travel,Abroad,Others,Wfsid,Wfupdate,StartDate,TerminationDate,FundTypeId,WorkPlan2,Wages,Benefits,Assistant,Subcontracts,IndirectCosts,ContractNumber,Orcid,ProcessProjectWayId,PorganizationsId,LocationId")] Models.Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommId", project.CommId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", project.DepartmentId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearId", project.FiscalYearId);
            ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaId", project.ProgramAreaId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Comm)
                .Include(p => p.Department)
                .Include(p => p.FiscalYear)
                .Include(p => p.ProgramArea)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'WorkplandbContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }


        #region nav

        //Page1

            [HttpPost]
            public  IActionResult RedirectPL(ProjectDetailsVM detailsVM) {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("ProjectList", "Projects", new{id = id });

                return Json(new {redirect = redirect, url = url });
            }


        //Page2
        [HttpPost]
            public IActionResult RedirectP2(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page2", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page3

            [HttpPost]
            public IActionResult RedirectP3(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page3", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page4

            [HttpPost]
            public IActionResult RedirectP4(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page4", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page5

            [HttpPost]
            public IActionResult RedirectP5(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page5", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page6

            [HttpPost]
            public IActionResult RedirectP6(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page6", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page7

            [HttpPost]
            public IActionResult RedirectP7(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page7", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page8

            [HttpPost]
            public IActionResult RedirectP8(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page8", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page9

            [HttpPost]
            public IActionResult RedirectP9(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page9", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page10

            [HttpPost]
            public IActionResult RedirectP10(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page10", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Page11

            [HttpPost]
            public IActionResult RedirectP11(ProjectDetailsVM detailsVM)
            {

                int id = int.Parse(detailsVM.ProjectId);
                bool redirect = true;
                string url = Url.Action("Page11", "Projects", new { id = id });

                return Json(new { redirect = redirect, url = url });
            }

        //Project Review

        [HttpPost]
        public IActionResult RedirectP12(ProjectDetailsVM detailsVM) {

            int id = int.Parse(detailsVM.ProjectId);
            bool redirect = true;
            string url = Url.Action("ProjectReview", "Projects", new { id = id });

            return Json(new { redirect = redirect, url = url });
        }
        #endregion








        //PAGE 0:

        public async Task<IActionResult> Page0(int? id) {

            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;

            var substation = _context.Substacions.ToList();
            _substationItems = new List<SelectListItem>();
            foreach (var item in substation)
            {
                _substationItems.Add(new SelectListItem
                {
                    Text = item.SubStationName,
                    Value = item.SubstationId.ToString()
                });
                ViewBag.substationItems = _substationItems;
            }




            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }



            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommName", project.CommId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", project.DepartmentId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName", project.FiscalYearId);
            ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName", project.ProgramAreaId);
            ViewData["SubstationId"] = new SelectList(_context.Substacions, "SubStationId", "SubStationName", project.SubStationId);

            ViewBag.ProjectNumberItem = project.ProjectNumber;
            ViewBag.CommoditiesItem = new SelectList(_context.Commodities, "CommId", "CommName");
            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.FiscalYearItem = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName");
            ViewBag.ProgramAreaItem = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName");
            ViewBag.POrganizationItem = new SelectList(_context.Porganizations, "PorganizationId", "PorganizationName");
            ViewBag.FundTypeItem = new SelectList(_context.FundTypes, "FundTypeId", "FundTypeName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            return View(project);
        }

        //GET WORKPLAN PAGE 1:

        [HttpPost]
        public async Task<IActionResult> Page0(int id,Models.Project project) {

            if (ModelState.IsValid) {
                var query = (from p in _context.Projects
                             where p.ProjectId == project.ProjectId
                             select
                             p).FirstOrDefault();

                query.ContractNumber = project.ContractNumber;
                query.Orcid= project.Orcid;

                _context.SaveChanges();

                return RedirectToAction("ProjectList", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectNumber
                });
            }





            return View();
        }

        








        // Report Section
        public IActionResult Print(int? id)
        {

            string param = id.ToString();

            Dictionary<string,string> parameters= new Dictionary<string,string>();
            parameters.Add("projectID", param);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var filepath = @"C:\Users\GGJEANZS\Documents\Prueba.rdl";
            var local = new LocalReport(filepath);
            var rpt = local.Execute(RenderType.Pdf,0,parameters);

            return File(rpt.MainStream, "application/pdf");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ProjectDetails(int id, [Bind("ProjectId,ProjectNumber,ProjectTitle,DepartmentId,CommId,ProgramAreaId,SubStationId,ProjectStatusId,FiscalYearId,ProjectPi")] Models.Project project)
        {


            if (id != project.ProjectId)
            {
                return NotFound();
            }
            

            if (ModelState.IsValid)
            {

                // return RedirectToAction(nameof(Page2));

                return RedirectToAction("ProjectList", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });
            }
           
            return View();



        }

        [HttpPost]
        public async Task<IActionResult> PostApproveData(ProjectDetailsVM projectFormView)
        {

            int id = int.Parse(projectFormView.ProjectId);


            var query = (from p in _context.Projects
                         where p.ProjectId == id
                         select p).FirstOrDefault();


            ProjectNote note = new ProjectNote() {

                Username = User.Identity.Name,
                Comment = projectFormView.comment,
                UserRole= projectFormView.userRole,
                ProjectId = id,
                LastUpdate= DateTime.Now,
                
            
            
            
            };

            _context.Add(note);
            query.ProjectStatusId= 11;
            _context.SaveChanges();

            return View();



        }


        [HttpPost]
        public async Task<IActionResult> PostRejectData(ProjectDetailsVM projectFormView)
        {



            int id = int.Parse(projectFormView.ProjectId);
            var query = (from p in _context.Projects
                         where p.ProjectId == id
                         select p).FirstOrDefault();



            ProjectNote note = new ProjectNote()
            {

                Username = User.Identity.Name,
                Comment = projectFormView.comment,
                UserRole = projectFormView.userRole,
                ProjectId = id,
                LastUpdate = DateTime.Now,




            };

            _context.Add(note);


            query.ProjectStatusId = 12;
            _context.SaveChanges();

            return View();



        }





        //Project : WorkPlan Page 2, Process 1>

        public async Task<IActionResult> Page2(int? id, Models.Project project)
        {
            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;






            var projects = await _context.Projects.FindAsync(id);


            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var projectss = await _context.Projects.FindAsync(id);

            var query = (from p in _context.Projects
                         where p.ProjectId == project.ProjectId
                         select
                         p).FirstOrDefault();

            var queryL = (from p in _context.Projects
                          where p.ProjectId == project.ProjectId
                          select p).ToList();
            ProjectFormView projectTemplate = new ProjectFormView()
            {

                ProjectNumber = projectss.ProjectNumber

            };
            if (projects == null)
            {
                return NotFound();
            }

            if (projectTemplate == null)
            {



            }
            else
            {
                //if(projectTemplate.Objectives.)
                if (projectss.Objectives == null)
                {
                    projectTemplate.Objectives = "";
                }
                else
                {

                    projectTemplate.Objectives = projectss.Objectives.ToString();
                }

                if (projectss.ObjWorkPlan == null)
                {
                    projectTemplate.ObjWorkPlan = "";
                }
                else
                {

                    projectTemplate.ObjWorkPlan = projectss.ObjWorkPlan.ToString();
                }


                if (projectss.PresentOutlook == null)
                {
                    projectTemplate.PresentOutlook = "";
                }
                else
                {

                    projectTemplate.PresentOutlook = projectss.PresentOutlook.ToString();
                }

                projectTemplate.ProjectId = id.Value;




            }




            return View(projectTemplate);
        }




        //Project : WorkPlan Page 2, Process 1>

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Page2(int id,  ProjectFormView template, Models.Project project)
        {
            ProjectFormView projectTemplate = new ProjectFormView();


        


            if (ModelState.IsValid) {

                try
                {

                    var query = (from p in _context.Projects
                                 where p.ProjectId == project.ProjectId
                                 select
                                 p).FirstOrDefault();

                    query.Objectives = project.Objectives;

                    query.ObjWorkPlan = project.ObjWorkPlan;
                    query.PresentOutlook = project.PresentOutlook;
                    query.ProjectStatusId = 2;

                    _context.SaveChanges();








                    return RedirectToAction("Page3", new
                    {
                        ID = project.ProjectId,
                        projectName = project.ProjectTitle
                    });



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
               
            }

           
            return View();



        }


     



     
        public IActionResult GetFieldWork(int fieldWorkId) 
        {
            return Ok(fieldWorkId);
        }


        public async Task<IActionResult> ProjectList(int? id)
        {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;




            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;

            var substation = _context.Substacions.ToList();
            _substationItems = new List<SelectListItem>();
            foreach (var item in substation)
            {
                _substationItems.Add(new SelectListItem
                {
                    Text = item.SubStationName,
                    Value = item.SubstationId.ToString()
                });
                ViewBag.substationItems = _substationItems;
            }




            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }



            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommName", project.CommId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", project.DepartmentId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName", project.FiscalYearId);
            ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName", project.ProgramAreaId);
            ViewData["SubstationId"] = new SelectList(_context.Substacions, "SubStationId", "SubStationName", project.SubStationId);

            ViewBag.ProjectNumberItem = project.ProjectNumber;
            ViewBag.CommoditiesItem = new SelectList(_context.Commodities, "CommId", "CommName");
            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.FiscalYearItem = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName");
            ViewBag.ProgramAreaItem = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName");
            ViewBag.POrganizationItem = new SelectList(_context.Porganizations, "PorganizationId", "PorganizationName");
            ViewBag.FundTypeItem = new SelectList(_context.FundTypes, "FundTypeId", "FundTypeName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            return View(project);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectList( Models.Project project, int id) {




            if (ModelState.IsValid)
            {
                var query = (from p in _context.Projects
                             where p.ProjectId == project.ProjectId
                             select
                             p).FirstOrDefault();

                query.ContractNumber = project.ContractNumber;
                query.Orcid = project.Orcid;
                

                _context.SaveChanges();

                return RedirectToAction("Page2", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectNumber
                });
            }





            return View();
        }





        // Page 3:
        public async Task<IActionResult> Page3(int? id ) {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;

            var project = await _context.Projects.FindAsync(id);


            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }


            var fields = _context.FieldOptions.ToList();
            _gradItems = new List<SelectListItem>();
            foreach (var item in fields)
            {
                _gradItems.Add(new SelectListItem
                {
                    Text = item.OptionName,
                    Value = item.FieldoptionId.ToString()
                });
            }
            ViewBag.fieldItems = _gradItems;


            var fieldworks = (from f in _context.FieldWorks
                              where f.ProjectId == id
                              select f).ToList();

            var fieldworks1 = (from f in _context.FieldWorks
                               where f.ProjectId == id
                               select f).FirstOrDefault();

            ProjectFormView template = new ProjectFormView()
            {
                ProjectNumber = project.ProjectNumber,
                ProjectId = project.ProjectId,
                fieldsWork = fieldworks

            };

            template.ProjectId = project.ProjectId;


            // template.FieldWorkId = fieldworks1.FieldWorkId;





            if (project == null)
            {
                return NotFound();
            }
            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommId", project.CommId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", project.DepartmentId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearId", project.FiscalYearId);
            ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaId", project.ProgramAreaId);


            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();
            foreach (var item in location)
            {

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;


            }


            return View(template);
        }










        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Page3( int? id, FieldWorkView fieldWorkView , Models.Project project  ) {
            if (ModelState.IsValid)
            {
                FieldWork fieldwork = new FieldWork()
                {
                    
                    ProjectId = project.ProjectId,


                    Wfieldwork = fieldWorkView.wfieldwork,
                    LocationId = fieldWorkView.LocationId,
                    DateStarted = DateTime.Parse(fieldWorkView.dateStarted),
                    DateEnded = DateTime.Parse(fieldWorkView.dateEnded),
                    FieldoptionId = fieldWorkView.fieldoption,
                    //InProgress = template.InProgress,
                    //ToBeInitiated = template.ToBeInitiated,
                    Area =fieldWorkView.area
                    




                };
                _context.Add(fieldwork);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page3", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });




            }

           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Page3Post(FieldWorkView fieldWork)
        {
            var datos = fieldWork;
            var query = (from f in _context.FieldWorks
                         where f.FieldWorkId == fieldWork.fieldWorkId
                         select f).FirstOrDefault();
            try
            {
                FieldWork fieldwork = new FieldWork()
                {
                    
                    ProjectId = int.Parse(fieldWork.projectId),


                    Wfieldwork = fieldWork.wfieldwork,
                    LocationId = fieldWork.LocationId,
                    DateStarted = DateTime.Parse(fieldWork.dateStarted),
                    DateEnded = DateTime.Parse(fieldWork.dateEnded),
                    FieldoptionId = fieldWork.fieldoption,
                    Area = fieldWork.area





                };
                _context.Add(fieldwork);
                await _context.SaveChangesAsync();

            }
            catch
            {
            }
            int id = int.Parse(fieldWork.projectId);
            bool redirect = true;
            string url = Url.Action("Page3", "Projects", new { id = id });

            return Json(new { redirect = redirect, url = url });
        }






        [HttpPost]
        public async Task<IActionResult> PostFieldWorkData(FieldWorkView fieldWork)
        {
            var datos = fieldWork;
            var query = (from f in _context.FieldWorks
                         where f.FieldWorkId == fieldWork.fieldWorkId
                         select f).FirstOrDefault();
            try
            {
                query.FieldWorkId = fieldWork.fieldWorkId;
                query.Wfieldwork = fieldWork.wfieldwork;
                query.LocationId = fieldWork.LocationId;
                query.FieldoptionId = fieldWork.fieldoption;
                query.Area = fieldWork.area;
                query.ProjectId = int.Parse(fieldWork.projectId);
                query.DateStarted = DateTime.Parse(fieldWork.dateStarted);
                query.DateEnded = DateTime.Parse(fieldWork.dateEnded);
                //query.InProgress = fieldWork.inProgress;
                //query.ToBeInitiated = fieldWork.toBeInitiated;
                _context.SaveChanges();

            }
            catch
            {
            }


            int id = query.ProjectId;
            bool redirect = true;
            string url = Url.Action("Page3", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }

        

        public async Task<IActionResult> DeletePage3(FieldWorkView fieldWorkView)
        {

            var datos = fieldWorkView;
            var query = (from f in _context.FieldWorks
                         where f.FieldWorkId == fieldWorkView.fieldWorkId
                         select f).FirstOrDefault();

            var entity = _context.FieldWorks.Find(query.FieldWorkId);
            try
            {
                if (entity == null) return NotFound();

                _context.FieldWorks.Remove(entity);
                _context.SaveChanges();
            }
            catch
            {



            }

            int id = query.ProjectId;
            bool redirect = true;
            string url = Url.Action("Page3", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }






        //Edit from Page4

        [HttpPost]
        public async Task<IActionResult> PostPage3Data(LaboratoryVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.Laboratories
                         where f.LabId == projectTemplate.LabId
                         select f).FirstOrDefault();
            try
            {
                query.LabId = projectTemplate.LabId;
                query.WorkPlanned = projectTemplate.WorkPlanned;
                query.Descriptions = projectTemplate.Descriptions;
                query.TimeEstimated = projectTemplate.TimeEstimated;
                query.FacilitiesNeeded = projectTemplate.FacilitiesNeeded;
                query.CentralLaboratory = projectTemplate.CentralLaboratory;
                query.ProjectId = projectTemplate.ProjectId;
                _context.SaveChanges();

            }
            catch
            {
            }
            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page5", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });

           
        }




        //Page 4> Analitical

        public async Task<IActionResult> Page4(int? id ) {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;



            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var laboratory = (from l in _context.Laboratories
                              where l.ProjectId == id
                              select l).ToList();

            ProjectFormView projectTemplate = new ProjectFormView()
            {
                ProjectNumber = project.ProjectNumber,
                laboratories = laboratory,

            };


            projectTemplate.ProjectId = id.Value;
            projectTemplate.ProjectNumber = project.ProjectNumber;
            return View(projectTemplate);
        }






        [HttpPost]
        public async Task<IActionResult> Page4(int? id, Models.Project project, ProjectFormView projectTemplate) {
            
            if (ModelState.IsValid) {
                Laboratory laboratory = new Laboratory()
                {



                    WorkPlanned = projectTemplate.WorkPlanned,
                    Descriptions = projectTemplate.Descriptions,
                    TimeEstimated = projectTemplate.TimeEstimated,
                    FacilitiesNeeded = projectTemplate.FacilitiesNeeded,
                    CentralLaboratory = projectTemplate.CentralLaboratory,
                    ProjectId = projectTemplate.ProjectId




                };
                _context.Add(laboratory);
                await _context.SaveChangesAsync();

               
                return RedirectToAction("Page4", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectNumber
                    
                });

            }
        
        
        
        
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Page4Post(LaboratoryVM projectTemplate)
        {
           
            try
            {
                Laboratory laboratory = new Laboratory()
                {

                    WorkPlanned = projectTemplate.WorkPlanned,
                    Descriptions = projectTemplate.Descriptions,
                    TimeEstimated = DateTime.Parse(projectTemplate.TimeEstimated.ToString()),

                    
                    FacilitiesNeeded = projectTemplate.FacilitiesNeeded,
                    CentralLaboratory = projectTemplate.CentralLaboratory,
                    ProjectId = projectTemplate.ProjectId

                };
                _context.Add(laboratory);
                await _context.SaveChangesAsync();

            }
            catch
            {
            }
            int id = projectTemplate.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page4", "Projects", new { id = id });

            return Json(new { redirect = redirect, url = url });
        }



        public async Task<IActionResult> DeletePage4(LaboratoryVM laboratoryVM)
        {

            var datos = laboratoryVM;
            var query = (from f in _context.Laboratories
                         where f.LabId == laboratoryVM.LabId
                         select f).FirstOrDefault();

            var entity = _context.Laboratories.Find(query.LabId);
            try
            {
                if (entity == null) return NotFound();

                _context.Laboratories.Remove(entity);
                _context.SaveChanges();
            }
            catch
            {



            }

            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page4", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }






        public async Task<IActionResult> Page5(int? id) {
            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;




            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

          

            var scientist =(from  s in _context.SciProjects
                            where s.ProjectId == id
                            select s).ToList();
            ProjectFormView projectTemplate = new ProjectFormView() { 
            
                sciProjects = scientist,
                
            
            
            };
            projectTemplate.ProjectNumber = project.ProjectNumber;
            projectTemplate.ProjectId = id.Value;
            
            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;



            var roles = _context.SciRoles.ToList();
            _scirolesItems = new List<SelectListItem>();
            foreach (var item in roles)
            {
                _scirolesItems.Add(new SelectListItem
                {
                    Text = item.SciRoleName,
                    Value = item.SciRolesId.ToString()
                });
            }
            ViewBag.scirolesItems = _scirolesItems;
            ViewData["selectedProjectPI"] = _rosterItems;

            return View(projectTemplate);
        }


        [HttpPost]
        public async Task<IActionResult> Page5(int? id,Models.Project project, ProjectFormView projectTemplate) {
            
            if (ModelState.IsValid) {
                SciProject sciProject = new SciProject() { 
                    //
                    RosterId = (int)projectTemplate.RosterId,
                    SciRolesId = projectTemplate.SciRolesId,
                 
                    Tr = projectTemplate.Tr,
                    Ca = projectTemplate.Ca,
                    Ah= projectTemplate.Ah,
                    Credits =projectTemplate.Tr + projectTemplate.Ca + projectTemplate.Ah,
                    ProjectId = projectTemplate.ProjectId
                    
                
                
                
                };
                _context.Add(sciProject);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page5", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });


            }
        
        
        
        
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostPage5Data(SciProjectVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.SciProjects
                         where f.SciId == projectTemplate.sciPId
                         select f).FirstOrDefault();

            

            try
            {
                if (projectTemplate.ca is null)
                {
                    projectTemplate.ca = 0;

                }
                if (projectTemplate.tr is null)
                {
                    projectTemplate.tr = 0;

                }

                if (projectTemplate.ah is null)
                {
                    projectTemplate.ah = 0;

                }


                string trFormat = string.Format("{0:0.0000}",projectTemplate.tr);
                string caFormat = string.Format("{0:0.0000}", projectTemplate.ca);
                string ahFormat = string.Format("{0:0.0000}", projectTemplate.ah);

                query.SciId = projectTemplate.sciPId;
                query.RosterId = (int)projectTemplate.rosterid;
                
                query.Tr = decimal.Parse(trFormat);
                query.Ca = decimal.Parse(caFormat);
                query.Ah = decimal.Parse(ahFormat);

                
                ;
                query.Credits = query.Tr + query.Ca + query.Ah;
                string creditFormaat = string.Format("{0:0.0000}", query.Credits);
                query.Credits = decimal.Parse(creditFormaat);
                query.SciRolesId= (int)projectTemplate.SciRolesId;

                query.ProjectId = projectTemplate.projectId;

               
               
                

                


                _context.SaveChanges();

            }
            catch
            {
            }
            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page5", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }


        public async Task<IActionResult> DeletePage5(SciProjectVM sciProjectVM) {

            var datos = sciProjectVM;

            var query = (from f in _context.SciProjects
                         where f.SciId == sciProjectVM.sciPId
                         select f).FirstOrDefault();

            var entity = _context.SciProjects.Find(query.SciId);
            try
            {
                if (entity == null) return NotFound();
                
                _context.SciProjects.Remove(entity);
                _context.SaveChanges();
            }
            catch {
            
            
            
            }

            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page5", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }



        public async Task<IActionResult> Page6(int? id ) {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;



            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var otherPersonel =( from op in _context.OtherPersonels
                                where op.ProjectId == id
                                select op).ToList();

           

            ProjectFormView projectTemplate = new ProjectFormView()
            {
               otherPersonels= otherPersonel
            };
            projectTemplate.ProjectNumber = project.ProjectNumber;
            projectTemplate.ProjectId = id.Value;
            if (projectTemplate.PerTime != null)
            {
                var porciento = projectTemplate.PerTime * 100;
            }
            else
            {
                var porciento = 0; // o maneja el caso nulo como corresponda
            }


            //var porciento = projectTemplate.PerTime * 100;

            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();
            foreach (var item in location)
            {

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;


            }

            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;

            return View(projectTemplate);
        }

        [HttpPost]

        public async Task<IActionResult> Page6(int? id, Models.Project project,  ProjectFormView projectTemplate) {
            if (ModelState.IsValid) {

                OtherPersonel otherPersonel = new OtherPersonel() {

                    Name = projectTemplate.Name,
                    PerTime= projectTemplate.PerTime,
                    LocationId= projectTemplate.LocationId,
                    RosterId = projectTemplate.RosterId,
                    PersonnelManAdded= projectTemplate.PersonnelManAdded,
                    RoleManAdded= projectTemplate.RoleManAdded,
                    ProjectId= projectTemplate.ProjectId,
                    
                    
                
                
                
                
                
                
                };
                _context.Add(otherPersonel);
                await _context.SaveChangesAsync();



                return RedirectToAction("Page6", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });



            }

            return View(projectTemplate);



        }



        [HttpPost]
        public async Task<IActionResult> PostPage6Data(OtherPersonnelVM projectTemplate)
        
        {
            
            var datos = projectTemplate;
            
            if (projectTemplate.Opid == 0)
            {
                OtherPersonel otherPersonel = new OtherPersonel()
                {

                    Name = projectTemplate.perName,
                    PerTime = projectTemplate.pertime,
                    LocationId = projectTemplate.locationid,
                    RosterId = projectTemplate.rosterid,

                    ProjectId = projectTemplate.projectId








                };
                _context.Add(otherPersonel);
                await _context.SaveChangesAsync();
                

            }
            else {
                var queryP = (from f in _context.OtherPersonels
                             where f.Opid == projectTemplate.Opid
                             select f).FirstOrDefault();
                try
                {
                    queryP.Opid = projectTemplate.Opid;
                    queryP.Name = projectTemplate.perName;
                         
                    queryP.LocationId = projectTemplate.locationid;
                    queryP.RosterId = projectTemplate.rosterid;
                    queryP.PerTime = projectTemplate.pertime;
                    queryP.PersonnelManAdded = projectTemplate.personnelman;
                    queryP.RoleManAdded = projectTemplate.roleman;
                    queryP.ProjectId = projectTemplate.projectId;
                    _context.SaveChanges();

                }
                catch
                {
                }


            }
            var query = (from f in _context.OtherPersonels
                         where f.Opid == projectTemplate.Opid
                         select f).FirstOrDefault();

            int id = projectTemplate.projectId.Value;
            bool redirect = true;
            string url = Url.Action("Page6", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }


        public async Task<IActionResult> DeletePage6(OtherPersonnelVM otherPersonnelVM)
        {

            var datos = otherPersonnelVM;
            var query = (from f in _context.OtherPersonels
                         where f.Opid == otherPersonnelVM.Opid
                         select f).FirstOrDefault();

            var entity = _context.OtherPersonels.Find(query.Opid);
            try
            {
                if (entity == null) return NotFound();

                _context.OtherPersonels.Remove(entity);
                _context.SaveChanges();
            }
            catch
            {



            }

            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page6", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }




        public async Task<IActionResult> Page7(int? id) {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }


            var grad = _context.GradOptions.ToList();
            _gradItems = new List<SelectListItem>();
            foreach (var item in grad)
            {
                _gradItems.Add(new SelectListItem
                {
                    Text = item.GradOptionName,
                    Value = item.GradoptionId.ToString()
                });
            }
            ViewBag.gradItems = _gradItems;


            var Graduas = (from g in _context.GradAsses
                           where g.ProjectId == id
                           select g).ToList();

            var thesis = _context.ThesisProjects.ToList();
            _thesisItems = new List<SelectListItem>();
            foreach (var item in thesis)
            {
                _thesisItems.Add(new SelectListItem
                {
                    Text = item.OptionName,
                    Value = item.ThesisProjectId.ToString()
                });
            }
            ViewBag.thesisItems = _thesisItems;


            ProjectFormView projectTemplate = new ProjectFormView()
            {
                gradAsses= Graduas,
                ProjectNumber = project.ProjectNumber
            };
            
            projectTemplate.ProjectId = id.Value;
            return View(projectTemplate);


        }


        [HttpPost]
        public async Task<IActionResult> Page7(int? id, Models.Project project, ProjectFormView projectTemplate) {
            

            if(ModelState.IsValid)
            {
                GradAss gradAss = new GradAss() { 
                
                    Gname = projectTemplate.Gname,
                    Thesis = projectTemplate.Thesis,
                    StudentId= projectTemplate.StudentId,
                    GradoptionId= projectTemplate.GradoptionId,
                    ProjectId= project.ProjectId,
                    ThesisProjectId= projectTemplate.ThesisProjectId,
                
                };
                _context.Add(gradAss);
                await _context.SaveChangesAsync();
                return RedirectToAction("Page7", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });


            }
        
        
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> PostPage7Data(GradassVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.GradAsses
                         where f.Gaid == projectTemplate.gradId
                         select f).FirstOrDefault();
            try
            {
                query.Gaid = projectTemplate.gradId;
                query.Gname = projectTemplate.gname;

                query.Thesis = projectTemplate.thesis;
                query.StudentId = projectTemplate.student;
          
               
                query.GradoptionId = projectTemplate.gradoption;
                query.ThesisProjectId = projectTemplate.thesisid;
                query.ProjectId = projectTemplate.projectId;
                _context.SaveChanges();

            }
            catch
            {
            }

            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page7", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }



        public async Task<IActionResult> DeletePage7(GradassVM gradassVM)
        {

            var datos = gradassVM;
            var query = (from f in _context.GradAsses
                         where f.Gaid == gradassVM.gradId
                         select f).FirstOrDefault();

            var entity = _context.GradAsses.Find(query.Gaid);
            try
            {
                if (entity == null) return NotFound();

                _context.GradAsses.Remove(entity);
                _context.SaveChanges();
            }
            catch
            {



            }

            int id = query.ProjectId.Value;
            bool redirect = true;
            string url = Url.Action("Page7", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }





        public async Task<IActionResult> Page8(int? id ) {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;



            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var funds = (from fu in _context.Funds
                         where fu.ProjectId == id
                         select fu).ToList();



            var tSalaries = (from fun in _context.Funds
                             where fun.ProjectId == id
                             select fun.Salaries).ToList();

            var tWages = (from fun in _context.Funds
                          where fun.ProjectId == id
                          select fun.Wages).ToList();

            var tBenefits = (from fun in _context.Funds
                             where fun.ProjectId == id
                             select fun.Benefits).ToList();

            var tAssistant = (from fun in _context.Funds
                              where fun.ProjectId == id
                              select fun.Assistant).ToList();

            var tMaterials = (from fun in _context.Funds
                              where fun.ProjectId == id
                              select fun.Materials).ToList();

            var tEquipment = (from fun in _context.Funds
                              where fun.ProjectId == id
                              select fun.Equipment).ToList();

            var tTravel = (from fun in _context.Funds
                           where fun.ProjectId == id
                           select fun.Travel).ToList();


            var tAbroad = (from fun in _context.Funds
                           where fun.ProjectId == id
                           select fun.Abroad).ToList();

            var tSubcontracts = (from fun in _context.Funds
                                 where fun.ProjectId == id
                                 select fun.Subcontracts).ToList();

            var tOthers = (from fun in _context.Funds
                           where fun.ProjectId == id
                           select fun.Others).ToList();

            var tIndirectCosts = (from fun in _context.Funds
                                  where fun.ProjectId == id
                                  select fun.IndirectCosts).ToList();

            var tTotalAmount = (from fun in _context.Funds
                                where fun.ProjectId == id
                                select fun.TotalAmount).ToList();


            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();
            foreach (var item in location)
            {

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;


            }
            ProjectFormView projectTemplate = new ProjectFormView()
            {
                ProjectNumber = project.ProjectNumber,
                Fundss = funds,
                TSalaries = tSalaries.Sum(),
                TWages = tWages.Sum(),
                TBenefits= tBenefits.Sum(),
                TAssistant= tAssistant.Sum(),
                TMaterials= tMaterials.Sum(),
                TEquipment= tEquipment.Sum(),
                TTravel = tTravel.Sum(),
                TAbroad = tAbroad.Sum(),
                TSubcontracts= tSubcontracts.Sum(),
                TOthers= tOthers.Sum(),
                TIndirectCosts= tIndirectCosts.Sum(),
                TTotalAmount= tTotalAmount.Sum(),


            };

            
            projectTemplate.ProjectId = id.Value;
            return View(projectTemplate);

        }




        [HttpPost]
        public async Task<IActionResult> Page8(int? id, Models.Project project, ProjectFormView projectTemplate) {
            if(ModelState.IsValid)
            {
                


                Fund fund = new Fund()
                {
                  LocationId = (int)projectTemplate.LocationId,
                  Salaries= projectTemplate.Salaries,
                  Wages = projectTemplate.Wages,
                  Subcontracts= projectTemplate.Subcontracts,
                  Benefits= projectTemplate.Benefits,
                  Assistant= projectTemplate.Assistant,
                  Materials= projectTemplate.Materials,
                  Equipment= projectTemplate.Equipment,
                  Travel = projectTemplate.Travel,
                  Abroad= projectTemplate.Abroad,
                  Others= projectTemplate.Others,
                  Ufisaccount= projectTemplate.Ufisaccount,
                  IndirectCosts= projectTemplate.IndirectCosts,
                  TotalAmount = projectTemplate.Salaries + projectTemplate.Wages + projectTemplate.Subcontracts + projectTemplate.Benefits + projectTemplate.Assistant +projectTemplate.Materials +
                    projectTemplate.Equipment +projectTemplate.Travel+projectTemplate.Abroad+projectTemplate.Others+projectTemplate.IndirectCosts,
                  ProjectId= project.ProjectId




                };
                _context.Add(fund);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page8", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });

            }





            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostPage8Data(FundVM datos)
        {
            //var datos = projectTemplate;
            var query = (from f in _context.Funds
                         where f.FundId == datos.fundId
                         select f).FirstOrDefault();
            try
            {
                query.FundId = datos.fundId;
                query.LocationId = int.Parse( datos.LocationId);

                query.Salaries = datos.salaries;
                query.Wages = datos.wages;
                query.Benefits = datos.benefit;
                query.Assistant = datos.assistant;
                query.Materials = datos.materials;
                query.Equipment = datos.equipment;
                query.Travel = datos.travel;
                query.Abroad= datos.abroad;
                query.Subcontracts = datos.subcontract;
                query.Others = datos.others;
                
                query.IndirectCosts = datos.indirectcosts;
                query.ProjectId = datos.projectId;
                query.TotalAmount = datos.salaries + datos.wages + datos.subcontract + datos.benefit + datos.assistant + datos.materials +
                    datos.equipment + datos.travel + datos.abroad + datos.others + datos.indirectcosts;
                _context.SaveChanges();

            }
            catch
            {
            }

            int id = query.ProjectId;
            bool redirect = true;
            string url = Url.Action("Page8", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }


        public async Task<IActionResult> DeletePage8(FundVM fundVM)
        {

            var datos = fundVM;
            var query = (from f in _context.Funds
                         where f.FundId == fundVM.fundId
                         select f).FirstOrDefault();

            var entity = _context.Funds.Find(query.FundId);
            try
            {
                if (entity == null) return NotFound();

                _context.Funds.Remove(entity);
                _context.SaveChanges();
            }
            catch
            {



            }

            int id = query.ProjectId;
            bool redirect = true;
            string url = Url.Action("Page8", "Projects", new { id = id });
            return Json(new { redirect = redirect, url = url });
        }




        // Workplan Page 9>

        public async Task<IActionResult> Page9(int? id, ProjectFormView projectTemplate )
        {
            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ProjectViewModel projectViewModel = new ProjectViewModel() { ProjectNumber = projectTemplate.ProjectNumber };
            
            projectViewModel.ProjectId = id.Value;
            projectViewModel.ProjectNumber = project.ProjectNumber;
            projectViewModel.Subcontracts = project.Subcontracts;
            projectViewModel.Impact = project.Impact;
            projectViewModel.Travel = project.Travel;
            projectViewModel.Wages = project.Wages;
            projectViewModel.Salaries = project.Salaries;
            projectViewModel.Materials = project.Materials;
            projectViewModel.Equipment= project.Equipment;
            projectViewModel.Abroad = project.Abroad;
            projectViewModel.IndirectCosts= project.IndirectCosts;
            projectViewModel.Benefits= project.Benefits;
            projectViewModel.Assistant= project.Assistant;
            projectViewModel.Others= project.Others;
            return View(projectViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Page9(int? id , Models.Project project, ProjectViewModel projectTemplate)
        {
            
            if (ModelState.IsValid) {

                try
                {
                    var query = (from p in _context.Projects
                                 where p.ProjectId == id
                                 select
                                 p

                                 ).FirstOrDefault();

                    projectTemplate.ProjectNumber = query.ProjectNumber;
                    query.Impact = projectTemplate.Impact;
                    query.Salaries = projectTemplate.Salaries;
                    query.Benefits = projectTemplate.Benefits;
                    query.Assistant = projectTemplate.Assistant;
                    query.Materials = projectTemplate.Materials;
                    query.Equipment = projectTemplate.Equipment;
                    query.Travel = projectTemplate.Travel;
                    query.Abroad= projectTemplate.Abroad;
                    query.Others= projectTemplate.Others;
                    query.Wages= projectTemplate.Wages;
                    query.Subcontracts = projectTemplate.Subcontracts;
                    query.IndirectCosts = projectTemplate.IndirectCosts;
                    query.ProjectStatusId = 9;
                    
                    await _context.SaveChangesAsync();



                    return RedirectToAction("Page9", new
                    {
                        ID = query.ProjectId,
                        projectName = project.ProjectTitle
                    });


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View();







            }



            return View();
        }

        public async Task<IActionResult> Page10(int? id)
        {
            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;


            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }
            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var projectNotes = ( from pno in _context.ProjectNotes
                                 where pno.ProjectId == id
                                 select pno).ToList();

            var roles = _context.Roles.ToList();
            var _roleItems = new List<SelectListItem>();
            foreach (var item in roles) {
                _roleItems.Add(new SelectListItem
                {
                    Text = item.Rname,
                    Value = item.RolesId.ToString()



                });
                    
                    
                    
            }
            ViewBag.roleItems = _roleItems;
            ProjectFormView projectViewModel = new ProjectFormView() { 
                ProjectNumber = project.ProjectNumber, 
                projectNotes= projectNotes
                ,
                

            };

            projectViewModel.ProjectId = id.Value;

            return View(projectViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Page10(int? id,  ProjectFormView projectForm)
        {
            if (ModelState.IsValid)
            {
                var email = HttpContext.User.FindAll(ClaimTypes.Email).Select(r => r.Value).FirstOrDefault();

                var roleId = int.Parse(projectForm.UserRole); 

                var selectedRole = await _context.Roles
                                   .Where(r => r.RolesId == roleId)
                                   .Select(r => r.Rname)
                                   .FirstOrDefaultAsync();


                ProjectNote notes = new ProjectNote()
                {
                    Comment = projectForm.Comment,
                    Username = User.Identity.Name,
                    Roles = HttpContext.User.FindAll(ClaimTypes.Role).Select(r => r.Value).FirstOrDefault(),
                    UserRole = selectedRole,
                    LastUpdate = DateTime.Now,
                    ProjectId = id,
                    

                };
                _context.Add(notes);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page10", new
                {
                    ID = id,
                    
                });


                //return RedirectToAction("Index", new
                //{
                //    ID = id

                //return View();

            



            }
            return View();
        }

        //Department Director Comments

        [HttpPost]
        public async Task<IActionResult> Page10DDPost(ProjectNotesVM projectNotesVM) {

            var datos = projectNotesVM;

            var query = (from p in _context.ProjectNotes
                         where p.ProjectNotesId == projectNotesVM.commentId
                         select p).FirstOrDefault();
            try {

                query.DepartmentDirectorComments = projectNotesVM.DepartmentDirector;
                _context.SaveChanges();





            } catch {
            
  
            
            }
      


            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Page10DCommentPost(ProjectNotesVM projectNotesVM)
        {

            var datos = projectNotesVM;

            var query = (from p in _context.ProjectNotes
                         where p.ProjectNotesId == projectNotesVM.commentId
                         select p).FirstOrDefault();
            try
            {

                query.DeanComments = projectNotesVM.DeanComments;
                _context.SaveChanges();





            }
            catch
            {
            }








            return Ok();
        }



        //Administrator Comments Page....

        public async Task<IActionResult> Page11(int? id) {

            var roleId = permissionService.GetCurrentUserRoleId(User);
            var permisos = permissionService.GetPermissionsForRole(roleId);

            ViewBag.Permissions = permisos;



            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }


            var AdminNotes = (from ad in _context.AdminOfficerComments
                              where ad.ProjectId == id
                              select ad).ToList();
            ProjectFormView projectFormView = new ProjectFormView { 
                ProjectNumber= project.ProjectNumber,
                AdminOfficerComments = AdminNotes
             
            };
            projectFormView.ProjectId = id.Value;



            return View(projectFormView);
        }


        [HttpPost]
        public async Task<IActionResult> Page11(int? id, ProjectFormView projectTemplate) {

            if (ModelState.IsValid) {

                AdminOfficerComment Admin = new AdminOfficerComment()
                {
                    AdComments = projectTemplate.AdComments,
                    ProjectVigency = projectTemplate.ProjectVigency,
                    ReviewDate = projectTemplate.ReviewDate,
                    WorkplanQuantity= projectTemplate.WorkplanQuantity,
                    FundsComments= projectTemplate.FundsComments,
                    ProjectId= projectTemplate.ProjectId


                };

                _context.Add(Admin);
                await _context.SaveChangesAsync();
            }



            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Page11Post(CommentsVM template)
        {
            int id = int.Parse(template.projectId);
            bool redirect = true;
            string url = Url.Action("Page11", "Projects", new { id = id });

            



            try
            {
                AdminOfficerComment Comments = new AdminOfficerComment() { 
                
                    AdComments = template.adComments,
                    ProjectId = id
                    , ReviewDate = template.reviewDate,
                    ProjectVigency= template.projectVigency,
                    WorkplanQuantity = template.workplanQuantity,
                    FundsComments= template.fundsComments,
                    Username = User.Identity.Name,
                    UserRole= template.userRole




                };
                _context.Add(Comments);

                 _context.SaveChanges();





            }
            catch
            {

            }








            return Json(new { redirect = redirect, url = url });
        }






        public async Task<IActionResult> ProjectReview(int id)
        {
            if (_context.Projects == null)
                return NotFound();

            var project = await _context.Projects
                .Include(p => p.Comm)
                .Include(p => p.Department)
                .Include(p => p.FiscalYear)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProgramArea)
                .Include(p => p.Porganizations)
                .Include(p => p.Roster)
                .Include(p => p.SubStation)
                .Include(p => p.FundType)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
                return NotFound();

            var template = new ProjectFormView
            {
                ProjectNumber = project.ProjectNumber,
                ProjectId = project.ProjectId,
                CommId = project.CommId,
                RosterId = project.RosterId,
                ProgramAreaId = project.ProgramAreaId,
                PorganizationsId = project.PorganizationsId,
                Roster = project.Roster,
                ContractNumber = project.ContractNumber,
                Orcid = project.Orcid,
                Substation = project.Substation,
                Projects = project,
                //projects = new List<Project> { project },
                ProjectTitle = project.ProjectTitle,

                fieldsWork = await _context.FieldWorks.
                Include( f => f.Fieldoption )
                .Include(f => f.Location)
                .Where(f => f.ProjectId == id).ToListAsync(),

                laboratories = await _context.Laboratories.Where(l => l.ProjectId == id).ToListAsync(),

                sciProjects = await _context.SciProjects
                .Include(s => s.SciRoles)
                .Where(s => s.ProjectId == id).ToListAsync(),

                otherPersonels = await _context.OtherPersonels
                .Include(op => op.Location)
                .Where(op => op.ProjectId == id).ToListAsync(),
                gradAsses = await _context.GradAsses
                .Include(g => g.Gradoption)
                .Include(g => g.ThesisProject)

                .Where(g => g.ProjectId == id).ToListAsync(),
                Fundss = await _context.Funds
                .Include(fu => fu.Location)
                .Where(fu => fu.ProjectId == id).ToListAsync()
            };

            return View(template);
        }




    }


}
