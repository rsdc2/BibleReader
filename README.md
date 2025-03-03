# BibleReader

This Windows application displays Bible files saved in the [`.usx` XML-based file format](https://markups.paratext.org/usx/). 

![Alt text](Readme.Resources/TyndaleMat.png "Tyndale's translation of Matthew's gospel")
*Tyndale's translation of Matthew in BibleReader (translation from [fetch.bible](https://fetch.bible/content/bibles/))*

## Features 

- **Formatted display**: displays a `.usx` file formatted as you might find it in a Bible 
- **XML display**: displays the underlying XML of a `.usx` file

Formatted and XML display modes may be toggled by pressing the `XML` button in the reader.

## Development environment and running requirements

*BibleReader* is written in C# (.NET Core 8). The GUI is written with [WPF](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-9.0). To run the application, you will need:

- Windows
- .NET runtime

### Build and run

1. Download or clone the repository
2. ```cd BibleReader```
3. ```dotnet run```

### Run the tests

1. Download or clone the repository
2. ```cd BibleReader.Tests```
3. ```dotnet test```

## Implementation details

### `.usx` file format

At present *BibleReader* implements the following subset of the `.usx` elements in the specification:

- `<usx>`
- `<book>`
- `<chapter>`
- `<verse>`
- `<para>`
- `<char>`

The following `@style` values are supported:

- `mt1`: main title 1
- `h`: heading
- `id`: for book titles
- `c`: for chapter numbers
- `v`: for verse numbers
- `p`: for paragraph text

## Acknowledgements

### Dependencies

The test project `BibleReader.Tests` relies on [NUnit](https://github.com/nunit/nunit) ([MIT](https://github.com/nunit/nunit?tab=MIT-1-ov-file#readme)).


### Further information

- USX specification: [https://markups.paratext.org/usx/](https://markups.paratext.org/usx/)
- Windows Presentation Foundation: [https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-9.0](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-9.0)