using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using framework;
using framework.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ServiceHost.Infrastructure.RazorUtils
{
    public class RazorBase : PageModel
    {
        protected IApplicationContext _context { get; private set; }
        protected ILogger _logger { get; private set; }
        public RazorBase(IApplicationContext context, ILogger logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> TryCatch(Func<Task<ResultModel>> func,
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
                    case ResultModelStatus.Success:
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
                    case ResultModelStatus.Error:
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
                    case ResultModelStatus.NotFound:
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
                var res = ResultModel.Error(errorMessage ?? message);
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
        public async Task<IActionResult> TryCatch<T>(Func<Task<ResultModel<T>>> func,
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
                    case ResultModelStatus.Success:
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
                    case ResultModelStatus.Error:
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
                    case ResultModelStatus.NotFound:
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
                var res = ResultModel.Error(errorMessage ?? message);
                var jsonResult = JsonConvert.SerializeObject(res);
                TempData["Error"] = jsonResult;
                if (errorReturn != null)
                {
                    return Redirect(errorReturn);
                }
                return Page();
            }
        }
        public async Task<ContentResult> AjaxTryCatch(Func<Task<ResultModel>> func,
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
                    case ResultModelStatus.Success:
                        {
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case ResultModelStatus.Error:
                        {
                            model.IsReloadPage = isErrorReloadPage;
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case ResultModelStatus.NotFound:
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
                var res = ResultModel.Error(message);
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
        public async Task<ContentResult> AjaxTryCatch<T>(Func<Task<ResultModel<T>>> func,
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
                    case ResultModelStatus.Success:
                        {
                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case ResultModelStatus.Error:
                        {
                            model.IsReloadPage = isErrorReloadPage;

                            var jsonResult = JsonConvert.SerializeObject(model);
                            return Content(jsonResult);
                        }
                    case ResultModelStatus.NotFound:
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
                var res = ResultModel.Error(message);
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
            public ResultModelStatus Status { get; set; }
        }
    }
}