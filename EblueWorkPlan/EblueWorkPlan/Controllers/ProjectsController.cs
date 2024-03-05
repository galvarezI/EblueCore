﻿using EblueWorkPlan.Models;
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
        private List<SelectListItem> _thesisItems;
        private List<SelectListItem> _gradItems;

        public ProjectsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Projects

        public async Task<IActionResult> Index()
        {


            var projects = await _context.Projects.Include(p => p.Comm)
                .Include(p => p.Department)
                .Include(p => p.FiscalYear)
                .Include(p => p.ProgramArea).Include(p => p.Roster).ToListAsync();
                
                /*.Include(ps => ps.ProjectStatus)*/;
            //await workplandbContext.ToListAsync())






            return View(projects);
        }

        public IActionResult IndexVM()
        {
        //    ProjectFormView template = new ProjectFormView();
        //    var queryRport = from p in _context.Projects
        //                     join rs in _context.Rosters on p.RosterId equals rs.RosterId

        //                     select new
        //                     {
        //                         RosterName = rs.RosterName,



        //                     };

        

            










            return View();
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
                    ProjectStatusId = 1

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


            var fieldworks =  (from f in _context.FieldWorks
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
        public async Task<IActionResult> PostFieldWorkData(FieldWorkView fieldWork)
        {
            var datos = fieldWork;
            var query = (from f in _context.FieldWorks
                         where f.FieldWorkId == fieldWork.fieldWorkId
                         select f).FirstOrDefault();
            try {
                query.FieldWorkId = fieldWork.fieldWorkId;
                query.Wfieldwork = fieldWork.wfieldwork;
                query.LocationId = fieldWork.locaionId;
                query.FieldoptionId = fieldWork.fieldoption;
                query.Area = fieldWork.area;
                
                query.DateStarted = DateTime.Parse(fieldWork.dateStarted);
                query.DateEnded = DateTime.Parse(fieldWork.dateEnded);
                //query.InProgress = fieldWork.inProgress;
                //query.ToBeInitiated = fieldWork.toBeInitiated;
                _context.SaveChanges();

            }
            catch{
            }

           
            return Ok();
        }


            //Project : WorkPlan Page 2, Process 1>

            [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Page2(int id,  ProjectFormView template, Models.Project project)
        {
            ProjectFormView projectTemplate = new ProjectFormView();


        


            if (ModelState.IsValid) {



                //Esta parte ocasiona un error....
                 FieldWork fieldwork = new FieldWork()
                {
                     Wfieldwork = template.Wfieldwork,
                    LocationId = (int)template.LocationId,
                    DateStarted = template.DateStarted,
                    DateEnded = template.DateEnded,
                    FieldoptionId = template.FieldoptionId,
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


     



     
        public IActionResult GetFieldWork(int fieldWorkId) 
        {
            return Ok(fieldWorkId);
        }


        public async Task<IActionResult> ProjectList(int? id, Models.Project project)
        {
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
            ProjectFormView projectTemplate = new ProjectFormView() {
                
                ProjectNumber = projectss.ProjectNumber
                
            };
            if (projects == null)
            {
                return NotFound();
            }

            if (projectTemplate == null)
            {



            }
            else {
                //if(projectTemplate.Objectives.)
                if (projectss.Objectives == null)
                {
                    projectTemplate.Objectives = "";
                }
                else {

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




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectList( Models.Project project, int id) {

            

            

           

            if (ModelState.IsValid)
            {
                try
                {

                    var query = (from p in _context.Projects
                                 where p.ProjectId == project.ProjectId
                                 select
                                 p).FirstOrDefault();

                    query.Objectives = project.Objectives;
                 
                    query.ObjWorkPlan = project.ObjWorkPlan;
                    query.PresentOutlook = project.PresentOutlook;


                    _context.SaveChanges();
                   
                 


                  



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
        public async Task<IActionResult> Page3(int? id ) {




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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Page3(int? id, Models.Project project, ProjectFormView projectTemplate) {
            if (ModelState.IsValid)
            {
                Laboratory laboratory = new Laboratory()
                {


                    
                    WorkPlanned = projectTemplate.WorkPlanned,
                    Descriptions = projectTemplate.Descriptions,
                    TimeEstimated = projectTemplate.TimeEstimated,
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
                query.ProjectId = projectTemplate.ProjectId;
                _context.SaveChanges();

            }
            catch
            {
            }


            return Ok();
        }


        //Page 4> Analitical

        public async Task<IActionResult> Page4(int? id ) {

            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }


            var analytical =(from a in _context.Analyticals
                             where a.ProjectId == id
                             select a).ToList();
            ProjectFormView projectTemplate = new ProjectFormView()
            {
                ProjectNumber = project.ProjectNumber,
                analyticals= analytical
                
            };

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
                    projectName = project.ProjectNumber
                    
                });

            }
        
        
        
        
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostPage4Data(AnalyticalVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.Analyticals
                         where f.AnalyticalId == projectTemplate.analitycalId
                         select f).FirstOrDefault();
            
            try
            {
                string dateFormat = string.Format("{0:dd/MM/yyyy}", projectTemplate.pblDate);
                query.AnalyticalId = projectTemplate.analitycalId;
                query.AnalysisRequired = projectTemplate.analysis;
                query.NumSamples = projectTemplate.numSamples;
                query.ProbableDate = DateTime.Parse(dateFormat);
                
                query.ProjectId = projectTemplate.ProjectId;
                _context.SaveChanges();

            }
            catch
            {
            }


            return Ok();
        }



        public async Task<IActionResult> Page5(int? id) {

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

            return View(projectTemplate);
        }


        [HttpPost]
        public async Task<IActionResult> Page5(int? id,Models.Project project, ProjectFormView projectTemplate) {
            
            if (ModelState.IsValid) {
                SciProject sciProject = new SciProject() { 
                    //
                    RosterId = (int)projectTemplate.RosterId,
                    
                 
                    Tr = projectTemplate.Tr,
                    Ca = projectTemplate.Ca,
                    Ah= projectTemplate.Ah,
                    Credits =projectTemplate.Tr + projectTemplate.Ca + projectTemplate.Ah,
                    ProjectId = projectTemplate.ProjectId
                
                
                
                
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

        [HttpPost]
        public async Task<IActionResult> PostPage5Data(SciProjectVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.SciProjects
                         where f.SciId == projectTemplate.sciPId
                         select f).FirstOrDefault();

            

            try
            {

                
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


                query.ProjectId = projectTemplate.projectId;
                _context.SaveChanges();

            }
            catch
            {
            }


            return Ok();
        }

        public async Task<IActionResult> Page6(int? id ) {
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
            var porciento = projectTemplate.PerTime * 100;

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



                return RedirectToAction("Page7", new
                {
                    ID = project.ProjectId,
                    projectName = project.ProjectTitle
                });



            }

            return View();



        }



        [HttpPost]
        public async Task<IActionResult> PostPage6Data(OtherPersonnelVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.OtherPersonels
                         where f.Opid == projectTemplate.Opid
                         select f).FirstOrDefault();
            try
            {
                query.Opid = projectTemplate.Opid;
                query.Name = projectTemplate.perName;

                query.LocationId = projectTemplate.locationid;
                query.RosterId = projectTemplate.rosterid;
                query.PerTime = projectTemplate.pertime;
                query.PersonnelManAdded = projectTemplate.personnelman;
                query.RoleManAdded = projectTemplate.roleman;
                query.ProjectId = projectTemplate.projectId;
                _context.SaveChanges();

            }
            catch
            {
            }


            return Ok();
        }
        public async Task<IActionResult> Page7(int? id) {



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
                    Amount= projectTemplate.Amount,
                    RoleId= projectTemplate.RoleId,
                    StudentName= projectTemplate.StudentName,
                    GradoptionId= projectTemplate.GradoptionId,
                    //IsGraduated= projectTemplate.IsGraduated,
                    //IsUndergraduated= projectTemplate.IsUndergraduated,
                    ProjectId= project.ProjectId,
                    ThesisProjectId= projectTemplate.ThesisProjectId,
                    
                
                
                
                
                
                
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
                query.Amount = projectTemplate.amount;
                query.StudentName = projectTemplate.studentName;
                query.GradoptionId = projectTemplate.gradoption;
                query.ThesisProjectId = projectTemplate.thesisid;
                //query.IsGraduated = projectTemplate.isGraduated;
                //query.IsUndergraduated = projectTemplate.isUndergraduated;
                query.ProjectId = projectTemplate.projectId;
                _context.SaveChanges();

            }
            catch
            {
            }


            return Ok();
        }



        public async Task<IActionResult> Page8(int? id ) {

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
                Fundss= funds
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

        [HttpPost]
        public async Task<IActionResult> PostPage8Data(FundVM projectTemplate)
        {
            var datos = projectTemplate;
            var query = (from f in _context.Funds
                         where f.FundId == projectTemplate.fundId
                         select f).FirstOrDefault();
            try
            {
                query.FundId = projectTemplate.fundId;
                query.LocationId = projectTemplate.locationId;

                query.Salaries = projectTemplate.salaries;
                query.Wages = projectTemplate.wages;
                query.Benefits = projectTemplate.benefit;
                query.Assistant = projectTemplate.assistant;
                query.Materials = projectTemplate.materials;
                query.Equipment = projectTemplate.equipment;
                query.Travel = projectTemplate.travel;
                query.Abroad= projectTemplate.abroad;
                query.Subcontracts = projectTemplate.subcontract;
                query.Others = projectTemplate.others;
                query.Ufisaccount= projectTemplate.ufisaccount;
                query.IndirectCosts = projectTemplate.indirectcosts;
                query.ProjectId = projectTemplate.projectId;
                _context.SaveChanges();

            }
            catch
            {
            }


            return Ok();
        }


        // Workplan Page 9>

        public async Task<IActionResult> Page9(int? id, ProjectFormView projectTemplate )
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
            ProjectViewModel projectViewModel = new ProjectViewModel() { ProjectNumber = project.ProjectNumber };
            
            projectViewModel.ProjectId = id.Value;
            projectViewModel.Facilities = project.Facilities;
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
                    
                    query.Facilities= projectTemplate.Facilities;
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



                    //return View();



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
            ProjectFormView projectViewModel = new ProjectFormView() { 
                ProjectNumber = project.ProjectNumber, 
                projectNotes= projectNotes
            };

            projectViewModel.ProjectId = id.Value;

            return View(projectViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Page10(int? id,  ProjectFormView projectForm)
        {
            if (ModelState.IsValid)
            {
                var UserName = (from us in _context.Rosters
                                where us.RosterId == projectForm.RosterId
                                select us).FirstOrDefault();
                ProjectNote notes = new ProjectNote()
                {
                    Comment = projectForm.Comment,
                    Username = UserName.RosterName,
                    LastUpdate = DateTime.Now,
                    ProjectId = id,
                    RosterId= projectForm.RosterId,
                    




                };
                _context.Add(notes);
                await _context.SaveChangesAsync();

                //return RedirectToAction("Index", new
                //{
                //    ID = id

                return View();

            



            }
            return View();
        }


        public async Task<IActionResult>  ReportView(int? id, Models.Project project)
        {
            #region dropdownlist
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
            foreach (var item in location)
            {

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;


            }


            #endregion






            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

             project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            ProjectFormView template = new ProjectFormView();
            var queryRport = from p in _context.Projects
                             join rs in _context.Rosters on p.RosterId equals rs.RosterId
                             where p.ProjectId == id
                             select new
                             {
                                 RosterName = rs.RosterName,



                             };


            return new ViewAsPdf("ReportView",project)
            {



            };
        }

       

        public async Task<IActionResult>ReportViewList(int? id)
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

            var query = (from p in _context.Projects
                         where p.ProjectId == id
                         select
                         p ).FirstOrDefault();
            var analytical = (from a in _context.Analyticals
                              where a.ProjectId == id
                              select a).ToList();

            var scientist = (from s in _context.SciProjects
                             where s.ProjectId == id
                             select s).ToList();

            var funds = (from fu in _context.Funds
                         where fu.ProjectId == id
                         select fu).ToList();

            var fieldwork = (from fi in _context.FieldWorks
                             where fi.ProjectId == id
                             select fi).ToList();

            var projectNotes = (from pno in _context.ProjectNotes
                                where pno.ProjectId == id
                                select pno).ToList();


            var Graduas = (from g in _context.GradAsses
                           where g.ProjectId == id
                           select g).ToList();

            var otherPersonel = (from op in _context.OtherPersonels
                                 where op.ProjectId == id
                                 select op).ToList();

            var laboratory = (from l in _context.Laboratories
                             where l.ProjectId == id
                             select l).ToList();

            ProjectFormView reportTemplate = new ProjectFormView() { 
            
                analyticals = analytical,
                sciProjects = scientist,
                Fundss = funds,
                fieldsWork= fieldwork,
                Project = query,
                gradAsses = Graduas,
                otherPersonels= otherPersonel,
                projectNotes= projectNotes,
                laboratories= laboratory

            
            
            };

            reportTemplate.ProjectId = id.Value;

            return View(reportTemplate);
        }



      


       


        [HttpPost]
        public async Task<IActionResult> Page2Modal(int? id , ProjectFormView projectTemplate)
        {
            id = projectTemplate.FieldWorkId;


            if(ModelState.IsValid)
            {
                var fieldatos = (from f in _context.FieldWorks
                                 where f.FieldWorkId == id
                                 select f).FirstOrDefault();

                fieldatos.Wfieldwork = projectTemplate.Wfieldwork;
                fieldatos.LocationId = projectTemplate.LocationId.Value;
                fieldatos.Area = projectTemplate.Area;
                fieldatos.InProgress = projectTemplate.InProgress;
                fieldatos.ToBeInitiated = projectTemplate.ToBeInitiated;
                fieldatos.DateStarted = projectTemplate.DateStarted;
                fieldatos.DateEnded = projectTemplate.DateEnded;

                await _context.SaveChangesAsync();
                
               
                projectTemplate.ProjectId = fieldatos.ProjectId;


                return RedirectToAction("Page3", new
                {
                    ID = projectTemplate.ProjectId
                });
            }
            


            return View();
        }

        public PartialViewResult Page3Modal(int? id)
        {
            var datos = (from l in _context.Laboratories
                             where l.LabId == id
                             select l).FirstOrDefault();


            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();
            

            ProjectFormView fieldView = new ProjectFormView()
            {
                WorkPlanned = datos.WorkPlanned,
                Descriptions = datos.Descriptions,
                FacilitiesNeeded = datos.FacilitiesNeeded,
                EstimatedTime = datos.EstimatedTime
            };

            return PartialView("_Page3Modal", fieldView);
        }

        [HttpPost]
        public async Task<IActionResult> Page3Modal(int? id, ProjectFormView projectTemplate)
        {
            id = projectTemplate.LabId;


            if (ModelState.IsValid)
            {
                var datos = (from l in _context.Laboratories
                             where l.LabId == id
                             select l).FirstOrDefault();

                datos.WorkPlanned= projectTemplate.WorkPlanned;
                datos.Descriptions = projectTemplate.Descriptions;
                datos.EstimatedTime = projectTemplate.EstimatedTime;
                datos.FacilitiesNeeded= projectTemplate.FacilitiesNeeded;

                await _context.SaveChangesAsync();


                projectTemplate.ProjectId = datos.ProjectId.Value;


                return RedirectToAction("Page4", new
                {
                    ID = projectTemplate.ProjectId
                });
            }





                return View();
        }



        public PartialViewResult Page4Modal(int? id)
        {
            var datos = (from a in _context.Analyticals
                         where a.AnalyticalId == id
                         select a).FirstOrDefault();


            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();


            ProjectFormView fieldView = new ProjectFormView()
            {   
                AnalyticalId = datos.AnalyticalId,
                AnalysisRequired = datos.AnalysisRequired,
                NumSamples = datos.NumSamples,
               
                ProbableDate = datos.ProbableDate
            };

            return PartialView("_Page4Modal", fieldView);
        }

        [HttpPost]
        public async Task<IActionResult> Page4Modal(int? id, ProjectFormView projectTemplate)
        {
            id = projectTemplate.AnalyticalId;


            if (ModelState.IsValid)
            {
                var datos = (from a in _context.Analyticals
                             where a.AnalyticalId == id
                             select a).FirstOrDefault();

                datos.AnalysisRequired = projectTemplate.AnalysisRequired;
                datos.NumSamples = projectTemplate.NumSamples;
                datos.ProbableDate = projectTemplate.ProbableDate;
                

                await _context.SaveChangesAsync();


                projectTemplate.ProjectId = datos.ProjectId.Value;


                return RedirectToAction("Page5", new
                {
                    ID = projectTemplate.ProjectId
                });
            }

                return View();

            }

            
        }


}
