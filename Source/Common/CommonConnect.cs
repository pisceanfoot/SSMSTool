using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using EnvDTE80;
using SSMSTool.Common.Command;

namespace SSMSTool.Common
{
    public abstract class CommonConnect
    {
        protected DTE2 applicationObject;
        protected AddIn addInInstance;
        protected PluginManager pluginManager;

        public CommonConnect(PluginManager pluginManager)
        {
            this.pluginManager = pluginManager;
            this.applicationObject = pluginManager.ApplicationObject;
            this.addInInstance = pluginManager.AddInInstance;
        }
    }
}
