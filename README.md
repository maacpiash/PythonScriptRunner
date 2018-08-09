# PythonScriptRunner


| Linux/macOS | Windows |
| -- | ------------ |
|[![Build Status](https://travis-ci.org/maacpiash/PythonScriptRunner.svg?branch=master)](https://travis-ci.org/maacpiash/PythonScriptRunner) | [![Build status](https://ci.appveyor.com/api/projects/status/6je79n4jn561mqpb?svg=true)](https://ci.appveyor.com/project/maacpiash/pythonscriptrunner) |

A simple cross-platform dotnet core application that takes a Python script as the input and runs the script.

### How to use
Inside the folder, use the command
```
$ dotnet run <PythonFileName>
```
This should work as the same as `$ python <PythonFileName>`.<br/>

A particular text is shown in console to denote the start of the Python code execution, and another text to denote the end of execution. If you do not wish to see those lines in console, put an 'n' or 'N' as another command line argument, i.e.
```
$ dotnet run <PythonFileName> n
```

For testing the program, a Python script has been included that takes input and showst outputs.<br/>

**Note:** If your dotnet core version is older than 2.0, you may want to restore the packages using `$ dotnet restore` command.   

### Acknowledgement
I'd like to thank my good buddy [Shawon Ashraf](https://github.com/ShawonAshraf) for his opinions and issues with this pet project of mine.