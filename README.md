# tiny unity game

## unity download + install

you have to make an account, but it's free unless you're making $$$$$ from your games

first you have to download unity hub\
https://unity.com/

then launch unity hub and install editor version `2021.3.16f1` (most recent LTS). under `Platforms`, choose `WebGL Build Support`

once the editor installs you should be able to open the project from unity hub

## vscode setup for unity

unity uses Visual Studio as its default code editor, but it feels pretty clunky / slow compared to VSCode and doesn't have much in the way of extensions / themes etc

you can tell Unity to use VSCode instead under `Unity > Preferences > External Tools > External Script Editor`

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
