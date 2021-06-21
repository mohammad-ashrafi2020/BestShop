using framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Common.Application;
using Common.Core.Utilities;

namespace ServiceHost.Infrastructure.RazorUtils
{
    public class RazorBase : PageModel
    {
        protected IApplicationContext Context { get; private set; }
        protected ILogger Logger { get; private set; }
        public RazorBase(IApplicationContext context, ILogger logger)
        {
            Logger = logger;
            Context = context;
        }
        public async Task<IActionResult> TryCatch(Func<Task<OperationResult>> func,
            string successReturn = null,
            string successMessage = null,
            string successTitle = null,
            string errorReturn = null,
            bool showAlert = true,
            string errorMessage = null)
        {
            try
            {
                var res = await func();
                switch (res.Status)
                {
                    case OperationResultStatus.Success:
                        {
                            if (successTitle != null)
                                res.Title = successTitle;
                            if (successMessage != null)
                                res.Message = successMessage;
                            var jsonResult = JsonConvert.SerializeObject(res);
                            TempData["Success"] = jsonResult;
                            if (successReturn != null)
                            {
                                return Redirect(successReturn);
                            }
                            return Page();
                        }
                    case OperationResultStatus.Error:
                        {
                            if (errorMessage != null)
                                res.Message = errorMessage;
                            var jsonResult = JsonConvert.SerializeObject(res);
                            TempData["Error"] = jsonResult;
                            if (errorReturn != null)
                            {
                                return Redirect(errorReturn);
                            }
                            return Page();
                        }
                    case OperationResultStatus.NotFound:
                        {
                            res.Title ??= "نتیجه ای یافت نشد";
                            var jsonResult = JsonConvert.SerializeObject(res);
                            TempData["NotFound"] = jsonResult;
                            if (errorReturn != null)
                            {
                                return Redirect(errorReturn);
                            }
                            return Page();
                        }
                    default:
                        return Page();

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message.IsUniCode() ? ex.Message : "عملیات ناموفق بود";
                var res = OperationResult.Error(errorMessage ?? message);
                res.Title = "اعملیات ناموفق";
                var jsonResult = JsonConvert.SerializeObject(res);
                TempData["Error"] = jsonResult;
                if (errorReturn != null)
                {
                    return Redirect(errorReturn);
                }
                return Page();
            }
        }
        public async Task<IActionResult> TryCatch<T>(Func<Task<OperationResult<T>>> func,
            string successReturn = null,
            string successMessage = null,
            string successTitle = null,
            string errorReturn = null,
            bool showAlert = true,
            string errorMessage = null)
        {
            try
            {
                var res = await func();
                res.Data = default(T);

                switch (res.Status)
                {
                    case OperationResultStatus.Success:
                        {
                            if (successTitle != null)
                                res.Title = successTitle;
                            if (successMessage != null)
                                res.Message = successMessage;
                            var jsonResult = JsonConvert.SerializeObject(res);
                            TempData["Success"] = jsonResult;
                            if (successReturn != null)
                            {
                                return Redirect(successReturn);
                            }
                            return Page();
                        }
                    case OperationResultStatus.Error:
                        {
                            if (errorMessage != null)
                                res.Message = errorMessage;
                            var jsonResult = JsonConvert.SerializeObject(res);
                            TempData["Error"] = jsonResult;
                            if (errorReturn != null)
                            {
                                return Redirect(errorReturn);
                            }
                            return Page();
                        }
                    case OperationResultStatus.NotFound:
                        {
                            var jsonResult = JsonConvert.SerializeObject(res);
                            TempData["NotFound"] = jsonResult;
                            if (errorReturn != null)
                            {
                                return Redirect(errorReturn);
                            }
                            return Page();
                        }
                    default:
                        return Page();

                }

            }
            catch (Exception ex)
            {
                var message = ex.Message.IsUniCode() ? ex.Message : "عملیات ناموفق بود";
                var res = OperationResult.Error(errorMessage ?? message);
                var jsonResult = JsonConvert.SerializeObject(res);
                TempData["Error"] = jsonResult;
                if (errorReturn != null)
                {
                    return Redirect(errorReturn);
                }
                return Page();
            }
        }
        public async Task<ContentResult> AjaxTryCatch(Func<Task<OperationResult>> func,
            bool isSuccessReloadPage = false,
            bool isErrorReloadPage = false)
        {
            try
            {
                var res = await func();
                var model = new AjaxResult()
                {
                    Status = res.Status,
                    Title = res.Title,
                    IsReloadPage = isSuccessReloadPage,
                    Message = res.Message
                };
                switch (res.Status)
                {
                    case OperationResultStatus.Success:
                        {
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case OperationResultStatus.Error:
                        {
                            model.IsReloadPage = isErrorReloadPage;
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case OperationResultStatus.NotFound:
                        {
                            model.IsReloadPage = isErrorReloadPage;
                            model.Title ??= "نتیجه ای یافت نشد";
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    default:
                        return Content("Success");

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message.IsUniCode() ? ex.Message : "عملیات ناموفق بود";
                var res = OperationResult.Error(message);
                var model = new AjaxResult()
                {
                    Status = res.Status,
                    Title = res.Title,
                    IsReloadPage = isErrorReloadPage,
                    Message = res.Message
                };
                var jsonResult = JsonConvert.SerializeObject(model);
                return Content(jsonResult);
            }
        }
        public async Task<ContentResult> AjaxTryCatch<T>(Func<Task<OperationResult<T>>> func,
            bool isSuccessReloadPage = false,
            bool isErrorReloadPage = false)
        {
            try
            {
                var res = await func();
                var model = new AjaxResult()
                {
                    Status = res.Status,
                    Title = res.Title,
                    IsReloadPage = isSuccessReloadPage,
                    Message = res.Message,
                    Data = res.Data
                };
                switch (res.Status)
                {
                    case OperationResultStatus.Success:
                        {
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case OperationResultStatus.Error:
                        {
                            model.IsReloadPage = isErrorReloadPage;

                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case OperationResultStatus.NotFound:
                        {
                            model.IsReloadPage = isErrorReloadPage;

                            model.Title ??= "نتیجه ای یافت نشد";
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    default:
                        return Content("Success");

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message.IsUniCode() ? ex.Message : "عملیات ناموفق بود";
                var res = OperationResult.Error(message);
                var model = new AjaxResult()
                {
                    Status = res.Status,
                    Title = res.Title,
                    IsReloadPage = isErrorReloadPage,
                    Message = res.Message
                };
                var jsonResult = JsonConvert.SerializeObject(model);
                return Content(jsonResult);
            }
        }

        public class AjaxResult
        {
            public string Message { get; set; }
            public string Title { get; set; }
            public bool IsReloadPage { get; set; }
            public Object Data { get; set; }
            public OperationResultStatus Status { get; set; }
        }
    }
}