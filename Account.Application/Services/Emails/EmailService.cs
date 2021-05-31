using System;
using System.Net.Mail;
using Account.Application.Models.DTOs.Account;
using AngleSharp;
using framework.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Account.Application.Services.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IHttpContextAccessor _accessor;

        private string SiteBaseUrl { get; }
        private EmailConfig Options { get; }

        public EmailService(IHttpContextAccessor accessor, IOptions<EmailConfig> emailConfig)
        {
            _accessor = accessor;
            SiteBaseUrl = $"{_accessor.HttpContext.Request.Scheme}://{_accessor.HttpContext.Request.Host}";
            Options = emailConfig.Value;
        }

        public void SendForgotPassword(UserDto user, string url)
        {
            var body = $"<h2 style='text-align:center'> سلام {user.FullName} </h2><h4> برای تغییر کلمه عبور روی لینک زیر کلیک کنید </h4><a href='{SiteBaseUrl}/{url}' style='font-size:14px' >تغییر کلمه عبور</a></div>";
            Send(user.Email, "فراموشی کلمه عبور", BuildView(body));
        }

        #region Utils
        private void Send(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Options.SmtpServer);
                mail.From = new MailAddress(Options.EmailAddress, Options.DisplayName);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                //System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                // mail.Attachments.Add(attachment);

                SmtpServer.Port = Options.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Options.EmailAddress, Options.Password);
                SmtpServer.EnableSsl = Options.EnableSsl;
                SmtpServer.Send(mail);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                // ignored
            }

        }
        private string BuildView(string body)
        {
            var styleBody = @"*{-webkit-font-smoothing:antialiased;}body{Margin:0;padding:0;min-width:100%;-webkit-font-smoothing:antialiased;mso-line-height-rule:exactly;}table{border-spacing:0;color:#333333;}img{border:0;}.wrapper{width:100%;table-layout:fixed;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;}.webkit{max-width:600px;}.outer{Margin:0auto;width:100%;max-width:600px;}
                            .full-width-imageimg{width:100%;max-width:600px;height:auto;}.inner{padding:10px;}p{Margin:0;padding-bottom:10px;}.h1{font-size:21px;font-weight:bold;Margin-top:15px;Margin-bottom:5px;font-family:Arial,sans-serif;-webkit-font-smoothing:antialiased;}
                            .h2{font-size:18px;font-weight:bold;Margin-top:10px;Margin-bottom:5px;-webkit-font-smoothing:antialiased;}.one-column.contents{text-align:left;-webkit-font-smoothing:antialiased;}.one-columnp{font-size:14px;Margin-bottom:10px;-webkit-font-smoothing:antialiased;}.two-column{text-align:center;font-size:0;}.two-column.column{width:100%;max-width:300px;display:inline-block;vertical-align:top;}.contents{width:100%;}.two-column.contents{font-size:14px;text-align:left;}.two-columnimg{width:100%;max-width:280px;height:auto;}
                            .two-column.text{padding-top:10px;}.three-column{text-align:center;font-size:0;padding-top:10px;padding-bottom:10px;}.three-column.column{width:100%;max-width:200px;display:inline-block;vertical-align:top;}.three-column.contents{font-size:14px;text-align:center;}.three-columnimg{width:100%;max-width:180px;height:auto;}.three-column.text{padding-top:10px;}.img-align-verticalimg{display:inline-block;vertical-align:middle;}";

            var tempBody = @$"<center  class='wrapper' style='width:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;'><table class='outer' align='center' cellpadding='0'cellspacing='0' border='0'style='border-spacing:0;Margin:0auto;width:100%;max-width:800px;'><tr><td style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;'><table border='0'width='100%'cellpadding='0'cellspacing='0'><tr><td><table style='width:100%;'cellpadding='0'cellspacing='0'border='0'><tbody><tr><td  align='center'><center><table  border='0' align='center' width='100%'cellpadding='0'cellspacing='0' style='Margin:0auto;'><tbody><tr><td class='one-column' style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;'>
                            <table border='0'cellpadding='0'cellspacing='0'width='100%' style=' border-spacing:0'><tr><td>&nbsp;</td></tr><tr><td align='center'>&nbsp;</td align=></tr><tr><td height='6'bgcolor='#1f3ca6' class='contents' style='width:100%; border-top-left-radius:10px; border-top-right-radius:10px'></td height=></tr></table></td></tr></tbody></table></center></td></tr></tbody></table></td></tr></table><table class='one-column' border='0'cellpadding='0'cellspacing='0'width='100%' style=' border-spacing:0'bgcolor='#f7f7f7'><tr>
                            <td  style='padding-left:40px;padding-right:40px;padding-top:0px;padding-bottom:40px'><div style='direction:rtl;font-family:Tahoma;font-size:12px'>{body}</div style=></tr></table><table width='100%' border='0'cellspacing='0'cellpadding='0'><tr><td><tablewidth='100%'cellpadding='0'cellspacing='0' border='0'bgcolor='#1f3ca6'><tr><td align='center'bgcolor='#1f3ca6' class='one-column' style='padding-top:4px;padding-bottom:4px;padding-right:10px;padding-left:10px;'><font style='font-size:17px;text-decoration:none;color:#ffffff;font-family:Verdana,Geneva,sans-serif;text-align:center'>
                            <h4 style='margin:0';><a href='{SiteBaseUrl}' target='_blank' style='color:#ffffff;text-decoration:none;'>{Options.DisplayName}</a></h4></font></td></tr></table></td></tr><tr><td><table width='100%'cellpadding='0'cellspacing='0' border='0'><tr><td height='6' bgcolor='#1f3ca6' class='contents' style='width:100%; border-bottom-left-radius:10px; border-bottom-right-radius:10px'></td height=></tr><tr><td>&nbsp;</td></tr></table width=></td></tr></table></td></tr></table></center>";

            var emailBody = $"<style type='text/css'>{styleBody}</style>{tempBody}";
            return emailBody;
        }

        #endregion
    }
}