using DbUp.Engine;
using DbUp.Support;
using System.Collections.Generic;
using System.IO;

namespace DbUp.Builder
{
    public static class UpgradeEngineBuilderExtensions
    {
        public static UpgradeEngineBuilder WithScriptManifest(this UpgradeEngineBuilder builder, string manifestFilePath)
        {
            var scripts = new List<SqlScript>(500);

            var paths = File.ReadAllLines(manifestFilePath);

            int groupOrder = DbUpDefaults.DefaultRunGroupOrder; // 100
            foreach (var scriptPath in paths)
            {
                var script = SqlScript.FromFile(
                    Path.GetDirectoryName(scriptPath),
                    scriptPath,
                    DbUpDefaults.DefaultEncoding, // UTF-8
                    new SqlScriptOptions { RunGroupOrder = groupOrder, ScriptType = ScriptType.RunOnce });
                scripts.Add(script);
                groupOrder += 100;
            }

            builder.WithScripts(scripts);
            return builder;
        }
    }
}
