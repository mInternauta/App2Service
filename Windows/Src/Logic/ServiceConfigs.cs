using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace App2Service.Logic
{
    public class ServiceConfigs
    {
        public static List<ServiceSet> Load()
        {
            List<ServiceSet> services = new List<ServiceSet>();
            string cfgFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Services.cfg");
            XmlSerializer xml = new XmlSerializer(services.GetType());

            if(File.Exists(cfgFile))
            {
                using (var stream = File.Open(cfgFile, FileMode.Open))
                {
                    services = (List<ServiceSet>)xml.Deserialize(stream);
                }
            }
            else
            {
                services.Add(new ServiceSet()
                {
                    Executable = "MyTest.exe",
                    Name = "MyName",
                    Parameters = "1 2"
                });

                using (var stream = File.Open(cfgFile, FileMode.OpenOrCreate))
                {
                    xml.Serialize(stream, services);
                    stream.Flush();
                }
            }

            return services;
        }
    }
}