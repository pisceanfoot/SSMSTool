SSMS Plugin
================================

Step 1
--------------------------------
Create a Visual Studio Plugin Project

Step 2
--------------------------------
1. Open Project Property Tab
2. Build - Register Com
3. Debug
    -   Start external program, my computer is "C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\Ssms.exe"
    -   Clear command line arguments
    -   Set work directory where "SSMS" located, "C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\" for me

Register
--------------------------------
>   location 
    >>  HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Microsoft SQL Server\100\Tools\Shell\Addins
        >>>   1.    add key named "{namespace.class}", for example "CodeShare.SSMSPlugin.Connect"
        >>>   2.    add dword "LoadBehavior" set value "1"

Add Reference
-------------------------------
There are two places to look for SSMS assemblies:
C:\Program Files\Microsoft SQL Server\100\SDK\Assemblies\
C:\Program Files\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE

C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE

Add dll:

SqlWorkbench.Interfaces.dll
Microsoft.SqlServer.SqlTools.VSIntegration.dll

You might need more depend on what you do in your add-in



Chage Code
-------------------------------
1.  change "_applicationObject = (DTE2)application;" to "_applicationObject = (DTE2)ServiceCache.ExtensibilityModel;"
OR
_applicationObject = (DTE2)_addInInstance.DTE;
    