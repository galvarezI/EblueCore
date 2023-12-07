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

namespace EblueWorkPlan.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly WorkplandbContext _context;
        private List<SelectListItem> _rosterItems;
        private List<SelectListItem> _departmentsItems;
        private List<SelectListItem> _porganizationsItems;

        private List<SelectListItem> _fundtypeItems;
        private List<SelectListItem> _commodityItems;
        private List<SelectListItem> _fiscalYearItems;
        private List<SelectListItem> _substationItems;
        private List<SelectListItem> _programAreaItems;
        private List<SelectListItem> _locationsItems;
        public ProjectsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Projects

        public async Task<IActionResult> Index()
        {


            var workplandbContext = _context.Projects.Include(p => p.Comm).Include(p => p.Department).Include(p => p.FiscalYear).Include(p => p.ProgramArea).Include(p => p.Roster)/*.Include(ps => ps.ProjectStatus)*/;
            //await workplandbContext.ToListAsync())






            return View(await workplandbContext.ToListAsync());
        }

        public IActionResult IndexVM()
        {


            ViewModelIndex viewModelIndex = new ViewModelIndex();
            //IndexViewModel indexViewModel = new IndexViewModel();

            //var projectlist = (from p in _context.Projects
            //                   join r in _context.Rosters on p.RosterId equals r.RosterId
            //                   join ps in _context.ProjectStatuses on p.ProjectStatusId equals ps.ProjectstatusId
            //                   select new IndexViewModel
            //                   {
            //                      projectId= p.ProjectId,
            //                      projectNumber= p.ProjectNumber,
            //                      projectTitle= p.ProjectTitle,
            //                      accountNumber = p.Orcid,
            //                      contractNumber= p.ContractNumber,
            //                      ProjectstatusId= ps.ProjectstatusId,
            //                      StatusName= ps.StatusName,
            //                      RosterId = r.RosterId,
            //                      RosterName = r.RosterName,
            //                      projectPI = r.RosterName







            //                   }).ToList();

            //IndexViewModel modelo = _context.Projects.Include(ps => ps.ProjectStatus).Include(r => r.Roster)
            //.Select(p => new IndexViewModel()
            //{

            //    ProjectId = p.ProjectId,
            //    projectNumber = p.ProjectNumber,
            //    accountNumber = p.Orcid,
            //    projectTitle = p.ProjectTitle,
            //    contractNumber = p.ContractNumber,
            //    projectstatus = p.ProjectStatus.Select(ps => new ProjectStatusViewModel()
            //    {

            //        ProjectstatusId = ps.ProyectStatusId,
            //        StatusName = ps.StatusName,




            //    }).ToList(),
            //    rosterPI = p.Roster.Select(r => new RosterViewModel()
            //    {



            //    })

            //})











            return View(viewModelIndex);
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
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public async Task<IActionResult> Create()
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






            //ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true),"RosterID","RosterName");
            //ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");

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

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //public async Task<IActionResult> Create([Bind("ProjectId,ProjectNumber,ProjectTitle,ProjectPi,DepartmentId,CommId,ProgramAreaId,SubStationId,DateRegister,Salaries,Materials,Equipment,Travel,Abroad,Others,Wfsid,Wfupdate,StartDate,TerminationDate,FundTypeId,ContractNumber,Orcid,PorganizationsId,LocationId")] Project project)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(project);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));

        //    }
        //    ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterName");
        //    ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");
        //    ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommId", project.CommId);
        //    ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", project.DepartmentId);
        //    ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearId", project.FiscalYearId);
        //    ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaId", project.ProgramAreaId);
        //    return View(project);
        //}

        [HttpPost]

        [ValidateAntiForgeryToken]

        //[Bind("ProjectId,ProjectNumber,ProjectTitle,ProjectPi,DepartmentId,CommId,ProgramAreaId,SubStationId,DateRegister,Salaries,Materials,Equipment,Travel,Abroad,Others,Wfsid,Wfupdate,StartDate,TerminationDate,FundTypeId,ContractNumber,Orcid,PorganizationsId,LocationId")] Project project

        public async Task<IActionResult> Create(ProjectViewModel template)
        {


            ProjectViewModel projects = new ProjectViewModel();



            if (ModelState.IsValid)
            {
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

                    RosterId = template.RosterId,
                    FiscalYearId = template.FiscalYearId,


                };
                var Fundtype = new FundType()
                {
                    FundTypeName = template.OtherFundtype

                };

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
                    projectName = project.ProjectTitle
                });
            }





            return View();
        }

        //GET WORKPLAN PAGE 1:







        public async Task<IActionResult> ProjectDetails(int? id)
        {
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

            ViewBag.CommoditiesItem = new SelectList(_context.Commodities, "CommId", "CommName");
            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.FiscalYearItem = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName");
            ViewBag.ProgramAreaItem = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName");
            ViewBag.POrganizationItem = new SelectList(_context.Porganizations, "PorganizationId", "PorganizationName");
            ViewBag.FundTypeItem = new SelectList(_context.FundTypes, "FundTypeId", "FundTypeName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");



            ViewData["CommId"] = new SelectList(_context.Commodities, "CommId", "CommName", project.CommId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", project.DepartmentId);
            ViewData["FiscalYearId"] = new SelectList(_context.FiscalYears, "FiscalYearId", "FiscalYearName", project.FiscalYearId);
            ViewData["ProgramAreaId"] = new SelectList(_context.ProgramAreas, "ProgramAreaId", "ProgramAreaName", project.ProgramAreaId);
            ViewData["SubstationId"] = new SelectList(_context.Substacions, "SubStationId", "SubStationName", project.SubStationId);




            return View(project);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ProjectDetails(int id, [Bind("ProjectId,ProjectNumber,ProjectTitle,DepartmentId,CommId,ProgramAreaId,SubStationId,ProjectStatusId,FiscalYearId,ProjectPi")] Models.Project project)
        {


            if (id != project.ProjectId)
            {
                return NotFound();
            }
            #region depreceated
            /*
             * 
             *  try
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
             
             */
            #endregion

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



        //Project : WorkPlan Page 2, Process 1>

        public async Task<IActionResult> Page2(int? id, FieldWork fieldwork)
        {
            ProjectFormView template= new ProjectFormView();

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            template.ProjectId = project.ProjectId;
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


        //Project : WorkPlan Page 2, Process 1>

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Objectives,ObjWorkPlan,PresentOutlook")] in case to use it.
        public async Task<IActionResult> Page2(int id,  ProjectFormView template, Models.Project project  )
        {
            ProjectFormView projectTemplate = new ProjectFormView();


        


            if (ModelState.IsValid) {



                //Esta parte ocasiona un error....
                 FieldWork fieldwork = new FieldWork()
                {
                    LocationId = (int)template.LocationId,
                    DateStarted = template.DateStarted,
                    DateEnded = template.DateEnded,
                    InProgress = template.InProgress,
                    ToBeInitiated = template.ToBeInitiated,
                    Area = template.Area,
                    ProjectId = project.ProjectId
                    





                     };
                _context.Add(fieldwork);
                await _context.SaveChangesAsync();

                template.ProjectId = project.ProjectId;
                template.ProjectTitle = project.ProjectTitle;
                return RedirectToAction("Page3", new
                {
                    ID = template.ProjectId,
                    projectName = template.ProjectTitle
                });
            }

           
            return View();



        }







        public ActionResult RedirectTo(string action, string controller)
        {
            return RedirectToAction(action, controller);
        }







        public async Task<IActionResult> ProjectList(int? id, Models.Project project)
        {
            ProjectFormView projectTemplate = new ProjectFormView();

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            projectTemplate.ProjectId = id.Value;
            return View(projectTemplate);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectList( Models.   Project project, int id) {

            

            

           

            if (ModelState.IsValid)
            {
                try
                {

                    var query = (from p in _context.Projects
                                 where p.ProjectId == project.ProjectId
                                 select
                                 p).FirstOrDefault();

                    query.Objectives = project.Objectives;
                    query.Objectives2= project.Objectives2;
                    query.Objectives3= project.Objectives3;
                    query.Objectives4= project.Objectives4;
                    query.Objectives5= project.Objectives5;
                    query.Objectives6= project.Objectives6;
                    query.ObjWorkPlan = project.ObjWorkPlan;
                    query.PresentOutlook = project.PresentOutlook;


                    _context.SaveChanges();
                   
                 


                    //var result = _context.Projects
                    //    .FromSqlInterpolated($"EXEC ActualizarPag1 @ProjectId = {projectTemplate.ProjectId} ,@Objectives = {projectTemplate.Objectives},@ObjWorkPlan = {projectTemplate.ObjWorkPlan},@PresentOutlook = {projectTemplate.PresentOutlook}").AsAsyncEnumerable();



                      
                    //_context.Update(project);
                    //await _context.SaveChangesAsync();



                    return RedirectToAction("Page2", new
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
                return View();

            }

            return View();
        }





        // Page 3:
        public async Task<IActionResult> Page3(int? id, ProjectFormView projectTemplate) {

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }


            projectTemplate.ProjectId = id.Value;

            return View(projectTemplate);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Page3(int? id, Models.Project project, ProjectFormView projectTemplate) {
            if (ModelState.IsValid)
            {
                Laboratory laboratory = new Laboratory()
                {


                    
                    WorkPlanned = projectTemplate.WorkPlanned,
                    Descriptions = projectTemplate.Descriptions,
                    EstimatedTime = projectTemplate.EstimatedTime,
                    FacilitiesNeeded = projectTemplate.FacilitiesNeeded,
                    ProjectId = projectTemplate.ProjectId




                };
                _context.Add(laboratory);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page4", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });




            }

           
            return View();
        }



        //Page 4> Analitical

        public async Task<IActionResult> Page4(int? id, ProjectFormView projectTemplate) {

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            projectTemplate.ProjectId = id.Value;




            return View(projectTemplate);
        }






        [HttpPost]
        public async Task<IActionResult> Page4(int? id, Models.Project project, ProjectFormView projectTemplate) {
            
            if (ModelState.IsValid) {
                Analytical analytical = new Analytical()
                {
                        AnalysisRequired= projectTemplate.AnalysisRequired,
                        NumSamples= projectTemplate.NumSamples,
                        ProbableDate= projectTemplate.ProbableDate,
                        ProjectId= projectTemplate.ProjectId

                };
                _context.Add(analytical);
                await _context.SaveChangesAsync();

               
                return RedirectToAction("Page5", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });

            }
        
        
        
        
        
            return View();
        }





        public async Task<IActionResult> Page5(int? id, ProjectFormView projectTemplate) {

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
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

            return View(projectTemplate);
        }


        [HttpPost]
        public async Task<IActionResult> Page5(int? id,     Models.Project project, ProjectFormView projectTemplate) {
            
            if (ModelState.IsValid) {
                SciProject sciProject = new SciProject() { 
                
                    RosterId = (int)projectTemplate.RosterId,
                    Roles= projectTemplate.Roles,
                    Credits= projectTemplate.Credits,
                    Tr = projectTemplate.Tr,
                    Ca = projectTemplate.Ca,
                    Ah= projectTemplate.Ah,
                    AdHonorem= projectTemplate.AdHonorem,
                    ProjectId= project.ProjectId
                
                
                
                
                };
                _context.Add(sciProject);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page6", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });


            }
        
        
        
        
        
            return View();
        }



        public async Task<IActionResult> Page6(int? id, ProjectFormView projectTemplate) {

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            projectTemplate.ProjectId = id.Value;
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

        public async Task<IActionResult> Page6(int? id, Models.Project project, ProjectFormView projectTemplate) {
            if (ModelState.IsValid) {

                OtherPersonel otherPersonel = new OtherPersonel() {

                    Name = projectTemplate.Name,
                    PerTime= projectTemplate.PerTime,
                    LocationId= projectTemplate.LocationId,
                    RosterId = projectTemplate.RosterId,
                    PersonnelManAdded= projectTemplate.PersonnelManAdded,
                    RoleManAdded= projectTemplate.RoleManAdded,
                    ProjectId= projectTemplate.ProjectId
                
                
                
                
                
                
                
                };
                _context.Add(otherPersonel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page7", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });



            }

            return View();



        }

        public async Task<IActionResult> Page7(int? id, ProjectFormView projectTemplate) {



            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }


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
                    Amount= projectTemplate.Amount,
                    RoleId= projectTemplate.RoleId,
                    StudentName= projectTemplate.StudentName,
                    IsGraduated= projectTemplate.IsGraduated,
                    IsUndergraduated= projectTemplate.IsUndergraduated,
                    ProjectId= project.ProjectId
                
                
                
                
                
                
                
                };
                _context.Add(gradAss);
                await _context.SaveChangesAsync();
                return RedirectToAction("Page8", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });


            }
        
        
            return View();
        }






        public async Task<IActionResult> Page8(int? id, ProjectFormView projectTemplate) {

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

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
                  ProjectId= project.ProjectId




                };
                _context.Add(fund);
                await _context.SaveChangesAsync();

                return RedirectToAction("Page9", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });

            }





            return View();
        }

        // Workplan Page 9>

        public async Task<IActionResult> Page9(int? id, ProjectFormView projectTemplate, ProjectViewModel projectViewModel)
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


            projectViewModel.ProjectId = id.Value;

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
                    
                    query.Facilities= projectTemplate.Facilities;
                    query.Impact = projectTemplate.Impact;
                    query.Salaries = projectTemplate.Salaries;
                    query.Materials = projectTemplate.Materials;
                    query.Equipment = projectTemplate.Equipment;
                    query.Travel = projectTemplate.Travel;
                    query.Abroad= projectTemplate.Abroad;
                    query.Others= projectTemplate.Others;
                    query.Wages= projectTemplate.Wages;
                    query.Benefits= projectTemplate.Benefits;
                    query.Assistant= projectTemplate.Assistant;
                    query.Subcontracts = projectTemplate.Subcontracts;
                    query.IndirectCosts = projectTemplate.IndirectCosts;

                    
                    await _context.SaveChangesAsync();



                    return RedirectToAction(nameof(Index));



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
    }
    

    
}
