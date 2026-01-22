using EblueWorkPlan.Models.ViewModels;
using EblueWorkPlan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class PermissionViewBagFilter : IActionFilter
{
    private readonly PermissionService _permissionService;

    public PermissionViewBagFilter(PermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Controller is Controller controller)
        {
            var user = context.HttpContext.User;

            if (user.Identity?.IsAuthenticated == true)
            {
                var roleId = _permissionService.GetCurrentUserRoleId(user);
                var permissions = _permissionService.GetPermissionsForRole(roleId);


                //  AQUÍ VA LA LÓGICA
                if (controller.ViewData.Model is BaseViewModel vm)
                {
                    vm.Permissions = permissions;
                }



                //  ESTA ES LA CLAVE
                controller.ViewBag.Permissions = permissions;
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
       
    }
}
