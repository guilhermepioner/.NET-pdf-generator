# HTML to PDF using .NET 6

## Description

In this project, I'll follow the tutorial from code-maze youtube channel: <br>
https://www.youtube.com/watch?v=J8Ff57Jj6t8

As an example API, the objective here is to generate a PDF from a HTML web page or directly from a HTML code. We want to have the options to just renderize the PDF on a browser page or create a download link to it as well. 

To achieve this, I'll be using **DinkToPdf** library from NuGet Package Manager.

## Dll and packages

In order to use DinkToPdf, its necessary to install the NuGet package as the [documentation](https://github.com/rdvojmoc/DinkToPdf) suggests

**VisualStudio PackageManager:**
```
PM> Install-Package DinkToPdf
```

It still may be necessary to include the dll package manually. You can find those on the [repository of the library](https://github.com/rdvojmoc/DinkToPdf/tree/master/v0.12.4) too, just need to choose between [32](https://github.com/rdvojmoc/DinkToPdf/tree/master/v0.12.4/32%20bit) or [64 bits](https://github.com/rdvojmoc/DinkToPdf/tree/master/v0.12.4/64%20bit) depending on your Operational System

> Note: download it from GitHub download button as you open each of the files. Browser right click download options may fail due to their sizes

With the dll packages downloaded, you'll need to get them in the same directory as your **.csproj**. Once you done that, include one of the following pieces of code to the **.csproj** file depending on your Operational System:

- **Windows:**

```
<ItemGroup>
  <None Remove="libwkhtmltox.dll" />
</ItemGroup>

<ItemGroup>
  <EmbeddedResource Include="libwkhtmltox.dll">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </EmbeddedResource>
</ItemGroup>
```

- **Linux:**

```
<ItemGroup>
  <None Remove="libwkhtmltox.so" />
</ItemGroup>

<ItemGroup>
  <EmbeddedResource Include="libwkhtmltox.so">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </EmbeddedResource>
</ItemGroup>
```

- **MacOS:**

```
<ItemGroup>
  <None Remove="libwkhtmltox.dylib" />
</ItemGroup>

<ItemGroup>
  <EmbeddedResource Include="libwkhtmltox.dylib">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </EmbeddedResource>
</ItemGroup>
```

Reference: <br>
https://github.com/rdvojmoc/DinkToPdf/issues/76
