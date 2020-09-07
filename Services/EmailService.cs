using Carrington_Service.Infrastructure;
using Carrington_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Carrington_Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger Logger;
        private readonly IConfigHelper ConfigHelper;
        public EmailService(ILogger logger, IConfigHelper configHelper)
        {
            Logger = logger;
            ConfigHelper = configHelper;
        }
        public bool SendNotification(string emailBody)
        {
            try
            {
                string mailTo = ConfigHelper.Model.SMTP_To;
                string mailFrom = ConfigHelper.Model.SMTP_From;
                string mailBCC = string.Empty;
                string mailCC = string.Empty;
                string mailSubject = "NCP System Generated Mail. Please Do not Reply";
                string mailBody = emailBody;

                string FilePath = @"C:\NCP-Carrington\Input\EmailTemplate.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();

                //Repalce [newusername] = signup user name   
                MailText = MailText.Replace("[Receiver]", "Tim");
                MailText = MailText.Replace("[Sender]", "Bhawna");

                bool mailHTML = true;
                List<string> mailAttachmentPath = new List<string>();
                return SendMailMessage(mailTo, mailFrom, mailBCC, mailCC, mailSubject,
                    mailBody, mailAttachmentPath, mailHTML);
            }
            catch { return false; }
        }

        /// <summary>
        /// This helper class sends an email message using the System.Net.Mail namespace
        /// </summary>
        /// <param name="fromEmail">Sender email address</param>
        /// <param name="toEmail">Recipient email address</param>
        /// <param name="emailBcc">Blind carbon copy email address</param>
        /// <param name="emailCc">Carbon copy email address</param>
        /// <param name="mailSubject">Subject of the email message</param>
        /// <param name="mailBody">Body of the email message</param>
        /// <param name="attachment">File to attach</param>
        private bool SendMailMessage(string toEmail, string fromEmail, string emailCc, string emailBcc,
            string mailSubject, string mailBody, List<string> attachmentFullPath, bool htmlEnabled)
        {
            try
            {
                //create the MailMessage object
                MailMessage mMailMessage = new MailMessage();

                //set the sender address of the mail message
                if (!string.IsNullOrEmpty(fromEmail))
                {
                    mMailMessage.From = new MailAddress(fromEmail);
                }

                //set the recipient address of the mail message
                mMailMessage.To.Add(new MailAddress(toEmail));

                //set the carbon copy address
                if (!string.IsNullOrEmpty(emailCc))
                {
                    mMailMessage.CC.Add(new MailAddress(emailCc));
                }

                //set the blind carbon copy address
                if (!string.IsNullOrEmpty(emailBcc))
                {
                    mMailMessage.Bcc.Add(new MailAddress(emailBcc));
                }

                //set the subject of the mail message
                if (string.IsNullOrEmpty(mailSubject))
                {
                    mMailMessage.Subject = "NCP System Generated Mail. Please Do not Reply";
                }
                else
                {
                    mMailMessage.Subject = mailSubject;
                }

                //set the body of the mail message
                mMailMessage.Body = mailBody;

                //set the format of the mail message body
                mMailMessage.IsBodyHtml = htmlEnabled;

                //set the priority
                mMailMessage.Priority = MailPriority.Normal;

                //add any attachments from the filesystem
                foreach (string attachmentPath in attachmentFullPath)
                {
                    Attachment mailAttachment = new Attachment(attachmentPath);
                    mMailMessage.Attachments.Add(mailAttachment);
                }

                SmtpClient smtpClient;
                //create the SmtpClient instance

                if (!string.IsNullOrEmpty(ConfigHelper.Model.SMTP_Usr))
                {
                    smtpClient = new SmtpClient()
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(ConfigHelper.Model.SMTP_Usr, ConfigHelper.Model.SMTP_Pwd),
                        Port = ConfigHelper.Model.SMTP_Port,
                        Host = ConfigHelper.Model.SMTP_Host,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true,

                    };
                }
                else
                {
                    smtpClient = new SmtpClient()
                    {
                        UseDefaultCredentials = true,
                        Credentials = CredentialCache.DefaultNetworkCredentials,
                        Port = ConfigHelper.Model.SMTP_Port,
                        Host = ConfigHelper.Model.SMTP_Host,
                    };
                }

                //send the mail message
                smtpClient.Send(mMailMessage);
                smtpClient.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SendMailMessage");
                return false;
            }
            return true;
        }

    }
}
