# tiny unity game


### vscode setup for unity

unity uses Visual Studio as its default code editor, but you can set it to VSCode instead under `Unity > Preferences > External Tools > External Script Editor`. not strictly necessary, but VSCode feels a little bit nicer / faster overall and is a lot more customizable with themes/extensions/etc than the mac version of Visual Studio 

i had to do a few things to make VSCode recognize / autocomplete Unity classes instead of throwing red squigglies:

### ~~1~~
*may not need this first step - i think unity uses mono (open source .NET implementation) instead of official .NET from microsoft*\
~~install latest version of .NET for mac~~\
~~https://dotnet.microsoft.com/en-us/download~~

### 2
install mono (visual studio channel)\
*note installation path for step 4*\
https://www.mono-project.com/download/stable/

### 3
install C# extension in vscode - it's the official one from microsoft\
https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp

### 4
change C# extension settings in vscode:
- `Omnisharp: Mono Path` -> (mono installation path from step 2) - should be something like `"/Library/Frameworks/Mono.framework/Versions/Current"`
- `Omnisharp: Use Modern Net` -> `FALSE`
