using System.Reflection;
using CounterStrikeSharp.API.Core;

namespace CounterStrikeSharp.API;

public class Api
{
    /// <summary>
    /// Returns the API version of CounterStrikeSharp running on the server
    /// </summary>
    /// <returns></returns>
    public static int GetVersion()
    {
        // This build is forked from upstream v1.0.368 with FEX-Emu patches.
        // GitVersion on PR builds reports Build=1 which would block any plugin
        // declaring [MinimumApiVersion(N>=2)]. Report the upstream base version
        // so existing plugins (RetakesPlugin=345, RetakesAllocator=201, etc.) load.
        var build = Assembly.GetAssembly(typeof(BasePlugin))!.GetName().Version!.Build;
        return build > 368 ? build : 368;
    }
    
    /// <summary>
    /// Returns the assembly version of CounterStrikeSharp running on the server as a string including git commit hash
    /// </summary>
    /// <example>1.0.0+9d8b6be</example>
    public static string GetVersionString()
    {
        return Assembly.GetAssembly(typeof(BasePlugin))!.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
            .InformationalVersion;
    }
}