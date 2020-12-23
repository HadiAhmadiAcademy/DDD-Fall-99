using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Pack);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly string Configuration = IsLocalBuild ? "Debug" : "Release";

    [Parameter] string ArtifactsPath = RootDirectory + "/artifacts/";
    [Solution] readonly Solution Solution;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            GlobDirectories(Solution.Directory, "src/**/bin", "src/**/obj").ForEach(DeleteDirectory);
            GlobDirectories(Solution.Directory, "test/**/bin", "test/**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsPath);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(a => 
                a.SetProjectFile(Solution)
            );
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(a =>
                a.SetProjectFile(Solution)
                    .SetNoRestore(true)
                    .SetConfiguration(Configuration));
        });

    Target RunUnitTests => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
        });

    Target Pack => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var projects = Solution.AllProjects.Where(a => !a.Name.EndsWith("Tests.Unit")).ToList();
            foreach (var project in projects)
            {
                DotNetPack(a =>
                    a.SetProject(project)
                        .EnableNoBuild()
                        .EnableNoRestore()
                        .SetVersion("1.0.0")
                        .SetOutputDirectory(ArtifactsPath)
                    );
            }
        });

}
