using Grupo14_ONG.Models.mailService;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Grupo14_ONG.Services
{
    public static class mailService
    {
        public static async Task<Response> sendMailNotification(sendMailModel model)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("agustincuadrado22@gmail.com", "ONG");
            var to = new EmailAddress("luciana.a.arrua@gmail.com"); //a donde se envia el ContactForm
            var msg = MailHelper.CreateSingleEmail(from, to, model.subject, model.content, createBodyHtml(model.content,model.subject,model.email));
            Response response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return response;
        }
        private static string createBodyHtml(string content,string subject, string email)
        {

            string bodyHtml = @"<html>
                        <body>
                            <table style='height:100%;width:100%;'>
                                <tbody>
                                        <tr height='32' style='height: 32px'>
                                             <td>
                                               
                                            </td>
                                        </tr>
                                        <tr align='center'>
                                           <td>
                                                <table border='0' cellspacing='0' cellpadding='0' style='padding-bottom:20px; max-width:516px; min-width:220px'>
                                                    <tbody>
                                                                <td height='17'>
                                                                    &nbsp;
                                                                </td>
                                                            <tr>
                                                              <td>
                                                              <p style='text-align:center;font-family:arial;font-size:17px;color:#3d3d3d;font-weight:normal;line-height:27px;padding-right:20px;padding-left:20px'>" + subject + @"</p>
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                              <td>
                                                              <p style='text-align:center;font-family:arial;font-size:17px;color:#3d3d3d;font-weight:normal;line-height:27px;padding-right:20px;padding-left:20px'>"+ content + @"</p>
                                                              </td>
                                                            <tr>
                                                              <td>
                                                              <p style='text-align:center;font-family:arial;font-size:17px;color:#3d3d3d;font-weight:normal;line-height:27px;padding-right:20px;padding-left:20px'>Mail enviado por " + email + @"</p>
                                                              </td>
                                                            </tr>
                                                            </tr>
                                                            <tr>
                                                              <td>
                                                              <p style='text-align:center;font-family:arial;font-size:13px;color:#3d3d3d;font-weight:normal;line-height:27px;padding-right:20px;padding-left:20px'>Este es un email automático. Por favor, no responder a esta dirección.Puedes contactarnos en ongWeb.com</p>
                                                              </td>
                                                            </tr>
                                                    </tbody>
                                                </table>
                                           </td>     
                                        </tr>
                                        <tr height='32' style='height: 32px'>
                                             <td>
                                               
                                            </td>
                                        </tr>
                                </tbody>
                            </table>
                      </body>
                      </html>
                  ";



            return bodyHtml;
        }
    }
}
