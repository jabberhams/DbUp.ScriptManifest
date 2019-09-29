# DbUp.ScriptManifest
[DbUp](https://github.com/DbUp/DbUp) extension methods to support manifest-based script discovery.

**This code and package is in preview.**

## Usage
```
var upgrader =
    DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptManifest("manifest.idx")
        .LogToConsole()
        .Build();
```
See the DbUp docs [here](https://dbup.readthedocs.io/en/latest/) for a complete DbUp implementation example.

## Why a manifest file?
Managing the development of database scripts can be a challenge on large, fast-moving projects.  When a database change is required, its deployment has to be coordinated with other in-flight database changes.  Dependent scripts (changes that have to come before or after other changes) are rare but possible. 

DbUp can load scripts from a directory or from an assembly, but by default the execution order of the scripts is evaluated using the filename of the script files; that is, alphanumerically.  This puts a burden on the team to manage the names of the scripts if multiple database changes are in-flight as separate deployment scripts.  You need to make sure the scripts are always executed in the proper order every time.

The strategy offered by the extension method `WithScriptManifest` is a way to define the order of your deployment scripts irrespective of filename in a source-control-friendly format.  The manifest file separates script names from order of execution, and can support complex scenarios like script dependencies and hotfixes.

## File Format
The manifest file should be a plain-text file.  Any file extension is supported though `.idx` is recommended.  File paths can be fully-qualified or relative to the executable.

## Examples

Coming soon...
