# tiny unity game

### vscode setup for unity
not actually necessary for running / compiling C# scripts in unity, but i had to do this stuff to make VSCode recognize Unity classes and get intellisense etc working

### ~~1~~
*may not need this first step - i think unity uses mono (open source .NET implementation) instead of official .NET from microsoft*\
~~install latest version of .NET for mac~~\
~~https://dotnet.microsoft.com/en-us/download~~

### 2
install mono (visual studio channel)\
*note installation path for step 4*\
https://www.mono-project.com/download/stable/

### 3
install C# extension for vscode\
https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp

### 4
change C# extension settings in vscode:
- **Omnisharp: Mono Path** -> (mono installation path from step 2) - should be something like "/Library/Frameworks/Mono.framework/Versions/Current"
- **Omnisharp: Use Modern Net** -> FALSE
