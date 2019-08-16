//MIT License
//Copyright(c) [2019]
//[Xylex Sirrush Rayne]
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DreadBot
{
    #region Static Plugin Methods
    public static class PluginManager
    {
        

        public static Dictionary<string, Plugin> plugins = new Dictionary<string, Plugin>(8);

        public static string getPluginList()
        {
            StringBuilder sb = new StringBuilder();

            if (plugins.Count == 0) { return "No Plugins Loaded."; }
            if (plugins.Count == 1) { return "1 Plugin Loaded.\n\n" + plugins.First().Key + "\n"; }
            else if (plugins.Count > 1)
            {
                sb.Append(plugins.Count + "Plugins Loaded.\n\n");
                foreach (string PluginID in plugins.Keys) { sb.Append(PluginID + "\n"); }
            }
            return sb.ToString();
        }

        public static void Init()
        {
            if (Directory.Exists(@"Plugins"))
            {
                string[] DllFiles = Directory.GetFiles(@"Plugins", @"*.dll");

                foreach (string dllFile in DllFiles)
                {
                    Plugin pluginObject = null;
                    try {
                        pluginObject = new Plugin(dllFile);
                        plugins.Add(pluginObject.PluginID, pluginObject);
                    }
                    catch { continue; }
                }
                foreach (Plugin plugin in plugins.Values)
                {
                    plugin.plugin.PostInit();
                }
            }
            else { Directory.CreateDirectory(@"Plugins"); }
        }

        
    }

    #endregion

    #region Plugin Objects

    public interface IDreadBotPlugin
    {
        string PluginID { get; }
        void Init();
        void PostInit();
    }

    public class Plugin
    {
        public string DllFileName { get; set; }
        public AssemblyName assemblyName { get; set; }
        public Assembly assembly { get; set; }
        public Type[] types { get; set; }
        public IDreadBotPlugin plugin { get; set; }
        public string PluginID { get; set; }
        public Plugin(string DllFile)
        {
            DllFileName = DllFile;

            try { assemblyName = AssemblyName.GetAssemblyName(DllFile); }
            catch (Exception e) { Logger.LogFatal("While loading Plugin " + DllFile + " threw getting assemblyname: " + e); throw e; }

            try { assembly = Assembly.Load(assemblyName); }
            catch (Exception e) { Logger.LogFatal("While loading Plugin " + DllFile + " threw loading assembly: " + e); throw e; }

            if (assembly == null) { Logger.LogFatal("While loading Plugin " + DllFile + " assembly is null"); throw new NullAssemplyPluginException(); }

            try { types = assembly.GetTypes(); }
            catch (Exception e) { Logger.LogFatal("While loading Plugin " + DllFile + " failed getting it's types: " + e); throw e; }

            foreach(Type type in types)
            {
                int t = types.Count();
                int i = 1;

                if (type.IsClass) 
                {

                    if (type.GetInterface(typeof(IDreadBotPlugin).FullName) != null)
                    {
                        try { plugin = (IDreadBotPlugin)Activator.CreateInstance(type); }
                        catch (Exception e) { Logger.LogFatal("Failed to Activate Plugin instance. " + DllFileName + "\r\nPlugin Will be Skipped. Exception: " + e); throw e; }
                        
                        try
                        {
                            plugin.Init();
                            PluginID = plugin.PluginID;
                            break;
                        }
                        catch (Exception e) { Logger.LogFatal("The Plugin " + DllFile + "failed to Activate and will be skipped. The Exception is Below\r\n\r\n" + e); throw e; }
                    }
                }
                
                if (i == t) {
                    if (plugin == null) {
                        Logger.LogFatal("The Plugin " + DllFile + "does not contain a IDreadBotPlugin interface type and will be skipped.");
                        throw new NoLoadableInterfacesException();
                    }
                }
                i++;
            }

        }
    }

    #endregion

    #region Plugin Manager Exceptions
    class NullAssemplyPluginException : Exception
    {
        public NullAssemplyPluginException() : base("NullAssemblyPlugin")
        {

        }
    }

    class NoLoadableInterfacesException : Exception
    {
        public NoLoadableInterfacesException() : base("NoLoadableInterfacesException")
        {

        }
    }

    #endregion
}
