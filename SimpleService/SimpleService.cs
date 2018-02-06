using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleService" in both code and config file together.
    public class SimpleService : ISimpleService
    {
        public string GetMessage(string message)
        {
            StringBuilder stringBuilder = new StringBuilder("Input Message: " + message);
            stringBuilder.AppendLine("Is Authenticated: " + ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated);
            stringBuilder.AppendLine("Authentication type: " + ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType);
            stringBuilder.AppendLine("Username: " + ServiceSecurityContext.Current.PrimaryIdentity.Name);

            List<string> groups = ServiceSecurityContext.Current.WindowsIdentity.Groups.Select(g => g.Value.ToString()).ToList();
            if(groups != null && groups.Any())
            {
                stringBuilder.AppendLine("Windows Identity Groups the user belongs to: \n              ");
                stringBuilder.AppendLine("Groups: " + string.Join(Environment.NewLine + "              ", groups.Select(s => s)));

            }

            stringBuilder.AppendLine("Windows Identity Name: " + ServiceSecurityContext.Current.WindowsIdentity.Name);
            stringBuilder.AppendLine("Windows Identity User value: " + ServiceSecurityContext.Current.WindowsIdentity.User.Value);
            stringBuilder.AppendLine("Windows Identity Is system: " + ServiceSecurityContext.Current.WindowsIdentity.IsSystem);

            Console.WriteLine(stringBuilder);

            return stringBuilder.ToString() ;
        }
    }
}
