# PythonScriptRunner

A simple cross-platform dotnet core application that takes a Python script as the input and runs the script.

### How to use
Inside the folder, use the command
```
$ dotnet run <PythonFileName>
```
This should work the same as `$ python <PythonFileName>`.
For testing the program, a Python script has been included with input and outputs.
If your dotnet core version is older than 2.0, you may want to restore the packages using `$ dotnet restore` command.

### Acknowledgement
I'd like to thank my good buddy [Shawon Ashraf](https://github.com/ShawonAshraf) for his opinions and issues with this pet project of mine.