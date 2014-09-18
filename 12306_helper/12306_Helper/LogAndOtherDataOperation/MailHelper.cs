using System;
using System.Collections.Generic;
using System.Text;

namespace _12306_Helper
{
	public class MailHelper
	{
		/// <summary>
		/// 邮件服务器定义
		/// </summary>
		public class MailDomain
		{
			/// <summary>
			/// 服务器地址
			/// </summary>
			public string ServerDomain { get; set; }
			/// <summary>
			/// 服务器端口
			/// </summary>
			public int ServerPort { get; set; }
			/// <summary>
			/// 登陆用户名
			/// </summary>
			public string MailUser { get; set; }
			/// <summary>
			/// 登陆密码
			/// </summary>
			public string MailPass { get; set; }

			/// <summary>
			/// 创建 <see cref="MailDomain" /> 的新实例
			/// </summary>
			public MailDomain(string serverDomain, int serverPort, string mailUser, string mailPass)
			{
				ServerDomain = serverDomain;
				ServerPort = serverPort;
				MailUser = mailUser;
				MailPass = mailPass;
			}

			/// <summary>
			/// 创建 <see cref="MailDomain" /> 的新实例
			/// </summary>
			public MailDomain(string serverDomain, string mailUser, string mailPass)
			{
				this.ServerPort = 25;
				ServerDomain = serverDomain;
				MailUser = mailUser;
				MailPass = mailPass;
			}
		}

		/// <summary>
		/// 用预设的邮箱发送邮件
		/// </summary>
		/// <remarks></remarks>
		public static Exception SendEmail(MailDomain server, System.Net.Mail.MailMessage message)
		{
			System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
			client.Host = server.ServerDomain;
			client.Port = server.ServerPort;

			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(server.MailUser, server.MailPass);
			client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

			try
			{
				client.Send(message);
				return null;
			}
			catch (Exception e)
			{
				return e;
			}
		}

		/// <summary>
		/// 快速发送邮件
		/// </summary>
		/// <param name="server"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="subject"></param>
		/// <param name="body"></param>
		/// <returns></returns>
		public static Exception SendEmail(MailDomain server, string from, string to, string subject, string body)
		{
			System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
			client.Host = server.ServerDomain;
			client.Port = server.ServerPort;

			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(server.MailUser, server.MailPass);
			client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

			try
			{
				client.Send(from, to, subject, body);
				return null;
			}
			catch (Exception e)
			{
				return e;
			}
		}

		/// <summary>
		/// 用预设的邮箱发送邮件
		/// </summary>
		/// <param name="FromMail"></param>
		/// <param name="Subject"></param>
		/// <param name="Body"></param>
		/// <remarks></remarks>
		public static Exception SendEmail(MailDomain server, string FromMail, string FromUser, string Subject, string Body, System.Text.Encoding BodyEncoding, params System.Net.Mail.MailAddress[] ToUsers)
		{
			System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
			message.From = new System.Net.Mail.MailAddress(FromMail, FromUser, BodyEncoding);
			message.Subject = Subject;
			message.SubjectEncoding = BodyEncoding;
			message.Body = Body;
			message.BodyEncoding = BodyEncoding;

			foreach (System.Net.Mail.MailAddress ma in ToUsers)
			{
				message.To.Add(ma);
			}

			message.BodyEncoding = BodyEncoding;
			message.IsBodyHtml = true;

			return SendEmail(server, message);
		}

	}
}
